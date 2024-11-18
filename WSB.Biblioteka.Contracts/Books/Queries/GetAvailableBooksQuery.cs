using WSB.Biblioteka.Contracts.Generics;

namespace WSB.Biblioteka.Contracts.Books.Queries;

public class GetAvailableBooksQuery : IQuery<IReadOnlyCollection<AvailableBookResponse>>;

public record AvailableBookResponse
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author_FirstName { get; private set; }
    public string Author_LastName { get; private set; }
    
    public int AvailableCount { get; private set; }
}
