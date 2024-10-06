using WSB.Biblioteka.Books;

namespace WSB.Biblioteka.Users;

public class Reader : User
{
    public ReadersCard Card { get; private set; }

    public IReadOnlyCollection<Reservation> Reservations { get; private set; }
    public IReadOnlyCollection<Borrowing> CurrentlyBorrowed { get; private set; }
}


public class ReadersCard
{

}