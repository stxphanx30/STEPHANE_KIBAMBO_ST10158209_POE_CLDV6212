
using System.Data.SqlClient;

namespace st10158209.Models
{
    public class CustomerProfile
    {

        public static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=Database;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";



        public static SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


        public int insert_User(CustomerProfile m)
        {

            try
            {
                string sql = "INSERT INTO CustomerProfile (Name,Surname,PhoneNumber,Email ) VALUES (@Name, @Surname, @PhoneNumber,@Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.Name);
                cmd.Parameters.AddWithValue("@Surname", m.Surname);
                cmd.Parameters.AddWithValue("@PhoneNumber", m.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }


        }

    }
}