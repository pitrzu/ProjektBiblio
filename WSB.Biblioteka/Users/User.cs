namespace WSB.Biblioteka.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string PasswordHash { get; private set; }

        private User(Guid id, string name, string login, string passwordHash)
        {
            Id = id;
            Name = name;
            Login = login;
            PasswordHash = passwordHash;
        }

        public static User Register(string name, string login, string password)
        {
            ValidateInput(name, nameof(name));
            ValidateInput(login, nameof(login));
            ValidatePassword(password);

            var passwordHash = HashPassword(password);
            return new User(Guid.NewGuid(), name, login, passwordHash);
        }

        private static void ValidateInput(string input, string paramName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(paramName, $"{paramName} nie może być puste.");
        }

        private static void ValidatePassword(string password)
        {
            if (password.Length < 6)
                throw new ArgumentException("Hasło musi mieć co najmniej 6 znaków.", nameof(password));
        }

        private static string HashPassword(string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256())
            {
                var salt = Guid.NewGuid().ToByteArray();
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password + Convert.ToBase64String(salt)));
                return Convert.ToBase64String(hash) + ":" + Convert.ToBase64String(salt);
            }
        }

        public override string ToString()
        {
            return $"User: {Name} (Login: {Login}, Id: {Id})";
        }
    }
}
