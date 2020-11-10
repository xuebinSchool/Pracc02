using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class ProductBLL
    {
        public Product GetProdDetail(decimal prodID)
        {
            Product prodDetail = new Product();

            return prodDetail.GetProduct(prodID);
        }
        public List<Product> GetAllProduct()
        {
            List<Product> allProduct = new List<Product>();
            Product product = new Product();

            allProduct = product.GetProductAll();

            return allProduct;
        }

        public string ProductInsert(string _ProductName, string _ProductDesc, string _UnitPrice, string _Image, string _StockLevel)
        {
            string msg = null;
            int result = 0;

            Product prod = new Product(_ProductName, _ProductDesc, decimal.Parse(_UnitPrice), _Image, Int32.Parse(_StockLevel));

            result = prod.ProductInsert();
            if (result == 1)
            {
                msg = "Product has been insert successfully";
            }
            else
            {
                msg = "Error! Please try again.";
            }

            return msg;
        }

        public int ProductDelete(decimal ID)
        {
            string msg = null;
            int result = 0;

            Product PDAL = new Product();
            result = PDAL.ProductDelete(ID);

            if (result == 1)
            {
                msg = "Product has been insert successfully";
            }
            else
            {
                msg = "Error! Please try again.";
            }

            return result;
        } //End  Delete

        public string ProductUpdate(string _ProductID, string _ProductName, string _UnitPrice)
        {
            string msg = null;
            int result = 0;

            Product prod = new Product();

            result = prod.ProductUpdate(_ProductID, _ProductName, Convert.ToDecimal(_UnitPrice));
            if (result == 1)
            {
                msg = "Product has been updated successfully";
            }
            else
            {
                msg = "Error! Please try again.";
            }

            return msg;
        } //End Update
    }
}
