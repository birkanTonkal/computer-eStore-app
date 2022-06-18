
using System;
using System.Collections.Generic;
using System.Data;
using Karkas.Core.Data.SqlServer;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using eStore.BackendLibrary.TypeLibrary;
using eStore.BackendLibrary.TypeLibrary.Common;
using eStore.BackendLibrary.Dal.Common;


namespace eStore.BackendLibrary.Bs.Common
{
	public partial class UsersBs : BaseBs<Users, UsersDal,  AdoTemplateSqlServer,ParameterBuilderSqlServer>
	{
	public override string DatabaseName
	{
		get
		{
			return "Shop";
		}
	}
	public void Delete(Guid pUsersKey)
	{
		dal.Delete( pUsersKey);
	}
	public Users QueryByUsersKey(Guid pUsersKey)
	{
		return dal.QueryByUsersKey(pUsersKey);
	}
}
}
