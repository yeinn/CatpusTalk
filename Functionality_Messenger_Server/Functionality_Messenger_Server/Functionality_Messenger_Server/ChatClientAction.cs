using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
namespace Functionality_Messenger_Server
{
    class ChatClientAction
    {
        public delegate void MessageReceive_Throw(string Orogin_message, string S_message, string name, string users);
        public event MessageReceive_Throw Receive_Action;
        public delegate void ShutdownCode_Throw(TcpClient client, string name);
        public event ShutdownCode_Throw Shutdown_Action;

        NetworkStream stream = null;
       
        public TcpClient client{ //연결된 해당 클라이언트의 객체
            get; set;
        }
        public string name //해당 클라이언트의 id
        {
            get;set;
        }
        public string users
        {
            get;set;
        }
        public ChatClientAction(TcpClient Client, string name,string users)
        {
            client = Client; 
            this.name = name;
            this.users = users;
        }
        public void Start_Thread_of_Client() //아래 함수 실행
        {
            Thread Runner = new Thread(Checking_and_EventAction);
            Runner.IsBackground = true;
            Runner.Start();
        }
        private void Checking_and_EventAction()
        {
            byte[] Stream_data = new byte[1024];
            string S_message = null;
            string message = null;
            int Len;
            try
            {
                while (true)
                {
                    stream = client.GetStream(); //각 클라이언트와의 스트림
                    Len = stream.Read(Stream_data, 0, Stream_data.Length);
                    message = Encoding.Default.GetString(Stream_data, 0, Len);
                    S_message = "Receiving..." + message; //메세지를 받았다면

                    Receive_Action(message, S_message, name,users); //receiveMessage함수 실행
                    if (message.Equals(Packet.Shutdown))
                    {
                        Shutdown_Action(client, name); //ExitServer함수 실행
                        return; //해당 클라이언트의 종료
                    }
                    
                }
            }
            //finally로 스트림을 받아야할까?
            catch (SocketException se)
            {
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
