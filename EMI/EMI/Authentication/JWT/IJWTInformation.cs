namespace EMI.Authentication.JWT
{
    public interface IJWTInformation
    {
        string GetUserId();
        string GetTokenId();
        string GetEmail();
    }
}
