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
    }
}
