using System;
using System.Collections.Generic;

namespace PracticeProject.Models
{
    public partial class MyLoginTable
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string? UserName { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public DateTime? CreateDate { get; set; }


    }
}
