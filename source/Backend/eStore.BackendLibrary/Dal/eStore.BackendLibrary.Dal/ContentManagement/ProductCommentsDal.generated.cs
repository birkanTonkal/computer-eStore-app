
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Karkas.Core.Data.SqlServer;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Example.TypeLibrary;
using Karkas.Example.TypeLibrary.ContentManagement;


namespace Karkas.Example.Dal.ContentManagement
{
public partial class ProductCommentsDal : BaseDalSqlServer<ProductComments, AdoTemplateSqlServer, ParameterBuilderSqlServer>
{
	
	public override string DatabaseName
	{
		get
		{
			return "SHOP";
		}
	}
	protected override void setIdentityColumnValue(ProductComments pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM CONTENT_MANAGEMENT.ProductComments";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT ProductCommentsKey,ProductKey,UsersKey,CommentTitle,CommentText,CommentDate FROM CONTENT_MANAGEMENT.ProductComments";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM CONTENT_MANAGEMENT.ProductComments WHERE ProductCommentsKey = @ProductCommentsKey ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE CONTENT_MANAGEMENT.ProductComments
			 SET 
			ProductKey = @ProductKey
,UsersKey = @UsersKey
,CommentTitle = @CommentTitle
,CommentText = @CommentText
,CommentDate = @CommentDate
			
			WHERE 
			 ProductCommentsKey = @ProductCommentsKey
 ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO CONTENT_MANAGEMENT.ProductComments 
			 (ProductCommentsKey,ProductKey,UsersKey,CommentTitle,CommentText,CommentDate) 
			 VALUES 
						(@ProductCommentsKey,@ProductKey,@UsersKey,@CommentTitle,@CommentText,@CommentDate)";
		}
	}
	public ProductComments QueryByProductCommentsKey(Guid pProductCommentsKey )
	{
		List<ProductComments> liste = new List<ProductComments>();
		ExecuteQuery(liste,String.Format(" ProductCommentsKey = '{0}'",pProductCommentsKey));		
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
			return "ProductCommentsKey";
		}
	}
	
	public virtual void Delete(Guid ProductCommentsKey)
	{
		ProductComments satir = new ProductComments();
		satir.ProductCommentsKey = ProductCommentsKey;
		base.Delete(satir);
	}
	protected override void ProcessRow(IDataReader dr, ProductComments satir)
	{
		satir.ProductCommentsKey = dr.GetGuid(0);
		satir.ProductKey = dr.GetGuid(1);
		satir.UsersKey = dr.GetGuid(2);
		if (!dr.IsDBNull(3))
		{
			satir.CommentTitle = dr.GetString(3);
		}
		if (!dr.IsDBNull(4))
		{
			satir.CommentText = dr.GetString(4);
		}
		satir.CommentDate = dr.GetDateTime(5);
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, ProductComments satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductCommentsKey",SqlDbType.UniqueIdentifier, satir.ProductCommentsKey);
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
		builder.AddParameter("@UsersKey",SqlDbType.UniqueIdentifier, satir.UsersKey);
		builder.AddParameter("@CommentTitle",SqlDbType.VarChar, satir.CommentTitle,100);
		builder.AddParameter("@CommentText",SqlDbType.VarChar, satir.CommentText,5000);
		builder.AddParameter("@CommentDate",SqlDbType.Date, satir.CommentDate);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	ProductComments	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductCommentsKey",SqlDbType.UniqueIdentifier, satir.ProductCommentsKey);
		builder.AddParameter("@ProductKey",SqlDbType.UniqueIdentifier, satir.ProductKey);
		builder.AddParameter("@UsersKey",SqlDbType.UniqueIdentifier, satir.UsersKey);
		builder.AddParameter("@CommentTitle",SqlDbType.VarChar, satir.CommentTitle,100);
		builder.AddParameter("@CommentText",SqlDbType.VarChar, satir.CommentText,5000);
		builder.AddParameter("@CommentDate",SqlDbType.Date, satir.CommentDate);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	ProductComments	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@ProductCommentsKey",SqlDbType.UniqueIdentifier, satir.ProductCommentsKey);
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
