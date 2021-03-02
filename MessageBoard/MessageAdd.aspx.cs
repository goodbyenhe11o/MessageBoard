using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Confirm_Click(object sender, EventArgs e)
        {
            
            
            string config = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings["MessageBoardConnectionString"].ConnectionString;
            
            //set the connection with db by the connection string in the "config"

            SqlConnection conn = new SqlConnection(config);

            //two ways of creating sql query command
            
            //SqlCommand cmd =
            //    new SqlCommand($"INSERT INTO MsgBoards ( Header, Name, Main) VALUES(@header, @Name, @Main)", conn);

            string query = $"INSERT INTO MsgBoards ( Header, Name, MainContent) VALUES(@header, @Name, @MainContent)";
            SqlCommand cmd = new SqlCommand(query, conn);
            
            conn.Open();
            cmd.Parameters.AddWithValue("@Header", Message_Header.Text);
            cmd.Parameters.AddWithValue("@Name", Message_Name.Text);
            cmd.Parameters.AddWithValue("@MainContent", Message_Main.Text);
            cmd.ExecuteNonQuery(); //執行command的SQL語法，回傳受影響的資料數目

            conn.Close();
            
            Response.Redirect("MessageIndex.aspx");








        }
    }
}