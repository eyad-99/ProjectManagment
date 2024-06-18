namespace ProjectManagment.service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}
