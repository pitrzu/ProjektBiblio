using NodaTime;
using WSB.Biblioteka.Contracts.Generics;

namespace WSB.Biblioteka.Contracts.Books.Queries;

public record GetBorrowedBooksQuery(Guid UserId) : IQuery<IReadOnlyCollection<BorrowedBookResponse>>;

public record BorrowedBookResponse(
    Guid Id,
    LocalDate BorrowingDate,
    string Title,
    string AuthorFirstName,
    string AuthorLastName,
    LocalDate ExpirationDate,
    LocalDate? ReturnDate,
    bool IsReturned);
