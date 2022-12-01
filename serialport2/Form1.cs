using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MySql.Data.MySqlClient;

namespace serialport2
{
    public partial class Form1 : Form
    {
        public class Global
        {
            public static int number = 0;
            public static int Number { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {

            try
            {
                if (port_comboBox.Text == "" || buadrate_comboBox.Text == "")//no setting status
                {
                    MessageBox.Show(" 未選擇 Arduino 通訊埠 或 Buadrate !!");
                    return;
                }
                else if (serialPort1.IsOpen)// connected status
                {
                    serialPort1.Dispose();
                    connect_port();
                }
                else if ((!serialPort1.IsOpen))// no error and no connected's status
                {
                    connect_port();
                }

            }
            catch (Exception a)
            {
                Console.WriteLine("{0} Exception caught.", a);
            }

        }

        private void connect_port()
        {
            set_serialPort();
            serialPort1.Open();//connect
            connect_object_style();
        }

        private void connect_object_style()
        {
            Connect_button.Text = "Connected";
            Connect_button.BackColor = Color.GreenYellow;
            Disconnect_button.Enabled = true;
            LOW_button.Enabled = true;
            HIGH_button.Enabled = true;
            SendCommend.Enabled = true;
        }

        private void set_serialPort()
        {
            serialPort1.PortName = port_comboBox.Text.ToString();
            serialPort1.BaudRate = int.Parse(buadrate_comboBox.Text);
        }

        private void port_comboBox_MouseClick(object sender, MouseEventArgs e)
        {
            find_all_ports();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            find_all_ports();
        }

        private void find_all_ports()
        {
            port_comboBox.Items.Clear();
            string[] serialPorts = System.IO.Ports.SerialPort.GetPortNames();

            if (serialPorts.Length != 0)// if has port
            {
                port_comboBox.Text = serialPorts[0];
            }
            else// if no port
            {
                port_comboBox.Text = "";
                MessageBox.Show("Not found any port number.\nPlease confirm the USB.");
            }

            port_comboBox.Items.AddRange(serialPorts);
        }

        private void Disconnect_button_Click(object sender, EventArgs e)
        {
            serialPort1.Dispose();//disconnect
            disconnect_object_style();
        }

        private void disconnect_object_style()
        {
            Connect_button.Text = "Connect";
            Connect_button.BackColor = Color.FromArgb(224, 224, 224);
            Disconnect_button.Enabled = false;
            HIGH_button.Enabled = false;
            LOW_button.Enabled = false;
            SendCommend.Enabled = false;
        }

        private void LOW_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("LOW3\r");
        }


        private void HIGH_Click(object sender, EventArgs e)
        {
            serialPort1.Write("HIGH3\r\n");
        }

        private async void SendCommend_Click(object sender, EventArgs e)
        {
            serialPort1.Write(textBox1.Text + "\r\n");//send message
            await Task.Delay(100);
            Global.Number += 1;
            string receivedata = get_receive_message();
            Show_receive_message.AppendText(Global.Number + ":  " + receivedata + "  " + "\r\n");
        }

        private string get_receive_message()
        {

            int len = serialPort1.BytesToRead;
            string receivedata = String.Empty;
            if (len != 0)
            {
                receivedata = serialPort1.ReadExisting();

                //這方法就算delay還是會導致部分字串收不到
                //byte[] buff = new byte[len];
                //serialPort1.ReadExisting();
                //receivedata = Encoding.Default.GetString(buff);
            }
            return receivedata;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show_receive_message.Text = "";
            Global.Number = 0;
        }

        private async void Setting_button_Click(object sender, EventArgs e)
        {
            serialPort1.Write("OUTP:STAT:IMM ON" + "\r\n" + "APPL 10,5" + "\r\n");
            await Task.Delay(100);
            Show_receive_message.Text = "It's OK.\r\n";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            double dc = 0.0;
            double sum_dc = 0.0f;

            for (int i = 0; i < 5; i++)
            {
                serialPort1.Write("MEAS:SCAL:CURR:DC?" + "\r\n");
                await Task.Delay(100);
                dc = Convert.ToDouble(get_receive_message().Substring(1)) * 1000;
                sum_dc += dc;
                Show_receive_message.AppendText((i + 1) + ": " + dc.ToString() + "\r\n");
            }
            Show_receive_message.AppendText("Average： " + (sum_dc / 5).ToString());
        }


        private void mo_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (mo_textBox.Text == "")
                {
                    MessageBox.Show("Please input the 工單.");
                }
                else
                {
                    Get_ProductionName_and_Total();// Can show in textBox
                    get_Station();//Can show in comboBox
                }
            }
        }

        private void get_Station()
        {
                                                                                        // IP, database, UID, password
            string Connect_Info = setting_info_for_connect("192.168.0.99", "ma430104_Station", "johnson", "johnson");

            MySqlConnection connect_database = new MySqlConnection(Connect_Info);

            Open_database(connect_database);

            //----------Quary----------------------------
            String[] need_column = new string[] { "Data" };

            String cmdText =
                "SELECT Data " +
                "FROM All_Station " +
                "WHERE product_name='" + product_name_textBox.Text.Trim() + "'";

            string[] myData = Quary_database(connect_database, cmdText, need_column);


            station_comboBox.Items.AddRange(myData);
            
     
        }

        private void Get_ProductionName_and_Total()
        {
                                                                                        // IP, database, UID, password
            string Connect_Info = setting_info_for_connect("192.168.0.99", "ma430104_Production_Information", "johnson", "johnson");

            MySqlConnection connect_database = new MySqlConnection(Connect_Info);

            Open_database(connect_database);

            //----------Quary----------------------------
            String[] need_column = new string[] { "product_name", "total" };
            
            String cmdText =
                "SELECT product_name,total " +
                "FROM Production_Information " +    
                "WHERE mo='" + mo_textBox.Text.Trim() + "'";

            string[] myData = Quary_database(connect_database, cmdText,need_column);
            product_name_textBox.Text = myData[0];
            total_textBox.Text = myData[1];

        }

        private string[] Quary_database(MySqlConnection connect_database, string cmdText,string[] need_column)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, connect_database);

                using (MySqlDataReader readData = cmd.ExecuteReader())
                {
                    if (!readData.HasRows)
                    {
                        // 如果沒有資料,顯示沒有資料的訊息
                        MessageBox.Show("No data.");
                    }
                    else
                    {
                        string[] myData = new string[need_column.Length];

                        // 依照欄位讀取資料並且顯示出來
                        while (readData.Read())
                        {
                            for (int i =0; i < need_column.Length; i++)
                            {
                                myData[i]= readData[need_column[i]].ToString();
                            }
                            //myData[0] = readData["product_name"].ToString();
                            //myData[1] = readData["total"].ToString();
                            if (myData.Length == 1){
                                MessageBox.Show("MyData: " + myData[0]);
                            }
                            return myData;
                        }
                        readData.Close();
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " : " + ex.Message);
            }
            return (new string[] { "No data(last)" });
        }

        private static void Open_database(MySqlConnection connect_database)
        {
            try
            {
                connect_database.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("無法連線到資料庫.");
                        MessageBox.Show("Could not connect to database.");
                        break;
                    case 1045:
                        Console.WriteLine("The user account or password is wrong, please try again.");
                        break;
                }
            }
        }

        private string setting_info_for_connect(string sql_server, string sql_database, string sql_UID, string sql_password)
        {
            return "Server=" + sql_server + ";" +
                "Database=" + sql_database + ";" +
                "uid=" + sql_UID + ";" +
                "Pwd=" + sql_password + ";" +
                "charset=utf8;" +
                "SslMode=None;";
        }
    }
}
