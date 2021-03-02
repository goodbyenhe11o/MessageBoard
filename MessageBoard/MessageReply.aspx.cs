using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class MessageReply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string getId = Request.QueryString["id"];
                string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
                string query = $"Select * from MsgBoards where id = {getId}";
                SqlConnection conn = new SqlConnection(config);
                SqlCommand cmd = new SqlCommand(query, conn);
                
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader(); // use datareader

                if (dr.Read())
                {
                    Reply_Header.Text = "RE:" + dr["header"].ToString();
                }   
                conn.Close();
                
                }

        }

        protected void Confirm_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Reply_Main.Text) && string.IsNullOrEmpty(Reply_Name.Text))
            {
                Message.Text = "欄位必填";
            }
         else if (string.IsNullOrEmpty(Reply_Name.Text))
            {
                Message.Text = "姓名欄位必填";
            }
            else if (string.IsNullOrEmpty(Reply_Header.Text))
            {
                Message.Text = "標題欄位必填";
            }
            else
            {
                string config = System.Web.Configuration.WebConfigurationManager
                    .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;

                //set the connection with db by the connection string in the "config"

                SqlConnection conn = new SqlConnection(config);

                //two ways of creating sql query command

                //SqlCommand cmd =
                //    new SqlCommand($"INSERT INTO MsgBoards ( Header, Name, Main) VALUES(@header, @Name, @Main)", conn);

                string query = $"INSERT INTO Reply (  MsgId, Name, Main) VALUES( @MsgId, @Name, @Main)";
                string getId = Request.QueryString["id"];
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@MsgId", getId);
                cmd.Parameters.AddWithValue("@Name", Reply_Name.Text).ToString();
                cmd.Parameters.AddWithValue("@Main", Reply_Main.Text).ToString();
                
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("MessageMain.aspx?id=" + getId);

            }
        }
    }
}