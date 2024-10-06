using WSB.Biblioteka.Books;

namespace WSB.Biblioteka.Users;

public class Librarian : User
{
    public bool AddNewBook(Book book);
    public bool RemoveExistingBook(Book book);

    public bool Borrow(Guid bookId, User user);
    public bool Return(Book book);
}

