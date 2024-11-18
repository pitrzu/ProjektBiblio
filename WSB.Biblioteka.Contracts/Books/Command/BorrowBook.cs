using NodaTime;
using WSB.Biblioteka.Contracts.Generics;

namespace WSB.Biblioteka.Contracts.Books.Command;

public record BorrowBook(Guid UserId, Guid BookId, LocalDate? BorrowingDate = null) : ICommand;
