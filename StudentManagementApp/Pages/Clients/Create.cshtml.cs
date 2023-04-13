using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using static StudentManagementApp.Pages.IndexModel;

namespace StudentManagementApp.Pages
{
    public class CreateModel : PageModel
    {
        public Student stdInfo = new Student();
        public String errorMessage = "", successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
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
                        String insertQuery = "INSERT INTO STUDENT (firstname,lastname,address,city) VALUES(@firstname,@lastname,@address,@city);";

                        using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@firstname", stdInfo.firstname);
                            cmd.Parameters.AddWithValue("@lastname", stdInfo.lastname);
                            cmd.Parameters.AddWithValue("@address", stdInfo.address);
                            cmd.Parameters.AddWithValue("@city", stdInfo.city);

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

                successMessage = "New Student added";
            }
            Response.Redirect("/Index");
        }
    }
}
