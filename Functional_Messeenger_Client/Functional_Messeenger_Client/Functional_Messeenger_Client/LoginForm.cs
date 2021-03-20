using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Functional_Messeenger_Client
{
    public partial class LoginForm : Form
    {
        Quary quary = new Quary();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginFoorm_Load(object sender, EventArgs e)
        {
            this.loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            bool flag = false;
            try
            {
                quary.connection.Open();
                quary.command.CommandText = "select ID,PW from userlist";
                quary.reader = quary.command.ExecuteReader();
                while (quary.reader.Read())
                {
                    if (quary.reader["ID"].ToString() == idbox.Text && quary.reader["PW"].ToString() == pwbox.Text)
                        flag = true;
                    if (flag)
                        break;
                }
            }
            catch (Exception err) { }
            finally
            {
                quary.reader.Close();
                quary.connection.Close();
            }
            if (flag) {
                Home home = new Home(idbox.Text);
                this.Opacity = 0;
                home.ShowDialog();
                this.Opacity = 1;
            }
            else
            {
                MessageBox.Show("아이디나 비밀번호를 잘못 입력하였습니다.");
                return;
            }
        }
        private void joinButton_Click(object sender, EventArgs e)
        {
            JoinForm joinform = new JoinForm();
            joinform.Show();
        }

        private void mouseHover(object sender, EventArgs e)
        {
            loginButton.BackColor = Color.FromArgb(0, 255, 34, 255);
        }
    }
}
