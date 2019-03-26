using System;
using System.ComponentModel.DataAnnotations;

namespace loginApp.Models {
    public class UserDTO {
        public string username { get; set; }

        public string password { get; set; }

        public string name { get; set; }
    }
}