﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.DeploymentManager.Models
{
    using System;
    using Microsoft.Azure.DeploymentManager.Models;

    public class PSServiceUnitResource : PSResource
    {
        public PSServiceUnitResource() : base()
        {
        }

        public PSServiceUnitResource(
            string resourceGroup,
            string serviceTopologyName,
            string serviceName,
            ServiceUnitResource serviceUnitResource) : base(serviceUnitResource)
        {
            this.ResourceGroupName = resourceGroup;
            this.DeploymentMode = serviceUnitResource.DeploymentMode.ToString();
            this.ServiceTopologyName = serviceTopologyName;
            this.ServiceName = serviceName;
            this.TargetResourceGroup = serviceUnitResource.TargetResourceGroup;
            this.TemplateUri = serviceUnitResource.TemplateUri;
            this.ParametersUri = serviceUnitResource.ParametersUri;
            this.ParametersArtifactSourceRelativePath = serviceUnitResource.ParametersArtifactSourceRelativePath;
            this.TemplateArtifactSourceRelativePath = serviceUnitResource.TemplateArtifactSourceRelativePath;
            this.Identity = serviceUnitResource.Identity != null ? new PSResourceIdentity(serviceUnitResource.Identity) : null;
        }

        /// <summary>
        /// Gets or sets the resource group to which the service unit belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the service topology the service unit belongs to.
        /// </summary>
        public string ServiceTopologyName { get; set; }

        /// <summary>
        /// Gets or sets the service the service unit belongs to.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the resource group to which the resources in the topology group should be deployed to.
        /// </summary>
        public string TargetResourceGroup { get; set; }

		/// <summary>
		/// Gets or sets describes the type of ARM deployment to be performed
		/// on the resource. Possible values include: 'Complete', 'Incremental'
		/// </summary>
		public string DeploymentMode { get; set; }

        /// <summary>
        /// Gets or sets the SAS URI of the ARM template.
        /// </summary>
        public string TemplateUri { get; set; }

        /// <summary>
        /// Gets or sets the SAS URI of the ARM parameters file.
        /// </summary>
        public string ParametersUri { get; set; }

        /// <summary>
        /// Gets or sets the relative path of the ARM parameters file from the artifact source for this topology.
        /// </summary>
        public string ParametersArtifactSourceRelativePath { get; set; }

        /// <summary>
        /// Gets or sets the relative path of the ARM template file from the artifact source for this topology.
        /// </summary>
        public string TemplateArtifactSourceRelativePath { get; set; }

        /// <summary>
        /// Gets or sets the identity information.
        /// </summary>
        public PSResourceIdentity Identity { get; set; }

        internal ServiceUnitResource ToSdkType()
        {
            return new ServiceUnitResource(
                this.Location, 
                this.TargetResourceGroup, 
                (DeploymentMode)Enum.Parse(typeof(DeploymentMode), this.DeploymentMode, ignoreCase: true),
                this.Name, 
                this.Type, 
                this.Id, 
                this.Tags)
            {
                Identity = this.Identity?.ToSdkType(),
                TemplateUri = this.TemplateUri,
                ParametersUri = this.ParametersUri,
                TemplateArtifactSourceRelativePath = this.TemplateArtifactSourceRelativePath,
                ParametersArtifactSourceRelativePath = this.ParametersArtifactSourceRelativePath
            };
        }
    }
}
