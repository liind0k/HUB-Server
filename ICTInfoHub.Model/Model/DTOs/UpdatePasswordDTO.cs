﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTInfoHub.Model.Model.DTOs
{
    public class UpdatePasswordDTO
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }

        public string Password { get; set; }
    }
}
