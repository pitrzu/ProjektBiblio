using WSB.Biblioteka.Books;
using WSB.Biblioteka.Users;

namespace WSB.Biblioteka.BookCollections;
public class BookCollection
{
    public bool IsBookAvailable(Guid bookId);

    public Reservation ReserveBook(Guid bookId, User reserver);
    public bool ReleaseBookReservation(Guid bookId);

    public IReadOnlyCollection<BookAvailability> Books { get; private set; }
}
