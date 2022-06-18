
using System;
using System.Collections.Generic;
using System.Data;
using Karkas.Core.Data.SqlServer;
using System.Data.SqlClient;
using System.Text;
using Karkas.Core.DataUtil;
using Karkas.Core.DataUtil.BaseClasses;
using eStore.BackendLibrary.TypeLibrary;
using eStore.BackendLibrary.TypeLibrary.ContentManagement;
using eStore.BackendLibrary.Dal.ContentManagement;


namespace eStore.BackendLibrary.Bs.ContentManagement
{
public partial class CartBs : BaseBs<Cart, CartDal,  AdoTemplateSqlServer,ParameterBuilderSqlServer>
{
}
}
