namespace PracticeProject.RequestModels
{
    public class UserCredential
    { 
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
    public class ViewMyLoginTable
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; } = null!;
        public string? UserName { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public DateTime? CreateDate { get; set; }

    }
}
