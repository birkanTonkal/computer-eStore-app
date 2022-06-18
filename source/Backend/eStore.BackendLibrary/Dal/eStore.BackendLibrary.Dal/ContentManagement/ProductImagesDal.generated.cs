
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Karkas.Core.Data.SqlServer;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using eStore.BackendLibrary.TypeLibrary;
using eStore.BackendLibrary.TypeLibrary.ContentManagement;


namespace eStore.BackendLibrary.Dal.ContentManagement
{
public partial class ProductImagesDal : BaseDalSqlServer<ProductImages, AdoTemplateSqlServer, ParameterBuilderSqlServer>
{
	
	public override string DatabaseName
	{
		get
		{
			return "Shop";
		}
	}
	protected override void setIdentityColumnValue(ProductImages pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM CONTENT_MANAGEMENT.ProductImages";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT ProductImageKey,ProductKey,Image FROM CONTENT_MANAGEMENT.ProductImages";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM CONTENT_MANAGEMENT.ProductImages WHERE ProductImageKey = @ProductImageKey ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE CONTENT_MANAGEMENT.ProductImages
			 SET 
			ProductKey = @ProductKey
,Image = @Image
			
			WHERE 
			 ProductImageKey = @ProductImageKey
 ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO CONTENT_MANAGEMENT.ProductImages 
			 (ProductImageKey,ProductKey,Image) 
			 VALUES 
						(@ProductImageKey,@ProductKey,@Image)";
		}
	}
	public ProductImages QueryByProductImageKey(Guid pProductImageKey )
	{
		List<ProductImages> liste = new List<ProductImages>();
		ExecuteQuery(liste,String.Format(" ProductImageKey = '{0}'",pProductImageKey));		
		if (liste.Count > 0)
		{
			return liste[0];
		}
		else
		{
			return null;
		}
	}
	
	protected override bool IdentityExists
	{
		get
		{
			return false;
		}
	}
	
	protected override bool IsPkGuid
	{
		get
		{
			return true;
		}
	}
	
	
	public override string PrimaryKey
	{
		get
		{
			return "ProductImageKey";
		}
	}
	
	public virtual void Delete(Guid ProductImageKey)
	{
		ProductImages satir = new ProductImages();
		satir.ProductImageKey = ProductImageKey;
		base.Delete(satir);
	}
	protected override void ProcessRow(IDataReader dr, ProductImages satir)
	{
		satir.ProductImageKey = dr.GetGuid(0);
		satir.ProductKey = dr.GetGuid(1);
		if (!dr.IsDBNull(2))
		{
			satir.Image = (Byte[])dr.GetValue(2);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, ProductImages satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductImageKey",SqlDbType.UniqueIdentifier, satir.ProductImageKey);
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
		builder.AddParameter("@Image",SqlDbType.Image, satir.Image);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	ProductImages	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductImageKey",SqlDbType.UniqueIdentifier, satir.ProductImageKey);
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
		builder.AddParameter("@Image",SqlDbType.Image, satir.Image);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	ProductImages	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductImageKey",SqlDbType.UniqueIdentifier, satir.ProductImageKey);
	}
	public override string DbProviderName
	{
		get
		{
			return "";
		}
	}
}
}
