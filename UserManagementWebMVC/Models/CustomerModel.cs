using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UserManagementWebMVC.Models
{
    public class CustomerModel
    {
        [Key]
        public string UserID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Enter Birthdate")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter EmailID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public string Gender { get; set; }
        public List<CustomerModel> ShowallCustomer { get; set; }
    }
}