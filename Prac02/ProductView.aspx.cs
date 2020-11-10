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
    public partial class ProductView : System.Web.UI.Page
    {
        ProductBLL prodBLL = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<Product> prodAll = new List<Product>();

            //prodAll = prodBLL.GetAllProduct();

            //gvProduct.DataSource = prodAll;
            //gvProduct.DataBind();

            if (!IsPostBack)
            {
                bind();
            }

        }

        protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvProduct.SelectedRow;

            string prodID = row.Cells[0].Text;

            Response.Redirect("ProductDetails.aspx?ProdID=" + prodID);
        }

        protected void btn_Add_New_Product_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductInsert.aspx");
        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ProductBLL pBLL = new ProductBLL();
            decimal categoryID = (decimal)gvProduct.DataKeys[e.RowIndex].Value;
            pBLL.ProductDelete(categoryID);

            Response.Redirect("ProductView.aspx");
        }

        protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProduct.EditIndex = -1;
            bind();
        }

        protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProduct.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            ProductBLL pBLL = new ProductBLL();

            GridViewRow row = (GridViewRow)gvProduct.Rows[e.RowIndex];
            decimal id = decimal.Parse(gvProduct.DataKeys[e.RowIndex].Value.ToString());
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tname = ((TextBox)row.Cells[2].Controls[0]).Text;
            string tprice = ((TextBox)row.Cells[3].Controls[0]).Text;

            pBLL.ProductUpdate(tid, tname, tprice);

            gvProduct.EditIndex = -1;
            bind();
        }
        protected void bind()
        {
            List<Product> prodAll = new List<Product>();
            prodAll = prodBLL.GetAllProduct();

            gvProduct.DataSource = prodAll;
            gvProduct.DataBind();
        }
    }
}