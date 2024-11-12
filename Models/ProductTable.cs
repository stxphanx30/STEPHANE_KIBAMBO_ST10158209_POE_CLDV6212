
    using Microsoft.AspNetCore.Mvc;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System;

    namespace st10158209.Models
{
        public class ProductTable
        {
            private static string con_string = "Server=tcp:cldv-server-sql.database.windows.net,1433;Initial Catalog=Database;Persist Security Info=False;User ID=stephane-kib;Password=CTMMonecole1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public decimal ProductPrice { get; set; }           
            public int ProductAvailability { get; set; }           

            public static List<ProductTable> GetAllProducts()
            {
                List<ProductTable> products = new List<ProductTable>();

                string sql = "SELECT * FROM ProductTable";

                try
                {
                    using (SqlConnection con = new SqlConnection(con_string))
                    {
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            con.Open();
                            using (SqlDataReader rdr = cmd.ExecuteReader())
                            {
                                while (rdr.Read())
                                {
                                ProductTable product = new ProductTable
                                {
                                        ProductID = Convert.ToInt32(rdr["ProductID"]),
                                        ProductName = rdr["ProductName"].ToString(),
                                        ProductPrice = Convert.ToDecimal(rdr["ProductPrice"]),                                      
                                        ProductAvailability = Convert.ToInt32(rdr["ProductAvailability"]),
                                    };

                                    products.Add(product);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    // For now, rethrow the exception with additional context
                    throw new Exception("An error occurred while retrieving products.", ex);
                }

                return products;
            }
        }
    }