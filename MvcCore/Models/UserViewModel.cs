﻿using System;

namespace MvcCore.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string PasswordConfirm { get; set; }
        public DateTime created_at { get; set; }

    }
}
