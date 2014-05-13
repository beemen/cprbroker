﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CprBroker.Data.Queues
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="part")]
	public partial class QueueDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertQueueItem(QueueItem instance);
    partial void UpdateQueueItem(QueueItem instance);
    partial void DeleteQueueItem(QueueItem instance);
    partial void InsertQueue(Queue instance);
    partial void UpdateQueue(Queue instance);
    partial void DeleteQueue(Queue instance);
    #endregion
		
		public QueueDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QueueDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QueueDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QueueDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<QueueItem> QueueItems
		{
			get
			{
				return this.GetTable<QueueItem>();
			}
		}
		
		public System.Data.Linq.Table<Queue> Queues
		{
			get
			{
				return this.GetTable<Queue>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.QueueItem")]
	public partial class QueueItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _QueueItemId;
		
		private System.Guid _QueueId;
		
		private string _ItemKey;
		
		private System.DateTime _CreatedTS;
		
		private int _AttemptCount;
		
		private EntityRef<Queue> _Queue;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnQueueItemIdChanging(int value);
    partial void OnQueueItemIdChanged();
    partial void OnQueueIdChanging(System.Guid value);
    partial void OnQueueIdChanged();
    partial void OnItemKeyChanging(string value);
    partial void OnItemKeyChanged();
    partial void OnCreatedTSChanging(System.DateTime value);
    partial void OnCreatedTSChanged();
    partial void OnAttemptCountChanging(int value);
    partial void OnAttemptCountChanged();
    #endregion
		
		public QueueItem()
		{
			this._Queue = default(EntityRef<Queue>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QueueItemId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int QueueItemId
		{
			get
			{
				return this._QueueItemId;
			}
			set
			{
				if ((this._QueueItemId != value))
				{
					this.OnQueueItemIdChanging(value);
					this.SendPropertyChanging();
					this._QueueItemId = value;
					this.SendPropertyChanged("QueueItemId");
					this.OnQueueItemIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QueueId", DbType="uniqueidentifier NOT NULL")]
		public System.Guid QueueId
		{
			get
			{
				return this._QueueId;
			}
			set
			{
				if ((this._QueueId != value))
				{
					if (this._Queue.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnQueueIdChanging(value);
					this.SendPropertyChanging();
					this._QueueId = value;
					this.SendPropertyChanged("QueueId");
					this.OnQueueIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ItemKey", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ItemKey
		{
			get
			{
				return this._ItemKey;
			}
			set
			{
				if ((this._ItemKey != value))
				{
					this.OnItemKeyChanging(value);
					this.SendPropertyChanging();
					this._ItemKey = value;
					this.SendPropertyChanged("ItemKey");
					this.OnItemKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedTS", DbType="DateTime NOT NULL")]
		public System.DateTime CreatedTS
		{
			get
			{
				return this._CreatedTS;
			}
			set
			{
				if ((this._CreatedTS != value))
				{
					this.OnCreatedTSChanging(value);
					this.SendPropertyChanging();
					this._CreatedTS = value;
					this.SendPropertyChanged("CreatedTS");
					this.OnCreatedTSChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AttemptCount", DbType="Int")]
		public int AttemptCount
		{
			get
			{
				return this._AttemptCount;
			}
			set
			{
				if ((this._AttemptCount != value))
				{
					this.OnAttemptCountChanging(value);
					this.SendPropertyChanging();
					this._AttemptCount = value;
					this.SendPropertyChanged("AttemptCount");
					this.OnAttemptCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Queue_QueueItem", Storage="_Queue", ThisKey="QueueId", OtherKey="QueueId", IsForeignKey=true)]
		public Queue Queue
		{
			get
			{
				return this._Queue.Entity;
			}
			set
			{
				Queue previousValue = this._Queue.Entity;
				if (((previousValue != value) 
							|| (this._Queue.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Queue.Entity = null;
						previousValue.QueueItems.Remove(this);
					}
					this._Queue.Entity = value;
					if ((value != null))
					{
						value.QueueItems.Add(this);
						this._QueueId = value.QueueId;
					}
					else
					{
						this._QueueId = default(System.Guid);
					}
					this.SendPropertyChanged("Queue");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Queue")]
	public partial class Queue : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _QueueId;
		
		private System.Nullable<int> _TypeId;
		
		private string _TypeName;
		
		private int _BatchSize;
		
		private int _MaxRetry;
		
		private System.Data.Linq.Binary _image;
		
		private EntitySet<QueueItem> _QueueItems;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnQueueIdChanging(System.Guid value);
    partial void OnQueueIdChanged();
    partial void OnTypeIdChanging(System.Nullable<int> value);
    partial void OnTypeIdChanged();
    partial void OnTypeNameChanging(string value);
    partial void OnTypeNameChanged();
    partial void OnBatchSizeChanging(int value);
    partial void OnBatchSizeChanged();
    partial void OnMaxRetryChanging(int value);
    partial void OnMaxRetryChanged();
    partial void OnEncryptedDataChanging(System.Data.Linq.Binary value);
    partial void OnEncryptedDataChanged();
    #endregion
		
		public Queue()
		{
			this._QueueItems = new EntitySet<QueueItem>(new Action<QueueItem>(this.attach_QueueItems), new Action<QueueItem>(this.detach_QueueItems));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QueueId", DbType="uniqueidentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid QueueId
		{
			get
			{
				return this._QueueId;
			}
			set
			{
				if ((this._QueueId != value))
				{
					this.OnQueueIdChanging(value);
					this.SendPropertyChanging();
					this._QueueId = value;
					this.SendPropertyChanged("QueueId");
					this.OnQueueIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TypeId", DbType="INT")]
		public System.Nullable<int> TypeId
		{
			get
			{
				return this._TypeId;
			}
			set
			{
				if ((this._TypeId != value))
				{
					this.OnTypeIdChanging(value);
					this.SendPropertyChanging();
					this._TypeId = value;
					this.SendPropertyChanged("TypeId");
					this.OnTypeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TypeName", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string TypeName
		{
			get
			{
				return this._TypeName;
			}
			set
			{
				if ((this._TypeName != value))
				{
					this.OnTypeNameChanging(value);
					this.SendPropertyChanging();
					this._TypeName = value;
					this.SendPropertyChanged("TypeName");
					this.OnTypeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BatchSize", DbType="Int NOT NULL")]
		public int BatchSize
		{
			get
			{
				return this._BatchSize;
			}
			set
			{
				if ((this._BatchSize != value))
				{
					this.OnBatchSizeChanging(value);
					this.SendPropertyChanging();
					this._BatchSize = value;
					this.SendPropertyChanged("BatchSize");
					this.OnBatchSizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaxRetry", DbType="Int NOT NULL")]
		public int MaxRetry
		{
			get
			{
				return this._MaxRetry;
			}
			set
			{
				if ((this._MaxRetry != value))
				{
					this.OnMaxRetryChanging(value);
					this.SendPropertyChanging();
					this._MaxRetry = value;
					this.SendPropertyChanged("MaxRetry");
					this.OnMaxRetryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", DbType="varbinary(MAX)")]
		public System.Data.Linq.Binary EncryptedData
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnEncryptedDataChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("EncryptedData");
					this.OnEncryptedDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Queue_QueueItem", Storage="_QueueItems", ThisKey="QueueId", OtherKey="QueueId")]
		public EntitySet<QueueItem> QueueItems
		{
			get
			{
				return this._QueueItems;
			}
			set
			{
				this._QueueItems.Assign(value);
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
		
		private void attach_QueueItems(QueueItem entity)
		{
			this.SendPropertyChanging();
			entity.Queue = this;
		}
		
		private void detach_QueueItems(QueueItem entity)
		{
			this.SendPropertyChanging();
			entity.Queue = null;
		}
	}
}
#pragma warning restore 1591
