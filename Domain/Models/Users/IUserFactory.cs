namespace Domain.Models.Users
{
    public interface IUserFactory
    {
        User Create(string name);
    }
}