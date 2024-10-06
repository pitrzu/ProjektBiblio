namespace WSB.Biblioteka.Users;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } 
    public string Login { get; private set; }   
    public string Password { get; private set; } 
}
