﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36366
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoeSto.DAC
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="MoeSto")]
	public partial class DataAccessManagerDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertImage(Image instance);
    partial void UpdateImage(Image instance);
    partial void DeleteImage(Image instance);
    partial void InsertCompany(Company instance);
    partial void UpdateCompany(Company instance);
    partial void DeleteCompany(Company instance);
    #endregion
		
		public DataAccessManagerDataContext() : 
				base(global::MoeSto.DAC.Properties.Settings.Default.MoeStoConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessManagerDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessManagerDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessManagerDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAccessManagerDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Image> Images
		{
			get
			{
				return this.GetTable<Image>();
			}
		}
		
		public System.Data.Linq.Table<Company> Companies
		{
			get
			{
				return this.GetTable<Company>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Image")]
	public partial class Image : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CompanyId;
		
		private int _ImageId;
		
		private System.Data.Linq.Binary _ImagePresentation;
		
		private EntityRef<Company> _Company;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCompanyIdChanging(int value);
    partial void OnCompanyIdChanged();
    partial void OnImageIdChanging(int value);
    partial void OnImageIdChanged();
    partial void OnImagePresentationChanging(System.Data.Linq.Binary value);
    partial void OnImagePresentationChanged();
    #endregion
		
		public Image()
		{
			this._Company = default(EntityRef<Company>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompanyId", DbType="Int NOT NULL")]
		public int CompanyId
		{
			get
			{
				return this._CompanyId;
			}
			set
			{
				if ((this._CompanyId != value))
				{
					if (this._Company.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCompanyIdChanging(value);
					this.SendPropertyChanging();
					this._CompanyId = value;
					this.SendPropertyChanged("CompanyId");
					this.OnCompanyIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ImageId
		{
			get
			{
				return this._ImageId;
			}
			set
			{
				if ((this._ImageId != value))
				{
					this.OnImageIdChanging(value);
					this.SendPropertyChanging();
					this._ImageId = value;
					this.SendPropertyChanged("ImageId");
					this.OnImageIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImagePresentation", DbType="Image", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary ImagePresentation
		{
			get
			{
				return this._ImagePresentation;
			}
			set
			{
				if ((this._ImagePresentation != value))
				{
					this.OnImagePresentationChanging(value);
					this.SendPropertyChanging();
					this._ImagePresentation = value;
					this.SendPropertyChanged("ImagePresentation");
					this.OnImagePresentationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Company_Image", Storage="_Company", ThisKey="CompanyId", OtherKey="Id", IsForeignKey=true)]
		public Company Company
		{
			get
			{
				return this._Company.Entity;
			}
			set
			{
				Company previousValue = this._Company.Entity;
				if (((previousValue != value) 
							|| (this._Company.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Company.Entity = null;
						previousValue.Images.Remove(this);
					}
					this._Company.Entity = value;
					if ((value != null))
					{
						value.Images.Add(this);
						this._CompanyId = value.Id;
					}
					else
					{
						this._CompanyId = default(int);
					}
					this.SendPropertyChanged("Company");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Company")]
	public partial class Company : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _Address;
		
		private string _Email;
		
		private int _Unp;
		
		private string _Phones;
		
		private double _Latitude;
		
		private double _Longitude;
		
		private EntitySet<Image> _Images;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnUnpChanging(int value);
    partial void OnUnpChanged();
    partial void OnPhonesChanging(string value);
    partial void OnPhonesChanged();
    partial void OnLatitudeChanging(double value);
    partial void OnLatitudeChanged();
    partial void OnLongitudeChanging(double value);
    partial void OnLongitudeChanged();
    #endregion
		
		public Company()
		{
			this._Images = new EntitySet<Image>(new Action<Image>(this.attach_Images), new Action<Image>(this.detach_Images));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(MAX)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Unp", DbType="Int NOT NULL")]
		public int Unp
		{
			get
			{
				return this._Unp;
			}
			set
			{
				if ((this._Unp != value))
				{
					this.OnUnpChanging(value);
					this.SendPropertyChanging();
					this._Unp = value;
					this.SendPropertyChanged("Unp");
					this.OnUnpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phones", DbType="NVarChar(MAX)")]
		public string Phones
		{
			get
			{
				return this._Phones;
			}
			set
			{
				if ((this._Phones != value))
				{
					this.OnPhonesChanging(value);
					this.SendPropertyChanging();
					this._Phones = value;
					this.SendPropertyChanged("Phones");
					this.OnPhonesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Latitude", DbType="Float NOT NULL")]
		public double Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				if ((this._Latitude != value))
				{
					this.OnLatitudeChanging(value);
					this.SendPropertyChanging();
					this._Latitude = value;
					this.SendPropertyChanged("Latitude");
					this.OnLatitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Longitude", DbType="Float NOT NULL")]
		public double Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				if ((this._Longitude != value))
				{
					this.OnLongitudeChanging(value);
					this.SendPropertyChanging();
					this._Longitude = value;
					this.SendPropertyChanged("Longitude");
					this.OnLongitudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Company_Image", Storage="_Images", ThisKey="Id", OtherKey="CompanyId")]
		public EntitySet<Image> Images
		{
			get
			{
				return this._Images;
			}
			set
			{
				this._Images.Assign(value);
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
		
		private void attach_Images(Image entity)
		{
			this.SendPropertyChanging();
			entity.Company = this;
		}
		
		private void detach_Images(Image entity)
		{
			this.SendPropertyChanging();
			entity.Company = null;
		}
	}
}
#pragma warning restore 1591
