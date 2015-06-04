﻿using Microsoft.SharePoint.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Configuration;

namespace OfficeDevPnP.Core.Tests.Framework.Providers
{
    [TestClass]
    public class BaseTemplateTests
    {

        /// <summary>
        /// This is not a test, merely used to dump the needed template files
        /// </summary>
        [TestMethod]
        [Ignore]
        public void DumpBaseTemplates()
        {
            using (ClientContext ctx = TestCommon.CreateClientContext())
            {
                DumpTemplate(ctx, "STS0");
                DumpTemplate(ctx, "BLOG0");
                DumpTemplate(ctx, "BDR0");
                DumpTemplate(ctx, "DEV0");
                DumpTemplate(ctx, "OFFILE1");
#if !CLIENTSDKV15
                DumpTemplate(ctx, "EHS1");
#else
                DumpTemplate(ctx, "STS1");
                DumpTemplate(ctx, "BLANKINTERNET0");
#endif
                DumpTemplate(ctx, "BICENTERSITE0");
                DumpTemplate(ctx, "SRCHCEN0");
                DumpTemplate(ctx, "BLANKINTERNETCONTAINER0");
                DumpTemplate(ctx, "BLANKINTERNETCONTAINER0", "CMSPUBLISHING0");
                DumpTemplate(ctx, "ENTERWIKI0");
                DumpTemplate(ctx, "PROJECTSITE0");
                DumpTemplate(ctx, "COMMUNITY0");
                DumpTemplate(ctx, "COMMUNITYPORTAL0");
                DumpTemplate(ctx, "SRCHCENTERLITE0");
                DumpTemplate(ctx, "VISPRUS0");
            }
        }

        private void DumpTemplate(ClientContext ctx, string template, string subSiteTemplate = "")
        {
            Uri devSiteUrl = new Uri(ConfigurationManager.AppSettings["SPODevSiteUrl"]);
            string baseUrl = String.Format("{0}://{1}", devSiteUrl.Scheme, devSiteUrl.DnsSafeHost);

            string siteUrl = "";
            if (subSiteTemplate.Length > 0)
            {
                siteUrl = (String.Format("{1}/sites/template{0}/template{2}", template, baseUrl, subSiteTemplate));
            }
            else
            {
                siteUrl = (String.Format("{1}/sites/template{0}", template, baseUrl));
            }

            using (ClientContext cc = ctx.Clone(siteUrl))
            {
                // Specify null as base template since we do want "everything" in this case
                ProvisioningTemplateCreationInformation creationInfo = new ProvisioningTemplateCreationInformation(cc.Web);
                creationInfo.BaseTemplate = null;

                ProvisioningTemplate p = cc.Web.GetProvisioningTemplate(creationInfo);
                if (subSiteTemplate.Length > 0)
                {
                    p.Id = String.Format("{0}template", subSiteTemplate);
                }
                else
                {
                    p.Id = String.Format("{0}template", template);
                }

                // Cleanup before saving
                p.Security.AdditionalAdministrators.Clear();


                XMLFileSystemTemplateProvider provider = new XMLFileSystemTemplateProvider(".", "");
                if (subSiteTemplate.Length > 0)
                {
                    provider.SaveAs(p, String.Format("{0}Template.xml", subSiteTemplate));
                }
                else
                {
                    provider.SaveAs(p, String.Format("{0}Template.xml", template));
                }
            }
        }

        /// <summary>
        /// Get the base template for the current site
        /// </summary>
        [TestMethod]
        public void GetBaseTemplateForCurrentSiteTest()
        {
            using (ClientContext ctx = TestCommon.CreateClientContext())
            {
                ProvisioningTemplate t = ctx.Web.GetBaseTemplate();

                Assert.IsNotNull(t);
            }
        }

        /// <summary>
        /// Get the template for the current site
        /// </summary>
        [TestMethod]
        public void GetTemplateForCurrentSiteTest()
        {
            using (ClientContext cc = TestCommon.CreateClientContext())
            {
                //using (ClientContext ctx = cc.Clone("https://bertonline.sharepoint.com/sites/temp2/s1"))
                using (ClientContext ctx = cc.Clone(TestCommon.DevSiteTemplateSubtUrl))
                {

                    ProvisioningTemplate p = ctx.Web.GetProvisioningTemplate();

                    Assert.IsNotNull(p);

                    // Save to file system
                    XMLFileSystemTemplateProvider xmlProv = new XMLFileSystemTemplateProvider("c:\\temp", "");
                    xmlProv.SaveAs(p, "test.xml");

                    // Verify that the saved XML is still valid
                    var p2 = xmlProv.GetTemplate("test.xml");
                }
            }
        }

        [TestMethod]
        public void ApplyRootSiteProvisioningTemplateToSubSiteTest()
        {
            using (ClientContext cc = TestCommon.CreateClientContext())
            {
                //using (ClientContext ctx = cc.Clone("https://bertonline.sharepoint.com/sites/temp2"))
                using (ClientContext ctx = cc.Clone(TestCommon.DevSiteTemplateParentUrl))
                {
                    ProvisioningTemplateCreationInformation creationInfo = new ProvisioningTemplateCreationInformation(ctx.Web);
                    creationInfo.FileConnector = new FileSystemConnector(@"c:\temp\template\garage", "");
                    creationInfo.PersistComposedLookFiles = true;

                    ProvisioningTemplate p = ctx.Web.GetProvisioningTemplate(creationInfo);
                    Assert.IsNotNull(p);

                    //using (ClientContext cc2 = cc.Clone("https://bertonline.sharepoint.com/sites/temp2/s1"))
                    using (ClientContext cc2 = cc.Clone(TestCommon.DevSiteTemplateSubtUrl))
                    {
                        p.Connector = new FileSystemConnector("./resources", "");
                        cc2.Web.ApplyProvisioningTemplate(p);
                    }                    
                }
            }
        }

        [TestMethod]
        public void IsSubsiteTest()
        {
            using (ClientContext cc = TestCommon.CreateClientContext())
            {
                Assert.IsFalse(cc.Web.IsSubSite());

                //using (ClientContext ctx = cc.Clone("https://bertonline.sharepoint.com/sites/temp2/s1"))
                using (ClientContext ctx = cc.Clone(TestCommon.DevSiteTemplateSubtUrl))
                {
                    Assert.IsTrue(ctx.Web.IsSubSite());
                }
            }
        }


    }
}
