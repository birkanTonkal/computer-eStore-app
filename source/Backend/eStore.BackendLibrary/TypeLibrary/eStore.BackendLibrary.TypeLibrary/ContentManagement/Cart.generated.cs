using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using System.ComponentModel.DataAnnotations;

namespace eStore.BackendLibrary.TypeLibrary.ContentManagement
{
	[Serializable]
	[DebuggerDisplay("UserKey = {UserKey}ProductKey = {ProductKey}")]
	public partial class 	Cart: BaseTypeLibrary
	{
		private Guid userKey;
		private Guid productKey;

		[Key]
		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid UserKey
		{
			[DebuggerStepThrough]
			get
			{
				return userKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (userKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				userKey = value;
			}
		}

		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid ProductKey
		{
			[DebuggerStepThrough]
			get
			{
				return productKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (productKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				productKey = value;
			}
		}

		public Cart ShallowCopy()
		{
			Cart obj = new Cart();
			obj.userKey = userKey;
			obj.productKey = productKey;
			return obj;
		}
		
		public class PropertyIsimleri
		{
			public const string UserKey = "UserKey";
			public const string ProductKey = "ProductKey";
		}

	}
}
