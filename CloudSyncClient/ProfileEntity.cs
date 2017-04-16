﻿#region license
// Copyright (c) Microsoft Corporation
// All rights reserved. 
// Licensed under the Apache License, Version 2.0 (the License); you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0 
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
// INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR NON-INFRINGEMENT. 
// See the Apache Version 2.0 License for specific language governing permissions and limitations under the License.
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;

namespace CloudSyncClient
{
    public class ProfileEntity : TableEntity
    {
        public ProfileEntity() { }
        public ProfileEntity
        (
            string mode,
            string profile,
            string aadDomain, 
            string aadUsername, 
            string aadPassword, 
            string adDomain, 
            string adUsername,
            string adPassword)
        {
            this.Mode = mode;
            this.RowKey = profile;
            this.PartitionKey = aadDomain;
            this.AADUsername = aadUsername;
            this.AADPassword = aadPassword;
            this.ADDomain = adDomain;
            this.ADUsername = adUsername;
            this.ADPassword = adPassword;

        }
        public string Mode { get; set; }
        public string AADUsername { get; set; }
        public string AADPassword { get; set; }
        public string ADDomain { get; set; }
        public string ADUsername { get; set; }
        public string ADPassword { get; set; }
    }
}
    
