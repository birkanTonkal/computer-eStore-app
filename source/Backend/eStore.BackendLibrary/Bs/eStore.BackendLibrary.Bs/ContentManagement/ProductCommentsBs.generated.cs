
using System;
using System.Collections.Generic;
using System.Data;
using Karkas.Core.Data.SqlServer;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using Karkas.Example.TypeLibrary;
using Karkas.Example.TypeLibrary.ContentManagement;
using Karkas.Example.Dal.ContentManagement;


namespace Karkas.Example.Bs.ContentManagement
{
	public partial class ProductCommentsBs : BaseBs<ProductComments, ProductCommentsDal,  AdoTemplateSqlServer,ParameterBuilderSqlServer>
	{
	public override string DatabaseName
	{
		get
		{
			return "SHOP";
		}
	}
	public void Delete(Guid pProductCommentsKey)
	{
		dal.Delete( pProductCommentsKey);
	}
	public ProductComments QueryByProductCommentsKey(Guid pProductCommentsKey)
	{
		return dal.QueryByProductCommentsKey(pProductCommentsKey);
	}
}
}
