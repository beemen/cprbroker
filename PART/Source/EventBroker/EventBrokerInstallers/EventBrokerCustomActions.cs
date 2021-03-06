﻿/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License
 * Version 1.1 (the "License"); you may not use this file except in
 * compliance with the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS"basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The CPR Broker concept was initally developed by
 * Gentofte Kommune / Municipality of Gentofte, Denmark.
 * Contributor(s):
 * Steen Deth
 *
 *
 * The Initial Code for CPR Broker and related components is made in
 * cooperation between Magenta, Gentofte Kommune and IT- og Telestyrelsen /
 * Danish National IT and Telecom Agency
 *
 * Contributor(s):
 * Beemen Beshara
 *
 * The code is currently governed by IT- og Telestyrelsen / Danish National
 * IT and Telecom Agency
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
using System.IO;
using Microsoft.Deployment.WindowsInstaller;
using System.Management;
using CprBroker.Utilities;
using CprBroker.Installers;
using CprBroker.Engine;
using CprBroker.EventBroker.Data;
using CprBroker.EventBroker.Backend;
using CprBroker.Utilities.Config;
using System.Configuration;

namespace CprBroker.Installers.EventBrokerInstallers
{
    public static partial class EventBrokerCustomActions
    {
        private static string GetServiceExeFullFileName(SessionAdapter session)
        {
            return string.Format("{0}{1}bin\\Backend\\CprBroker.EventBroker.Backend.exe", session.GetInstallDirProperty(), PathConstants.EventBrokerWebsiteDirectoryRelativePath);
        }

        private static string GetOldServiceExeFullFileName(SessionAdapter session)
        {
            return string.Format("{0}{1}bin\\CprBroker.EventBroker.Backend.exe", session.GetInstallDirProperty(), PathConstants.EventBrokerWebsiteDirectoryRelativePath);
        }

        public static string GetServiceExeConfigFullFileName(SessionAdapter session)
        {
            return GetServiceExeFullFileName(session) + ".config";
        }

        private static string GetOldServiceExeConfigFullFileName(SessionAdapter session)
        {
            return GetOldServiceExeFullFileName(session) + ".config";
        }

        private static Version GetServiceExeFrameworkVersion()
        {
            return new Version(4, 0);
        }

        private static string GetExistingServiceExePath()
        {
            var serciceName = new BackendService().ServiceName;
            ManagementClass mc = new ManagementClass("Win32_Service");
            foreach (ManagementObject mo in mc.GetInstances())
            {
                if (mo.GetPropertyValue("Name").ToString() == serciceName)
                {
                    return mo.GetPropertyValue("PathName").ToString().Trim('"');
                }
            }
            return null;
        }

        [CustomAction]
        public static ActionResult InstallBackendService(Session session)
        {
            return InstallBackendService(session.Adapter());
        }
        public static ActionResult InstallBackendService(SessionAdapter session)
        {
            try
            {
                Installation.SetConnectionStringInConfigFile(GetServiceExeConfigFullFileName(session), "CprBroker.Config.Properties.Settings.CprBrokerConnectionString", DatabaseSetupInfo.CreateFromFeature(session, "CPR").CreateConnectionString(false, true));
                Installation.SetConnectionStringInConfigFile(GetServiceExeConfigFullFileName(session), "CprBroker.Config.Properties.Settings.EventBrokerConnectionString", DatabaseSetupInfo.CreateFromFeature(session, "EVENT").CreateConnectionString(false, true));
                InstallService(GetServiceExeFullFileName(session), GetServiceExeFrameworkVersion());

                StartService(ServiceName);
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.ShowErrorMessage(ex);
                throw ex;
            }
        }

        [CustomAction]
        public static ActionResult RollbackBackendService(Session session)
        {
            return RollbackBackendService(session.Adapter());
        }
        public static ActionResult RollbackBackendService(SessionAdapter session)
        {
            try
            {
                return UnInstallBackendService(session);
            }
            catch (Exception ex)
            {
                session.ShowErrorMessage(ex);
                throw ex;
            }
        }

        [CustomAction]
        public static ActionResult UnInstallBackendService(Session session)
        {
            return UnInstallBackendService(session.Adapter());
        }
        public static ActionResult UnInstallBackendService(SessionAdapter session)
        {
            try
            {
                StopService(ServiceName);
                UninstallService(GetServiceExeFullFileName(session), GetServiceExeFrameworkVersion());
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.ShowErrorMessage(ex);
                throw ex;
            }
        }

        [CustomAction]
        public static ActionResult SetCprBrokerUrl(Session session)
        {
            return SetCprBrokerUrl(session.Adapter());
        }
        public static ActionResult SetCprBrokerUrl(SessionAdapter session)
        {
            try
            {
                WebInstallationInfo cprBrokerWebInstallationInfo = WebInstallationInfo.CreateFromFeature(session, "CPR");

                var urls = cprBrokerWebInstallationInfo.CalculateWebUrls();
                Func<string, string> urlFunc = u => string.Format("{0}Services/Events.asmx", u);
                var bestUrl = urlFunc(urls[0]);

                for (int i = 0; i < urls.Length; i++)
                {
                    string url = urlFunc(urls[i]);
                    var client = new System.Net.WebClient();
                    try
                    {
                        client.DownloadData(url);
                        bestUrl = url;
                        break;
                    }
                    catch (Exception ex)
                    {
                        object o = ex;
                    }
                }

                Installation.SetApplicationSettingInConfigFile(
                    GetServiceExeConfigFullFileName(session),
                    typeof(CprBroker.Config.Properties.Settings),
                    "EventsServiceUrl",
                    bestUrl
                    );
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.ShowErrorMessage(ex);
                throw ex;
            }
        }

        [CustomAction]
        public static ActionResult CloneDataProviderSectionsToBackendService(Session session)
        {
            return CloneDataProviderSectionsToBackendService(session.Adapter());
        }
        public static ActionResult CloneDataProviderSectionsToBackendService(SessionAdapter session)
        {
            try
            {
                try { StopService(ServiceName); }
                catch { }
                WebInstallationInfo cprBrokerWebInstallationInfo = WebInstallationInfo.CreateFromFeature(session, "CPR");
                var sourcePath = cprBrokerWebInstallationInfo.GetWebConfigFilePath(PathConstants.CprBrokerWebsiteDirectoryRelativePath);
                var targetPath = GetServiceExeConfigFullFileName(session);

                // TODO: Shall we also clone connection strings?
                Installation.CopyConfigNode("//configuration", "configSections", sourcePath, targetPath, Installation.MergeOption.Overwrite);
                Installation.CopyConfigNode("//configuration", "dataProvidersGroup", sourcePath, targetPath, Installation.MergeOption.Overwrite);

                try { StartService(ServiceName); }
                catch { }
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.ShowErrorMessage(ex);
                throw ex;
            }
        }

        [CustomAction]
        public static ActionResult CloneCprBrokerConfigToEventBroker(Session session)
        {
            return CloneCprBrokerConfigToEventBroker(session.Adapter());
        }
        public static ActionResult CloneCprBrokerConfigToEventBroker(SessionAdapter session)
        {
            try
            {
                WebInstallationInfo cprBrokerWebInstallationInfo = WebInstallationInfo.CreateFromFeature(session, "CPR");
                var sourcePath = cprBrokerWebInstallationInfo.GetWebConfigFilePath(PathConstants.CprBrokerWebsiteDirectoryRelativePath);

                WebInstallationInfo eventBrokerWebInstallationInfo = WebInstallationInfo.CreateFromFeature(session, "EVENT");
                var targetPath = eventBrokerWebInstallationInfo.GetWebConfigFilePath(PathConstants.EventBrokerWebsiteDirectoryRelativePath);

                // TODO: Shall we also clone connection strings?
                Installation.CopyConfigNode("//configuration", "configSections", sourcePath, targetPath, Installation.MergeOption.Overwrite);
                Installation.CopyConfigNode("//dataProvidersGroup", "dataProviderKeys", sourcePath, targetPath, Installation.MergeOption.Overwrite);

                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                session.ShowErrorMessage(ex);
                throw ex;
            }
        }

        public static void MoveBackendServiceToNewLocation(Session session)
        {
            MoveBackendServiceToNewLocation(session.Adapter());
        }
        public static void MoveBackendServiceToNewLocation(SessionAdapter session)
        {
            var currentExePath = GetExistingServiceExePath();
            var newExePath = GetServiceExeFullFileName(session);

            if (currentExePath != null
                && !currentExePath.Trim().ToLower().Equals(newExePath.Trim().ToLower()))
            {

                var oldConfigPath = GetOldServiceExeConfigFullFileName(session);
                var newConfigPath = GetServiceExeConfigFullFileName(session);

                // Uninstall service at old location
                try
                {
                    UninstallService(GetOldServiceExeFullFileName(session), GetServiceExeFrameworkVersion());
                }
                catch { }

                // Copy old config file
                if (File.Exists(oldConfigPath))
                {
                    if (File.Exists(newConfigPath))
                        File.Delete(newConfigPath);

                    File.Move(oldConfigPath, newConfigPath);
                }

                // Install service at new location

                InstallService(GetServiceExeFullFileName(session), GetServiceExeFrameworkVersion());
            }
        }

        [CustomAction]
        public static ActionResult InitTasksConfiguration(Session session)
        {
            return InitTasksConfiguration(session.Adapter());
        }
        public static ActionResult InitTasksConfiguration(SessionAdapter session)
        {
            // Create temp config file
            string sourceFileName = GetServiceExeConfigFullFileName(session) + ".template";
            File.WriteAllText(sourceFileName, Properties.Resources.Backend_App_Config);
            var sourceConfig = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap() { ExeConfigFilename = sourceFileName },
                ConfigurationUserLevel.None);
            var sourceSection = sourceConfig.Sections[TasksConfigurationSection.SectionName] as TasksConfigurationSection;

            // Add section definition
            Installation.AddConfigSectionDefinition(GetServiceExeConfigFullFileName(session), null, TasksConfigurationSection.SectionName, typeof(TasksConfigurationSection));

            // Load service file            
            var targetConfig = ConfigurationManager.OpenExeConfiguration(GetServiceExeFullFileName(session));
            var targetSection = targetConfig.GetSection(TasksConfigurationSection.SectionName) as TasksConfigurationSection;

            targetSection.AutoLoaded.ImportDiffFrom(sourceSection);
            targetConfig.Save();

            // Cleanup
            try { File.Delete(sourceFileName); }
            catch { /*Do nothing, ignore failure*/}

            return ActionResult.Success;
        }

        public static void MigrateBackendToDotNet40(Session session)
        {
            MigrateBackendToDotNet40(session.Adapter());
        }
        public static void MigrateBackendToDotNet40(SessionAdapter session)
        {
            var path = GetServiceExeFullFileName(session);

            var actions = new Action[] {
                ()=> StopService(ServiceName),
                ()=> UninstallService(path, GetServiceExeFrameworkVersion())
            };

            foreach (var action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                { session.Log(ex.ToString()); }
            }

            InstallService(path, GetServiceExeFrameworkVersion());
            StartService(ServiceName);
        }

    }
}
