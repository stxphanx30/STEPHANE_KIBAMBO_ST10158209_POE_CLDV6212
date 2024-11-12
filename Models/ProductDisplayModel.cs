

using System.Data.SqlClient;

namespace st10158209.Models
{
    public class ProductDisplayModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAvailability { get; set; }

        public ProductDisplayModel() { }

        //Parameterized Constructor: This constructor takes five parameters (id, name, price, category, availability) and initializes the corresponding properties of ProductDisplayModel with the provided values.
        public ProductDisplayModel(int id, string name, decimal price, string category, int availability)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;          
            ProductAvailability = availability;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=Database;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, ProductName, ProductPrice, ProductAvailability FROM ProductTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplayModel product = new ProductDisplayModel();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = Convert.ToString(reader["ProductName"]);
                    product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);                 
                    product.ProductAvailability = Convert.ToInt32(reader["ProductAvailability"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}