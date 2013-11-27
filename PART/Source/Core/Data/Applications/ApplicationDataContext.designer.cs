﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CprBroker.Data.Applications
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PART")]
	public partial class ApplicationDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLogType(LogType instance);
    partial void UpdateLogType(LogType instance);
    partial void DeleteLogType(LogType instance);
    partial void InsertApplication(Application instance);
    partial void UpdateApplication(Application instance);
    partial void DeleteApplication(Application instance);
    partial void InsertLogEntry(LogEntry instance);
    partial void UpdateLogEntry(LogEntry instance);
    partial void DeleteLogEntry(LogEntry instance);
    partial void InsertDataProviderCall(DataProviderCall instance);
    partial void UpdateDataProviderCall(DataProviderCall instance);
    partial void DeleteDataProviderCall(DataProviderCall instance);
    #endregion
		
		public ApplicationDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ApplicationDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ApplicationDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ApplicationDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<LogType> LogTypes
		{
			get
			{
				return this.GetTable<LogType>();
			}
		}
		
		public System.Data.Linq.Table<Application> Applications
		{
			get
			{
				return this.GetTable<Application>();
			}
		}
		
		public System.Data.Linq.Table<LogEntry> LogEntries
		{
			get
			{
				return this.GetTable<LogEntry>();
			}
		}
		
		public System.Data.Linq.Table<DataProviderCall> DataProviderCalls
		{
			get
			{
				return this.GetTable<DataProviderCall>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LogType")]
	public partial class LogType : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _LogTypeId;
		
		private string _Name;
		
		private EntitySet<LogEntry> _LogEntries;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLogTypeIdChanging(int value);
    partial void OnLogTypeIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public LogType()
		{
			this._LogEntries = new EntitySet<LogEntry>(new Action<LogEntry>(this.attach_LogEntries), new Action<LogEntry>(this.detach_LogEntries));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogTypeId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int LogTypeId
		{
			get
			{
				return this._LogTypeId;
			}
			set
			{
				if ((this._LogTypeId != value))
				{
					this.OnLogTypeIdChanging(value);
					this.SendPropertyChanging();
					this._LogTypeId = value;
					this.SendPropertyChanged("LogTypeId");
					this.OnLogTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LogType_LogEntry", Storage="_LogEntries", ThisKey="LogTypeId", OtherKey="LogTypeId")]
		public EntitySet<LogEntry> LogEntries
		{
			get
			{
				return this._LogEntries;
			}
			set
			{
				this._LogEntries.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_LogEntries(LogEntry entity)
		{
			this.SendPropertyChanging();
			entity.LogType = this;
		}
		
		private void detach_LogEntries(LogEntry entity)
		{
			this.SendPropertyChanging();
			entity.LogType = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Application")]
	public partial class Application : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ApplicationId;
		
		private string _Name;
		
		private string _Token;
		
		private System.DateTime _RegistrationDate;
		
		private bool _IsApproved;
		
		private System.Nullable<System.DateTime> _ApprovedDate;
		
		private EntitySet<LogEntry> _LogEntries;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnApplicationIdChanging(System.Guid value);
    partial void OnApplicationIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTokenChanging(string value);
    partial void OnTokenChanged();
    partial void OnRegistrationDateChanging(System.DateTime value);
    partial void OnRegistrationDateChanged();
    partial void OnIsApprovedChanging(bool value);
    partial void OnIsApprovedChanged();
    partial void OnApprovedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnApprovedDateChanged();
    #endregion
		
		public Application()
		{
			this._LogEntries = new EntitySet<LogEntry>(new Action<LogEntry>(this.attach_LogEntries), new Action<LogEntry>(this.detach_LogEntries));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Token", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Token
		{
			get
			{
				return this._Token;
			}
			set
			{
				if ((this._Token != value))
				{
					this.OnTokenChanging(value);
					this.SendPropertyChanging();
					this._Token = value;
					this.SendPropertyChanged("Token");
					this.OnTokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegistrationDate", DbType="DateTime NOT NULL")]
		public System.DateTime RegistrationDate
		{
			get
			{
				return this._RegistrationDate;
			}
			set
			{
				if ((this._RegistrationDate != value))
				{
					this.OnRegistrationDateChanging(value);
					this.SendPropertyChanging();
					this._RegistrationDate = value;
					this.SendPropertyChanged("RegistrationDate");
					this.OnRegistrationDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsApproved", DbType="Bit NOT NULL")]
		public bool IsApproved
		{
			get
			{
				return this._IsApproved;
			}
			set
			{
				if ((this._IsApproved != value))
				{
					this.OnIsApprovedChanging(value);
					this.SendPropertyChanging();
					this._IsApproved = value;
					this.SendPropertyChanged("IsApproved");
					this.OnIsApprovedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApprovedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ApprovedDate
		{
			get
			{
				return this._ApprovedDate;
			}
			set
			{
				if ((this._ApprovedDate != value))
				{
					this.OnApprovedDateChanging(value);
					this.SendPropertyChanging();
					this._ApprovedDate = value;
					this.SendPropertyChanged("ApprovedDate");
					this.OnApprovedDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Application_LogEntry", Storage="_LogEntries", ThisKey="ApplicationId", OtherKey="ApplicationId")]
		public EntitySet<LogEntry> LogEntries
		{
			get
			{
				return this._LogEntries;
			}
			set
			{
				this._LogEntries.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_LogEntries(LogEntry entity)
		{
			this.SendPropertyChanging();
			entity.Application = this;
		}
		
		private void detach_LogEntries(LogEntry entity)
		{
			this.SendPropertyChanging();
			entity.Application = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LogEntry")]
	public partial class LogEntry : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _LogEntryId;
		
		private int _LogTypeId;
		
		private System.Nullable<System.Guid> _ApplicationId;
		
		private string _UserToken;
		
		private string _UserId;
		
		private string _MethodName;
		
		private string _Text;
		
		private string _DataObjectType;
		
		private string _DataObjectXml;
		
		private System.DateTime _LogDate;
		
		private System.Nullable<System.Guid> _ActivityID;
		
		private EntityRef<Application> _Application;
		
		private EntityRef<LogType> _LogType;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLogEntryIdChanging(System.Guid value);
    partial void OnLogEntryIdChanged();
    partial void OnLogTypeIdChanging(int value);
    partial void OnLogTypeIdChanged();
    partial void OnApplicationIdChanging(System.Nullable<System.Guid> value);
    partial void OnApplicationIdChanged();
    partial void OnUserTokenChanging(string value);
    partial void OnUserTokenChanged();
    partial void OnUserIdChanging(string value);
    partial void OnUserIdChanged();
    partial void OnMethodNameChanging(string value);
    partial void OnMethodNameChanged();
    partial void OnTextChanging(string value);
    partial void OnTextChanged();
    partial void OnDataObjectTypeChanging(string value);
    partial void OnDataObjectTypeChanged();
    partial void OnDataObjectXmlChanging(string value);
    partial void OnDataObjectXmlChanged();
    partial void OnLogDateChanging(System.DateTime value);
    partial void OnLogDateChanged();
    partial void OnActivityIDChanging(System.Nullable<System.Guid> value);
    partial void OnActivityIDChanged();
    #endregion
		
		public LogEntry()
		{
			this._Application = default(EntityRef<Application>);
			this._LogType = default(EntityRef<LogType>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogEntryId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid LogEntryId
		{
			get
			{
				return this._LogEntryId;
			}
			set
			{
				if ((this._LogEntryId != value))
				{
					this.OnLogEntryIdChanging(value);
					this.SendPropertyChanging();
					this._LogEntryId = value;
					this.SendPropertyChanged("LogEntryId");
					this.OnLogEntryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogTypeId", DbType="Int NOT NULL")]
		public int LogTypeId
		{
			get
			{
				return this._LogTypeId;
			}
			set
			{
				if ((this._LogTypeId != value))
				{
					if (this._LogType.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLogTypeIdChanging(value);
					this.SendPropertyChanging();
					this._LogTypeId = value;
					this.SendPropertyChanged("LogTypeId");
					this.OnLogTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					if (this._Application.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserToken", DbType="VarChar(250)")]
		public string UserToken
		{
			get
			{
				return this._UserToken;
			}
			set
			{
				if ((this._UserToken != value))
				{
					this.OnUserTokenChanging(value);
					this.SendPropertyChanging();
					this._UserToken = value;
					this.SendPropertyChanged("UserToken");
					this.OnUserTokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="VarChar(250)")]
		public string UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MethodName", DbType="VarChar(250)")]
		public string MethodName
		{
			get
			{
				return this._MethodName;
			}
			set
			{
				if ((this._MethodName != value))
				{
					this.OnMethodNameChanging(value);
					this.SendPropertyChanging();
					this._MethodName = value;
					this.SendPropertyChanged("MethodName");
					this.OnMethodNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Text", DbType="NVarChar(MAX)")]
		public string Text
		{
			get
			{
				return this._Text;
			}
			set
			{
				if ((this._Text != value))
				{
					this.OnTextChanging(value);
					this.SendPropertyChanging();
					this._Text = value;
					this.SendPropertyChanged("Text");
					this.OnTextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataObjectType", DbType="VarChar(250)")]
		public string DataObjectType
		{
			get
			{
				return this._DataObjectType;
			}
			set
			{
				if ((this._DataObjectType != value))
				{
					this.OnDataObjectTypeChanging(value);
					this.SendPropertyChanging();
					this._DataObjectType = value;
					this.SendPropertyChanged("DataObjectType");
					this.OnDataObjectTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataObjectXml", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string DataObjectXml
		{
			get
			{
				return this._DataObjectXml;
			}
			set
			{
				if ((this._DataObjectXml != value))
				{
					this.OnDataObjectXmlChanging(value);
					this.SendPropertyChanging();
					this._DataObjectXml = value;
					this.SendPropertyChanged("DataObjectXml");
					this.OnDataObjectXmlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogDate", DbType="DateTime NOT NULL")]
		public System.DateTime LogDate
		{
			get
			{
				return this._LogDate;
			}
			set
			{
				if ((this._LogDate != value))
				{
					this.OnLogDateChanging(value);
					this.SendPropertyChanging();
					this._LogDate = value;
					this.SendPropertyChanged("LogDate");
					this.OnLogDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityID", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> ActivityID
		{
			get
			{
				return this._ActivityID;
			}
			set
			{
				if ((this._ActivityID != value))
				{
					this.OnActivityIDChanging(value);
					this.SendPropertyChanging();
					this._ActivityID = value;
					this.SendPropertyChanged("ActivityID");
					this.OnActivityIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Application_LogEntry", Storage="_Application", ThisKey="ApplicationId", OtherKey="ApplicationId", IsForeignKey=true)]
		public Application Application
		{
			get
			{
				return this._Application.Entity;
			}
			set
			{
				Application previousValue = this._Application.Entity;
				if (((previousValue != value) 
							|| (this._Application.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Application.Entity = null;
						previousValue.LogEntries.Remove(this);
					}
					this._Application.Entity = value;
					if ((value != null))
					{
						value.LogEntries.Add(this);
						this._ApplicationId = value.ApplicationId;
					}
					else
					{
						this._ApplicationId = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("Application");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LogType_LogEntry", Storage="_LogType", ThisKey="LogTypeId", OtherKey="LogTypeId", IsForeignKey=true)]
		public LogType LogType
		{
			get
			{
				return this._LogType.Entity;
			}
			set
			{
				LogType previousValue = this._LogType.Entity;
				if (((previousValue != value) 
							|| (this._LogType.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LogType.Entity = null;
						previousValue.LogEntries.Remove(this);
					}
					this._LogType.Entity = value;
					if ((value != null))
					{
						value.LogEntries.Add(this);
						this._LogTypeId = value.LogTypeId;
					}
					else
					{
						this._LogTypeId = default(int);
					}
					this.SendPropertyChanged("LogType");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DataProviderCall")]
	public partial class DataProviderCall : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _DataProviderCallId;
		
		private System.Guid _ActivityId;
		
		private System.DateTime _CallTime;
		
		private string _DataProviderType;
		
		private decimal _Cost;
		
		private string _Operation;
		
		private string _Input;
		
		private System.Nullable<bool> _Success;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDataProviderCallIdChanging(System.Guid value);
    partial void OnDataProviderCallIdChanged();
    partial void OnActivityIdChanging(System.Guid value);
    partial void OnActivityIdChanged();
    partial void OnCallTimeChanging(System.DateTime value);
    partial void OnCallTimeChanged();
    partial void OnDataProviderTypeChanging(string value);
    partial void OnDataProviderTypeChanged();
    partial void OnCostChanging(decimal value);
    partial void OnCostChanged();
    partial void OnOperationChanging(string value);
    partial void OnOperationChanged();
    partial void OnInputChanging(string value);
    partial void OnInputChanged();
    partial void OnSuccessChanging(System.Nullable<bool> value);
    partial void OnSuccessChanged();
    #endregion
		
		public DataProviderCall()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataProviderCallId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid DataProviderCallId
		{
			get
			{
				return this._DataProviderCallId;
			}
			set
			{
				if ((this._DataProviderCallId != value))
				{
					this.OnDataProviderCallIdChanging(value);
					this.SendPropertyChanging();
					this._DataProviderCallId = value;
					this.SendPropertyChanged("DataProviderCallId");
					this.OnDataProviderCallIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ActivityId", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid ActivityId
		{
			get
			{
				return this._ActivityId;
			}
			set
			{
				if ((this._ActivityId != value))
				{
					this.OnActivityIdChanging(value);
					this.SendPropertyChanging();
					this._ActivityId = value;
					this.SendPropertyChanged("ActivityId");
					this.OnActivityIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CallTime", DbType="DateTime NOT NULL")]
		public System.DateTime CallTime
		{
			get
			{
				return this._CallTime;
			}
			set
			{
				if ((this._CallTime != value))
				{
					this.OnCallTimeChanging(value);
					this.SendPropertyChanging();
					this._CallTime = value;
					this.SendPropertyChanged("CallTime");
					this.OnCallTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataProviderType", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string DataProviderType
		{
			get
			{
				return this._DataProviderType;
			}
			set
			{
				if ((this._DataProviderType != value))
				{
					this.OnDataProviderTypeChanging(value);
					this.SendPropertyChanging();
					this._DataProviderType = value;
					this.SendPropertyChanged("DataProviderType");
					this.OnDataProviderTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cost", DbType="Decimal(18,4) NOT NULL")]
		public decimal Cost
		{
			get
			{
				return this._Cost;
			}
			set
			{
				if ((this._Cost != value))
				{
					this.OnCostChanging(value);
					this.SendPropertyChanging();
					this._Cost = value;
					this.SendPropertyChanged("Cost");
					this.OnCostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Operation", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Operation
		{
			get
			{
				return this._Operation;
			}
			set
			{
				if ((this._Operation != value))
				{
					this.OnOperationChanging(value);
					this.SendPropertyChanging();
					this._Operation = value;
					this.SendPropertyChanged("Operation");
					this.OnOperationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Input", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Input
		{
			get
			{
				return this._Input;
			}
			set
			{
				if ((this._Input != value))
				{
					this.OnInputChanging(value);
					this.SendPropertyChanging();
					this._Input = value;
					this.SendPropertyChanged("Input");
					this.OnInputChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Success", DbType="Bit NULL")]
		public System.Nullable<bool> Success
		{
			get
			{
				return this._Success;
			}
			set
			{
				if ((this._Success != value))
				{
					this.OnSuccessChanging(value);
					this.SendPropertyChanging();
					this._Success = value;
					this.SendPropertyChanged("Success");
					this.OnSuccessChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
