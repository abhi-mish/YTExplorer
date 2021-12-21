namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Video = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_Channel = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Asc = new System.Windows.Forms.CheckBox();
            this.radioButton_Date = new System.Windows.Forms.RadioButton();
            this.radioButton_Size = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage_Video.SuspendLayout();
            this.tabPage_Channel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_Video);
            this.tabControl1.Controls.Add(this.tabPage_Channel);
            this.tabControl1.Location = new System.Drawing.Point(-4, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 1046);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Video
            // 
            this.tabPage_Video.Controls.Add(this.label3);
            this.tabPage_Video.Controls.Add(this.flowLayoutPanel1);
            this.tabPage_Video.Controls.Add(this.textBox2);
            this.tabPage_Video.Controls.Add(this.button3);
            this.tabPage_Video.Controls.Add(this.button2);
            this.tabPage_Video.Controls.Add(this.button1);
            this.tabPage_Video.Controls.Add(this.textBox1);
            this.tabPage_Video.Controls.Add(this.label1);
            this.tabPage_Video.Location = new System.Drawing.Point(4, 29);
            this.tabPage_Video.Name = "tabPage_Video";
            this.tabPage_Video.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Video.Size = new System.Drawing.Size(800, 1013);
            this.tabPage_Video.TabIndex = 0;
            this.tabPage_Video.Text = "VideoView";
            this.tabPage_Video.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Download Queue:";
            this.label3.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 270);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(777, 732);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(20, 124);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(751, 110);
            this.textBox2.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(436, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 33);
            this.button3.TabIndex = 6;
            this.button3.Text = "GetAudio(mp3)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(252, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 33);
            this.button2.TabIndex = 5;
            this.button2.Text = "GetVideo(mp4)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 33);
            this.button1.TabIndex = 4;
            this.button1.Text = "SelectDownloadLocation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(649, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video URL:";
            // 
            // tabPage_Channel
            // 
            this.tabPage_Channel.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_Channel.Controls.Add(this.checkBox1);
            this.tabPage_Channel.Controls.Add(this.textBox4);
            this.tabPage_Channel.Controls.Add(this.groupBox1);
            this.tabPage_Channel.Controls.Add(this.button4);
            this.tabPage_Channel.Controls.Add(this.textBox3);
            this.tabPage_Channel.Controls.Add(this.label2);
            this.tabPage_Channel.Location = new System.Drawing.Point(4, 29);
            this.tabPage_Channel.Name = "tabPage_Channel";
            this.tabPage_Channel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Channel.Size = new System.Drawing.Size(800, 1013);
            this.tabPage_Channel.TabIndex = 1;
            this.tabPage_Channel.Text = "ChannelView";
            this.tabPage_Channel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 232);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 778F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(797, 778);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(129, 70);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(167, 24);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "DisplayThumbnails";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged_1);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(18, 122);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(756, 110);
            this.textBox4.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_Asc);
            this.groupBox1.Controls.Add(this.radioButton_Date);
            this.groupBox1.Controls.Add(this.radioButton_Size);
            this.groupBox1.Location = new System.Drawing.Point(311, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 54);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SortBy:";
            this.groupBox1.Visible = false;
            // 
            // checkBox_Asc
            // 
            this.checkBox_Asc.AutoSize = true;
            this.checkBox_Asc.Checked = true;
            this.checkBox_Asc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Asc.Location = new System.Drawing.Point(207, 17);
            this.checkBox_Asc.Name = "checkBox_Asc";
            this.checkBox_Asc.Size = new System.Drawing.Size(110, 24);
            this.checkBox_Asc.TabIndex = 9;
            this.checkBox_Asc.Text = "Ascending";
            this.checkBox_Asc.UseVisualStyleBackColor = true;
            this.checkBox_Asc.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // radioButton_Date
            // 
            this.radioButton_Date.AutoSize = true;
            this.radioButton_Date.Location = new System.Drawing.Point(132, 17);
            this.radioButton_Date.Name = "radioButton_Date";
            this.radioButton_Date.Size = new System.Drawing.Size(69, 24);
            this.radioButton_Date.TabIndex = 1;
            this.radioButton_Date.TabStop = true;
            this.radioButton_Date.Text = "Date";
            this.radioButton_Date.UseVisualStyleBackColor = true;
            this.radioButton_Date.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton_Size
            // 
            this.radioButton_Size.AutoSize = true;
            this.radioButton_Size.Checked = true;
            this.radioButton_Size.Location = new System.Drawing.Point(61, 17);
            this.radioButton_Size.Name = "radioButton_Size";
            this.radioButton_Size.Size = new System.Drawing.Size(65, 24);
            this.radioButton_Size.TabIndex = 0;
            this.radioButton_Size.TabStop = true;
            this.radioButton_Size.Text = "Size";
            this.radioButton_Size.UseVisualStyleBackColor = true;
            this.radioButton_Size.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "GetVideos";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(129, 20);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(645, 26);
            this.textBox3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Channel URL:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1041);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "YTUtils";
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Video.ResumeLayout(false);
            this.tabPage_Video.PerformLayout();
            this.tabPage_Channel.ResumeLayout(false);
            this.tabPage_Channel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Video;
        private System.Windows.Forms.TabPage tabPage_Channel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_Date;
        private System.Windows.Forms.RadioButton radioButton_Size;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox_Asc;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

