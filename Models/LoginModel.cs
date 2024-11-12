

using System.Data.SqlClient;


namespace st10158209.Models
{
    public class LoginModel
    {

        public static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=Database;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int SelectUser(string Name, string Email, string PhoneNumber)
        {
            int UserID = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ID FROM CustomerProfile WHERE Email = @Email AND Name = @Name AND PhoneNumber = @PhoneNumber";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        UserID = Convert.ToInt32(result);

                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception
                    throw ex;
                }

            }

            return UserID;
        }

    }
}

