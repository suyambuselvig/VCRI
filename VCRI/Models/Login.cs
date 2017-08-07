using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace VCRI.Models
{
    public partial class Login
    {
        [Required]
        public string userid { get; set; }
        [Required]
        public string passwrd { get; set; }
        [Required]
        public string role { get; set; }
        [Required]
        public string username { get; set; }

    }
}