﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MVC_Localization.Models
{
    public partial class Jobs
    {
        public Jobs()
        {
            Employee = new HashSet<Employee>();
        }

        public short JobId { get; set; }
        public string JobDesc { get; set; }
        public byte MinLvl { get; set; }
        public byte MaxLvl { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}