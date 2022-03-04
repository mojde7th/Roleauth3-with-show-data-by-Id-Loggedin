namespace Roleauth3.services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}