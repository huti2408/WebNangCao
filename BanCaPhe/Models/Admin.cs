using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BanCaPhe.Models
{
    public class Admin
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}