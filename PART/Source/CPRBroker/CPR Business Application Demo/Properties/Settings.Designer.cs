﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3615
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CPR_Business_Application_Demo.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CPR Business Application Demo")]
        public string UserToken {
            get {
                return ((string)(this["UserToken"]));
            }
            set {
                this["UserToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:1551/Services/")]
        public string CPRBrokerWebServiceUrl {
            get {
                return ((string)(this["CPRBrokerWebServiceUrl"]));
            }
            set {
                this["CPRBrokerWebServiceUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int NotificationMode {
            get {
                return ((int)(this["NotificationMode"]));
            }
            set {
                this["NotificationMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string NotificationCallbackWebServiceUrl {
            get {
                return ((string)(this["NotificationCallbackWebServiceUrl"]));
            }
            set {
                this["NotificationCallbackWebServiceUrl"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string NotificationFileShare {
            get {
                return ((string)(this["NotificationFileShare"]));
            }
            set {
                this["NotificationFileShare"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool FirstTime {
            get {
                return ((bool)(this["FirstTime"]));
            }
            set {
                this["FirstTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool CPRBrokerWebServiceUrlTestOk {
            get {
                return ((bool)(this["CPRBrokerWebServiceUrlTestOk"]));
            }
            set {
                this["CPRBrokerWebServiceUrlTestOk"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CPR Business Application Demo")]
        public string ApplicationName {
            get {
                return ((string)(this["ApplicationName"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("07059250-E448-4040-B695-9C03F9E59E38")]
        public string AdminAppToken {
            get {
                return ((string)(this["AdminAppToken"]));
            }
            set {
                this["AdminAppToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5f8b7af5-422e-46bb-9273-5e244dc37505")]
        public string AppToken {
            get {
                return ((string)(this["AppToken"]));
            }
            set {
                this["AppToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:1552/Services/")]
        public string EventBrokerWebServiceUrl {
            get {
                return ((string)(this["EventBrokerWebServiceUrl"]));
            }
            set {
                this["EventBrokerWebServiceUrl"] = value;
            }
        }
    }
}
