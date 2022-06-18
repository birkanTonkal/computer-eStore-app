
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
public partial class ProductDal : BaseDalSqlServer<Product, AdoTemplateSqlServer, ParameterBuilderSqlServer>
{
	
	public override string DatabaseName
	{
		get
		{
			return "Shop";
		}
	}
	protected override void setIdentityColumnValue(Product pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM CONTENT_MANAGEMENT.Product";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT ProductKey,Title,Price,Type,DateCreated,GraphicCard,Cpu,Ram,OtherFeatures,Stock FROM CONTENT_MANAGEMENT.Product";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM CONTENT_MANAGEMENT.Product WHERE ProductKey = @ProductKey ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE CONTENT_MANAGEMENT.Product
			 SET 
			Title = @Title
,Price = @Price
,Type = @Type
,DateCreated = @DateCreated
,GraphicCard = @GraphicCard
,Cpu = @Cpu
,Ram = @Ram
,OtherFeatures = @OtherFeatures
,Stock = @Stock
			
			WHERE 
			 ProductKey = @ProductKey
 ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO CONTENT_MANAGEMENT.Product 
			 (ProductKey,Title,Price,Type,DateCreated,GraphicCard,Cpu,Ram,OtherFeatures,Stock) 
			 VALUES 
						(@ProductKey,@Title,@Price,@Type,@DateCreated,@GraphicCard,@Cpu,@Ram,@OtherFeatures,@Stock)";
		}
	}
	public Product QueryByProductKey(Guid pProductKey )
	{
		List<Product> liste = new List<Product>();
		ExecuteQuery(liste,String.Format(" ProductKey = '{0}'",pProductKey));		
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
			return "ProductKey";
		}
	}
	
	public virtual void Delete(Guid ProductKey)
	{
		Product satir = new Product();
		satir.ProductKey = ProductKey;
		base.Delete(satir);
	}
	protected override void ProcessRow(IDataReader dr, Product satir)
	{
		satir.ProductKey = dr.GetGuid(0);
		if (!dr.IsDBNull(1))
		{
			satir.Title = dr.GetString(1);
		}
		satir.Price = dr.GetInt32(2);
		if (!dr.IsDBNull(3))
		{
			satir.Type = dr.GetString(3);
		}
		if (!dr.IsDBNull(4))
		{
			satir.DateCreated = dr.GetDateTime(4);
		}
		if (!dr.IsDBNull(5))
		{
			satir.GraphicCard = dr.GetString(5);
		}
		if (!dr.IsDBNull(6))
		{
			satir.Cpu = dr.GetString(6);
		}
		if (!dr.IsDBNull(7))
		{
			satir.Ram = dr.GetString(7);
		}
		if (!dr.IsDBNull(8))
		{
			satir.OtherFeatures = dr.GetString(8);
		}
		satir.Stock = dr.GetInt32(9);
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Product satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
		builder.AddParameter("@Title",SqlDbType.VarChar, satir.Title,500);
		builder.AddParameter("@Price",SqlDbType.Int, satir.Price);
		builder.AddParameter("@Type",SqlDbType.VarChar, satir.Type,50);
		builder.AddParameter("@DateCreated",SqlDbType.Date, satir.DateCreated);
		builder.AddParameter("@GraphicCard",SqlDbType.VarChar, satir.GraphicCard,50);
		builder.AddParameter("@Cpu",SqlDbType.VarChar, satir.Cpu,50);
		builder.AddParameter("@Ram",SqlDbType.VarChar, satir.Ram,50);
		builder.AddParameter("@OtherFeatures",SqlDbType.VarChar, satir.OtherFeatures,5000);
		builder.AddParameter("@Stock",SqlDbType.Int, satir.Stock);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Product	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
		builder.AddParameter("@Title",SqlDbType.VarChar, satir.Title,500);
		builder.AddParameter("@Price",SqlDbType.Int, satir.Price);
		builder.AddParameter("@Type",SqlDbType.VarChar, satir.Type,50);
		builder.AddParameter("@DateCreated",SqlDbType.Date, satir.DateCreated);
		builder.AddParameter("@GraphicCard",SqlDbType.VarChar, satir.GraphicCard,50);
		builder.AddParameter("@Cpu",SqlDbType.VarChar, satir.Cpu,50);
		builder.AddParameter("@Ram",SqlDbType.VarChar, satir.Ram,50);
		builder.AddParameter("@OtherFeatures",SqlDbType.VarChar, satir.OtherFeatures,5000);
		builder.AddParameter("@Stock",SqlDbType.Int, satir.Stock);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Product	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
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
