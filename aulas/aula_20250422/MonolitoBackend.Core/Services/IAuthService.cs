namespace MonolitoBackend.Core.Services;

public interface IAuthService
{
    public Task<string?> AuthenticateAsync(string userName, string password);
}
