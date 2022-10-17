namespace Domain.ValueObjects;

public class UserAccount
{
    public string Email { get; init; } = default!;
    public string Phone { get; init; } = default!;
    public string Name { get; init; } = default!;
    public string Surname { get; init; } = default!;

    private bool Equals(UserAccount other)
    {
        return Email == other.Email && Phone == other.Phone && Name == other.Name && Surname == other.Surname;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        return obj.GetType() == GetType() && Equals((UserAccount) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, Phone, Name, Surname);
    }
}