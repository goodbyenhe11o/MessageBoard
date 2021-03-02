using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class MessageIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LoadData();
            }
            
        }

        protected void LoadData()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(config);

            //string query = $"select * from MsgBoards";
            string query = $"SELECT id, header, name,initDate ,(select count(*) from Reply where MsgId=MsgBoards.id)as 回應 FROM MsgBoards";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd); //get the sql command

            DataSet ds = new DataSet(); //build a new dataset memory db

            da.Fill(ds); //put the data got from data adapter into dataset

            GridView1.DataSource = ds; 
            GridView1.DataBind();
            conn.Close();

        }




        protected void LoadRepeater()
        {
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(config);

            SqlCommand cm = new SqlCommand($"select Name, Header, MainContent from MsgBoards", cn);
            cn.Open();
            SqlDataReader rdRpReader = cm.ExecuteReader();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MessageAdd.aspx");
        }



     
    }
}