using WSB.Biblioteka.Users;

namespace WSB.Biblioteka.Books;
public class Book
{
    public Guid Id { get; private set; }
    
    public string Iban { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }

    public User Author { get; private set; }   
}
