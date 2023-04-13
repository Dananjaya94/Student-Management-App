using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace StudentManagementApp.Pages
{
    public class IndexModel : PageModel
    {
        public String errorMessage;
        public List<Student> studentInfo = new List<Student>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DESKTOP-BV68OOS\\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    String query = "SELECT * FROM Student";

                    using(SqlCommand cmd = new SqlCommand(query,con))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Student std = new Student();
                                std.Id = reader.GetInt32(0);
                                std.firstname = reader.GetString(1);
                                std.lastname = reader.GetString(2);
                                std.address = reader.GetString(3);
                                std.city = reader.GetString(4);

                                studentInfo.Add(std);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public class Student
        {
            public int Id { get; set; }
            public string? firstname { get; set; }
            public string? lastname { get; set; }
            public string? address { get; set; }
            public string? city { get; set; }


        }
    }
}