namespace pubgforms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button_Go = new System.Windows.Forms.Button();
            this.list_map = new System.Windows.Forms.CheckedListBox();
            this.FollowBox = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            this.Stop_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Box30sec = new System.Windows.Forms.CheckBox();
            this.box_tg_id = new System.Windows.Forms.TextBox();
            this.LineCheck = new System.Windows.Forms.CheckBox();
            this.FollowCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_Go
            // 
            button_Go.BackColor = System.Drawing.Color.LightGreen;
            button_Go.Cursor = System.Windows.Forms.Cursors.Hand;
            button_Go.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            button_Go.FlatAppearance.BorderSize = 2;
            button_Go.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LimeGreen;
            button_Go.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            button_Go.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button_Go.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            button_Go.Location = new System.Drawing.Point(11, 210);
            button_Go.Name = "button_Go";
            button_Go.Size = new System.Drawing.Size(270, 41);
            button_Go.TabIndex = 0;
            button_Go.Text = "Go!";
            button_Go.UseVisualStyleBackColor = false;
            button_Go.Click += new System.EventHandler(button_Go_Click);
            // 
            // list_map
            // 
            this.list_map.BackColor = System.Drawing.Color.LightSkyBlue;
            this.list_map.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_map.CheckOnClick = true;
            this.list_map.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.list_map.FormattingEnabled = true;
            this.list_map.Items.AddRange(new object[] {
            "Taego",
            "Karakin",
            "Paramo",
            "Deston",
            "Erangel",
            "Miramar",
            "Vikendi",
            "Sanhok",
            "Rondo"});
            this.list_map.Location = new System.Drawing.Point(297, 3);
            this.list_map.Name = "list_map";
            this.list_map.Size = new System.Drawing.Size(125, 236);
            this.list_map.TabIndex = 1;
            // 
            // FollowBox
            // 
            this.FollowBox.FormattingEnabled = true;
            this.FollowBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.FollowBox.Location = new System.Drawing.Point(89, 142);
            this.FollowBox.Name = "FollowBox";
            this.FollowBox.Size = new System.Drawing.Size(39, 24);
            this.FollowBox.TabIndex = 7;
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            button1.Cursor = System.Windows.Forms.Cursors.Hand;
            button1.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Location = new System.Drawing.Point(297, 220);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(110, 33);
            button1.TabIndex = 10;
            button1.Text = "Secret room";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(button1_Click);
            // 
            // Stop_button
            // 
            this.Stop_button.BackColor = System.Drawing.Color.Tomato;
            this.Stop_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Stop_button.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.Stop_button.FlatAppearance.BorderSize = 2;
            this.Stop_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.Stop_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.Stop_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop_button.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Stop_button.Location = new System.Drawing.Point(11, 210);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(270, 41);
            this.Stop_button.TabIndex = 11;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = false;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Telegram ID";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(270, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "PUBG (search map)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bot name";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(179, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 90);
            this.panel1.TabIndex = 13;
            // 
            // Box30sec
            // 
            this.Box30sec.AutoSize = true;
            this.Box30sec.Checked = global::pubgforms.Properties.Settings.Default.Box30;
            this.Box30sec.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::pubgforms.Properties.Settings.Default, "Box30", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Box30sec.Location = new System.Drawing.Point(11, 174);
            this.Box30sec.Name = "Box30sec";
            this.Box30sec.Size = new System.Drawing.Size(134, 20);
            this.Box30sec.TabIndex = 12;
            this.Box30sec.Text = "30 second alert";
            this.Box30sec.UseVisualStyleBackColor = true;
            // 
            // box_tg_id
            // 
            this.box_tg_id.Location = new System.Drawing.Point(11, 83);
            this.box_tg_id.Name = "box_tg_id";
            this.box_tg_id.Size = new System.Drawing.Size(270, 23);
            this.box_tg_id.TabIndex = 3;
            this.box_tg_id.Text = global::pubgforms.Properties.Settings.Default.TelegramID;
            // 
            // LineCheck
            // 
            this.LineCheck.AutoSize = true;
            this.LineCheck.Checked = global::pubgforms.Properties.Settings.Default.LineBool;
            this.LineCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::pubgforms.Properties.Settings.Default, "LineBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LineCheck.Location = new System.Drawing.Point(11, 114);
            this.LineCheck.Name = "LineCheck";
            this.LineCheck.Size = new System.Drawing.Size(147, 20);
            this.LineCheck.TabIndex = 9;
            this.LineCheck.Text = "Plane line search";
            this.LineCheck.UseVisualStyleBackColor = true;
            // 
            // FollowCheck
            // 
            this.FollowCheck.AutoSize = true;
            this.FollowCheck.Checked = global::pubgforms.Properties.Settings.Default.FollowBool;
            this.FollowCheck.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::pubgforms.Properties.Settings.Default, "FollowBool", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FollowCheck.Location = new System.Drawing.Point(11, 144);
            this.FollowCheck.Name = "FollowCheck";
            this.FollowCheck.Size = new System.Drawing.Size(72, 20);
            this.FollowCheck.TabIndex = 5;
            this.FollowCheck.Text = "Follow";
            this.FollowCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(420, 260);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Box30sec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Stop_button);
            this.Controls.Add(this.box_tg_id);
            this.Controls.Add(button1);
            this.Controls.Add(this.LineCheck);
            this.Controls.Add(this.FollowBox);
            this.Controls.Add(this.FollowCheck);
            this.Controls.Add(this.list_map);
            this.Controls.Add(button_Go);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "PUBG search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.all_save);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox list_map;
        private System.Windows.Forms.CheckBox FollowCheck;
        private System.Windows.Forms.ComboBox FollowBox;
        private System.Windows.Forms.CheckBox LineCheck;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.TextBox box_tg_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Box30sec;
        private System.Windows.Forms.Panel panel1;
        public static System.Windows.Forms.Button button1;
        public static System.Windows.Forms.Button button_Go;
    }
}

