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

namespace CorporateAcademyPortalScheduleData
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CorporateAcademyPortalDB")]
	public partial class CorporateAcademyPortalDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBatch(Batch instance);
    partial void UpdateBatch(Batch instance);
    partial void DeleteBatch(Batch instance);
    partial void InsertNewEvent(NewEvent instance);
    partial void UpdateNewEvent(NewEvent instance);
    partial void DeleteNewEvent(NewEvent instance);
    partial void InsertEmployeeData(EmployeeData instance);
    partial void UpdateEmployeeData(EmployeeData instance);
    partial void DeleteEmployeeData(EmployeeData instance);
    partial void InsertEmployeeBatch(EmployeeBatch instance);
    partial void UpdateEmployeeBatch(EmployeeBatch instance);
    partial void DeleteEmployeeBatch(EmployeeBatch instance);
    #endregion
		
		public CorporateAcademyPortalDataClassesDataContext() : 
				base(global::CorporateAcademyPortalScheduleData.Properties.Settings.Default.CorporateAcademyPortalDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CorporateAcademyPortalDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CorporateAcademyPortalDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CorporateAcademyPortalDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CorporateAcademyPortalDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Batch> Batches
		{
			get
			{
				return this.GetTable<Batch>();
			}
		}
		
		public System.Data.Linq.Table<NewEvent> NewEvents
		{
			get
			{
				return this.GetTable<NewEvent>();
			}
		}
		
		public System.Data.Linq.Table<EmployeeData> EmployeeDatas
		{
			get
			{
				return this.GetTable<EmployeeData>();
			}
		}
		
		public System.Data.Linq.Table<EmployeeBatch> EmployeeBatches
		{
			get
			{
				return this.GetTable<EmployeeBatch>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Batch")]
	public partial class Batch : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BatchId;
		
		private string _BatchName;
		
		private System.DateTime _FromDate;
		
		private System.DateTime _ToDate;
		
		private EntitySet<NewEvent> _NewEvents;
		
		private EntitySet<EmployeeBatch> _EmployeeBatches;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBatchIdChanging(int value);
    partial void OnBatchIdChanged();
    partial void OnBatchNameChanging(string value);
    partial void OnBatchNameChanged();
    partial void OnFromDateChanging(System.DateTime value);
    partial void OnFromDateChanged();
    partial void OnToDateChanging(System.DateTime value);
    partial void OnToDateChanged();
    #endregion
		
		public Batch()
		{
			this._NewEvents = new EntitySet<NewEvent>(new Action<NewEvent>(this.attach_NewEvents), new Action<NewEvent>(this.detach_NewEvents));
			this._EmployeeBatches = new EntitySet<EmployeeBatch>(new Action<EmployeeBatch>(this.attach_EmployeeBatches), new Action<EmployeeBatch>(this.detach_EmployeeBatches));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BatchId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int BatchId
		{
			get
			{
				return this._BatchId;
			}
			set
			{
				if ((this._BatchId != value))
				{
					this.OnBatchIdChanging(value);
					this.SendPropertyChanging();
					this._BatchId = value;
					this.SendPropertyChanged("BatchId");
					this.OnBatchIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BatchName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string BatchName
		{
			get
			{
				return this._BatchName;
			}
			set
			{
				if ((this._BatchName != value))
				{
					this.OnBatchNameChanging(value);
					this.SendPropertyChanging();
					this._BatchName = value;
					this.SendPropertyChanged("BatchName");
					this.OnBatchNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromDate", DbType="Date NOT NULL")]
		public System.DateTime FromDate
		{
			get
			{
				return this._FromDate;
			}
			set
			{
				if ((this._FromDate != value))
				{
					this.OnFromDateChanging(value);
					this.SendPropertyChanging();
					this._FromDate = value;
					this.SendPropertyChanged("FromDate");
					this.OnFromDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToDate", DbType="Date NOT NULL")]
		public System.DateTime ToDate
		{
			get
			{
				return this._ToDate;
			}
			set
			{
				if ((this._ToDate != value))
				{
					this.OnToDateChanging(value);
					this.SendPropertyChanging();
					this._ToDate = value;
					this.SendPropertyChanged("ToDate");
					this.OnToDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Batch_NewEvent", Storage="_NewEvents", ThisKey="BatchId", OtherKey="BatchId")]
		public EntitySet<NewEvent> NewEvents
		{
			get
			{
				return this._NewEvents;
			}
			set
			{
				this._NewEvents.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Batch_EmployeeBatch", Storage="_EmployeeBatches", ThisKey="BatchId", OtherKey="BatchId")]
		public EntitySet<EmployeeBatch> EmployeeBatches
		{
			get
			{
				return this._EmployeeBatches;
			}
			set
			{
				this._EmployeeBatches.Assign(value);
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
		
		private void attach_NewEvents(NewEvent entity)
		{
			this.SendPropertyChanging();
			entity.Batch = this;
		}
		
		private void detach_NewEvents(NewEvent entity)
		{
			this.SendPropertyChanging();
			entity.Batch = null;
		}
		
		private void attach_EmployeeBatches(EmployeeBatch entity)
		{
			this.SendPropertyChanging();
			entity.Batch = this;
		}
		
		private void detach_EmployeeBatches(EmployeeBatch entity)
		{
			this.SendPropertyChanging();
			entity.Batch = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NewEvent")]
	public partial class NewEvent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EventId;
		
		private int _BatchId;
		
		private System.DateTime _Date;
		
		private string _Topic;
		
		private string _Trainer;
		
		private int _TheoryHours;
		
		private int _PracticalHours;
		
		private EntityRef<Batch> _Batch;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEventIdChanging(int value);
    partial void OnEventIdChanged();
    partial void OnBatchIdChanging(int value);
    partial void OnBatchIdChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnTopicChanging(string value);
    partial void OnTopicChanged();
    partial void OnTrainerChanging(string value);
    partial void OnTrainerChanged();
    partial void OnTheoryHoursChanging(int value);
    partial void OnTheoryHoursChanged();
    partial void OnPracticalHoursChanging(int value);
    partial void OnPracticalHoursChanged();
    #endregion
		
		public NewEvent()
		{
			this._Batch = default(EntityRef<Batch>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int EventId
		{
			get
			{
				return this._EventId;
			}
			set
			{
				if ((this._EventId != value))
				{
					this.OnEventIdChanging(value);
					this.SendPropertyChanging();
					this._EventId = value;
					this.SendPropertyChanged("EventId");
					this.OnEventIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BatchId", DbType="Int NOT NULL")]
		public int BatchId
		{
			get
			{
				return this._BatchId;
			}
			set
			{
				if ((this._BatchId != value))
				{
					if (this._Batch.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBatchIdChanging(value);
					this.SendPropertyChanging();
					this._BatchId = value;
					this.SendPropertyChanged("BatchId");
					this.OnBatchIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="Date NOT NULL")]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Topic", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Topic
		{
			get
			{
				return this._Topic;
			}
			set
			{
				if ((this._Topic != value))
				{
					this.OnTopicChanging(value);
					this.SendPropertyChanging();
					this._Topic = value;
					this.SendPropertyChanged("Topic");
					this.OnTopicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Trainer", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Trainer
		{
			get
			{
				return this._Trainer;
			}
			set
			{
				if ((this._Trainer != value))
				{
					this.OnTrainerChanging(value);
					this.SendPropertyChanging();
					this._Trainer = value;
					this.SendPropertyChanged("Trainer");
					this.OnTrainerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TheoryHours", DbType="Int NOT NULL")]
		public int TheoryHours
		{
			get
			{
				return this._TheoryHours;
			}
			set
			{
				if ((this._TheoryHours != value))
				{
					this.OnTheoryHoursChanging(value);
					this.SendPropertyChanging();
					this._TheoryHours = value;
					this.SendPropertyChanged("TheoryHours");
					this.OnTheoryHoursChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PracticalHours", DbType="Int NOT NULL")]
		public int PracticalHours
		{
			get
			{
				return this._PracticalHours;
			}
			set
			{
				if ((this._PracticalHours != value))
				{
					this.OnPracticalHoursChanging(value);
					this.SendPropertyChanging();
					this._PracticalHours = value;
					this.SendPropertyChanged("PracticalHours");
					this.OnPracticalHoursChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Batch_NewEvent", Storage="_Batch", ThisKey="BatchId", OtherKey="BatchId", IsForeignKey=true)]
		public Batch Batch
		{
			get
			{
				return this._Batch.Entity;
			}
			set
			{
				Batch previousValue = this._Batch.Entity;
				if (((previousValue != value) 
							|| (this._Batch.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Batch.Entity = null;
						previousValue.NewEvents.Remove(this);
					}
					this._Batch.Entity = value;
					if ((value != null))
					{
						value.NewEvents.Add(this);
						this._BatchId = value.BatchId;
					}
					else
					{
						this._BatchId = default(int);
					}
					this.SendPropertyChanged("Batch");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EmployeeData")]
	public partial class EmployeeData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EmployeeId;
		
		private string _EmployeeName;
		
		private System.DateTime _DOJ;
		
		private string _Competency;
		
		private string _Designation;
		
		private EntityRef<EmployeeBatch> _EmployeeBatch;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmployeeIdChanging(int value);
    partial void OnEmployeeIdChanged();
    partial void OnEmployeeNameChanging(string value);
    partial void OnEmployeeNameChanged();
    partial void OnDOJChanging(System.DateTime value);
    partial void OnDOJChanged();
    partial void OnCompetencyChanging(string value);
    partial void OnCompetencyChanged();
    partial void OnDesignationChanging(string value);
    partial void OnDesignationChanged();
    #endregion
		
		public EmployeeData()
		{
			this._EmployeeBatch = default(EntityRef<EmployeeBatch>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int EmployeeId
		{
			get
			{
				return this._EmployeeId;
			}
			set
			{
				if ((this._EmployeeId != value))
				{
					this.OnEmployeeIdChanging(value);
					this.SendPropertyChanging();
					this._EmployeeId = value;
					this.SendPropertyChanged("EmployeeId");
					this.OnEmployeeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string EmployeeName
		{
			get
			{
				return this._EmployeeName;
			}
			set
			{
				if ((this._EmployeeName != value))
				{
					this.OnEmployeeNameChanging(value);
					this.SendPropertyChanging();
					this._EmployeeName = value;
					this.SendPropertyChanged("EmployeeName");
					this.OnEmployeeNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOJ", DbType="Date NOT NULL")]
		public System.DateTime DOJ
		{
			get
			{
				return this._DOJ;
			}
			set
			{
				if ((this._DOJ != value))
				{
					this.OnDOJChanging(value);
					this.SendPropertyChanging();
					this._DOJ = value;
					this.SendPropertyChanged("DOJ");
					this.OnDOJChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Competency", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Competency
		{
			get
			{
				return this._Competency;
			}
			set
			{
				if ((this._Competency != value))
				{
					this.OnCompetencyChanging(value);
					this.SendPropertyChanging();
					this._Competency = value;
					this.SendPropertyChanged("Competency");
					this.OnCompetencyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Designation", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Designation
		{
			get
			{
				return this._Designation;
			}
			set
			{
				if ((this._Designation != value))
				{
					this.OnDesignationChanging(value);
					this.SendPropertyChanging();
					this._Designation = value;
					this.SendPropertyChanged("Designation");
					this.OnDesignationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EmployeeData_EmployeeBatch", Storage="_EmployeeBatch", ThisKey="EmployeeId", OtherKey="EmployeeId", IsUnique=true, IsForeignKey=false)]
		public EmployeeBatch EmployeeBatch
		{
			get
			{
				return this._EmployeeBatch.Entity;
			}
			set
			{
				EmployeeBatch previousValue = this._EmployeeBatch.Entity;
				if (((previousValue != value) 
							|| (this._EmployeeBatch.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._EmployeeBatch.Entity = null;
						previousValue.EmployeeData = null;
					}
					this._EmployeeBatch.Entity = value;
					if ((value != null))
					{
						value.EmployeeData = this;
					}
					this.SendPropertyChanged("EmployeeBatch");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EmployeeBatch")]
	public partial class EmployeeBatch : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EmployeeId;
		
		private int _BatchId;
		
		private EntityRef<Batch> _Batch;
		
		private EntityRef<EmployeeData> _EmployeeData;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmployeeIdChanging(int value);
    partial void OnEmployeeIdChanged();
    partial void OnBatchIdChanging(int value);
    partial void OnBatchIdChanged();
    #endregion
		
		public EmployeeBatch()
		{
			this._Batch = default(EntityRef<Batch>);
			this._EmployeeData = default(EntityRef<EmployeeData>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int EmployeeId
		{
			get
			{
				return this._EmployeeId;
			}
			set
			{
				if ((this._EmployeeId != value))
				{
					if (this._EmployeeData.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEmployeeIdChanging(value);
					this.SendPropertyChanging();
					this._EmployeeId = value;
					this.SendPropertyChanged("EmployeeId");
					this.OnEmployeeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BatchId", DbType="Int NOT NULL")]
		public int BatchId
		{
			get
			{
				return this._BatchId;
			}
			set
			{
				if ((this._BatchId != value))
				{
					if (this._Batch.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBatchIdChanging(value);
					this.SendPropertyChanging();
					this._BatchId = value;
					this.SendPropertyChanged("BatchId");
					this.OnBatchIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Batch_EmployeeBatch", Storage="_Batch", ThisKey="BatchId", OtherKey="BatchId", IsForeignKey=true)]
		public Batch Batch
		{
			get
			{
				return this._Batch.Entity;
			}
			set
			{
				Batch previousValue = this._Batch.Entity;
				if (((previousValue != value) 
							|| (this._Batch.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Batch.Entity = null;
						previousValue.EmployeeBatches.Remove(this);
					}
					this._Batch.Entity = value;
					if ((value != null))
					{
						value.EmployeeBatches.Add(this);
						this._BatchId = value.BatchId;
					}
					else
					{
						this._BatchId = default(int);
					}
					this.SendPropertyChanged("Batch");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EmployeeData_EmployeeBatch", Storage="_EmployeeData", ThisKey="EmployeeId", OtherKey="EmployeeId", IsForeignKey=true)]
		public EmployeeData EmployeeData
		{
			get
			{
				return this._EmployeeData.Entity;
			}
			set
			{
				EmployeeData previousValue = this._EmployeeData.Entity;
				if (((previousValue != value) 
							|| (this._EmployeeData.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._EmployeeData.Entity = null;
						previousValue.EmployeeBatch = null;
					}
					this._EmployeeData.Entity = value;
					if ((value != null))
					{
						value.EmployeeBatch = this;
						this._EmployeeId = value.EmployeeId;
					}
					else
					{
						this._EmployeeId = default(int);
					}
					this.SendPropertyChanged("EmployeeData");
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
