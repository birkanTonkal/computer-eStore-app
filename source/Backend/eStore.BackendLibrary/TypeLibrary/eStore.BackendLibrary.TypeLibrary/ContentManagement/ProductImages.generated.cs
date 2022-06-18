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
	[DebuggerDisplay("ProductImageKey = {ProductImageKey}ProductKey = {ProductKey}")]
	public partial class 	ProductImages: BaseTypeLibrary
	{
		private Guid productImageKey;
		private Guid productKey;
		private byte[] image;

		[Key]
		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid ProductImageKey
		{
			[DebuggerStepThrough]
			get
			{
				return productImageKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (productImageKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				productImageKey = value;
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

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public byte[] Image
		{
			[DebuggerStepThrough]
			get
			{
				return image;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (image!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				image = value;
			}
		}

		public ProductImages ShallowCopy()
		{
			ProductImages obj = new ProductImages();
			obj.productImageKey = productImageKey;
			obj.productKey = productKey;
			obj.image = image;
			return obj;
		}
		
		public class PropertyIsimleri
		{
			public const string ProductImageKey = "ProductImageKey";
			public const string ProductKey = "ProductKey";
			public const string Image = "Image";
		}

	}
}
