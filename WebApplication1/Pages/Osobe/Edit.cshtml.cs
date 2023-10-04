using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebApplication1.Pages.Osobe
{
    public class EditModel : PageModel
    {
        public OsobeInfo osobeInfo = new OsobeInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["Id"];
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=databaseOsobe;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "SELECT * FROM OSOBE WHERE Id=@Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                osobeInfo.Id = "" + reader.GetInt32(0);
                                osobeInfo.Ime = reader.GetString(1);
                                osobeInfo.Prezime = reader.GetString(2);
                                osobeInfo.Telefon = reader.GetString(3);
                                osobeInfo.Email = reader.GetString(4);
                                osobeInfo.Spol = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public void OnPost()
        {
            osobeInfo.Id = Request.Form["Id"];
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
                    String sql = "UPDATE Osobe " + 
                        "SET Ime=@Ime, Prezime=@Prezime, Telefon=@Telefon, Email=@Email, Spol=@Spol " +
                        "WHERE Id=@Id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", osobeInfo.Id);
                        command.Parameters.AddWithValue("@Ime", osobeInfo.Ime);
                        command.Parameters.AddWithValue("@Prezime", osobeInfo.Prezime);
                        command.Parameters.AddWithValue("@Telefon", osobeInfo.Telefon);
                        command.Parameters.AddWithValue("@Email", osobeInfo.Email);
                        command.Parameters.AddWithValue("@Spol", osobeInfo.Spol);

                        command.ExecuteNonQuery();
                    }
                }
            }
                 catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Osobe/Index");
        }
    }
}