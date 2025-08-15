namespace ICTInfoHub.Model.Model
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool IsDepartment { get; set; }
        public string Category { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public string? DocLocation { get; set; }

        
    }
    public enum Priority{
        urgent,
        moderate,
        low
    }
}
