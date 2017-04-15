﻿//-------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//     Differential Query sample client.
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

namespace DQClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Web;
    using System.Web.Script.Serialization;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// Sample implementation of obtaining changes from graph using Differential Query.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// JavaScript Serializer.
        /// </summary>
        private static readonly JavaScriptSerializer javascriptSerializer = new JavaScriptSerializer();

        /// <summary>
        /// Logger to be used for logging output/debug.
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="logger">Logger to be used for logging output/debug.</param>
        public Client(ILogger logger)
        {
            this.ReadConfiguration();
            this.logger = logger;
        }

        /// <summary>
        /// Gets or sets the Graph service endpoint.
        /// </summary>
        protected string AzureADServiceHost { get; set; }

        /// <summary>
        /// Gets or sets the OAuth2 bearer token.
        /// </summary>
        protected string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the Graph API version.
        /// </summary>
        protected string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets the well known service principal ID for Windows Azure AD Access Control.
        /// </summary>
        private string ProtectedResourcePrincipalId { get; set; }

        /// <summary>
        /// Calls the Differential Query service and returns the result.
        /// </summary>
        /// <param name="skipToken">
        /// Skip token returned by a previous call to the service or <see langref="null"/>.
        /// </param>
        /// <returns>Result from the Differential Query service.</returns>
        public DifferentialQueryResult DifferentialQuery(string skipToken, string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            return this.DifferentialQuery(
                "directoryObjects",
                skipToken,
                aadDomain,
                appPrincipalId,
                appPrincipalPassword,
                new string[0], 
                new string[0]);
        }

        public string GetCompanyName(string aadDomain, string appPrincipalId, string appPrincipalPassword, ref string displayName)
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("api-version", this.ApiVersion);

            byte[] responseBytes = null;

            this.InvokeOperationWithRetry(
                () => { responseBytes = DownloadData(webClient, "tenantDetails", aadDomain, appPrincipalId, appPrincipalPassword); });

            if (responseBytes != null)
            {
                // find the display name
                Dictionary<string, object> response = javascriptSerializer.DeserializeObject(
                    Encoding.UTF8.GetString(responseBytes)) as Dictionary<string, object>;
                if (response == null || !response.ContainsKey("value"))
                {
                    return "tenantDetails: couldn't find displayName";
                }
                Object[] tenantDetailsArray = (Object[])response["value"];
                Dictionary<string, object> tenantDetails = (Dictionary < string, object>)tenantDetailsArray[0];
                displayName = tenantDetails["displayName"].ToString();
                if (string.IsNullOrEmpty(displayName))
                {
                    return "tenantDetails: couldn't extract displayName";
                }
            }
            return "tenantDetails: null response";
        }

        /// <summary>
        /// Calls the Graph service and returns the directory object with the specified object ID.
        /// </summary>
        /// <param name="objectId">Object ID of the object to retrieve.</param>
        /// <returns>Directory object with the specified object ID.</returns>
        public Dictionary<string, object> GetDirectoryObject(string objectId, string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            WebClient webClient = new WebClient();
            
            webClient.QueryString.Add("api-version", this.ApiVersion);

            string suffix = string.Format(
                CultureInfo.InvariantCulture,
                "directoryObjects('{0}')",
                objectId);

            byte[] responseBytes = null;

            this.InvokeOperationWithRetry(
                () => { responseBytes = DownloadData(webClient, suffix, aadDomain, appPrincipalId, appPrincipalPassword); });

            if (responseBytes != null)
            {
                return javascriptSerializer.DeserializeObject(
                    Encoding.UTF8.GetString(responseBytes)) as Dictionary<string, object>;
            }

            return null;
        }

        #region helpers
        /// <summary>
        /// Calls the Differential Query service and returns the result.
        /// </summary>
        /// <param name="resourceSet">Name of the resource set to query.</param>
        /// <param name="skipToken">
        /// Skip token returned by a previous call to the service or <see langref="null"/>.
        /// </param>
        /// <param name="objectClassList">List of directory object classes to retrieve.</param>
        /// <param name="propertyList">List of directory properties to retrieve.</param>
        /// <returns>Result from the Differential Query service.</returns>
        private DifferentialQueryResult DifferentialQuery(
            string resourceSet,
            string skipToken,
            string aadDomain,
            string appPrincipalId,
            string appPrincipalPassword,
            ICollection<string> objectClassList,
            ICollection<string> propertyList)
        {
            WebClient webClient = new WebClient();
            webClient.QueryString.Add("api-version", this.ApiVersion);
            webClient.QueryString.Add("deltaLink", skipToken ?? String.Empty);

            if (propertyList.Any())
            {
                webClient.QueryString.Add("$select", String.Join(",", propertyList));
            }

            if (objectClassList.Any())
            {
                webClient.QueryString.Add(
                    "$filter",
                    String.Join(" or ", objectClassList.Select(x => String.Format("isof('{0}')", x))));
            }

            byte[] responseBytes = null;

            Stopwatch sw = Stopwatch.StartNew();
            this.InvokeOperationWithRetry(
                () => { responseBytes = DownloadData(webClient, resourceSet, aadDomain, appPrincipalId, appPrincipalPassword); });
            long elapsed = sw.ElapsedMilliseconds;

            if (responseBytes != null)
            {
                return new DifferentialQueryResult(
                    javascriptSerializer.DeserializeObject(
                        Encoding.UTF8.GetString(responseBytes)) as Dictionary<string, object>);
            }

            return null;
        }

        /// <summary>
        /// Get Token for Application.
        /// </summary>
        /// <returns>Token for application.</returns>
        private string GetTokenForApplication(string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            string authEndpoint = string.Format(Constants.AuthEndpoint, aadDomain);
            AuthenticationContext authenticationContext = new AuthenticationContext(authEndpoint, false);
            // Config for OAuth client credentials 
            ClientCredential clientCred = new ClientCredential(appPrincipalId, appPrincipalPassword);
            AuthenticationResult authenticationResult = authenticationContext.AcquireToken(this.ProtectedResourcePrincipalId, clientCred);
            return authenticationResult.AccessToken;
        }

        /// <summary>
        /// Returns a string that can logged given a <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="queryParameters">Query parameters to be logged.</param>
        /// <returns>String to be logged.</returns>
        private static string LogQueryParameters(NameValueCollection queryParameters)
        {
            string logString = string.Empty;
            foreach (string key in queryParameters.AllKeys)
            {
                logString = String.Join("&", logString, String.Join("=", key, queryParameters[key]));
            }

            return logString;
        }

        /// <summary>
        /// Reads the client configuration.
        /// </summary>
        private void ReadConfiguration()
        {
            this.AzureADServiceHost = Configuration.GetElementValue("AzureADServiceHost");
            this.ApiVersion = Configuration.GetElementValue("ApiVersion");
            this.ProtectedResourcePrincipalId = Configuration.GetElementValue("ProtectedResourcePrincipalId");
        }

        /// <summary>
        /// Adds the required headers to the specified web client.
        /// </summary>
        /// <param name="webClient">Web client to add the required headers to.</param>
        private void AddHeaders(WebClient webClient, string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            webClient.Headers.Add(Constants.HeaderNameAuthorization, this.GetTokenForApplication(aadDomain, appPrincipalId, appPrincipalPassword));
            webClient.Headers.Add(Constants.HeaderNameClientRequestId, Guid.NewGuid().ToString());
            webClient.Headers.Add(HttpRequestHeader.Accept, "application/json;odata=minimalmetadata");
        }

        /// <summary>
        /// Constructs the URI with the specified suffix and downloads it with the specified web client.
        /// </summary>
        /// <param name="webClient">Web client to be used to download the URI.</param>
        /// <param name="suffix">Suffix to be used to construct the URI.</param>
        /// <returns>Byte array containing the downloaded URI.</returns>
        private byte[] DownloadData(WebClient webClient, string suffix, string aadDomain, string appPrincipalId, string appPrincipalPassword)
        {
            this.AddHeaders(webClient, aadDomain, appPrincipalId, appPrincipalPassword);
            string serviceEndPoint = string.Format(
                @"https://{0}/{1}/{2}",
                this.AzureADServiceHost,
                aadDomain,
                suffix);

            // Log the query string and endpoint.
            if (this.logger != null)
            {
                this.logger.LogDebug("Making call to endpoint : {0}", serviceEndPoint);
                this.logger.LogDebug("Query Parameters : {0}", LogQueryParameters(webClient.QueryString));
            }

            return webClient.DownloadData(serviceEndPoint);
        }

        /// <summary>
        /// Delegate to invoke the specified operation, and retry if necessary.
        /// </summary>
        /// <param name="operation">Operation to invoke.</param>
        private void InvokeOperationWithRetry(Action operation)
        {
            int retryCount = Constants.MaxRetryAttempts;
            while (retryCount > 0)
            {
                try
                {
                    operation();

                    // Operation was successful
                    retryCount = 0;
                }
                catch (InvalidOperationException ex)
                {
                    // Operation not successful

                    // De-serialize error message to check the error code from AzureAD Service
                    ParsedException parsedException = ParsedException.Parse(ex);
                    if (parsedException == null)
                    {
                        // Could not parse the exception so it wasn't in the format of DataServiceException
                        throw;
                    }

                    // Look at the error code to determine if we want to retry on this exception 
                    switch (parsedException.Code)
                    {
                        // These are the errors we don't want to retry on
                        // Please look at the descriptions for details about each of these
                        case Constants.MessageIdAuthorizationIdentityDisabled:
                        case Constants.MessageIdAuthorizationIdentityNotFound:
                        case Constants.MessageIdAuthorizationRequestDenied:
                        case Constants.MessageIdBadRequest:
                        case Constants.MessageIdContractVersionHeaderMissing:
                        case Constants.MessageIdHeaderNotSupported:
                        case Constants.MessageIdInternalServerError:
                        case Constants.MessageIdInvalidDataContractVersion:
                        case Constants.MessageIdInvalidReplicaSessionKey:
                        case Constants.MessageIdInvalidRequestUrl:
                        case Constants.MessageIdMediaTypeNotSupported:
                        case Constants.MessageIdThrottledPermanently:
                        case Constants.MessageIdThrottledTemporarily:
                        case Constants.MessageIdUnauthorized:
                        case Constants.MessageIdUnknown:
                        case Constants.MessageIdUnsupportedQuery:
                        case Constants.MessageIdUnsupportedToken:
                        {
                            // We just create a new exception with the message
                            // and throw it so that the 'OnException' handler handles it
                            throw new InvalidOperationException(parsedException.Message.Value, ex);
                        }

                        // This means that the token has expired. 
                        case Constants.MessageIdExpired:
                        {
                            // Renew the token and retry the operation. This is done as a 
                            // part of the operation itself (AddHeaders)
                            this.AccessToken = null;
                            retryCount--;
                            break;
                        }

                        default:
                        {
                            // Not sure what happened, don't want to retry
                            throw;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Access token format.
        /// </summary>
        [DataContract]
        private class AccessTokenFormat
        {
            /// <summary>
            /// Gets or sets the token type.
            /// </summary>
            [SuppressMessage(
                "Microsoft.StyleCop.CSharp.NamingRules",
                "SA1300:ElementMustBeginWithUpperCaseLetter",
                Justification = "JSON key name")]
            [DataMember]
            internal string token_type { get; set; }

            /// <summary>
            /// Gets or sets the access token.
            /// </summary>
            [SuppressMessage(
                "Microsoft.StyleCop.CSharp.NamingRules",
                "SA1300:ElementMustBeginWithUpperCaseLetter",
                Justification = "JSON key name")]
            [DataMember]
            internal string access_token { get; set; }
        }

        #endregion
    }
}
