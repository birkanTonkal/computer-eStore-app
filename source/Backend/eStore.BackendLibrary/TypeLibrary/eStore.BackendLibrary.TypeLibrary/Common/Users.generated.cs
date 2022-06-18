using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using System.ComponentModel.DataAnnotations;

namespace eStore.BackendLibrary.TypeLibrary.Common
{
	[Serializable]
	[DebuggerDisplay("UsersKey = {UsersKey}")]
	public partial class 	Users: BaseTypeLibrary
	{
		private Guid usersKey;
		private string userType;
		private string email;
		private string password;

		[Key]
		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid UsersKey
		{
			[DebuggerStepThrough]
			get
			{
				return usersKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (usersKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				usersKey = value;
			}
		}

		[StringLength(50)]
		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string UserType
		{
			[DebuggerStepThrough]
			get
			{
				return userType;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (userType!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				userType = value;
			}
		}

		[StringLength(50)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Email
		{
			[DebuggerStepThrough]
			get
			{
				return email;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (email!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				email = value;
			}
		}

		[StringLength(20)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Password
		{
			[DebuggerStepThrough]
			get
			{
				return password;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (password!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				password = value;
			}
		}

		public Users ShallowCopy()
		{
			Users obj = new Users();
			obj.usersKey = usersKey;
			obj.userType = userType;
			obj.email = email;
			obj.password = password;
			return obj;
		}
		
		public class PropertyIsimleri
		{
			public const string UsersKey = "UsersKey";
			public const string UserType = "UserType";
			public const string Email = "Email";
			public const string Password = "Password";
		}

	}
}
