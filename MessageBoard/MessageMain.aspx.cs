using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class MessageMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string getId = Request.QueryString["id"];
                //string config = System.Web.Configuration.WebConfigurationManager
                //    .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
                //SqlConnection conn = new SqlConnection(config);

                //conn.Open();

                //string query = $"select * from MsgBoards where id={getId}";
                //SqlCommand cmd = new SqlCommand(query, conn);

                ////cmd.Parameters.AddWithValue("@id", Request["id"]); //the request["id"] part doesnt' work
                ////cmd.Parameters.Add("@id", SqlDbType.NVarChar);
                ////cmd.Parameters["id"].Value = Request["id"];


                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{
                //    Message_Header.Text = dr["header"].ToString();
                //    Message_Name.Text = dr["name"].ToString();
                //    Message_Time.Text = dr["initDate"].ToString();
                //    Main.Text = dr["maincontent"].ToString();
                //}

                //dr.Close();
                LoadMessage();
                LoadRepeater();
                
            }
        }

        protected void LoadRepeater()
        { 

            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
            SqlConnection rconn = new SqlConnection(config);
            
            rconn.Open();
            string getRid = Request.QueryString["id"];
            string rquery = $"SELECT Rid, MsgId, Name, Main, initDate FROM Reply where MsgId = {getRid}";

            SqlCommand rCommand = new SqlCommand(rquery, rconn);

            rCommand.Parameters.AddWithValue("@MsgId", getRid);

            SqlDataReader reReader = rCommand.ExecuteReader();
            Repeater1.DataSource = reReader;
            Repeater1.DataBind();
        }

        protected void LoadMessage()
        {
            
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(config);
            
            conn.Open();
            string getId = Request.QueryString["id"];
            string query = $"select id, header, name, maincontent, initDate from MsgBoards where (id={getId})";
            SqlCommand cmd = new SqlCommand(query, conn);

            //cmd.Parameters.AddWithValue("@id", Request["id"]); //the request["id"] part doesnt' work
          

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Message_Header.Text = dr["header"].ToString();
                Message_Name.Text = dr["name"].ToString();
                Message_Time.Text = dr["initDate"].ToString();
                Main.Text = dr["maincontent"].ToString();
                
            }

            dr.Close();

        }

        protected void Reply_Click(object sender, EventArgs e)
        {
            Response.Redirect("MessageReply.aspx?id=" + Request.QueryString["id"]);
        }

        protected void Revert_Click(object sender, EventArgs e)
        {
            Response.Redirect("MessageIndex.aspx");
        }
    }
}