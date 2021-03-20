using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Functional_Messeenger_Client
{
    public partial class JoinForm : Form
    {
        Quary quary = new Quary();
        bool flag = false;
        public JoinForm()
        {
            InitializeComponent();
        }

        private void JoinForm_Load(object sender, EventArgs e)
        {

        }

        private void idCheckBox_Click(object sender, EventArgs e)
        {
            flag = false;
            try
            {
                quary.connection.Open();
                quary.command.CommandText = "select ID from userlist";
                quary.reader = quary.command.ExecuteReader();
                while (quary.reader.Read())
                {
                    if (quary.reader["ID"].ToString() == idbox.Text)
                    {
                        MessageBox.Show("중복된 아이디입니다.");
                        quary.reader.Close();
                        quary.connection.Close();
                        return;
                    }
                }
                flag = true;
                MessageBox.Show($"'{idbox.Text}'는 사용 가능한 아이디입니다.");
            }
            catch (Exception err) { }
            finally
            {
                quary.reader.Close();
                quary.connection.Close();
            }

        }

        private void tryJoinButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag && (pwbox.Text == checkPwBox.Text))
                {
                    MessageBox.Show("회원가입이 완료되었습니다.");
                    quary.connection.Open();
                    quary.command.CommandText = "create table " + idbox.Text + "_Scheduler (" +
                        "Time TEXT NOT NULL," +
                        "Schedule TEXT NOT NULL)";
                    quary.command.ExecuteNonQuery();
                    quary.command.CommandText = "create table " + idbox.Text + "_Friends (" +
                        "ID varchar(30) NOT NULL," +
                        "status varchar(20)," +
                        "PRIMARY KEY(ID))";
                    quary.command.ExecuteNonQuery();
                    quary.command.CommandText = "insert into userlist values ('" + idbox.Text + "', '" + pwbox.Text + "', '" + "red')";
                    quary.command.ExecuteNonQuery();
                    this.Close();
                }
                else if (!flag)
                    MessageBox.Show("ID중복확인필요.");
                else
                    MessageBox.Show("PW와 확인란이 서로 다릅니다.");
            }
            catch (Exception err) { }
            finally {
                quary.connection.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
