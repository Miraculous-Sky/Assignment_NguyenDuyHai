using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlClient;


namespace Bai5.Pages
{
    public class TaoPhieuNghiModel : PageModel
    {
        [BindProperty, DisplayName("Tên nhân viên")]
        public string Name { get; set; }
        [BindProperty, DisplayName("Phòng ban")]
        public string Department { get; set; }
        [BindProperty, DisplayName("Tổng số ngày")]
        public int TotalDate { get; set; }
        [BindProperty, DisplayName("Từ ngày")]
        public string FromDate { get; set; }
        [BindProperty, DisplayName("Đến ngày")]
        public string ToDate { get; set; }
        [BindProperty, DisplayName("Ghi chú")]
        public string Note { get; set; }
        public List<TaoPhieuNghiModel> AbsenabsenceLetters;
        public void LoadData()
        {
            SqlConnection connection = new SqlConnection("data source=.; database=administrative_management; integrated security=true");
            connection.Open();
            SqlCommand command = new SqlCommand("Select * from absence_letter", connection);
            SqlDataReader myReader = command.ExecuteReader();
            AbsenabsenceLetters = new List<TaoPhieuNghiModel>();
            TaoPhieuNghiModel absenabsenceLetter;
            while (myReader.Read())
            {
                absenabsenceLetter = new TaoPhieuNghiModel();
                absenabsenceLetter.Name = myReader.GetString(0);
                absenabsenceLetter.Department = myReader.GetString(1);
                absenabsenceLetter.TotalDate = myReader.GetInt32(2);
                absenabsenceLetter.FromDate = myReader.GetString(3);
                absenabsenceLetter.ToDate = myReader.GetString(4);
                absenabsenceLetter.Note = myReader.GetString(5);
                AbsenabsenceLetters.Add(absenabsenceLetter);
            }
            connection.Close();
        }
        public void OnGet()
        {
            LoadData();
        }
        public IActionResult OnPost()
        {
            SqlConnection connection = new SqlConnection("data source=.; database=administrative_management; integrated security=true");
            connection.Open();
            SqlCommand command = new SqlCommand("insert into absence_letter values (@name,@department,@total,@from,@to,@note)", connection);
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@department", Department);
            command.Parameters.AddWithValue("@total", TotalDate);
            command.Parameters.AddWithValue("@from", FromDate);
            command.Parameters.AddWithValue("@to", ToDate);
            command.Parameters.AddWithValue("@note", Note);

            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    ModelState.AddModelError(string.Empty, "Insert completed successfully!");
                }
                else ModelState.AddModelError(string.Empty, "An error occurred during inserting");
            }
            catch (SqlException er)
            {
                Console.WriteLine(er);
                ModelState.AddModelError(string.Empty, "An error occurred!");
                ModelState.AddModelError(string.Empty, er.ToString());
            }
            connection.Close();
            LoadData();
            return Page();
        }
    }
}
