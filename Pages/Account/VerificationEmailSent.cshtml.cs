using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Pages.Account;

public class VerificationEmailSentModel : PageModel
{
  private readonly ILogger<VerificationEmailSentModel> _logger;

  public VerificationEmailSentModel(ILogger<VerificationEmailSentModel> logger)
  {
    _logger = logger;
  }

  public void OnGet()
  {

  }
}
