namespace Notes.Models;

public class Note
{

    public Guid Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime CreatedDate { get; }
    public DateTime ModifiedDate { get; }

    public Note(Guid id, string title, string description, DateTime createdDate, DateTime modifiedDate)
    {
        Id = id;
        Title = title;
        Description = description;
        CreatedDate = createdDate;
        ModifiedDate = modifiedDate;
    }
}