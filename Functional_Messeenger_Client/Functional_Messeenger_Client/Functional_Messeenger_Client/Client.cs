using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Functional_Messeenger_Client
{ //나가기버튼 추가해야함
    public partial class Client : Form
    {
        private TcpClient client = null;
        private NetworkStream N_stream = null;
        private Quary quary = null;
        public string id{
            get;set;
        }
        public string userArray
        {
            get;set;
        }
        public Client(string id,string userArray)
        {
            InitializeComponent();
            this.id = id;
            this.userArray = userArray;
            quary = new Quary();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect("192.168.35.191", 9999);
            N_stream = client.GetStream();
            string linkingArray_with_id = id + "+" + userArray;
            byte[] MyId = Encoding.Default.GetBytes(linkingArray_with_id);
            N_stream.Write(MyId, 0, MyId.Length);
            Action RECEIVE = new Action(Receive_Message);
            BeginInvoke(RECEIVE);
            
        }

        private void Send_button_Click(object sender, EventArgs e)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(textBox.Text);
            N_stream.Write(data, 0, data.Length);
            N_stream.Flush();
            textBox.Clear();
        }
        private void Receive_Message()
        {
            int Len;
            byte[] Stream_data = new byte[1024];
            string message = null;
            try
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        if (N_stream.CanRead)
                        {
                            Len = N_stream.Read(Stream_data, 0, Stream_data.Length); //비동기 코드
                            message = Encoding.Default.GetString(Stream_data, 0, Len);
                           
                            if (message.Equals(Packet.Shutdown))
                            {
                                ChatBox.Invoke((MethodInvoker)delegate () {
                                    ChatBox.AppendText("서버와의 연결이 끊어졌습니다.\n");
                                });
                                N_stream.Close();
                                client.Close();
                                goto EXIT;
                            }
                            else if (message.StartsWith("[$") && message.EndsWith("$]"))
                            {
                                List<string> Date_and_Text = message.Split('$').ToList<string>();
                                Date_and_Text.RemoveAt(0);
                                Date_and_Text.RemoveAt(Date_and_Text.Count - 1);//'[', ']'제거
                                if (MessageBox.Show("일정이 왔습니다.\n일정 : " +Date_and_Text[0]+ "\n내용 : "+Date_and_Text[1], "공유알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        quary.connection.Open();
                                        quary.command.CommandText = "select Time from " + id + "_scheduler where Time='" + Date_and_Text[0] + "'";
                                        quary.reader = quary.command.ExecuteReader();
                                        if (quary.reader.Read())//일정이 존재하면 덮어씌우기
                                        {
                                            quary.reader.Close();
                                            quary.command.CommandText = "update " + id + "_scheduler set Schedule='" + Date_and_Text[1] + "' where Time='" + Date_and_Text[0] + "'";
                                            quary.command.ExecuteNonQuery();
                                            MessageBox.Show("일정이 수정되었습니다.");
                                        }
                                        else
                                        {
                                            quary.reader.Close();
                                            quary.command.CommandText = "insert into " + id + "_scheduler values ('" + Date_and_Text[0] + "', '" + Date_and_Text[1] + "')";
                                            quary.command.ExecuteNonQuery();
                                            MessageBox.Show("일정이 삽입되었습니다.");
                                        }
                                    }
                                    catch (Exception err) { }
                                    finally
                                    {
                                        quary.connection.Close();
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (message.Equals(Packet.Approve))
                            {
                                ChatBox.Invoke((MethodInvoker)delegate ()
                                {
                                    ChatBox.AppendText("접속성공!\n");
                                });
                            }
                            else if (message.Length >= 1) //한 글자 이상이라면,
                            {
                                ChatBox.Invoke((MethodInvoker)delegate () {
                                    ChatBox.AppendText(message + "\n");
                                });
                            }
                        }
                    }
                EXIT:;
                });
            }
            catch (SocketException errcode)
            {
                MessageBox.Show(errcode.Message);
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(Packet.Shutdown);
            N_stream.Write(data, 0, data.Length);
        }

        private void Sharing_button_Click(object sender, EventArgs e)
        {
            string scheduleText = null;
            try
            {
                quary.connection.Open();
                quary.command.CommandText = "select Schedule from " + id + "_scheduler where Time='" + Myschedule_date.Value.ToString("yyyy-MM-dd") + "'";
                quary.reader = quary.command.ExecuteReader();
                if (quary.reader.Read())
                {
                    scheduleText = quary.reader["Schedule"].ToString();
                }
                else
                    scheduleText = "";
                byte[] data = System.Text.Encoding.Default.GetBytes("[$" + Myschedule_date.Value.ToString("yyyy-MM-dd") + "$"+
                    scheduleText+"$]");
                N_stream.Write(data, 0, data.Length);
                N_stream.Flush();
            }
            catch (Exception err) { }
            finally
            {
                quary.reader.Close();
                quary.connection.Close();
            }
        }
    }
}
