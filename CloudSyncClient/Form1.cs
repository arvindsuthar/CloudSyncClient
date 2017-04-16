using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudSyncClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // disable profile text entry fields until new profile button is hit
            this.comboboxMode.Enabled = false;
            this.profileName.Enabled = false;
            this.AADDomain.Enabled = false;
            this.AADClientID.Enabled = false;
            this.AADPassword.Enabled = false;
            this.ADDomain.Enabled = false;
            this.ADUsername.Enabled = false;
            this.ADPassword.Enabled = false;

            // check if emulator is already running
            if (!IsEmulatorRunning())
            {
                // show error and disable actions
                this.AADDetail.Text = "You must install and start the Azure Storage Emulator described here:\n https://docs.microsoft.com/en-us/azure/storage/storage-use-emulator";
                this.AADDetail.ForeColor = Color.Red;

                this.buttonNewProfile.Enabled = false;
                this.buttonSave.Enabled = false;
                this.buttonCancel.Enabled = false;
                this.buttonEdit.Enabled = false;

                return;
            }

            // result labels are invisible until verification
            this.AADResult.Visible = false;
            this.AADDetail.Visible = false;

            // fill in default AppId and AppSecret and verify
            this.comboboxMode.SelectedIndex = this.comboboxMode.FindStringExact("Headquarters");
            this.profileName.Text = "Hitachi";
            this.AADDomain.Text = ConfigurationManager.AppSettings["TenantDomainName"];
            this.AADClientID.Text = ConfigurationManager.AppSettings["AppPrincipalId"];
            this.AADPassword.Text = ConfigurationManager.AppSettings["AppPrincipalPassword"];
            VerifyAAD();

            // only new and verify buttons enabled initially
            this.buttonNewProfile.Enabled = true;
            this.buttonSave.Enabled = false;
            this.buttonCancel.Enabled = false;
            this.buttonEdit.Enabled = false;
        }

        private void buttonNewProfile_Click(object sender, EventArgs e)
        {
            AllowEditing(true);
        }

        private void buttonVerifyAAD_Click(object sender, EventArgs e)
        {
            if(VerifyAAD())
            {
                string message = "Successfully verified company: " + this.AADResult.Text;
                MessageBox.Show(message);
            }
            else
            {
                string message = "Failed to verify domain: " + this.AADDomain.Text;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CloudTable profileTable = null;
            if (!CreateTableIfNecessary(ref profileTable)) return;

            // ensure that we don't have a duplicate name
            TableOperation retrieveOperation = TableOperation.Retrieve<ProfileEntity>(this.AADDomain.Text, this.profileName.Text);
            TableResult retrievedResult = profileTable.Execute(retrieveOperation);
            if(retrievedResult.Result != null)
            {
                // we have a duplicate name!
                string message = "Profile name " + this.profileName.Text + " already exists for domain " + this.AADDomain.Text;
                MessageBox.Show(message);
                return;
            }

            // add profile to table (no concurrency checks for now)
            ProfileEntity newProfile = new ProfileEntity
                   (this.comboboxMode.SelectedItem.ToString(),
                    this.profileName.Text,
                    this.AADDomain.Text,
                    this.AADClientID.Text,
                    this.AADPassword.Text,
                    this.ADDomain.Text,
                    this.ADUsername.Text,
                    this.ADPassword.Text);
            TableOperation insert = TableOperation.InsertOrReplace(newProfile);
            profileTable.Execute(insert);

            // retrieve all profiles and add to view
            RefreshProfileListview();

            // all entry fields disabled
            this.comboboxMode.Enabled = false;
            this.profileName.Enabled = false;
            this.AADDomain.Enabled = false;
            this.AADClientID.Enabled = false;
            this.AADPassword.Enabled = false;
            this.ADDomain.Enabled = false;
            this.ADUsername.Enabled = false;
            this.ADPassword.Enabled = false;

            // now only new and edit enabled
            this.buttonNewProfile.Enabled = true;
            this.buttonSave.Enabled = false;
            this.buttonCancel.Enabled = false;
            this.buttonEdit.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // disable profile text entry fields
            this.comboboxMode.Enabled = false;
            this.profileName.Enabled = false;
            this.AADDomain.Enabled = false;
            this.AADClientID.Enabled = false;
            this.AADPassword.Enabled = false;
            this.ADDomain.Enabled = false;
            this.ADUsername.Enabled = false;
            this.ADPassword.Enabled = false;

            // only new and verify buttons enabled
            this.buttonNewProfile.Enabled = true;
            this.buttonSave.Enabled = false;
            this.buttonCancel.Enabled = false;
            this.buttonEdit.Enabled = false;
        }

        private void listviewProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfileEntity profile = null;
            ListView.SelectedListViewItemCollection sel = this.listviewProfile.SelectedItems;
            foreach (ListViewItem item in sel)
            {
                // domain is partition, profile is rowKey
                string AADDomain = item.SubItems[1].Text;

                // extract "profileName" from "mode[profileName]"
                string profileName = Regex.Match(item.Text, @"(?<=\[)(.*?)(?=\])").ToString();

                // retrieve table
                CloudTable profileTable = null;
                if (!CreateTableIfNecessary(ref profileTable)) return;

                // query table
                TableOperation retrieveOperation = TableOperation.Retrieve<ProfileEntity>(AADDomain, profileName);
                TableResult retrievedResult = profileTable.Execute(retrieveOperation);
                profile = (ProfileEntity)retrievedResult.Result;
            }

            // refresh text boxes based on selection (or lack of selection)
            if(profile != null)
            {
                this.comboboxMode.SelectedIndex = this.comboboxMode.FindStringExact(profile.Mode);
            }
            this.profileName.Text = (profile!=null) ? profile.RowKey : "";
            this.AADDomain.Text = (profile != null) ? profile.PartitionKey : "";
            this.AADClientID.Text = (profile != null) ? profile.AADUsername : "";
            this.AADPassword.Text = (profile != null) ? profile.AADPassword : "";
            this.ADDomain.Text = (profile != null) ? profile.ADDomain : "";
            this.ADUsername.Text = (profile != null) ? profile.ADUsername : "";
            this.ADPassword.Text = (profile != null) ? profile.ADPassword : "";

            // allow editing if we have a selection
            this.buttonEdit.Enabled = (profile != null);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AllowEditing(false);
        }
        private void AllowEditing(bool bNew)
        {
            // name and domain are readonly when editing (writable when new) as they are partition and rowkey
            this.comboboxMode.Enabled = bNew;
            this.profileName.Enabled = bNew;
            this.AADDomain.Enabled = bNew;
            this.AADClientID.Enabled = true;
            this.ADUsername.Enabled = true;
            this.ADDomain.Enabled = true;
            this.ADPassword.Enabled = true;
            this.AADPassword.Enabled = true;

            // now only save and cancel enabled
            this.buttonNewProfile.Enabled = false;
            this.buttonSave.Enabled = true;
            this.buttonCancel.Enabled = true;
            this.buttonEdit.Enabled = false;

            // set focus as last thing
            if (bNew)
            {
                // clear list view selection if there was one, otherwise not point in clearing defaults
                ListView.SelectedListViewItemCollection sel = this.listviewProfile.SelectedItems;
                if(sel.Count > 0) this.listviewProfile.SelectedIndices.Clear();
                // set focus to profile name to allow entry of a new profile
                this.profileName.Focus();
            }
            else
            {
                // set focus to client ID if we are editing an existng profile
                this.AADClientID.Focus();
            }
        }
        private bool CreateTableIfNecessary(ref CloudTable profileTable)
        {
            string TABLENAME = GetTableName();
            if (string.IsNullOrEmpty(TABLENAME)) return false;

            // create table if it doesn't exist
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            profileTable = tableClient.GetTableReference(TABLENAME);
            profileTable.CreateIfNotExists();
            return true;
        }

        private string GetTableName()
        {
            // profile table name is based on <Company>
            string TABLENAME = this.AADResult.Text;
            if (string.IsNullOrEmpty(TABLENAME)) return TABLENAME;

            // strip out spaces
            TABLENAME = TABLENAME.Replace(" ", String.Empty);

            // strip out other illegal characters
            TABLENAME = Regex.Replace(TABLENAME, "([!@#$%^&*_-])", "");

            // does TABLENAME now adhere to profile table restrictions?
            string sLegalTableName = "^[A-Za-z][A-Za-z0-9]{2,62}$";
            bool bLegalTableName = Regex.IsMatch(TABLENAME, sLegalTableName, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            if (!bLegalTableName) return null;
            return TABLENAME;
        }
        private bool IsEmulatorRunning()
        {
            var processes = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();
            if (processes.Any(process => process.ProcessName.Contains("AzureStorageEmulator")))
            {
                return true;
            }
            return false;
        }

        private bool RefreshProfileListview()
        {
            bool anyItemsRetrieved = false;

            // clear the listview
            listviewProfile.Items.Clear();

            CloudTable profileTable = null;
            if (!CreateTableIfNecessary(ref profileTable)) return anyItemsRetrieved;

            // refresh listview
            var entities = profileTable.ExecuteQuery(new TableQuery<ProfileEntity>()).ToList();
            foreach (ProfileEntity entity in entities)
            {
                // add to list view
                string[] liArray = new string[3];
                liArray[0] = entity.Mode + "[" + entity.RowKey + "]";
                liArray[1] = entity.PartitionKey;
                liArray[2] = entity.ADDomain;

                ListViewItem li = new ListViewItem(liArray);
                listviewProfile.Items.Add(li);
                anyItemsRetrieved = true;
            }
            return anyItemsRetrieved;
        }

        private bool VerifyAAD()
        {
            bool verified = false;
            IDirectoryChangeManager directoryChangeManager = new DirectoryChangeManager(null, listviewOutput);
            string displayName = null;
            string errorDetail = directoryChangeManager.GetCompanyName(this.AADDomain.Text, this.AADClientID.Text, this.AADPassword.Text, ref displayName);
            if (!string.IsNullOrEmpty(displayName))
            {
                this.AADResult.Text = displayName;
                this.AADResult.ForeColor = Color.Green;
                this.AADResult.Visible = true;
                verified = true;

                this.AADDetail.Text = "";
                this.AADDetail.Visible = false;

                // new, save, cancel, and verify enabled
                this.buttonNewProfile.Enabled = true;
                this.buttonSave.Enabled = true;
                this.buttonCancel.Enabled = true;
                this.buttonEdit.Enabled = false;
            }
            else
            {
                this.AADResult.Text = "";
                this.AADResult.Visible = false;
                verified = false;

                this.AADDetail.Text = errorDetail;
                this.AADDetail.ForeColor = Color.Red;
                this.AADDetail.Visible = true;

                // cancel, verify enabled, not save
                this.buttonNewProfile.Enabled = true;
                this.buttonSave.Enabled = false;
                this.buttonCancel.Enabled = true;
                this.buttonEdit.Enabled = false;
            }
            // since the profile table is derived from company name, we may need to refresh profile
            if (verified)
            {
                // retrieve all profiles and add to view
                if (RefreshProfileListview())
                {
                    // if there was one, select the first one (in future remember this machine)
                    listviewProfile.Items[0].Selected = true;

                    // selected item may point to different company, but they can verify again if they want
                }
            }
            return verified;
        }

        private void Writeback_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.AADResult.Text))
            {
                labelVerified.Text = "You do not have a verified connection to an Azure AD tenant. Please configure one.";
                labelProfile.Visible = false;
                labelStorage.Visible = false;
                buttonExecute.Enabled = false;
            }
            else if (string.IsNullOrEmpty(GetTableName()))
            {
                labelVerified.Visible = false;
                labelProfile.Visible = false;
                labelStorage.Text = "We were not able to generate a table name for your company.";
                buttonExecute.Enabled = false;
            }
            else
            {
                this.labelVerified.Text = "You have a verified connection to: " + this.AADResult.Text;
                labelProfile.Text = "Your active profile is: " + this.profileName.Text;
                labelStorage.Text = "Your results will be stored in Azure Table: " + GetTableName();
                labelStorage.Text += "UsersSeen, Partition: " + this.profileName.Text;
                buttonExecute.Enabled = true;
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            IDirectoryChangeManager directoryChangeManager = new DirectoryChangeManager(listviewDQ, listviewDQOutput);
            directoryChangeManager.DifferentialQuery(this.AADDomain.Text, this.AADClientID.Text, this.AADPassword.Text);
        }
    }
}
