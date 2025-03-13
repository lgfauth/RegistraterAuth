using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegistraterAuthWeb.Pages;

public class AuthenticateModel : PageModel
{
    private readonly IApiAuthenticationService _apiService;

    public AuthenticateModel(IApiAuthenticationService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> OnPostAsync(string username, string password)
    {
        var response = await _apiService.AuthenticateUserAsync(username, password);

        if (response.IsSuccess)
        {
            ViewData["Token"] = response.Data.Token;
            ViewData["Expiration"] = response.Data.ExpiresAt;
        }
        else
            ViewData["Error"] = string.Format("Error code: {0} - {0}", response.Error.Code, response.Error.Message);

        return Page();
    }
}