namespace Proxy.Domain.User
{
    public class User(string username, int clearanceLevel)
    {
        public string Username { get; set; } = username;
        public int ClearanceLevel { get; set; } = clearanceLevel;
    }
}