using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using DataAccessLayer;

namespace Prac02
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductBLL prodBLL = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string prodID = Request.QueryString["ProdID"].ToString();

            decimal dProdID = decimal.Parse(prodID);

            Product prod = null;

            prod = prodBLL.GetProdDetail(dProdID);

            lbl_ProdName.Text = prod.Product_Name;
            lbl_ProdDesc.Text = prod.Product_Desc;
            lbl_Price.Text = prod.Unit_Price.ToString("c");
            img_Product.ImageUrl = "~\\Images\\" + prod.Product_Image;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\ProductView.aspx");
        }
    }
}