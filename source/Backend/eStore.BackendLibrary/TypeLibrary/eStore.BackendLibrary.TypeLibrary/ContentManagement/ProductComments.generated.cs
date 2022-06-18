using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Collections.Generic;
using Karkas.Core.TypeLibrary;
using System.ComponentModel.DataAnnotations;

namespace Karkas.Example.TypeLibrary.ContentManagement
{
	[Serializable]
	[DebuggerDisplay("ProductCommentsKey = {ProductCommentsKey}ProductKey = {ProductKey}UsersKey = {UsersKey}")]
	public partial class 	ProductComments: BaseTypeLibrary
	{
		private Guid productCommentsKey;
		private Guid productKey;
		private Guid usersKey;
		private string commentTitle;
		private string commentText;
		private DateTime commentDate;

		[Key]
		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Guid ProductCommentsKey
		{
			[DebuggerStepThrough]
			get
			{
				return productCommentsKey;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (productCommentsKey!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				productCommentsKey = value;
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

		[StringLength(100)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string CommentTitle
		{
			[DebuggerStepThrough]
			get
			{
				return commentTitle;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (commentTitle!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				commentTitle = value;
			}
		}

		[StringLength(5000)]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string CommentText
		{
			[DebuggerStepThrough]
			get
			{
				return commentText;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (commentText!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				commentText = value;
			}
		}

		[Required]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime CommentDate
		{
			[DebuggerStepThrough]
			get
			{
				return commentDate;
			}
			[DebuggerStepThrough]
			set
			{
				if ((this.RowState == DataRowState.Unchanged) && (commentDate!= value))
				{
					this.RowState = DataRowState.Modified;
				}
				commentDate = value;
			}
		}

		public ProductComments ShallowCopy()
		{
			ProductComments obj = new ProductComments();
			obj.productCommentsKey = productCommentsKey;
			obj.productKey = productKey;
			obj.usersKey = usersKey;
			obj.commentTitle = commentTitle;
			obj.commentText = commentText;
			obj.commentDate = commentDate;
			return obj;
		}
		
		public class PropertyIsimleri
		{
			public const string ProductCommentsKey = "ProductCommentsKey";
			public const string ProductKey = "ProductKey";
			public const string UsersKey = "UsersKey";
			public const string CommentTitle = "CommentTitle";
			public const string CommentText = "CommentText";
			public const string CommentDate = "CommentDate";
		}

	}
}
