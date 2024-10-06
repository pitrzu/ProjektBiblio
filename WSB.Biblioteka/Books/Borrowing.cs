namespace WSB.Biblioteka.Books;

public class Borrowing : Reservation
{
    public Borrowing()
    {
    }

    public bool IsReturned { get; private set; }
    public DateTimeOffset BorrowingStart { get; private set; }
    public DateTimeOffset BorrowedUntil { get; private set; }   
    public DateTimeOffset? BorrowingEnd {  get; private set; }
}
