using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace poe.Controllers
{
    public class TransactionController : Controller
    {
        public static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=cldv-DB;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {

                // Create a new instance of SqlConnection using the connection string
                {
                    // Define the SQL query to insert a new record into the transactionTable
                    string sql = "INSERT INTO TransactionTable (UserID, ProductID) VALUES (@UserID, @ProductID)";

                    // Create a new instance of SqlCommand with the SQL query and SqlConnection
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Add parameters to the SqlCommand for userID and productID
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        // Open the SqlConnection
                        con.Open();

                        // Execute the SqlCommand to insert the record into the transactionTable
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Close the SqlConnection
                        con.Close();

                        // Check if the insert operation was successful
                        if (rowsAffected > 0)
                        {
                            // Redirect the user to the home page after placing the order
                            return RedirectToAction("Order", "Home");
                        }
                        else
                        {
                            // If the insert operation failed, return an error view or message
                            return View("OrderFaile");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, return an error view or message
                return RedirectToAction("OrderFailed", "Home");
            }
        }
    }
}
