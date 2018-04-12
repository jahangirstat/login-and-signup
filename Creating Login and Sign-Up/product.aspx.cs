using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Creating_Login_and_Sign_Up
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LogiandSignUpConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            da = new SqlDataAdapter("Select * from clothTbl", con);
            da.Fill(dt);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "E")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((Int32)dr["ID"] == id)
                    {
                        txtName.Text = dr["Brand"].ToString();
                        txtCType.Text = dr["ClothType"].ToString();
                        txtColor.Text = dr["Color"].ToString();
                        txtQty.Text = dr["Quantity"].ToString();
                        txtPrice.Text = dr["Price"].ToString();
                        HiddenField1.Value = dr["ID"].ToString();
                    }
                }
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }

            if (e.CommandName == "Del")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((Int32)dr["ID"] == id)
                    {
                        dr.Delete();
                    }
                }
                da.Update(dt);
                dt.AcceptChanges();
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ColothInformation cinfo = new ColothInformation
            {
                Brand = txtName.Text,
                ClothType = txtCType.Text,
                Color = txtColor.Text,
                Quantity = txtQty.Text,
                Price = txtPrice.Text
            };
            DataRow dr = dt.NewRow();
            dr["ID"] = -1;
            dr["Brand"] = cinfo.Brand;
            dr["ClothType"] = cinfo.ClothType;
            dr["Color"] = cinfo.Color;
            dr["Quantity"] = cinfo.Quantity;
            dr["Price"] = cinfo.Price;
            dt.Rows.Add(dr);
            da.Update(dt);
            dt.Clear();
            da.Fill(dt);
            dt.AcceptChanges();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            clearControl();
            Response.Write("<script>alert('Data Save successfull')</script>");
            
        }

        public class ColothInformation
        {
            public int ID { get; set; }
            public string Brand { get; set; }
            public string ClothType { get; set; }
            public string Color { get; set; }
            public string Quantity { get; set; }
            public string Price { get; set; }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('update btn Clicked')</script>");
            try
            {
                
                string sql = string.Format(" UPDATE clothTbl SET Brand='{0}',ClothType='{1}',Color='{2}',Quantity='{3}',Price='{4}' WHERE ID={5}",txtName.Text,txtCType.Text,txtColor.Text,txtQty.Text,txtPrice.Text,HiddenField1.Value);
                cmd = new SqlCommand(sql, con);
                cmd.Connection.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    dt.Clear();
                    da.Update(dt);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    clearControl(); Response.Write("<script>alert('Data Save successfull')</script>");
                }
                cmd.Connection.Close();

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
           
            
        }
        private void clearControl()
        {
            txtName.Text = "";
            txtCType.Text = "";
            txtColor.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
        }
    }
}