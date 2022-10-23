using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Timers;

namespace PassGen
{
    public partial class Password : System.Web.UI.Page
    {
        string userID = "";
        string datePicked = "";
        string letterDate = "";
        string finalPassword = "";
        Random r;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false;
            }
        }

        protected void btnPickDate_Click(object sender, EventArgs e)
        {
            txtDateTime.Text = Calendar1.SelectedDate.ToString();
        }

        protected void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            lblPassword.Visible = true;
            if (txtUserID.Text == "" || txtDateTime.Text == "")
            {
                lblRFV.Visible = true;
            }
            else
            {
                lblRFV.Visible = false;
                userID = Convert.ToString(txtUserID.Text);
                datePicked = Convert.ToString(txtDateTime.Text);

                for (int i = 0; i < datePicked.Length; i++)
                {
                    string letter = datePicked.Substring(i, 1);
                    if (letter != "/" && letter != " " && letter != ":")
                    {
                        letterDate += letter;
                    }
                }

                int userIDSize = userID.Length;
                int letterDateSize = letterDate.Length;

                if (userIDSize <= letterDateSize)
                {
                    for (int i = 0; i < letterDateSize; i++)
                    {
                        userID += letterDate.Substring(i, 1);
                    }
                    string[] userArr = new string[userID.Length];
                    for (int i = 0; i < userID.Length; i++)
                    {
                        userArr[i] = userID.Substring(i, 1);
                    }
                    CreatePassword(userArr, userID.Length);
                }
                else if (userIDSize >= letterDateSize)
                {
                    for (int i = 0; i < userIDSize; i++)
                    {
                        letterDate += userID.Substring(i, 1);
                    }
                    string[] letterArr = new string[letterDate.Length];
                    for (int i = 0; i < letterDate.Length; i++)
                    {
                        letterArr[i] = letterDate.Substring(i, 1);
                    }
                    CreatePassword(letterArr, letterDate.Length);
                }
            }
        }

        protected void CreatePassword(string[] pass, int size)
        {
            r = new Random();
            for (int i = 0; i < pass.Length; i++)
            {
                finalPassword += pass[r.Next(0, size)];
            }

            lblPassword.Text = finalPassword;
            Timer1.Enabled = true;
            Session["Timer"] = DateTime.Now.AddSeconds(32).ToString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            if (DateTime.Compare(DateTime.Now, DateTime.Parse(Session["Timer"].ToString())) < 0)
            {
                litmsg.Text = "Time left: " + (((Int32)DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalSeconds) % 60).ToString() + " Seconds";
            }
            else
            {
                litmsg.Text = "Password has expired, please generate a new one!";
                lblPassword.Visible = false;
            }

        }
    }
}