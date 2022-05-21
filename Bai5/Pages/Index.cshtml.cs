using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Bai5.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty, Required(ErrorMessage = "Email must not be blank."), RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessage = "Password format is not correct.")]
        public string Email { get; set; }
        [BindProperty, Required(ErrorMessage = "Password must not be blank.")]
        public string Password { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            SqlConnection connection = new SqlConnection("data source=.; database=administrative_management; integrated security=true");
            connection.Open();
            SqlCommand command = new SqlCommand("Select count(*) from account where email = @email and password = @password", connection);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@password", Password);
            SqlDataReader myReader = command.ExecuteReader();
            myReader.Read();

            if (myReader.GetInt32(0) == 1)
            {
                connection.Close();
                return RedirectToPage("Home");
            }
            else
            {
                connection.Close();
                ModelState.AddModelError(string.Empty, "The combine of email and password not match.");
                return Page();
            }
        }
    }
}
