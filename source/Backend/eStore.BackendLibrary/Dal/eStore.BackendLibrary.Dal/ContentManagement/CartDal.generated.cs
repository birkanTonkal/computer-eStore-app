
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
public partial class CartDal : BaseDalSqlServer<Cart, AdoTemplateSqlServer, ParameterBuilderSqlServer>
{
	
	public override string DatabaseName
	{
		get
		{
			return "Shop";
		}
	}
	protected override void setIdentityColumnValue(Cart pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM CONTENT_MANAGEMENT.Cart";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT UserKey,ProductKey FROM CONTENT_MANAGEMENT.Cart";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM CONTENT_MANAGEMENT.Cart WHERE UserKey = @UserKey ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE CONTENT_MANAGEMENT.Cart
			 SET 
			ProductKey = @ProductKey
			
			WHERE 
			 UserKey = @UserKey
 ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO CONTENT_MANAGEMENT.Cart 
			 (UserKey,ProductKey) 
			 VALUES 
						(@UserKey,@ProductKey)";
		}
	}
	public Cart QueryByUserKey(Guid pUserKey )
	{
		List<Cart> liste = new List<Cart>();
		ExecuteQuery(liste,String.Format(" UserKey = '{0}'",pUserKey));		
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
			return "UserKey";
		}
	}
	
	public virtual void Delete(Guid UserKey)
	{
		Cart satir = new Cart();
		satir.UserKey = UserKey;
		base.Delete(satir);
	}
	protected override void ProcessRow(IDataReader dr, Cart satir)
	{
		satir.UserKey = dr.GetGuid(0);
		satir.ProductKey = dr.GetGuid(1);
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Cart satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@UserKey",SqlDbType.UniqueIdentifier, satir.UserKey);
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Cart	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@UserKey",SqlDbType.UniqueIdentifier, satir.UserKey);
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Cart	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@UserKey",SqlDbType.UniqueIdentifier, satir.UserKey);
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
