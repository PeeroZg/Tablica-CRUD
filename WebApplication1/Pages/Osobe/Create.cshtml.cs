using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication1.Pages.Osobe
{
    public class CreateModel : PageModel
    {
        public OsobeInfo osobeInfo = new OsobeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            osobeInfo.Ime = Request.Form["Ime"];
            osobeInfo.Prezime = Request.Form["Prezime"];
            osobeInfo.Telefon = Request.Form["Telefon"];
            osobeInfo.Email = Request.Form["Email"];
            osobeInfo.Spol = Request.Form["Spol"];

            if (osobeInfo.Ime.Length == 0 || osobeInfo.Prezime.Length == 0
                || osobeInfo.Telefon.Length == 0 || osobeInfo.Email.Length == 0
                || osobeInfo.Spol.Length == 0)
            {
                errorMessage = "Potrebno je popuniti sva polja.";
                return;
            }
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=databaseOsobe;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Osobe " +
                        "(Ime,Prezime,Telefon,Email,Spol) VALUES " + "(@Ime, @Prezime, @Telefon, @Email, @Spol);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Ime", osobeInfo.Ime);
                        command.Parameters.AddWithValue("@Prezime", osobeInfo.Prezime);
                        command.Parameters.AddWithValue("@Telefon", osobeInfo.Telefon);
                        command.Parameters.AddWithValue("@Email", osobeInfo.Email);
                        command.Parameters.AddWithValue("@Spol", osobeInfo.Spol);

                        command.ExecuteNonQuery();
                    }
                } 
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }



            osobeInfo.Ime = ""; osobeInfo.Prezime = ""; osobeInfo.Telefon = "";
            osobeInfo.Email = ""; osobeInfo.Spol = "";
            successMessage = "Dodali ste novu osobu!";
            Response.Redirect("/Osobe/Index");
            }
    }    
}