using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppCarRoles.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]  
        [Required]
        public String Name { get; set; }

        [MaxLength(50)]
        public String Brand { get; set; }

        [MaxLength(50)]
        public String Color { get; set; }

    }
}