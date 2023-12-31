﻿using MVC_Localization.Resources;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MVC_Localization.Models
{
    internal class AuthorsMetadata
    {
        [Required(ErrorMessageResourceName = "AuthorNameEmpty",ErrorMessageResourceType =typeof(WebResource))]
        [Display(Name = "AuthorName",ResourceType =typeof(WebResource))]
        [StringLength(40)]
        public string AuLname { get; set; }


        [Display(Name ="Phone",ResourceType =typeof(WebResource))]
        public string Phone { get; set; }

    }
}