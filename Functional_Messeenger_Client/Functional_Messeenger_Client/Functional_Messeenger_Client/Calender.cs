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
    public partial class Calender : Form
    {
        Quary quary = null;
        public string ID
        {
            get;set;
        }
        public Calender(string id)
        {
            InitializeComponent();
            ID = id;
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            quary = new Quary();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            try
            {
                string Date = monthCalendar.SelectionStart.ToString("yyyy-MM-dd");
                quary.connection.Open();
                quary.command.CommandText = "select Time from " + ID + "_scheduler" + " where Time='" + Date + "'";
                quary.reader = quary.command.ExecuteReader();
                if (quary.reader.Read()) //해당 날짜가 존재하다면,
                {
                    quary.reader.Close();
                    quary.command.CommandText = "update " + ID + "_scheduler set Schedule='" + schedule_box.Text + "' where Time='" + Date + "'";
                    quary.command.ExecuteNonQuery();
                    MessageBox.Show("수정이 완료되었습니다.");
                }
                else
                {
                    quary.reader.Close();
                    quary.command.CommandText = "insert into " + ID + "_scheduler values ('" + Date + "' ,'" + schedule_box.Text + "')";
                    quary.command.ExecuteNonQuery();
                    MessageBox.Show("추가가 완료되었습니다.");
                }
            }
            catch (Exception err) { }
            finally {
                quary.connection.Close();
            }
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            schedule_box.Clear();
            try {
                string Date = monthCalendar.SelectionStart.ToString("yyyy-MM-dd");
                quary.connection.Open();
                quary.command.CommandText = "select Schedule from " + ID +"_scheduler"+ " where Time='" + Date + "'";
                quary.reader = quary.command.ExecuteReader();
                if (quary.reader.Read())
                    schedule_box.Text = quary.reader["Schedule"].ToString(); //Time속성은 primary key로!
            }
            catch(Exception err)
            {            }
            finally
            {
                quary.connection.Close();
                quary.reader.Close();
            }
        }

        private void Erase_button_Click(object sender, EventArgs e)
        {
            schedule_box.Clear();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
