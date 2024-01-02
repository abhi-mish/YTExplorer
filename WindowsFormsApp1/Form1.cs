using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YouTubeApiSharp;
using System.IO;
using System.Net;

/*
 * Todo:
 * Channel content sorting
 * for both text boxes, check input url is valid (x all 3 corresponding buttons)
 * Get 720p working
 * support for channels w/ >200 items
 * document testcases
 * consider making channel content rendering non-blocking. timer-based progress?
 * on channel view - investigate why labels are indented inwards sometimes
 * playlist support - ditto to channel?
 * speed up download on large files - parallelize chunks?
 */

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string DownloadPath;
        SortOrder SortBy_Channels;
        List<DownloadQObject> Downloads;
        System.Windows.Forms.Timer DownloadQRefreshTimer;
        bool fChannel_DisplayThumbs;
        bool fTestMode;
        enum SortOrder
        {
            SizeAsc = 1,
            SizeDesc,
            DateAsc,
            DateDesc
        };
        public Form1()
        {
            InitializeComponent();
            DownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\YTU";
            Downloads = new List<DownloadQObject>();
            DownloadQRefreshTimer = new System.Windows.Forms.Timer();
            DownloadQRefreshTimer.Enabled = false;
            fChannel_DisplayThumbs = checkBox1.Checked;
            //ChannelSortCommon(); 
            fTestMode = false;
            InformUser_Videos("Download Path defaults to:" + DownloadPath);
        }

        private void InformUser_Videos(string S)
        {
            textBox2.AppendText(S + Environment.NewLine);
            textBox2.ScrollToCaret();
        }
        private void InformUser_Channels(string S)
        {
            textBox4.AppendText(S + Environment.NewLine);
            textBox4.ScrollToCaret();
        }

        //Set Download Path
        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                DownloadPath = folderBrowserDialog1.SelectedPath;
                InformUser_Videos("Download Path set to: " + DownloadPath);
            }
        }

        //Download video
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (fTestMode) textBox1.Text = "https://www.youtube.com/watch?v=-gOqkKSq8bw";
                else
                {
                    InformUser_Videos("Enter a URL to download");
                    return;
                }
            }
            if (DownloadPath == "")
            {
                InformUser_Videos("Choose a download location");
                return;
            }

            string Title = AddToDownloadQueue(textBox1.Text, true);

            if (Title == "ALREADYEXISTS")
                InformUser_Videos("That item already exists at the specified location.");
            else InformUser_Videos("Video download added to queue: " + Title);
        }

        //Download audio
        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (fTestMode) textBox1.Text = "https://www.youtube.com/watch?v=-gOqkKSq8bw";
                else
                {
                    InformUser_Videos("Enter a URL to download");
                    return;
                }
            }
            if (DownloadPath == "")
            {
                InformUser_Videos("Choose a download location");
                return;
            }

            string Title = AddToDownloadQueue(textBox1.Text, false);

            if (Title == "ALREADYEXISTS")
                InformUser_Videos("That item already exists at the specified location.");
            else InformUser_Videos("Audio download added to queue: " + Title);
        }

        bool ChannelPlaylistCommonStart()
        {
            bool fPlaylistMode = radioButton_playlist.Checked; // else channel mode

            if (textBox3.Text == "")
            {
                if (fTestMode)
                {
                    if (fPlaylistMode)
                        textBox3.Text = "https://www.youtube.com/watch?v=oOUGLKf8uU0&list=PLRQ6FzYGa8ru8eSdpiSvKDFy7FpRcpa2A&pp=iAQB";
                    //"https://www.youtube.com/watch?v=d08rlbrUOco&list=PLXpRJ1wzKbm5Me8WTtEhYCSew6uAb2NdX";
                    else textBox3.Text = "https://www.youtube.com/@amphone-wc2pt";
                    //"https://www.youtube.com/@itsvictoriaytfrazier1906/";

                    InformUser_Channels("Getting details for " + (fPlaylistMode ? "playlist" : "channel"));
                }
                else
                    InformUser_Channels("Enter a URL");
            }

            button4.Enabled = false;

            return fPlaylistMode;
        }

        void ChannelPlaylistCommonEnd()
        {
            button4.Enabled = true;
        }

        //Channel/Playlist
        private async void Button4_Click(object sender, EventArgs e)
        {
            bool fPlaylistMode = ChannelPlaylistCommonStart();
            if (textBox3.Text == "")
            {
                ChannelPlaylistCommonEnd();
                return;
            }

            // Items - todo: consider user-configurable input for channels w/ greater than 200 items. Hardcoded for now
            int citems = 50;

            PlaylistItemsSearch playlistItems = new PlaylistItemsSearch();
            ChannelItemsSearch channelItems = new ChannelItemsSearch();

            var Items = (fPlaylistMode ? (await playlistItems.GetPlaylistItems(textBox3.Text, citems)) : (await channelItems.GetChannelItems(textBox3.Text, citems)));

            PictureBox[] Pic = new PictureBox[Items.Count];
            Label[] L = new Label[Items.Count];
            System.Windows.Forms.Button[] Video = new System.Windows.Forms.Button[Items.Count];
            System.Windows.Forms.Button[] Audio = new System.Windows.Forms.Button[Items.Count];

            tableLayoutPanel1.Visible = false;
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowCount = Items.Count;

            if (fChannel_DisplayThumbs)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            else tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute,0));

            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            int i = 0; 
            foreach (var item in Items)
            {
                if (i%10 == 0)
                    InformUser_Channels("Rendering channel/playlist content. Progress: " + i + "/" + Items.Count);

                L[i] = new Label();
                Video[i] = new System.Windows.Forms.Button();
                Audio[i] = new System.Windows.Forms.Button();

                if (fChannel_DisplayThumbs)
                {
                    Pic[i] = new PictureBox();
                    Pic[i].ImageLocation = item.getThumbnail();
                    Pic[i].WaitOnLoad = false;
                    Pic[i].AutoSize = true;
                }

                L[i].Text = "#" + (i + 1) + Environment.NewLine + 
                            "Duration: " + item.getDuration() + Environment.NewLine +
                            "Author:" + item.getAuthor() + Environment.NewLine +
                            "Title: " + item.getTitle() + Environment.NewLine;
                L[i].AutoSize = true;
                L[i].Anchor = AnchorStyles.None;

                Video[i].Text = "DownloadVideo";
                Video[i].AutoSize = true;
                Video[i].Tag = item.getUrl();
                Video[i].Click += new System.EventHandler(this.Channel_VideoButton_Click);
                Video[i].Enabled = true;
                Video[i].Anchor = AnchorStyles.None;

                Audio[i].Text = "DownloadAudio";
                Audio[i].AutoSize = true;
                Audio[i].Tag = item.getUrl();
                Audio[i].Click += new System.EventHandler(this.Channel_AudioButton_Click);
                Audio[i].Enabled = true;
                Audio[i].Anchor = AnchorStyles.None;

                tableLayoutPanel1.Controls.Add(L[i], 1, i);
                tableLayoutPanel1.Controls.Add(Video[i], 2, i);
                tableLayoutPanel1.Controls.Add(Audio[i], 3, i);

                if (fChannel_DisplayThumbs)
                {
                    tableLayoutPanel1.Controls.Add(Pic[i], 0, i);
                    Pic[i].Visible = true;
                }

                Video[i].Visible = true;
                Audio[i].Visible = true;
                L[i].Visible = true;

                i++;
            }
            InformUser_Channels("Rendering complete");
            
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ResumeLayout();
            tableLayoutPanel1.Visible = true;

            Items.Clear();

            ChannelPlaylistCommonEnd();
        }

        private void Channel_VideoButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button B = sender as System.Windows.Forms.Button;

            B.Enabled = false;
            string url = (string)(B.Tag); 

            string Title = AddToDownloadQueue(url, true);

            if (Title == "ALREADYEXISTS")
                InformUser_Channels("That item already exists at the specified location.");
            else InformUser_Channels("Video download added to queue: " + Title);
        }

        private void Channel_AudioButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button B = sender as System.Windows.Forms.Button;

            B.Enabled = false;
            string url = (string)(B.Tag);

            string Title = AddToDownloadQueue(url, false);

            if (Title == "ALREADYEXISTS")
                InformUser_Channels("That item already exists at the specified location.");
            else InformUser_Channels("Audio download added to queue: " + Title);
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Size.Checked) ChannelSortCommon();
        }
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_Date.Checked) ChannelSortCommon();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            ChannelSortCommon();
        }

        private void ChannelSortCommon()
        {
            if (radioButton_Date.Checked)
                SortBy_Channels = (checkBox_Asc.Checked ? SortOrder.DateAsc : SortOrder.DateDesc);
            else if (radioButton_Size.Checked)
                SortBy_Channels = (checkBox_Asc.Checked ? SortOrder.SizeAsc : SortOrder.SizeDesc);

            InformUser_Channels("Sort order:" + SortBy_Channels);
        }

        private string AddToDownloadQueue(string url, bool fVideo)
        {
            if (DownloadPath == "")
                DownloadPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            /*
            * Get the available video formats.
            * We'll work with them in the video and audio download examples.
            */
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(url);
            VideoInfo video;

            // Select the first .mp4 video with 720p resolution. 0p for audio
            // todo - only 360p working currently. check why 720p isn't. ideally, download the highest quality res by default
            video = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == (fVideo?360:0));

            // Decrypt only if needed
            if (video.RequiresDecryption)
            {
                DownloadUrlResolver.DecryptDownloadUrl(video);
            }

            DownloadQObject DQO = new DownloadQObject();

            DQO.Title = video.Title;
            DQO.D = new Downloader();
            DQO.PB = new ProgressBar();
            Downloads.Add(DQO);

            Task.Run(() => DQO.D.DownloadFile(video.DownloadUrl, video.Title, fVideo, DownloadPath, video.VideoExtension));

            if (DQO.D.AlreadyExists) return "ALREADYEXISTS";
            //TODO this doesn't work yet - need to add synchronization. 

            //VISUALS below
            label3.Visible = true;

            FlowLayoutPanel FP = new FlowLayoutPanel();

            Label L = new Label();
            L.AutoSize = true;
            L.Text = DQO.Title;

            DQO.PB.Minimum = 0;
            DQO.PB.Maximum = 100;
            DQO.PB.Value = DQO.D.Progress;

            FP.FlowDirection = FlowDirection.LeftToRight;
            FP.AutoSize = true;

            L.Visible = true;
            DQO.PB.Visible = true;
            FP.Visible = true;

            FP.Controls.Add(DQO.PB);
            FP.Controls.Add(L);

            FP.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; 

            flowLayoutPanel1.Controls.Add(FP);

            if (DownloadQRefreshTimer.Enabled == false)
            {
                DownloadQRefreshTimer.Interval = 1000; // 1sec
                DownloadQRefreshTimer.Tick += new EventHandler(DownloadQRefreshTimer_Tick);
                DownloadQRefreshTimer.Enabled = true;
                DownloadQRefreshTimer.Start();
            }

            return DQO.Title;
        }

        void DownloadQRefreshTimer_Tick(object sender, EventArgs e)
        {
            bool fAllComplete = true;
            int cOutstanding = 0;

            foreach (var item in Downloads)
            {
                item.PB.Value = item.D.Progress;
                fAllComplete &= item.D.Complete;
                if (item.D.Complete == false) cOutstanding++;
            }

            if (fAllComplete == true)
            {
                DownloadQRefreshTimer.Stop();
                DownloadQRefreshTimer.Enabled = false;
                DownloadQRefreshTimer.Dispose();
            }

            label3.Text = "Download Queue (" + cOutstanding + " outstanding):";
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            fChannel_DisplayThumbs = checkBox1.Checked;
        }

        private async void DownloadAllCommon(bool fVideo)
        {
            bool fPlaylistMode = ChannelPlaylistCommonStart();

            if (textBox3.Text == "")
            {
                ChannelPlaylistCommonEnd();
                return;
            }

            // Items - todo: consider user-configurable input for channels w/ greater than 200 items. Hardcoded for now
            int citems = 50;

            PlaylistItemsSearch playlistItems = new PlaylistItemsSearch();
            ChannelItemsSearch channelItems = new ChannelItemsSearch();

            var Items = (fPlaylistMode ? (await playlistItems.GetPlaylistItems(textBox3.Text, citems)) : (await channelItems.GetChannelItems(textBox3.Text, citems)));

            int i = 1;

            foreach (var item in Items)
            {
                string Title = AddToDownloadQueue(item.getUrl(), fVideo);

                if (Title == "ALREADYEXISTS")
                    InformUser_Channels("That item already exists at the specified location.");
                else InformUser_Channels((fVideo ? "Video" : "Audio") + " download added to queue (" + i + "/" + Items.Count + "): " + Title);

                i++;
            }

            ChannelPlaylistCommonEnd();
        }

        private void button_DLAllAudio_Click(object sender, EventArgs e)
        {
            DownloadAllCommon(false);
        }
        private void button_DLAllVideo_Click(object sender, EventArgs e)
        {
            DownloadAllCommon(true);
        }
    }

    public class DownloadQObject
    {
        public string Title;
        public Downloader D;
        public ProgressBar PB;
    }
}
