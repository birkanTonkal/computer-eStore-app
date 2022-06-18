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
	[DebuggerDisplay("ProductKey = {ProductKey}")]
	public partial class 	Product: BaseTypeLibrary
	{
		private Guid productKey;
		private string title;
		private int price;
		private string type;
		private Nullable<DateTime> dateCreated;
		private string graphicCard;
		private string cpu;
		private string ram;
		private string otherFeatures;
		private int stock;

		[Key]
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

		[StringLength(500)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Title
		{
			[DebuggerStepThrough]
			get
			{
				return title;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (title!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				title = value;
			}
		}

		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Price
		{
			[DebuggerStepThrough]
			get
			{
				return price;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (price!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				price = value;
			}
		}

		[StringLength(50)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Type
		{
			[DebuggerStepThrough]
			get
			{
				return type;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (type!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				type = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Nullable<DateTime> DateCreated
		{
			[DebuggerStepThrough]
			get
			{
				return dateCreated;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (dateCreated!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				dateCreated = value;
			}
		}

		[StringLength(50)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string GraphicCard
		{
			[DebuggerStepThrough]
			get
			{
				return graphicCard;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (graphicCard!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				graphicCard = value;
			}
		}

		[StringLength(50)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Cpu
		{
			[DebuggerStepThrough]
			get
			{
				return cpu;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (cpu!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				cpu = value;
			}
		}

		[StringLength(50)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string Ram
		{
			[DebuggerStepThrough]
			get
			{
				return ram;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (ram!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				ram = value;
			}
		}

		[StringLength(5000)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string OtherFeatures
		{
			[DebuggerStepThrough]
			get
			{
				return otherFeatures;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (otherFeatures!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				otherFeatures = value;
			}
		}

		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int Stock
		{
			[DebuggerStepThrough]
			get
			{
				return stock;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (stock!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				stock = value;
			}
		}

		public Product ShallowCopy()
		{
			Product obj = new Product();
			obj.productKey = productKey;
			obj.title = title;
			obj.price = price;
			obj.type = type;
			obj.dateCreated = dateCreated;
			obj.graphicCard = graphicCard;
			obj.cpu = cpu;
			obj.ram = ram;
			obj.otherFeatures = otherFeatures;
			obj.stock = stock;
			return obj;
		}
		
		public class PropertyIsimleri
		{
			public const string ProductKey = "ProductKey";
			public const string Title = "Title";
			public const string Price = "Price";
			public const string Type = "Type";
			public const string DateCreated = "DateCreated";
			public const string GraphicCard = "GraphicCard";
			public const string Cpu = "Cpu";
			public const string Ram = "Ram";
			public const string OtherFeatures = "OtherFeatures";
			public const string Stock = "Stock";
		}

	}
}
