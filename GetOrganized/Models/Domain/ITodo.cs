namespace GetOrganized.Models.Domain
{
    public interface ITodo
    {
        bool Completed { get; set; }
        int Id { get; set; }
        string Outcome { get; set; }
        string Title { get; set; }
        Topic Topic { get; set; }
    }
}