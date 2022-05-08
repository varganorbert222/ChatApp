using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Pages.Chat;

[Authorize]
public class MessagesModel : PageModel
{
    private readonly ILogger<MessagesModel> _logger;

    public MessagesModel(ILogger<MessagesModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}
