using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Threading.Tasks;

string clientId = "84c83927-0e76-4a28-9b32-6dbdbde0349c";
string tenantId = "4d904a7a-e0ea-4ac8-8f85-7ee4cbd5917f";
string authority = $"https://login.microsoftonline.com/{tenantId}";

var app = PublicClientApplicationBuilder.Create(clientId)
                .WithAuthority(authority)
                .WithRedirectUri("http://localhost:64657")
                .Build();

var scopes = new[] { "user.read" }; // Example scope to read user profile

AuthenticationResult result;
try
{
    var accounts = await app.GetAccountsAsync();
    result = await app.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
}
catch (MsalUiRequiredException)
{
    result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();
}

Console.WriteLine($"Hello {result.Account.Username}!");























//using System.DirectoryServices.AccountManagement;

//Console.WriteLine("Enter your username:");
//string username = Console.ReadLine();
//Console.WriteLine("Enter your password:");
//string password = Console.ReadLine();

//string domain = "MyUScom.onmicrosoft.com";

//using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain))
//{
//    // Validate the credentials
//    bool isValid = principalContext.ValidateCredentials(username, password);

//    if (isValid)
//    {
//        Console.WriteLine("You are authenticated!");
//    }
//    else
//    {
//        Console.WriteLine("Authentication failed. Please check your username and password.");
//    }
//}