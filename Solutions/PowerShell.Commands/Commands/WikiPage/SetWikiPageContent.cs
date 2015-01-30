﻿using OfficeDevPnP.PowerShell.Commands.Base;
using Microsoft.SharePoint.Client;
using System.Management.Automation;
using Microsoft.SharePoint.Client.WebParts;

namespace OfficeDevPnP.PowerShell.Commands
{
    [Cmdlet(VerbsCommon.Set, "SPOWikiPageContent")]
    public class SetWikiPageContent : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "STRING")]
        public string Content = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = "FILE")]
        public string Path = string.Empty;

        [Parameter(Mandatory = true, ParameterSetName = "FILE", HelpMessage="Site Relative Page Url")]
        [Parameter(Mandatory = true, ParameterSetName = "STRING", HelpMessage="Site Relative Page Url")]
        [Alias("PageUrl")]
        public string ServerRelativePageUrl = string.Empty;

        protected override void ExecuteCmdlet()
        {
            if (ParameterSetName == "FILE")
            {
                if (System.IO.File.Exists(Path))
                {
                    var fileStream = new System.IO.StreamReader(Path);
                    var contentString = fileStream.ReadToEnd();
                    fileStream.Close();
                    SelectedWeb.AddHtmlToWikiPage(ServerRelativePageUrl, contentString);
                }
            }
            else
            {
                SelectedWeb.AddHtmlToWikiPage(ServerRelativePageUrl, Content);
            }
        }
    }
}
