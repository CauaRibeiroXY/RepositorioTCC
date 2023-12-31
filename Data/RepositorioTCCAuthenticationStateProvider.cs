using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using RepositorioTCC.Data;

public class RepositorioTCCAuthenticationStateProvider : AuthenticationStateProvider, IDisposable {

    private readonly UserServices userService;

    public RepositorioTCCAuthenticationStateProvider(UserServices userService)
    {
        this.userService = userService;
        AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
    }
    
    public User CurrentUser { get; private set;} = new();

    public async Task LoginAsync (string email, string senha) 
    {
        var principal = new ClaimsPrincipal();
        var user = await userService.Login(email, senha);

        if ( user is not null){
            await userService.PersistUserToBrowserAsync(user);
            principal = user.ToClaimsPrincipal();
        }

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public async Task LogoutAsync()
    {
        await userService.ClearBrowserUserDataAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ())));
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var principal = new ClaimsPrincipal();
        var user = await userService.FetchUserFromBrowserAsync();

        if (user is not null)
        {
            var userInDatabase = await userService.Login(user.Email, user.Senha);

            if ( userInDatabase is not null){
                principal= userInDatabase.ToClaimsPrincipal();
                CurrentUser = userInDatabase;
            }
        }

        return new(principal);
    }

    public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;

    private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
    {
        var authenticationState = await task;
        if (authenticationState is not null)
        {
            CurrentUser = User.FromClaimsPrincipal(authenticationState.User);
        }
    }
}