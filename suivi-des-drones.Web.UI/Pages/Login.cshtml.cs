using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using suivi_des_drones.Core.Interfaces.Repositories;
using suivi_des_drones.Core.Models;

namespace suivi_des_drones.Web.UI.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        #region Properties
        public AuthenticationUser User { get; set; }

        #endregion
        #region Fields
        private readonly IUserRepository repository;
        #endregion

        #region Constructors
        public LoginModel(IUserRepository repository)
        {
            this.repository = repository;
        }
        #endregion
        #region Public methods
        public IActionResult OnPost()
        {
            IActionResult result = this.Page();
            try
            {
                var user = this.repository.LogIn(this.User);
                if (user != null)
                {
                    this.HttpContext.Session.SetString("UserId", User.Login);

                    result = this.RedirectToPage("/Index");
                }

            }
            catch (Exception ex)
            {
            }


            return result;

        }
        #endregion

    }
}
