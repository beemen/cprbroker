﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 *
 * The Initial Developer of the Original Code is
 * IT- og Telestyrelsen / Danish National IT and Telecom Agency.
 *
 * Contributor(s):
 * Beemen Beshara
 * Niels Elgaard Larsen
 * Leif Lodahl
 * Steen Deth
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using CprBroker.Utilities;

namespace CprBroker.Installers
{
    public abstract partial class WebInstallationInfo
    {

        public static WebInstallationInfo FromSession(Session session)
        {
            bool createAsWebsite = session.GetPropertyValue("WEB_CREATEASWEBSITE") == "True";
            if (createAsWebsite)
            {
                return new WebsiteInstallationInfo()
                {
                    //CreateAsWebsite = session.GetPropertyValue("WEB_CREATEASWEBSITE") == "True",
                    //ApplicationPath = session.GetPropertyValue("WEB_APPLICATIONPATH"),
                    //VirtualDirectoryName = session.GetPropertyValue("WEB_VIRTUALDIRECTORYNAME"),
                    WebsiteName = session.GetPropertyValue("WEB_SITENAME"),
                    //WebsitePath = session.GetPropertyValue("WEB_VIRTUALDIRECTORYSITEPATH"),
                    InstallDir = session.GetPropertyValue("INSTALLDIR"),
                };
            }
            else
            {
                return new VirtualDirectoryInstallationInfo()
                {
                    //CreateAsWebsite = session.GetPropertyValue("WEB_CREATEASWEBSITE") == "True",
                    //ApplicationPath = session.GetPropertyValue("WEB_APPLICATIONPATH"),
                    VirtualDirectoryName = session.GetPropertyValue("WEB_VIRTUALDIRECTORYNAME"),
                    WebsiteName = session.GetPropertyValue("WEB_SITENAME"),
                    //WebsitePath = session.GetPropertyValue("WEB_VIRTUALDIRECTORYSITEPATH"),
                    InstallDir = session.GetPropertyValue("INSTALLDIR"),
                };
            }
        }

        public void CopyToSession(Session session)
        {
            if (this is WebsiteInstallationInfo)
            {
                WebsiteInstallationInfo websiteInstallationInfo = this as WebsiteInstallationInfo;
                session.SetPropertyValue("WEB_CREATEASWEBSITE", websiteInstallationInfo.CreateAsWebsite.ToString());
                session.SetPropertyValue("WEB_APPLICATIONPATH", websiteInstallationInfo.TargetWmiPath);
                //session.SetPropertyValue("WEB_VIRTUALDIRECTORYNAME", websiteInstallationInfo.VirtualDirectoryName);
                session.SetPropertyValue("WEB_SITENAME", websiteInstallationInfo.WebsiteName);
                //session.SetPropertyValue("WEB_VIRTUALDIRECTORYSITEPATH", websiteInstallationInfo.WebsitePath);
                session.SetPropertyValue("INSTALLDIR", websiteInstallationInfo.InstallDir);
            }
            else
            {
                VirtualDirectoryInstallationInfo virtualDirectoryInstallationInfo = this as VirtualDirectoryInstallationInfo;
                session.SetPropertyValue("WEB_CREATEASWEBSITE", virtualDirectoryInstallationInfo.CreateAsWebsite.ToString());
                session.SetPropertyValue("WEB_APPLICATIONPATH", virtualDirectoryInstallationInfo.TargetWmiPath);
                session.SetPropertyValue("WEB_VIRTUALDIRECTORYNAME", virtualDirectoryInstallationInfo.VirtualDirectoryName);
                session.SetPropertyValue("WEB_SITENAME", virtualDirectoryInstallationInfo.WebsiteName);
                session.SetPropertyValue("WEB_VIRTUALDIRECTORYSITEPATH", virtualDirectoryInstallationInfo.WebsitePath);
                session.SetPropertyValue("INSTALLDIR", virtualDirectoryInstallationInfo.InstallDir);
            }
        }

    }
}
