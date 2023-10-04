using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;                                                           

namespace WebApplication1.Pages.Osobe
{
    public class IndexModel : PageModel
    {
        public List<OsobeInfo> ListOsobe = new List<OsobeInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=databaseOsobe;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Osobe";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            while (reader.Read())
                            {
                                OsobeInfo osobeInfo = new OsobeInfo();
                                osobeInfo.Id = "" + reader.GetInt32(0);
                                osobeInfo.Ime = reader.GetString(1);
                                osobeInfo.Prezime = reader.GetString(2);                               
                                osobeInfo.Telefon = reader.GetString(3);
                                osobeInfo.Email = reader.GetString(4);
                                osobeInfo.Spol = reader.GetString(5);

                                ListOsobe.Add(osobeInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
    public class OsobeInfo
    {
        public String? Id;
        public String? Ime;
        public String? Prezime;
        public String? Telefon;
        public String? Email;
        public String? Spol;
    }
}

