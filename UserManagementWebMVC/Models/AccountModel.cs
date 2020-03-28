using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserManagementWebMVC.Models
{
    public class AccountModel
    {
        [Key]
        [Required]
        public string AccountID { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Roles { get; set; }
    }
}