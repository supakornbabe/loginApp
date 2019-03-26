using System;
using System.ComponentModel.DataAnnotations;

namespace loginApp.Models {
    public class UserModel {
        [Required]
        [Key]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string name { get; set; }
    }
}