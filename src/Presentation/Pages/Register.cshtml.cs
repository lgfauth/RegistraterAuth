using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegistraterAuthWeb.Pages;

public class RegisterModel : PageModel
{
    private readonly IApiSubscriptionService _apiService;

    public RegisterModel(IApiSubscriptionService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> OnPostAsync(string Username, string Password, string Email, string Name, string LastName)
    {
        var request = new SubscriptionRequest
        {
            Username = Username,
            Password = Password,
            Email = Email,
            Name = Name,
            LastName = LastName
        };

        var response = await _apiService.RegisterUserAsync(request);

        if (response.IsSuccess)
            ViewData["Message"] = response.Data.Message;
        else
            ViewData["Error"] = string.Format("Error code: {0} - {0}", response.Error.Code, response.Error.Message);

        return Page();
    }
}