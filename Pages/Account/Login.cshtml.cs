using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RepositorioTCC.Pages.Account
{
    public class LoginModel : PageModel {
        [BindProperty]
        public Credential Credential { get; set; }

        public void OnGet(){
            this.Credential = new Credential {UserName = "admin"};
            
        }

        public void OnPost(){

        }
    }

    public class Credential {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}