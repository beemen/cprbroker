﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.2012
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CprBrokerWixInstallers.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CprBrokerWixInstallers.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ApplicationId;Name;Token;RegistrationDate;IsApproved;ApprovedDate
        ///{3E9890FF-0038-42A4-987A-99B63E8BC865};Base Application;07059250-E448-4040-B695-9C03F9E59E38;2009-06-25;True;
        ///{C98F9BE7-2DDE-404a-BAB5-5A7B1BBC3063};Event Broker;FCD568A0-8F18-4b6f-8691-C09239F158F3;2011-01-01;True;
        ///{4A78A5C8-B39B-41B9-9707-5782DAA56E2A};CPR Business Application Demo;5f8b7af5-422e-46bb-9273-5e244dc37505;2011-01-01;True;.
        /// </summary>
        internal static string Application {
            get {
                return ResourceManager.GetString("Application", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 00037071620120702
        ///001000000019910923120000000000199109231200000000000000Ukendt Myndighed                                                                                                                                                                                      Ukendt Myndighed                                                                                                                                                     000
        ///001000139020110819105772269735201107010000000000000000Cpr-Kontoret      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Authority_4357 {
            get {
                return ResourceManager.GetString("Authority_4357", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /****** Object:  User [DDD]    Script Date: 11/20/2013 17:42:52 ******/
        ///IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N&apos;DDD&apos;)
        ///CREATE USER [DDD] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
        ///GO
        ////****** Object:  User [cpr]    Script Date: 11/20/2013 17:42:52 ******/
        ///IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N&apos;cpr&apos;)
        ///CREATE USER [cpr] FOR LOGIN [cpr] WITH DEFAULT_SCHEMA=[dbo]
        ///GO
        ////****** Object:  Table [dbo].[Country]    Script Date: 11/20/2013 17:42:53 ******/
        ///SET  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreatePartDatabaseObjects {
            get {
                return ResourceManager.GetString("CreatePartDatabaseObjects", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LifecycleStatusId;LifecycleStatusName
        ///0;Created
        ///1;Imported
        ///2;Deactivated
        ///3;Deleted
        ///4;Updated
        ///.
        /// </summary>
        internal static string LifecycleStatus {
            get {
                return ResourceManager.GetString("LifecycleStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to LogTypeId;Name
        ///1;Critical
        ///2;Error
        ///4;Warning
        ///8;Information
        ///16;Verbose
        ///256;Start
        ///512;Stop
        ///1024;Suspend
        ///2048;Resume
        ///4096;Transfer
        ///.
        /// </summary>
        internal static string LogType {
            get {
                return ResourceManager.GetString("LogType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///	This file patches the CPR broker database to version 1.3
        ///	Creates tables Extract, ExtractItem and Authority
        ///	SQL 9.xxx (2005) is a minimum because it makes use of INCLUDE in index for ExtractItem
        ///*/
        ///
        ////****** Object:  Column [dbo].[PersonRegistration].[Table]    Script Date: 23/08/2012 18:36:34 ******/
        ///IF NOT EXISTS(SELECT * FROM sys.columns WHERE object_id= object_id(&apos;PersonRegistration&apos;) AND name = &apos;SourceObjects&apos;)
        ///BEGIN
        ///	ALTER TABLE [dbo].[PersonRegistration] ADD [SourceObjects] [xml] NULL
        ///E [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PatchDatabase_1_3 {
            get {
                return ResourceManager.GetString("PatchDatabase_1_3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /****** Object:  Table [dbo].[Extract].[Ready]     ******/
        ///IF NOT EXISTS(SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N&apos;[dbo].[Extract]&apos;) AND name = &apos;Ready&apos;)
        ///BEGIN
        ///	ALTER TABLE dbo.Extract ADD
        ///		Ready bit NOT NULL CONSTRAINT DF_Extract_Ready DEFAULT 0 
        ///END
        ///GO
        ///
        ///SET QUOTED_IDENTIFIER ON
        ///GO
        ///
        ///SET ANSI_PADDING ON
        ///GO
        ///
        ////****** Object:  Table [dbo].[ExtractPersonStaging]    Script Date: 10/17/2012 19:15:13 ******/
        ///SET ANSI_NULLS ON
        ///GO
        ///SET QUOTED_IDENTIFIER ON
        ///GO
        ///SET ANSI_PADDING ON
        ///GO
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PatchDatabase_1_3_2 {
            get {
                return ResourceManager.GetString("PatchDatabase_1_3_2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///ALTER TABLE [dbo].[PersonProperties] ALTER COLUMN [BirthRegistrationAuthority] varchar(60) 
        ///GO.
        /// </summary>
        internal static string PatchDatabase_1_4 {
            get {
                return ResourceManager.GetString("PatchDatabase_1_4", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -------------------------------------
        ///-----  Column width expansion  ------
        ///-------------------------------------
        ///ALTER TABLE [dbo].[PersonProperties] ALTER COLUMN [BirthPlace] varchar(132) 
        ///GO
        ///
        ///
        ///---------------------------------------
        ///-----  Table for extract errors  ------
        ///---------------------------------------
        ///
        ///IF NOT EXISTS (SELECT * FROM sys.tables WHERE name=&apos;ExtractError&apos;)
        ///CREATE TABLE dbo.ExtractError(
        ///    ExtractErrorId uniqueidentifier NOT NULL DEFAULT(newid()),
        ///    ExtractId unique [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PatchDatabase_2_1 {
            get {
                return ResourceManager.GetString("PatchDatabase_2_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ----------------------------------------------------------------------------
        ///------------  Fixes to error in installer of previous version  -------------
        ///----------------------------------------------------------------------------
        ///
        ///IF EXISTS (SELECT * FROM sys.columns c WHERE name = &apos;EffectId&apos; and object_id=object_id(&apos;PersonProperties&apos;))
        ///	ALTER TABLE PersonProperties DROP COLUMN EffectId
        ///GO
        ///
        ///-----------------------------------------------------------------
        ///------------  Enables parameterized subscr [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PatchDatabase_2_2 {
            get {
                return ResourceManager.GetString("PatchDatabase_2_2", resourceCulture);
            }
        }
    }
}
