using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Product
    {
        private string _connStr = Properties.Settings.Default.DBConnStr;
        private decimal _prodID = 0;
        private string _prodName = string.Empty;
        private string _prodDesc = ""; // this is another way to specify empty string
        private decimal _unitPrice = 0;
        private string _prodImage = "";
        private int _stockLevel = 0;

        // Default constructor
        public Product()
        {
        }

        // Constructor that take in all data required to build a Product object
        public Product(decimal prodID, string prodName, string prodDesc,
                       decimal unitPrice, string prodImage, int stockLevel)
        {
            _prodID = prodID;
            _prodName = prodName;
            _prodDesc = prodDesc;
            _unitPrice = unitPrice;
            _prodImage = prodImage;
            _stockLevel = stockLevel;
        }

        // Constructor that take in all except product ID
        public Product(string prodName, string prodDesc,
               decimal unitPrice, string prodImage, int stockLevel)
            : this(0, prodName, prodDesc, unitPrice, prodImage, stockLevel)
        {
        }

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public Product(decimal prodID)
            : this(prodID, "", "", 0, "", 0)
        {
        }

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public decimal Product_ID
        {
            get { return _prodID; }
            set { _prodID = value; }
        }
        public string Product_Name
        {
            get { return _prodName; }
            set { _prodName = value; }
        }
        public string Product_Desc
        {
            get { return _prodDesc; }
            set { _prodDesc = value; }
        }
        public decimal Unit_Price
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        public string Product_Image
        {
            get { return _prodImage; }
            set { _prodImage = value; }
        }
        public int Stock_Level
        {
            get { return _stockLevel; }
            set { _stockLevel = value; }
        }

        /// <summary>
        /// This method retrieve details of the product from database table Product.
        /// It return a Product object.
        /// </summary>
        /// <param name="prodID">Product ID</param>
        /// <returns></returns>
        public Product GetProduct(decimal prodID)
        {
            Product prodDetail = null;

            string prod_Name, prod_Desc, Prod_Image;
            decimal unit_Price;
            int stock_Level;

            string queryStr = "SELECT * FROM Product WHERE Product_ID = @ProdID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ProdID", prodID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                prod_Name = dr["Product_Name"].ToString();
                prod_Desc = dr["Product_Desc"].ToString();
                Prod_Image = dr["Product_Image"].ToString();
                unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                stock_Level = int.Parse(dr["Stock_Level"].ToString());

                prodDetail = new Product(prodID, prod_Name, prod_Desc, unit_Price, Prod_Image, stock_Level);
            }
            else
            {
                prodDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return prodDetail;
        }

        /// <summary>
        /// This method retrieval all products from Product database table.
        /// The Product object is stored in a list and return to calling program.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductAll()
        {
            List<Product> prodAll = new List<Product>();

            string prod_Name, prod_Desc, Prod_Image;
            decimal prod_ID, unit_Price;
            int stock_Level;

            string queryStr = "SELECT * FROM Product Order By Product_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                prod_ID = decimal.Parse(dr["Product_ID"].ToString());
                prod_Name = dr["Product_Name"].ToString();
                prod_Desc = dr["Product_Desc"].ToString();
                Prod_Image = dr["Product_Image"].ToString();
                unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                stock_Level = int.Parse(dr["Stock_Level"].ToString());

                prodAll.Add(new Product(prod_ID, prod_Name, prod_Desc, unit_Price, Prod_Image, stock_Level));
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return prodAll;
        }

        public int ProductInsert()
        {
            int result = 0;
            string queryStr = "INSERT INTO Product(Product_Name, Product_Desc, Unit_Price, Product_Image,Stock_Level)"
                + "values (@Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            //cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
            cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
            cmd.Parameters.AddWithValue("@Product_Desc", this.Product_Desc);
            cmd.Parameters.AddWithValue("@Unit_Price", this.Unit_Price);
            cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
            cmd.Parameters.AddWithValue("@Stock_Level", this.Stock_Level);

            conn.Open();

            result += cmd.ExecuteNonQuery();

            conn.Close();

            return result;
        }

        public int ProductDelete(decimal ID)
        {
            string queryStr = "DELETE FROM Product WHERE Product_ID=@ID";
            //decimal ID_dec = Convert.ToDecimal(ID);

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Delete

        public int ProductUpdate(string pId, string pName, decimal pUnitPrice)
        {
            string queryStr = "UPDATE Product SET" +
            //" Product_ID = @productID, " +
            " Product_Name = @productName, " +
            " Unit_Price = @unitPrice " +
            " WHERE Product_ID = @productID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@productID", pId);
            cmd.Parameters.AddWithValue("@productName", pName);
            cmd.Parameters.AddWithValue("@unitPrice", pUnitPrice);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;

        }//end Update
    }
}
