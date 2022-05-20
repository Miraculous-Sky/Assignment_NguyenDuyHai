using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai4.Pages
{
    public class IndexModel : PageModel
    {
        public int[] Augends { get; set; }
        public int[] Addends { get; set; }
        public int[] Answers { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int n)
        {
            Augends = new int[n];
            Addends = new int[n];
            Answers = new int[n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                Augends[i] = r.Next(100);
                Addends[i] = r.Next(100);
            }
        }

        public IActionResult OnPost(int[] Augends, int[] Addends, int[] Answers)
        {
            ResultModel.Augends = Augends;
            ResultModel.Addends = Addends;
            ResultModel.Answers = Answers;
            return RedirectToPage("Result");
        }
    }
}
