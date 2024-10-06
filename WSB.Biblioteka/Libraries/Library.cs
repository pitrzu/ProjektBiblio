using WSB.Biblioteka.BookCollections;
using WSB.Biblioteka.Users;

namespace WSB.Biblioteka.Libraries;

public class Library
{
    public Guid Id { get; private set; }
    public Librarian? CurrentLibrarian { get; private set; }
    public BookCollection BookCollection { get; private set; }


    public void Open(Librarian librarian);
    public void Close();
}
