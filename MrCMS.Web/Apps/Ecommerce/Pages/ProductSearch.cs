﻿using System.ComponentModel;
using MrCMS.Entities.Documents.Web;

namespace MrCMS.Web.Apps.Ecommerce.Pages
{
    public class ProductSearch : Webpage, IUniquePage
    {
        [DisplayName("Page Size")]
        public virtual int PageSize { get; set; }
    }
}