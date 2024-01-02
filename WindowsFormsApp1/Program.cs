using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Downloader
    {
        internal string Folder;
        public int Progress = 0;
        public bool Complete = false;
        public bool AlreadyExists = false;
        public static string makeFilenameValid(string file)
        {
            char replacementChar = '_';

            var blacklist = new HashSet<char>(Path.GetInvalidFileNameChars());

            var output = file.ToCharArray();

            for (int i = 0, ln = output.Length; i < ln; i++)
            {
                if (blacklist.Contains(output[i]))
                    output[i] = replacementChar;
            }

            return new string(output);
        }
        /// <summary>
        /// Download video file
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="Title"></param>
        /// <param name="isVideo"></param>
        /// <param name="Folder"></param>
        /// <param name="file_extension"></param>
        public void DownloadFile(string URL, string Title, bool isVideo, string Folder, string file_extension)
        {
            this.Folder = Folder;
            var directory = Folder;

            // Check if directory exists
            try
            {
                if (!System.IO.Directory.Exists(directory))
                    System.IO.Directory.CreateDirectory(directory);
            }
            catch { }

            string file = string.Empty;
            if (isVideo)
            {
                file = Path.Combine(directory, makeFilenameValid(Title).Replace("/", "")
                    .Replace(".", "")
                    .Replace("|", "")
                    .Replace("?", "")
                    .Replace("!", "") + file_extension);
            }
            else
            {
                file = Path.Combine(directory, makeFilenameValid(Title).Replace("/", "")
                    .Replace(".", "")
                    .Replace("|", "")
                    .Replace("?", "")
                    .Replace("!", "") + ".m4a");
            }

            // Check if file already exists
            this.AlreadyExists = false;
            if (!System.IO.File.Exists(file))
            {
                WebClient DownloadFile = new WebClient();

                DownloadFile.DownloadProgressChanged += (sender, e) => DownloadFileProgressChanged(sender, e, DownloadFile);

                // Event when download completed
                DownloadFile.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);

                // Start download
                DownloadFile.DownloadFileAsync(new Uri(URL), file, file + "|" + Title);
            }
            else this.AlreadyExists = true;
        }

        /// <summary>
        /// Download progress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="webClient"></param>
        private void DownloadFileProgressChanged(object sender, DownloadProgressChangedEventArgs e, WebClient webClient)
        {
            // Progress
            string s = e.UserState as String;
            string[] s_ = s.Split(new char[] { '|' });

            long ProgressPercentage = 0;

            try
            {
                var contentLength = webClient.ResponseHeaders.Get("Content-Length");
                var totalBytesToReceive = Convert.ToInt64(contentLength);

                ProgressPercentage = 100 * e.BytesReceived / totalBytesToReceive;
            }
            catch
            {
                ProgressPercentage = 0;
            }

            Progress = (int)ProgressPercentage;
        }

        /// <summary>
        /// Download file completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Split arguments
            string s = e.UserState as String;

            string[] s_ = s.Split(new char[] { '|' });

            // Directory
            var directory = this.Folder;

            // File
            string mediaFile = s_[0];

            // Filename
            var filename = mediaFile.Replace(Convert.ToString(directory), "").Replace("/", "");

            if (filename.EndsWith(".m4a"))
            {
                // Write m4a tags
                try
                {
                    string performer = "";
                    string title = "";

                    if (filename.Contains("-"))
                    {
                        string[] split = filename.Split(new char[] { '-' });

                        //performer = split[0].TrimStart().TrimEnd();

                        foreach (var s__ in split)
                        {
                            if (!s__.Contains(split[0]))
                                title += s__;
                        }

                        title = title.TrimStart().TrimEnd().Replace(".m4a", "").Replace(".mp3", "").Replace(".mp4", "").Replace(".m4u", "");
                    }
                    else
                    {
                        if (filename.Contains(" "))
                        {
                            string[] split = filename.Split(new char[] { ' ' });

                            //performer = split[0].TrimStart().TrimEnd();

                            foreach (var s__ in split)
                            {
                                if (!s__.Contains(split[0]))
                                    title += s__ + " ";
                            }

                            title = title.TrimStart().TrimEnd().Replace(".m4a", "").Replace(".mp3", "").Replace(".mp4", "").Replace(".m4u", "");
                        }
                        else
                        {
                            //performer = filename;
                            title = " ";
                        }
                    }

                    TagLib.File file = TagLib.File.Create(mediaFile);

                    file.Tag.Performers = new string[] { performer };
                    file.Tag.Title = title;

                    file.Save();
                }
                catch (Exception ex)
                {}
            }

            Complete = true;
        }
    }
}
