﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace VCRI.Models
{
    public partial class ULogin
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SNo { get; set; }

        [Required]
        [Display(Name = "Login Name")]
        public string user_ID { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string user_Name { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string user_Pwd { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string role { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}