namespace serialport2   
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Connect_button = new System.Windows.Forms.Button();
            this.buadrate_comboBox = new System.Windows.Forms.ComboBox();
            this.port_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Relay = new System.Windows.Forms.GroupBox();
            this.Disconnect_button = new System.Windows.Forms.Button();
            this.Show_receive_message = new System.Windows.Forms.TextBox();
            this.SendCommend = new System.Windows.Forms.Button();
            this.HIGH_button = new System.Windows.Forms.Button();
            this.LOW_button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Clear_button = new System.Windows.Forms.Button();
            this.Setting_button = new System.Windows.Forms.Button();
            this.Get_DC_button = new System.Windows.Forms.Button();
            this.mo_textBox = new System.Windows.Forms.TextBox();
            this.product_name_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.station_number_comboBox = new System.Windows.Forms.ComboBox();
            this.total_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Relay.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connect_button
            // 
            this.Connect_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Connect_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Connect_button.Location = new System.Drawing.Point(226, 43);
            this.Connect_button.Name = "Connect_button";
            this.Connect_button.Size = new System.Drawing.Size(78, 21);
            this.Connect_button.TabIndex = 1;
            this.Connect_button.Text = "Connect";
            this.Connect_button.UseVisualStyleBackColor = false;
            this.Connect_button.Click += new System.EventHandler(this.Connect_Click);
            // 
            // buadrate_comboBox
            // 
            this.buadrate_comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buadrate_comboBox.FormattingEnabled = true;
            this.buadrate_comboBox.Items.AddRange(new object[] {
            "9600",
            "19200",
            "57600"});
            this.buadrate_comboBox.Location = new System.Drawing.Point(79, 80);
            this.buadrate_comboBox.Name = "buadrate_comboBox";
            this.buadrate_comboBox.Size = new System.Drawing.Size(121, 21);
            this.buadrate_comboBox.TabIndex = 24;
            this.buadrate_comboBox.Text = "9600";
            // 
            // port_comboBox
            // 
            this.port_comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.port_comboBox.FormattingEnabled = true;
            this.port_comboBox.Location = new System.Drawing.Point(79, 43);
            this.port_comboBox.Name = "port_comboBox";
            this.port_comboBox.Size = new System.Drawing.Size(121, 21);
            this.port_comboBox.TabIndex = 11;
            this.port_comboBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.port_comboBox_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Buadrate：";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Relay
            // 
            this.Relay.Controls.Add(this.Disconnect_button);
            this.Relay.Controls.Add(this.buadrate_comboBox);
            this.Relay.Controls.Add(this.label2);
            this.Relay.Controls.Add(this.Connect_button);
            this.Relay.Controls.Add(this.label1);
            this.Relay.Controls.Add(this.port_comboBox);
            this.Relay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Relay.Location = new System.Drawing.Point(29, 37);
            this.Relay.Name = "Relay";
            this.Relay.Size = new System.Drawing.Size(324, 129);
            this.Relay.TabIndex = 5;
            this.Relay.TabStop = false;
            this.Relay.Text = "Connect";
            // 
            // Disconnect_button
            // 
            this.Disconnect_button.Enabled = false;
            this.Disconnect_button.Location = new System.Drawing.Point(226, 80);
            this.Disconnect_button.Name = "Disconnect_button";
            this.Disconnect_button.Size = new System.Drawing.Size(78, 23);
            this.Disconnect_button.TabIndex = 11;
            this.Disconnect_button.Text = "Disconnect";
            this.Disconnect_button.UseVisualStyleBackColor = true;
            this.Disconnect_button.Click += new System.EventHandler(this.Disconnect_button_Click);
            // 
            // Show_receive_message
            // 
            this.Show_receive_message.Location = new System.Drawing.Point(6, 50);
            this.Show_receive_message.Multiline = true;
            this.Show_receive_message.Name = "Show_receive_message";
            this.Show_receive_message.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Show_receive_message.Size = new System.Drawing.Size(215, 95);
            this.Show_receive_message.TabIndex = 8;
            // 
            // SendCommend
            // 
            this.SendCommend.Enabled = false;
            this.SendCommend.Location = new System.Drawing.Point(227, 22);
            this.SendCommend.Name = "SendCommend";
            this.SendCommend.Size = new System.Drawing.Size(126, 28);
            this.SendCommend.TabIndex = 3;
            this.SendCommend.Text = "Send Commend";
            this.SendCommend.UseVisualStyleBackColor = true;
            this.SendCommend.Click += new System.EventHandler(this.SendCommend_Click);
            // 
            // HIGH_button
            // 
            this.HIGH_button.Enabled = false;
            this.HIGH_button.Location = new System.Drawing.Point(94, 22);
            this.HIGH_button.Name = "HIGH_button";
            this.HIGH_button.Size = new System.Drawing.Size(61, 23);
            this.HIGH_button.TabIndex = 11;
            this.HIGH_button.Text = "HIGH";
            this.HIGH_button.UseVisualStyleBackColor = true;
            this.HIGH_button.Click += new System.EventHandler(this.HIGH_Click);
            // 
            // LOW_button
            // 
            this.LOW_button.Enabled = false;
            this.LOW_button.Location = new System.Drawing.Point(16, 22);
            this.LOW_button.Name = "LOW_button";
            this.LOW_button.Size = new System.Drawing.Size(61, 21);
            this.LOW_button.TabIndex = 11;
            this.LOW_button.Text = "LOW";
            this.LOW_button.UseVisualStyleBackColor = true;
            this.LOW_button.Click += new System.EventHandler(this.LOW_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Commend";
            // 
            // Clear_button
            // 
            this.Clear_button.Location = new System.Drawing.Point(278, 114);
            this.Clear_button.Name = "Clear_button";
            this.Clear_button.Size = new System.Drawing.Size(75, 23);
            this.Clear_button.TabIndex = 10;
            this.Clear_button.Text = "Clear";
            this.Clear_button.UseVisualStyleBackColor = true;
            this.Clear_button.Click += new System.EventHandler(this.Clear_button_Click);
            // 
            // Setting_button
            // 
            this.Setting_button.Location = new System.Drawing.Point(253, 56);
            this.Setting_button.Name = "Setting_button";
            this.Setting_button.Size = new System.Drawing.Size(100, 23);
            this.Setting_button.TabIndex = 4;
            this.Setting_button.Text = "Auto setting";
            this.Setting_button.UseVisualStyleBackColor = true;
            this.Setting_button.Click += new System.EventHandler(this.Setting_button_Click);
            // 
            // Get_DC_button
            // 
            this.Get_DC_button.Location = new System.Drawing.Point(292, 85);
            this.Get_DC_button.Name = "Get_DC_button";
            this.Get_DC_button.Size = new System.Drawing.Size(61, 23);
            this.Get_DC_button.TabIndex = 5;
            this.Get_DC_button.Text = "Get DC";
            this.Get_DC_button.UseVisualStyleBackColor = true;
            this.Get_DC_button.Click += new System.EventHandler(this.getDC_button_Click);
            // 
            // mo_textBox
            // 
            this.mo_textBox.Location = new System.Drawing.Point(89, 22);
            this.mo_textBox.Name = "mo_textBox";
            this.mo_textBox.Size = new System.Drawing.Size(100, 23);
            this.mo_textBox.TabIndex = 7;
            this.mo_textBox.Text = "T01094A0";
            this.mo_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mo_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mo_textBox_KeyDown);
            // 
            // product_name_textBox
            // 
            this.product_name_textBox.Location = new System.Drawing.Point(89, 66);
            this.product_name_textBox.Name = "product_name_textBox";
            this.product_name_textBox.ReadOnly = true;
            this.product_name_textBox.Size = new System.Drawing.Size(100, 23);
            this.product_name_textBox.TabIndex = 8;
            this.product_name_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LOW_button);
            this.groupBox1.Controls.Add(this.HIGH_button);
            this.groupBox1.Location = new System.Drawing.Point(387, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 71);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Relay";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Get_DC_button);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.Clear_button);
            this.groupBox2.Controls.Add(this.Setting_button);
            this.groupBox2.Controls.Add(this.Show_receive_message);
            this.groupBox2.Controls.Add(this.SendCommend);
            this.groupBox2.Location = new System.Drawing.Point(403, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 155);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Commend";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.station_number_comboBox);
            this.groupBox3.Controls.Add(this.total_textBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.mo_textBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.product_name_textBox);
            this.groupBox3.Location = new System.Drawing.Point(29, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 246);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SQL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Station：";
            // 
            // station_number_comboBox
            // 
            this.station_number_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.station_number_comboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.station_number_comboBox.FormattingEnabled = true;
            this.station_number_comboBox.Location = new System.Drawing.Point(263, 22);
            this.station_number_comboBox.Name = "station_number_comboBox";
            this.station_number_comboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.station_number_comboBox.Size = new System.Drawing.Size(68, 21);
            this.station_number_comboBox.TabIndex = 12;
            // 
            // total_textBox
            // 
            this.total_textBox.Location = new System.Drawing.Point(89, 104);
            this.total_textBox.Name = "total_textBox";
            this.total_textBox.ReadOnly = true;
            this.total_textBox.Size = new System.Drawing.Size(100, 23);
            this.total_textBox.TabIndex = 28;
            this.total_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Total：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "機種名稱：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "工單：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Database：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Total：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Total：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 461);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Relay);
            this.Name = "Form1";
            this.Text = "Relay";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Relay.ResumeLayout(false);
            this.Relay.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button Connect_button;
        private System.Windows.Forms.ComboBox buadrate_comboBox;
        private System.Windows.Forms.ComboBox port_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox Relay;
        private System.Windows.Forms.Button Disconnect_button;
        private System.Windows.Forms.Button LOW_button;
        private System.Windows.Forms.Button HIGH_button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button SendCommend;
        private System.Windows.Forms.TextBox Show_receive_message;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Clear_button;
        private System.Windows.Forms.Button Setting_button;
        private System.Windows.Forms.Button Get_DC_button;
        private System.Windows.Forms.TextBox mo_textBox;
        private System.Windows.Forms.TextBox product_name_textBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox total_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox station_number_comboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

