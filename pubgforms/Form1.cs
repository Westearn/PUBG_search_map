using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using AutoUpdaterDotNET;
using System.IO;
using Telegram.Bot;
using Microsoft.Extensions.Configuration;

namespace pubgforms
{
    public partial class Form1 : Form
    {
        public TelegramBotClient botClient { get; set; }
        public Form1()
        {
            InitializeComponent();
            AutoUpdater.HttpUserAgent = Guid.NewGuid().ToString();
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Start("https://raw.githubusercontent.com/Westearn/search/main/version.xml");
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            botClient = new TelegramBotClient(configuration["TelegramBot:Token"]);
            button_Go.BringToFront();
            this.list_map.SetItemChecked(0, Properties.Settings.Default.TaegoVar);
            this.list_map.SetItemChecked(1, Properties.Settings.Default.KarakinVar);
            this.list_map.SetItemChecked(2, Properties.Settings.Default.ParamoVar);
            this.list_map.SetItemChecked(3, Properties.Settings.Default.DestonVar);
            this.list_map.SetItemChecked(4, Properties.Settings.Default.ErangelVar);
            this.list_map.SetItemChecked(5, Properties.Settings.Default.MiramarVar);
            this.list_map.SetItemChecked(6, Properties.Settings.Default.VikendiVar);
            this.list_map.SetItemChecked(7, Properties.Settings.Default.SanhokVar);
            this.list_map.SetItemChecked(8, Properties.Settings.Default.RondoVar);
            this.box_tg_id.Text = Properties.Settings.Default.TelegramID;
            this.FollowCheck.Checked = Properties.Settings.Default.FollowBool;
            this.LineCheck.Checked = Properties.Settings.Default.LineBool;
            this.FollowBox.Text = Properties.Settings.Default.FollowList;
        }

        private void button_Go_Click(object sender, EventArgs e)
        {
            Stop_button.BringToFront();
            variables.tg_id = this.box_tg_id.Text;
            bool check = false;
            for (byte i = 0; i <= 8; i++)
            {
                variables.maps[i] = this.list_map.GetItemChecked(i);
                if (variables.maps[i] == true)
                {
                    check = true;
                }
            }
            if (check == false)
            {
                MessageBox.Show("Необходимо выбрать хотя бы одну карту", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button_Go.BringToFront();
                return;
            }
            variables.Follow_Check = this.FollowCheck.Checked;
            variables.Line_Check = this.LineCheck.Checked;
            variables.Follow_Box = Convert.ToInt32(this.FollowBox.Text);
            variables.Box_30 = this.Box30sec.Checked;
            variables.source = new CancellationTokenSource();
            variables.token = variables.source.Token;
            defsearch.MMapSearch(botClient, variables.token);
        }

        private void all_save(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.TaegoVar = this.list_map.GetItemChecked(0);
            Properties.Settings.Default.KarakinVar = this.list_map.GetItemChecked(1);
            Properties.Settings.Default.ParamoVar = this.list_map.GetItemChecked(2);
            Properties.Settings.Default.DestonVar = this.list_map.GetItemChecked(3);
            Properties.Settings.Default.ErangelVar = this.list_map.GetItemChecked(4);
            Properties.Settings.Default.MiramarVar = this.list_map.GetItemChecked(5);
            Properties.Settings.Default.VikendiVar = this.list_map.GetItemChecked(6);
            Properties.Settings.Default.SanhokVar = this.list_map.GetItemChecked(7);
            Properties.Settings.Default.RondoVar = this.list_map.GetItemChecked(8);
            Properties.Settings.Default.TelegramID = this.box_tg_id.Text;
            Properties.Settings.Default.FollowBool = this.FollowCheck.Checked;
            Properties.Settings.Default.LineBool = this.LineCheck.Checked;
            Properties.Settings.Default.FollowList = this.FollowBox.Text;
            Properties.Settings.Default.Box30 = this.Box30sec.Checked;
            Properties.Settings.Default.Save();
        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            button_Go.BringToFront();
            variables.source.Cancel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            var resolution = Screen.PrimaryScreen.Bounds.Size;
            var ScreenWidth = resolution.Width;
            var ScreenHeight = resolution.Height;
            if (variables.mapping != null && variables.mapping == "ТАЭГО")
            {
                List <(float x, float y, float length)> podzemka_r = new List<(float x, float y, float length)> 
                                    { ( 814 * ScreenWidth / 2560f, 208 * ScreenHeight / 1440f, 0 ),
                                    ( 783 * ScreenWidth / 2560f, 486 * ScreenHeight / 1440f, 0 ),
                                    ( 741 * ScreenWidth / 2560f, 608 * ScreenHeight / 1440f, 0 ),
                                    ( 1016 * ScreenWidth / 2560f, 239 * ScreenHeight / 1440f, 0 ),
                                    ( 1191 * ScreenWidth / 2560f, 344 * ScreenHeight / 1440f, 0 ),
                                    ( 1413 * ScreenWidth / 2560f, 300 * ScreenHeight / 1440f, 0 ),
                                    ( 1780 * ScreenWidth / 2560f, 366 * ScreenHeight / 1440f, 0 ),
                                    ( 1816 * ScreenWidth / 2560f, 597 * ScreenHeight / 1440f, 0 ),
                                    ( 1621 * ScreenWidth / 2560f, 684 * ScreenHeight / 1440f, 0 ),
                                    ( 1342 * ScreenWidth / 2560f, 876 * ScreenHeight / 1440f, 0 ),
                                    ( 731 * ScreenWidth / 2560f, 927 * ScreenHeight / 1440f, 0 ),
                                    ( 987 * ScreenWidth / 2560f, 1141 * ScreenHeight / 1440f, 0 ),
                                    ( 1689 * ScreenWidth / 2560f, 983 * ScreenHeight / 1440f, 0 ),
                                    ( 1436 * ScreenWidth / 2560f, 1130 * ScreenHeight / 1440f, 0 ),
                                    ( 1680 * ScreenWidth / 2560f, 1271 * ScreenHeight / 1440f, 0 ) };
                defsearch.podzemka(podzemka_r);
            }
            else if (variables.mapping != null && variables.mapping == "ПАРАМО")
            {
                List<(float x, float y, float length)> podzemka_p = new List<(float x, float y, float length)>
                                    { ( 814 * ScreenWidth / 2560f, 208 * ScreenHeight / 1440f, 0 ),
                                    ( 783 * ScreenWidth / 2560f, 486 * ScreenHeight / 1440f, 0 ),
                                    ( 741 * ScreenWidth / 2560f, 608 * ScreenHeight / 1440f, 0 ),
                                    ( 1016 * ScreenWidth / 2560f, 239 * ScreenHeight / 1440f, 0 ),
                                    ( 1191 * ScreenWidth / 2560f, 344 * ScreenHeight / 1440f, 0 ),
                                    ( 1413 * ScreenWidth / 2560f, 300 * ScreenHeight / 1440f, 0 ),
                                    ( 1780 * ScreenWidth / 2560f, 366 * ScreenHeight / 1440f, 0 ),
                                    ( 1816 * ScreenWidth / 2560f, 597 * ScreenHeight / 1440f, 0 ),
                                    ( 1621 * ScreenWidth / 2560f, 684 * ScreenHeight / 1440f, 0 ),
                                    ( 1342 * ScreenWidth / 2560f, 876 * ScreenHeight / 1440f, 0 ),
                                    ( 731 * ScreenWidth / 2560f, 927 * ScreenHeight / 1440f, 0 ),
                                    ( 987 * ScreenWidth / 2560f, 1141 * ScreenHeight / 1440f, 0 ),
                                    ( 1689 * ScreenWidth / 2560f, 983 * ScreenHeight / 1440f, 0 ),
                                    ( 1436 * ScreenWidth / 2560f, 1130 * ScreenHeight / 1440f, 0 ),
                                    ( 1680 * ScreenWidth / 2560f, 1271 * ScreenHeight / 1440f, 0 ) };
                defsearch.podzemka(podzemka_p);
            }
        }
    }
}
