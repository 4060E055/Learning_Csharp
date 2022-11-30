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
                    // MessageBox.Show("Linking again is " + serialPort1.IsOpen.ToString());
                }
                else if ((!serialPort1.IsOpen))// no error status
                {
                    connect_port();
                    // MessageBox.Show("Linking is" + serialPort1.IsOpen.ToString());
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
            connect_style();
        }

        private void connect_style()
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

            if (serialPorts.Length != 0)
            {
                port_comboBox.Text = serialPorts[0];
            }
            else
            {
                port_comboBox.Text = "";
                MessageBox.Show("Not found any port number.\nPlease confirm the USB.");
            }

            port_comboBox.Items.AddRange(serialPorts);
        }

        private void Disconnect_button_Click(object sender, EventArgs e)
        {
            serialPort1.Dispose();//disconnect
            //MessageBox.Show("Disconnect is " + serialPort1.IsOpen.ToString());
            disconnect_style();
        }

        private void disconnect_style()
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
            //double[] dc = new double[5];
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
                    String production_name = query_database();
                    product_name_textBox.Text = production_name;
                }
            }
        }

        private string query_database()
        {

            string Connect_Info = setting_info_for_connect();

            MySqlConnection connect_database = new MySqlConnection(Connect_Info);
           
            //------Connect---------------------------------------
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
            //-----------------------------------------------------------


            //----------Quary----------------------------
            String cmdText =
                "SELECT product_name " +
                "FROM Production_Information " +
                "WHERE mo='" + mo_textBox.Text + "'";
            //String cmdText = "SELECT product_name FROM Production_Information WHERE mo='" + mo_textBox.Text + "'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(cmdText, connect_database);
                MySqlDataReader myData = cmd.ExecuteReader();

                if (!myData.HasRows)
                {
                    // 如果沒有資料,顯示沒有資料的訊息
                    //Console.WriteLine("No data.");
                    MessageBox.Show("No data.");
                }
                else
                {
                    // 讀取資料並且顯示出來
                    while (myData.Read())
                    {
                        //Console.WriteLine("Text={0}", myData.GetString(0));
                        MessageBox.Show("讀取的資料Text={0}", myData.GetString(0));
                        return myData.GetString(0);
                    }
                    myData.Close();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //Console.WriteLine("Error " + ex.Number + " : " + ex.Message);
                MessageBox.Show("Error " + ex.Number + " : " + ex.Message);
            }
            //---------------------------------

            //MySqlDataAdapter dat = new MySqlDataAdapter();
            //DataTable dt = new DataTable();
            //dat.SelectCommand = cmd;
            //dat.Fill(dt);
            //dat.Dispose();

            //connect_database.Close();

            return "error";
        }

        private string setting_info_for_connect()
        {
            string sql_server = "192.168.0.99";
            string sql_UID = "johnson";
            string sql_password = "johnson";
            string Connect_Info =
                "Server=" + sql_server + ";" +
                "Database=ma430104_Production_Information;" +
                "uid=" + sql_UID + ";" +
                "Pwd=" + sql_password + ";" +
                "charset=utf8;" +
                "SslMode=None;";



            return Connect_Info;
        }
    }
}
