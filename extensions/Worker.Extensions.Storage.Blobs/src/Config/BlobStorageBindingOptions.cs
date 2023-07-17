// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Azure.Core;
using Azure.Storage.Blobs;

namespace Microsoft.Azure.Functions.Worker
{
    internal class BlobStorageBindingOptions
    {
        public string? ConnectionString { get; set; }

        public Uri? ServiceUri { get; set; }

        public TokenCredential? Credential { get; set; }

        public BlobClientOptions? BlobClientOptions { get; set; }

        internal BlobServiceClient? Client { get; set; }

        internal BlobServiceClient CreateClient()
        {
            if (this.Client is not null)
            {
                return this.Client;
            }

            if (ServiceUri is not null && Credential is not null)
            {
                return new BlobServiceClient(ServiceUri, Credential, BlobClientOptions);
            }

            return new BlobServiceClient(ConnectionString, BlobClientOptions);
        }
    }
}