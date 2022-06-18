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
	[MetadataType(typeof(ProductCommentsValidation))]
	public partial class 	ProductComments
	{
	}
	public class 	ProductCommentsValidation
	{
	}
}
