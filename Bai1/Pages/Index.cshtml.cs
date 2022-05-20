using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bai1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty, Required(ErrorMessage = "This question is required")]
        public string StudentID { get; set; }
        [BindProperty, Required(ErrorMessage = "This question is required")]
        public string Fullname { get; set; }
        [BindProperty, Required(ErrorMessage = "This question is required"), RegularExpression("K1[6789]", ErrorMessage = "This answer must have format 'K1#', # is from 6 to 9")]
        public string Grade { get; set; }
        [BindProperty, Required(ErrorMessage = "This question is required")]
        public string TeacherDocsAbility { get; set; }
        [BindProperty, Required(ErrorMessage = "This question is required"), MinLength(1, ErrorMessage = "You must to type the answer")]
        public string TeacherToolAbility { get; set; }
        [BindProperty, Required(ErrorMessage = "This question is required")]
        public string GeneralReview { get; set; }
        [BindProperty, Required(ErrorMessage = "This question is required")]
        public string StudentToolAbility { get; set; }
        [BindProperty]
        public string MainCons { get; set; }
        [BindProperty, Required(ErrorMessage = "This question is required")]
        public string ExamType { get; set; }
        [BindProperty]
        public string OtherOpinion { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("Success");
            }
            return Page();
        }
    }
}
