//-------------------------------------------------------------------------------------------------
// <copyright file="DirectoryChangeManager.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//     Differential Query sample application.
// 
//     This source is subject to the Sample Client End User License Agreement
//     included in this project.
// </summary>
//
// <remarks />
//
// <disclaimer>
//     THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
//     EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
//     WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </disclaimer>
//-------------------------------------------------------------------------------------------------

namespace CloudSyncClient
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Web.Script.Serialization;
    using System.Windows.Forms;
    using DQClient;

    /// <summary>
    /// Defines methods to call the Differential Query service and process the results.
    /// </summary>
    public class DirectoryChangeManager : IDirectoryChangeManager
    {
        /// <summary>
        /// Differential Query client.
        /// </summary>
        private Client client = null;

        /// <summary>
        /// Cookie manager.
        /// </summary>
        private CookieManager cookieManager = null;
        
        /// <summary>
        /// JavaScript serializer.
        /// </summary>
        private JavaScriptSerializer javaScriptSerializer = null;

        /// <summary>
        /// Directory object handler.
        /// </summary>
        private ILogger logger = null;

        /// <summary>
        /// Directory object handler.
        /// </summary>
        private IDirectoryObjectHandler directoryObjectHandler = null;

        /// <summary>
        /// Directory link handler.
        /// </summary>
        private IDirectoryLinkHandler directoryLinkHandler = null;

        /// <summary>
        /// Output file for Differential Query result.
        /// </summary>
        private static StreamWriter outputFile;

        public DirectoryChangeManager(ListView listviewResults, ListView listviewOutput)
        {
            logger = new Logger(listviewResults, listviewOutput);
            client = new Client(logger);
            cookieManager = new CookieManager();
            javaScriptSerializer = new JavaScriptSerializer();
            directoryObjectHandler = new DirectoryObjectHandler(client, logger);
            directoryLinkHandler = new DirectoryLinkHandler(client, logger);
        }
    
    /// <summary>
    /// Calls the Differential Query service and processes the result.
    /// </summary>
    public void DifferentialQuery(string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            logger.LogDebug(
                "Differential Query initialized for tenant {0}, with appPrincipalId {1}.",
                aadDomain,
                appPrincipalId);
            int pullIntervalSec = int.Parse(ConfigurationManager.AppSettings["PullIntervalSec"]);
            int retryAfterFailureIntervalSec = pullIntervalSec;
            string outputFilePath = Path.Combine(
                Environment.CurrentDirectory,
                "DifferentialQueryResult" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt");
            outputFile = new StreamWriter(outputFilePath);
            logger.Log("Differential Query sample application initialized");
            logger.Log("Detected changes will be written to {0}.", outputFilePath);
            string skipToken = cookieManager.Read();
            logger.Log("skipToken: {0}", skipToken);

            DifferentialQueryResult result;
            long elapsed = 0;
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                result = client.DifferentialQuery(skipToken, aadDomain, appPrincipalId, appPrincipalPassword);
                elapsed = sw.ElapsedMilliseconds;
            }
            catch (Exception e)
            {
                logger.LogDebug("Differential Query request failed. Error: {0}", e.Message);
                return;
            }

            foreach (Dictionary<string, object> change in result.Changes)
            {
                try
                {
                    this.HandleChange(change, aadDomain, appPrincipalId, appPrincipalPassword);
                }
                catch (ArgumentException e)
                {
                    logger.Log("Invalid directory change: {0}", e.Message);
                }
            }

            skipToken = result.SkipToken;
            cookieManager.Save(skipToken);
        }

        /// <summary>
        /// Confirms whether a token can be received based on passed credentials.
        /// </summary>
        public string GetCompanyName(string aadDomain, string appPrincipalId, string appPrincipalPassword, ref string displayName)
        {
            string result = client.GetCompanyName(aadDomain, appPrincipalId, appPrincipalPassword, ref displayName);
            return result;
        }

        /// <summary>
        /// Processes the specified AAD object or link.
        /// </summary>
        /// <param name="change">Directory change representing an AAD object or link.</param>
        /// <exception cref="ArgumentNullException"><paramref name="change"/> is <see langref="null"/>.</exception>
        /// <exception cref="ArgumentException">Invalid directory change.</exception>
        public void HandleChange(Dictionary<string, object> change, string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            if (change == null)
            {
                throw new ArgumentNullException("change");
            }

            if (!change.ContainsKey("odata.type"))
            {
                throw new ArgumentException("Invalid directory change", "change");
            }

            string directoryChangeType = change["odata.type"].ToString();
            switch (directoryChangeType)
            {
                case "Microsoft.DirectoryServices.User":
                case "Microsoft.DirectoryServices.Contact":
                case "Microsoft.DirectoryServices.Group":
                    outputFile.WriteLine(javaScriptSerializer.Serialize(change));
                    logger.Log(
                        "Detected a change about an AAD {0} with objectId {1}",
                        change["objectType"].ToString(),
                        change["objectId"]);
                    this.HandleObject(change);
                    break;

                case "Microsoft.DirectoryServices.DirectoryLinkChange":
                    outputFile.WriteLine(javaScriptSerializer.Serialize(change));
                    logger.Log(
                        "Detected a change about an AAD link with sourceObjectId {0} and targetObjectId {1}",
                        change["sourceObjectId"],
                        change["targetObjectId"]);
                    this.HandleLink(change, aadDomain, appPrincipalId, appPrincipalPassword);
                    break;

                default:
                    logger.Log(
                        "Detected a change about unknown type {0} in AAD",
                        change["odata.type"]);
                    break;
            }
        }

        /// <summary>
        /// Processes the specified directory change representing an AAD object.
        /// </summary>
        /// <param name="change">Directory change representing an AAD object.</param>
        private void HandleObject(Dictionary<string, object> change)
        {
            bool isDeleted = change.ContainsKey("aad.isDeleted") &&
                bool.Parse(change["aad.isDeleted"].ToString());
            bool isSoftDeleted = change.ContainsKey("aad.isSoftDeleted") &&
                bool.Parse(change["aad.isSoftDeleted"].ToString());
            if (isDeleted || isSoftDeleted)
            {
                directoryObjectHandler.Delete(change);
            }
            else if (directoryObjectHandler.Exists(change))
            {
                directoryObjectHandler.Update(change);
            }
            else
            {
                directoryObjectHandler.Create(change);
            }
        }

        /// <summary>
        /// Processes the specified directory change representing an AAD link.
        /// </summary>
        /// <param name="change">Directory change representing an AAD link.</param>
        private void HandleLink(Dictionary<string, object> change, string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            bool isDeleted = change.ContainsKey("aad.isDeleted") &&
                bool.Parse(change["aad.isDeleted"].ToString());
            if (isDeleted)
            {
                directoryLinkHandler.Delete(change);
            }
            else if (directoryLinkHandler.Exists(change))
            {
                directoryLinkHandler.Update(change, aadDomain, appPrincipalId, appPrincipalPassword);
            }
            else 
            {
                directoryLinkHandler.Create(change, aadDomain, appPrincipalId, appPrincipalPassword);
            }
        }
    }
}
