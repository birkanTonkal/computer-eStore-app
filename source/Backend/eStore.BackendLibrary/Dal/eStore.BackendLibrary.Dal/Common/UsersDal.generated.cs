
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
using eStore.BackendLibrary.TypeLibrary.Common;


namespace eStore.BackendLibrary.Dal.Common
{
public partial class UsersDal : BaseDalSqlServer<Users, AdoTemplateSqlServer, ParameterBuilderSqlServer>
{
	
	public override string DatabaseName
	{
		get
		{
			return "Shop";
		}
	}
	protected override void setIdentityColumnValue(Users pTypeLibrary,long pIdentityKolonValue)
	{
	}
	protected override string SelectCountString
	{
		get
		{
			return @"SELECT COUNT(*) FROM COMMON.Users";
		}
	}
	protected override string SelectString
	{
		get 
		{
			return @"SELECT UsersKey,UserType,Email,Password FROM COMMON.Users";
		}
	}
	protected override string DeleteString
	{
		get 
		{
			return @"DELETE   FROM COMMON.Users WHERE UsersKey = @UsersKey ";
		}
	}
	protected override string UpdateString
	{
		get 
		{
			return @"UPDATE COMMON.Users
			 SET 
			UserType = @UserType
,Email = @Email
,Password = @Password
			
			WHERE 
			 UsersKey = @UsersKey
 ";
		}
	}
	protected override string InsertString
	{
		get 
		{
			return @"INSERT INTO COMMON.Users 
			 (UsersKey,UserType,Email,Password) 
			 VALUES 
						(@UsersKey,@UserType,@Email,@Password)";
		}
	}
	public Users QueryByUsersKey(Guid pUsersKey )
	{
		List<Users> liste = new List<Users>();
		ExecuteQuery(liste,String.Format(" UsersKey = '{0}'",pUsersKey));		
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
			return "UsersKey";
		}
	}
	
	public virtual void Delete(Guid UsersKey)
	{
		Users satir = new Users();
		satir.UsersKey = UsersKey;
		base.Delete(satir);
	}
	protected override void ProcessRow(IDataReader dr, Users satir)
	{
		satir.UsersKey = dr.GetGuid(0);
		satir.UserType = dr.GetString(1);
		if (!dr.IsDBNull(2))
		{
			satir.Email = dr.GetString(2);
		}
		if (!dr.IsDBNull(3))
		{
			satir.Password = dr.GetString(3);
		}
	}
	protected override void InsertCommandParametersAdd(DbCommand cmd, Users satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@UsersKey",SqlDbType.UniqueIdentifier, satir.UsersKey);
		builder.AddParameter("@UserType",SqlDbType.VarChar, satir.UserType,50);
		builder.AddParameter("@Email",SqlDbType.VarChar, satir.Email,50);
		builder.AddParameter("@Password",SqlDbType.VarChar, satir.Password,20);
	}
	protected override void UpdateCommandParametersAdd(DbCommand cmd, 	Users	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@UsersKey",SqlDbType.UniqueIdentifier, satir.UsersKey);
		builder.AddParameter("@UserType",SqlDbType.VarChar, satir.UserType,50);
		builder.AddParameter("@Email",SqlDbType.VarChar, satir.Email,50);
		builder.AddParameter("@Password",SqlDbType.VarChar, satir.Password,20);
	}
	protected override void DeleteCommandParametersAdd(DbCommand cmd, 	Users	 satir)
	{
		ParameterBuilderSqlServer builder = (ParameterBuilderSqlServer)Template.getParameterBuilder();
		builder.Command = cmd;
		builder.AddParameter("@UsersKey",SqlDbType.UniqueIdentifier, satir.UsersKey);
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
