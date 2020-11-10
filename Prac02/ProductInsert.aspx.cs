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
    public partial class ProductInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            ProductBLL prodBLL = new ProductBLL();
            string image = "";

            if (fileUpload.HasFile == true)
            {
                image = "Images\\" + fileUpload.FileName;
            }

            string msg = prodBLL.ProductInsert(tb_ProductName.Text, tb_ProductDesc.Text, tb_UnitPrice.Text, fileUpload.FileName, tb_StockLevel.Text);

            if (msg == "Prodict has been Inserted successfully")
            {
                string saveimg = Server.MapPath(" ") + "\\" + image;
                lbl_Result.Text = saveimg.ToString();
                fileUpload.SaveAs(saveimg);
            }

            lbl_Result.Text = msg;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductView.aspx");
        }
    }
}