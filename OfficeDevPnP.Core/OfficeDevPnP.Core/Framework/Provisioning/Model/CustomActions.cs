﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OfficeDevPnP.Core.Framework.Provisioning.Model
{
    /// <summary>
    /// Domain Object that represents a Collections of Custom Actions
    /// </summary>
    public class CustomActions
    {
        #region Private Members
        private List<CustomAction> _siteCustomActions;
        private List<CustomAction> _webCustomActions;
        #endregion

        #region Constructor
        public CustomActions()
        {
            this._siteCustomActions = new List<CustomAction>();
            this._webCustomActions = new List<CustomAction>();
        }
        #endregion


        #region Properties
        /// <summary>
        /// A Collection of CustomActions at the Site level
        /// </summary>
        public List<CustomAction> SiteCustomActions
        {
            get
            {
                return this._siteCustomActions;
            }
            private set { this._siteCustomActions = value; }
        }

        /// <summary>
        /// A Collection of CustomActions at the Web level
        /// </summary>
        public List<CustomAction> WebCustomActions
        {
            get
            {
                return this._webCustomActions;
            }
            private set { this._webCustomActions = value; }
        }

        #endregion

    }
}
