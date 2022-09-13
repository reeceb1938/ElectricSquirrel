﻿using System.ComponentModel.DataAnnotations;

namespace AccessControl.Core.Commands
{
    public class Login
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
