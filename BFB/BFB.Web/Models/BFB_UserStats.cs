﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BFB.Web.Models
{
    public class BFB_UserStats
    {
        [Key]
        public int UserStatId { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public int GamesPlayed { get; set; }
        public Boolean IsActive { get; set; }
        public string InsertedOn { get; set; }
        public string InsertedBy { get; set; }
        public string UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
