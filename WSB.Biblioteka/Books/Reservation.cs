namespace WSB.Biblioteka.Books
{
    public class Reservation
    { 
        public Guid Id { get; private set; }
        public Book Book { get; private set; }
        public Guid UserId { get; private set; }

        public DateTimeOffset ReservationStart { get; private set; }
        public DateTimeOffset ReservationEnd { get; private set; }
    }
}
