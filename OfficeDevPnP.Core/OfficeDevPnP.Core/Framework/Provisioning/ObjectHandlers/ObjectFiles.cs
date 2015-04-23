﻿using System;
using System.Linq;
using System.Web.Configuration;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Entities;
using OfficeDevPnP.Core.Framework.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Utilities;
using File = Microsoft.SharePoint.Client.File;

namespace OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers
{
    public class ObjectFiles : ObjectHandlerBase
    {
        public override void ProvisionObjects(Web web, ProvisioningTemplate template)
        {
            Log.Info(Constants.LOGGING_SOURCE_FRAMEWORK_PROVISIONING, "Files");

            var context = web.Context as ClientContext;

            if (!web.IsPropertyAvailable("ServerRelativeUrl"))
            {
                context.Load(web, w => w.ServerRelativeUrl);
                context.ExecuteQueryRetry();
            }

            foreach (var file in template.Files)
            {

                var folderName = file.Folder.ToParsedString();

                if (folderName.ToLower().StartsWith((web.ServerRelativeUrl.ToLower())))
                {
                    folderName = folderName.Substring(web.ServerRelativeUrl.Length);
                }


                var folder = web.EnsureFolderPath(folderName);

                Microsoft.SharePoint.Client.File targetFile = null;
                var checkedOut = false;

                targetFile = folder.GetFile(file.Src);

                if (targetFile != null)
                {
                    if (file.Overwrite)
                    {
                        checkedOut = CheckOutIfNeeded(web, targetFile);

                        using (var stream = template.Connector.GetFileStream(file.Src))
                        {
                            targetFile = folder.UploadFile(file.Src, stream, file.Overwrite);
                        }
                    }
                    else
                    {
                        checkedOut = CheckOutIfNeeded(web, targetFile);
                    }
                }
                else
                {
                    using (var stream = template.Connector.GetFileStream(file.Src))
                    {
                        targetFile = folder.UploadFile(file.Src, stream, file.Overwrite);
                    }

                    checkedOut = CheckOutIfNeeded(web, targetFile);
                }

                if (targetFile != null)
                {
                    if (file.WebParts != null && file.WebParts.Any())
                    {
                        if (!targetFile.IsPropertyAvailable("ServerRelativeUrl"))
                        {
                            web.Context.Load(targetFile, f => f.ServerRelativeUrl);
                            web.Context.ExecuteQuery();
                        }
                        foreach (var webpart in file.WebParts)
                        {
                            var wpEntity = new WebPartEntity();
                            wpEntity.WebPartTitle = webpart.Title;
                            wpEntity.WebPartXml = webpart.Contents.ToParsedString();
                            wpEntity.WebPartZone = webpart.Zone;
                            wpEntity.WebPartIndex = (int)webpart.Order;

                            web.AddWebPartToWebPartPage(targetFile.ServerRelativeUrl, wpEntity);
                        }
                    }
                    if (file.Properties != null && file.Properties.Any())
                    {
                        targetFile.SetFileProperties(file.Properties,false); // if needed, the file is already checked out
                    }
                    if (checkedOut)
                    {
                        targetFile.CheckIn("", CheckinType.MajorCheckIn);
                        web.Context.ExecuteQueryRetry();
                    }
                }

            }
        }

        private static bool CheckOutIfNeeded(Web web, File targetFile)
        {
            var checkedOut = false;
            try
            {
                web.Context.Load(targetFile, f => f.CheckOutType, f => f.ListItemAllFields.ParentList.ForceCheckout);
                web.Context.ExecuteQueryRetry();

                if (targetFile.CheckOutType == CheckOutType.None)
                {
                    targetFile.CheckOut();
                }
                checkedOut = true;
            }
            catch (ServerException ex)
            {
                if (ex.ServerErrorCode != -2146232832)
                {
                    throw;
                }
            }
            return checkedOut;
        }


        public override ProvisioningTemplate CreateEntities(Web web, ProvisioningTemplate template, ProvisioningTemplateCreationInformation creationInfo)
        {
            // Impossible to return all files in the site currently

            // If a base template is specified then use that one to "cleanup" the generated template model
            if (creationInfo.BaseTemplate != null)
            {
                template = CleanupEntities(template, creationInfo.BaseTemplate);
            }

            return template;
        }

        private ProvisioningTemplate CleanupEntities(ProvisioningTemplate template, ProvisioningTemplate baseTemplate)
        {

            return template;
        }
    }
}
