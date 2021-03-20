using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Functional_Messeenger_Client
{
    public partial class Home : Form
    {
        Client chatForm = null;
        bool isMove=false;
        Point fpt = new Point();
        Quary quary = new Quary();
        private TcpClient client = null;
        private NetworkStream N_stream = null;
        FriendsListBox friendsListBox = null;
        Action RunChatClient = null;
        
        public string id
        {
            get; set;
        }
        public Home(string id)
        {
            InitializeComponent();
            this.id = id;
            friendsListBox = new FriendsListBox(id);
            friendsListBox.Location = new Point(13, 69);
            RunChatClient = new Action(RunChatting);
            this.Controls.Add(friendsListBox);
        }
        private void Home_Load(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect("192.168.35.191", 10000);
            N_stream = client.GetStream();
            byte[] MyId = Encoding.Default.GetBytes($"{id}");
            N_stream.Write(MyId, 0, MyId.Length);
            friendsListBox.Change_ShowState();
            get_schedule();
            Action RECEIVE = new Action(Receive_Message);
            BeginInvoke(RECEIVE);
        }
        private async void Receive_Message()
        {
            
            bool flag = false;
            int Len;
            byte[] Stream_data = new byte[1024];
            string message = null;
            try
            {
                await Task.Run( () =>
                {
                    while (true)
                    {
                        flag = false;
                        if (N_stream.CanRead && N_stream != null)
                        {
                            Len = N_stream.Read(Stream_data, 0, Stream_data.Length); //비동기 코드
                            message = Encoding.Default.GetString(Stream_data, 0, Len);
                            if (message.Equals(Packet.Shutdown))
                            {
                                N_stream.Close();
                                client.Close();
                                N_stream = null;
                                client = null;
                                goto EXIT;
                            }
                            if (message.Equals(Packet.Approve))
                            {
                                MessageBox.Show("환영합니다.");
                            }
                            if (message.Equals(Packet.ChangeSignal))//상태변화
                            {
                                MessageBox.Show("Updating FriendsList...");
                                UpdateFriendsList_Click(this, new EventArgs());
                            }
                            if (message.StartsWith("[&") && message.EndsWith("&]"))
                            {
                                string[] userArray = message.Split('&');
                                string spliting_user = null;
                                for (int i = 1; i < userArray.Length - 1; i++)
                                {
                                    spliting_user += userArray[i];
                                    if (!(i == userArray.Length - 2))
                                        spliting_user += ",";
                                    if (this.id.Equals(userArray[i]))
                                        flag = true;
                                }
                                if (flag == true)
                                {
                                    if (MessageBox.Show("USER : "+spliting_user + "\n채팅을 시작하시겠습니까?", "채팅알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        chatForm = new Client(id, spliting_user);
                                        chatForm.ShowDialog();
                                        
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                EXIT: MessageBox.Show("turn off the HomeForm...");
                    this.Close();
                });
            }
            catch (SocketException errcode)
            {
                MessageBox.Show(errcode.Message);
            }
        }
        public void RunChatting()
        {
            chatForm.ShowDialog();
        }
        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] MyId = Encoding.Default.GetBytes(Packet.LogoutSignal);
            N_stream.Write(MyId, 0, MyId.Length);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            byte[] MyId = Encoding.Default.GetBytes(Packet.LogoutSignal);
            N_stream.Write(MyId, 0, MyId.Length);
            this.Close();
        }
        [Obsolete("사용하지않는 함수")]
        private void Calender_Click(object sender, EventArgs e)
        {
            //
        }

        private void UpdateFriendsList_Click(object sender, EventArgs e)
        {
            friendsListBox.Change_ShowState();
        }

        private void Addfriend_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string State = null;
            try
            {
                quary.connection.Open();
                quary.command.CommandText = "select ID,status from userlist";
                quary.reader = quary.command.ExecuteReader();
                while (quary.reader.Read())
                {
                    if (quary.reader["ID"].ToString().Equals(friendIDbox.Text))
                    {
                        if (quary.reader["ID"].ToString().Equals(id))
                        {
                            MessageBox.Show("자기자신을 추가할수는 없습니다.");
                            friendIDbox.Clear();
                            quary.reader.Close();
                            quary.connection.Close();
                            return;
                        }
                        flag = true;
                        State = quary.reader["status"].ToString();
                        foreach (string exist_fr in friendsListBox.Items)
                        {
                            if (exist_fr == friendIDbox.Text)
                            {
                                MessageBox.Show("이미 등록한 친구입니다.");
                                friendIDbox.Clear();
                                quary.reader.Close();
                                quary.connection.Close();
                                return;
                            }
                        }
                    }
                } quary.reader.Close();
                if (!flag)
                {
                    MessageBox.Show("존재하지 않는 ID입니다.");
                    friendIDbox.Clear();
                    quary.reader.Close();
                    quary.connection.Close();
                    return;
                }
                else
                {
                    quary.command.CommandText = "insert into " + id + "_friends values ('" +friendIDbox.Text+"', '"+State+"')";
                    quary.command.ExecuteNonQuery();
                    UpdateFriendsList_Click(this, new EventArgs());
                    MessageBox.Show("성공적으로 추가되었습니다.");
                }
            }
            catch (Exception err) { }
            finally
            {
                quary.reader.Close();
                quary.connection.Close();
            }
        }

        private async void StartChatting_Click(object sender, EventArgs e)
        {//dataformat : [&user1&user2&]
            if (friendsListBox.CheckedItems.Count < 1)
            {
                MessageBox.Show("혼자선 채팅할 수 없습니다.");
                return;
            }
            await Task.Run(() =>
            {
                bool leastOne = false;
                string selectedUser = "[&"+this.id;
                string id = null;
                for (int i = 0; i < friendsListBox.Items.Count; i++)
                {
                    id = friendsListBox.Items[i].ToString();
                    if (friendsListBox.GetItemChecked(friendsListBox.Items.IndexOf(id)))
                    {
                        leastOne = true;
                        selectedUser += "&"+id;
                    }
                }
                if (!leastOne)
                    selectedUser += "&]";
                else
                    selectedUser += "&]";
               
                byte[] MyId = Encoding.Default.GetBytes(selectedUser);
                N_stream.Write(MyId, 0, MyId.Length);
            });
        }

        private void Panel_down(object sender, MouseEventArgs e)
        {
            isMove = true;
            fpt = new Point(e.X, e.Y);
        }

        private void Panel_move(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
                this.Location = new Point(this.Left - (fpt.X - e.X), this.Top - (fpt.Y - e.Y));
        }

        private void Panel_up(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void Open_calender_button_Click(object sender, EventArgs e)
        {
            Calender cal = new Calender(this.id);
            cal.Show();
        }

        private void button1_Click(object sender, EventArgs e)//D-day설정 버튼(progress바 추가시 button2도 추가)
        {
            string startTime = null;
            string endTime = Dday_setEnd.Value.ToString("yyyy-MM-dd");
            string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd");
            DateTime T1 = DateTime.Parse(endTime);//종료시간
            DateTime T2 = DateTime.Parse(nowTime);//현재시간
            if (DateTime.Compare(T1, T2) < 0) {
                MessageBox.Show("잘못된 시간설정입니다.");
                return;
            }
            try
            {
                quary.connection.Open();
                quary.command.CommandText = "select pnum from " + id + "_progress where pnum=1"; //button2에선 2로
                quary.reader = quary.command.ExecuteReader();
                if (quary.reader.Read())
                { //해당 번호의 progress가 존재하면
                    quary.reader.Close();
                    quary.command.CommandText = "update " + id + "_progress set "+
                        "end='" + endTime + "', " + "subject='" + subject_box.Text + "' where pnum=1";
                    quary.command.ExecuteNonQuery();
                    quary.command.CommandText = "select start from " + id + "_progress where pnum=1";
                    quary.reader = quary.command.ExecuteReader();
                    quary.reader.Read();
                    end_time.Text = endTime;
                    start_time.Text = quary.reader["start"].ToString();
                    subject.Text = subject_box.Text;
                    MessageBox.Show("D-day 수정이 완료되었습니다.");
                    Calcutate_Date1(quary.reader["start"].ToString(), nowTime, endTime); //button2에선 2로
                }
                else
                {
                    quary.reader.Close();
                    startTime = nowTime;
                    quary.command.CommandText = "insert into " + id + "_progress values ('" + startTime + "', '" + endTime + "', '" + subject_box.Text + "',1)";
                    quary.command.ExecuteNonQuery();
                    end_time.Text = endTime;
                    start_time.Text = startTime;
                    subject.Text = subject_box.Text;
                    MessageBox.Show("추가가 완료되었습니다.");
                    Calcutate_Date1(startTime, nowTime, endTime);
                }
            }
            catch (Exception err) { }
            finally {
                quary.connection.Close();
            }  
        }
        private void get_schedule()
        {
            string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                quary.connection.Open();
                for (int i = 1; i <= 2; i++)
                {
                    quary.command.CommandText = "select * from " + id + "_progress where pnum=" + i;
                    quary.reader = quary.command.ExecuteReader();
                    if (quary.reader.Read())
                    {
                        if (i == 1)
                        {
                            start_time.Text = quary.reader["start"].ToString();
                            end_time.Text = quary.reader["end"].ToString();
                            subject.Text = quary.reader["subject"].ToString();
                            Calcutate_Date1(quary.reader["start"].ToString(), nowTime, quary.reader["end"].ToString());
                        }
                        else
                        {
                            start_time2.Text = quary.reader["start"].ToString();
                            end_time2.Text = quary.reader["end"].ToString();
                            subject2.Text = quary.reader["subject"].ToString();
                            Calcutate_Date2(quary.reader["start"].ToString(), nowTime, quary.reader["end"].ToString());//버튼2에선 2로
                        }
                    }
                    else
                    {
                        continue;
                    }
                    quary.reader.Close();
                }
            }
            catch (Exception err) { }
            finally
            {
                quary.connection.Close();
            }
         }
        private void Calcutate_Date1(string startTime, string nowTime, string endTime) {
            quary.reader.Close();
            DateTime T1 = DateTime.Parse(endTime);
            DateTime T2 = DateTime.Parse(startTime);
            DateTime T3 = DateTime.Parse(nowTime);
            int flag = DateTime.Compare(T1, T3);
            if (flag == 0) {
                try
                {
                    quary.command.CommandText = "delete from " + id + "_progress where pnum=1";
                    quary.command.ExecuteNonQuery();
                    MessageBox.Show("D-day 입니다!");
                }
                catch (Exception err) { }
                finally
                {
                    start_time.Text = "label1";
                    end_time.Text = "label2";
                    subject.Text = "label3";
                    Dday_label.Text = "label4";
                    progress1.Value = 0;
                }
                return;
            }
            TimeSpan TS = T1 - T2; //end-start - start-time
            TimeSpan TG = T3 - T2; //now-start - start-time
            int totalTime = TS.Days;
            int thisTime = TG.Days;
            progress1.Minimum = 0;
            progress1.Maximum = totalTime;
            progress1.Step = 1;
            progress1.Value = thisTime;
            Dday_label.Text = "D-" + (totalTime - thisTime);
            progress1.ForeColor = Color.FromArgb(150, 0, 0);
        }
        private void Calcutate_Date2(string startTime, string nowTime, string endTime)
        {
            quary.reader.Close();
            DateTime T1 = DateTime.Parse(endTime);
            DateTime T2 = DateTime.Parse(startTime);
            DateTime T3 = DateTime.Parse(nowTime);
            int flag = DateTime.Compare(T1, T3);
            if (flag == 0)
            {
                try
                {
                    quary.command.CommandText = "delete from " + id + "_progress where pnum=2";
                    quary.command.ExecuteNonQuery();
                    MessageBox.Show("D-day 입니다!");
                }
                catch (Exception err) { }
                finally
                {
                    start_time2.Text = "label1";
                    end_time2.Text = "label2";
                    subject2.Text = "label3";
                    Dday_label2.Text = "label4";
                    progress2.Value = 0;
                }
                return;
            }
            TimeSpan TS = T1 - T2; //end-start
            TimeSpan TG = T3 - T2; //now-start
            int totalTime = TS.Days;
            int thisTime = TG.Days;
            progress2.Minimum = 0; //progress2로
            progress2.Maximum = totalTime;
            progress2.Step = 1;
            progress2.Value = thisTime;
            Dday_label2.Text = "D-" + (totalTime - thisTime);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string startTime = null;
            string endTime = Dday_setEnd2.Value.ToString("yyyy-MM-dd");
            string nowTime = System.DateTime.Now.ToString("yyyy-MM-dd");
            DateTime T1 = DateTime.Parse(endTime);//종료시간
            DateTime T2 = DateTime.Parse(nowTime);//현재시간
            if (DateTime.Compare(T1, T2) < 0)
            {
                MessageBox.Show("잘못된 시간설정입니다.");
                return;
            }
            try
            {
                quary.connection.Open();
                quary.command.CommandText = "select pnum from " + id + "_progress where pnum=2"; //button2에선 2로
                quary.reader = quary.command.ExecuteReader();
                if (quary.reader.Read())
                { //해당 번호의 progress가 존재하면
                    quary.reader.Close();
                    quary.command.CommandText = "update " + id + "_progress set " +
                        "end='" + endTime + "', " + "subject='" + subject_box2.Text + "' where pnum=2";
                    quary.command.ExecuteNonQuery();
                    quary.command.CommandText = "select start from " + id + "_progress where pnum=2";
                    quary.reader = quary.command.ExecuteReader();
                    quary.reader.Read();
                    end_time2.Text = endTime;
                    start_time2.Text = quary.reader["start"].ToString();
                    subject2.Text = subject_box2.Text;
                    MessageBox.Show("D-day 수정이 완료되었습니다.");
                    Calcutate_Date2(quary.reader["start"].ToString(), nowTime, endTime); //button2에선 2로
                }
                else
                {
                    quary.reader.Close();
                    startTime = nowTime;
                    quary.command.CommandText = "insert into " + id + "_progress values ('" + startTime + "', '" + endTime + "', '" + subject_box2.Text + "',2)";
                    quary.command.ExecuteNonQuery();
                    end_time2.Text = endTime;
                    start_time2.Text = startTime;
                    subject2.Text = subject_box2.Text;
                    MessageBox.Show("추가가 완료되었습니다.");
                    Calcutate_Date2(startTime, nowTime, endTime);
                }
            }
            catch (Exception err) { }
            finally
            {
                quary.connection.Close();
            }
        }
    }
    public partial class FriendsListBox : CheckedListBox {
        List<Color> StatusColor = new List<Color>();
        Quary quary = new Quary();

        public string id {
            get; set;
        }
        public FriendsListBox(string id) {
            this.id = id;
        }
        public void Change_ShowState() {
            try
            {
                this.Invoke((MethodInvoker)delegate () {
                    int i = 0;
                    StatusColor.Clear();
                    this.Items.Clear();
                    quary.connection.Open();
                    quary.command.CommandText = "select ID,status from " + this.id + "_friends";
                    quary.reader = quary.command.ExecuteReader();
                    while (quary.reader.Read())
                    {
                        if (quary.reader["status"].ToString().Equals("red"))
                        {
                            this.Items.Add(quary.reader["ID"].ToString());
                            StatusColor.Add(Color.FromArgb(255, 0, 0));
                        }
                        else
                        {
                            this.Items.Add(quary.reader["ID"].ToString());
                            StatusColor.Add(Color.FromArgb(0, 255, 0));
                        }
                        i++;
                    }
                });
                
            }
            catch (Exception err) { }
            finally
            {
                 quary.connection.Close();
                 quary.reader.Close();
            }
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (StatusColor.Count <= e.Index)
            {
                base.OnDrawItem(e);
                return;
            }
            DrawItemEventArgs E = new DrawItemEventArgs(e.Graphics, e.Font, new Rectangle(e.Bounds.Location, e.Bounds.Size),
                e.Index, e.State, StatusColor[e.Index], Color.White);
            base.OnDrawItem(E);
        }
    }
}
