namespace WSB.Biblioteka.Books;

public class Borrowing : Reservation
{
    public Borrowing()
    {
    }

    public DateTimeOffset BorrowingStart { get; private set; }
    public DateTimeOffset BorrowedUntil { get; private set; }   
    public DateTimeOffset? BorrowingEnd {  get; private set;}
}
