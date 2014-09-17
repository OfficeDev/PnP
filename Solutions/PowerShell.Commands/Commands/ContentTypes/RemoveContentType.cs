﻿using OfficeDevPnP.PowerShell.Commands.Base;
using OfficeDevPnP.PowerShell.Commands.Base.PipeBinds;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Remove, "SPOContentType")]
    public class RemoveContentType : SPOWebCmdlet
    {

        [Parameter(Mandatory = true, Position=0, ValueFromPipeline=true)]
        public ContentTypePipeBind Identity;

        [Parameter(Mandatory = false)]
        public SwitchParameter Force;

        protected override void ExecuteCmdlet()
        {
            if (Force || ShouldContinue(Properties.Resources.RemoveContentType, Properties.Resources.Confirm))
            {
                ContentType ct = null;
                if (Identity.ContentType != null)
                {
                    ct = Identity.ContentType;
                }
                else
                {
                    if (!string.IsNullOrEmpty(Identity.Id))
                    {
                        ct = this.SelectedWeb.GetContentTypeById(Identity.Id);
                    }
                    else if (!string.IsNullOrEmpty(Identity.Name))
                    {
                        ct = this.SelectedWeb.GetContentTypeByName(Identity.Id);
                    }
                }
                if(ct != null)
                {
                    ct.DeleteObject();
                    ClientContext.ExecuteQuery();
                }

            }
        }
    }
}
