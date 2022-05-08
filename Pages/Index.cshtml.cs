using ChatApp.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp.Pages;

public class IndexModel : LoginModel
{


    public IndexModel(SignInManager<IdentityUser> signInManager, ILogger<IndexModel> logger) : base(signInManager, logger)
    {

    }
}
