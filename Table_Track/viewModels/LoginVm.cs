﻿using System.ComponentModel.DataAnnotations;

namespace Table_Track.viewModels
{
    public class LoginVm
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }

    }
}
