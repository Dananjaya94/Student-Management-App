using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static StudentManagementApp.Pages.IndexModel;

namespace StudentManagementApp.Pages
{
    public class EditModel : PageModel
    {
        public Student stdInfo = new Student();
        public String errorMessage = "", successMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=DESKTOP-BV68OOS\\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    String insertQuery = "SELECT * FROM Student WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@id", Int16.Parse(id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stdInfo.Id = reader.GetInt32(0);
                                stdInfo.firstname = reader.GetString(1);
                                stdInfo.lastname = reader.GetString(2);
                                stdInfo.address = reader.GetString(3);
                                stdInfo.city = reader.GetString(4);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                successMessage = ex.Message;
                return;
            }
        }

        public void OnPost()
        {
            stdInfo.Id = Int16.Parse(s: Request.Form["id"]);
            stdInfo.firstname = Request.Form["firstname"];
            stdInfo.lastname = Request.Form["lastname"];
            stdInfo.address = Request.Form["address"];
            stdInfo.city = Request.Form["city"];

            if (stdInfo.firstname == null || stdInfo.lastname == null || stdInfo.address == null || stdInfo.city == null)
            {
                errorMessage = "All the field should be filled";
                return;
            }
            else
            {
                try
                {
                    String connectionString = "Data Source=DESKTOP-BV68OOS\\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True";

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        String insertQuery = "UPDATE STUDENT SET firstname=@firstname,lastname=@lastname,address=@address,city=@city WHERE id=@id;";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@firstname", stdInfo.firstname);
                            cmd.Parameters.AddWithValue("@lastname", stdInfo.lastname);
                            cmd.Parameters.AddWithValue("@address", stdInfo.address);
                            cmd.Parameters.AddWithValue("@city", stdInfo.city);
                            cmd.Parameters.AddWithValue("@id", stdInfo.Id);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                }

                stdInfo.firstname = "";
                stdInfo.lastname = "";
                stdInfo.address = "";
                stdInfo.city = "";

                successMessage = "Student Updated";
            }
            Response.Redirect("/Index");
        }
    }
}
