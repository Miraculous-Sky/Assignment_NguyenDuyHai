using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bai4.Pages
{
    public class ResultModel : PageModel
    {
        public static int[] Augends { get; set; }
        public static int[] Addends { get; set; }
        public static int[] Answers { get; set; }
        public static bool[] Result { get; set; }
        public void OnGet()
        {
            Result = new bool[Answers.Length];
            for (int i = 0; i < Answers.Length; i++)
            {
                Result[i] = Augends[i] + Addends[i] == Answers[i];
            }
        }
    }
}
