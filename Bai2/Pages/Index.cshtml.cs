using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Pages
{
    public class IndexModel : PageModel
    {
        public int[][] Data { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
        public void OnGet(int m, int n)
        {
            if (m < 0 || n < 0) return;
            Row = m;
            Column = n;
            Data = new int[m][];
            Random r = new Random();
            for (int i = 0; i < m; i++)
            {
                Data[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    Data[i][j] = r.Next(100);
                }
            }
        }
    }
}
