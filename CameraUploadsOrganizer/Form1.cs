using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CameraUploadsOrganizer
{
    public partial class Organizer : Form
    {
        private static readonly Regex R = new Regex(":");

        private readonly List<string> _ignoredFiles = new List<string>
        {
            ".dropbox",
            ".lnk"
        };

        private readonly List<string> _ignoredExtensions = new List<string>
        {
            ".ini"
        };

        public Organizer()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = false;
            backgroundWorker1.WorkerSupportsCancellation = false;
        }

        private void btnOpenUploadsDialog_Click(object sender, EventArgs e)
        {
            DialogResult result = fbdUploadsFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblSelectedUploadsLocation.Text = fbdUploadsFolder.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
               
        private void OrganizePhotos()
        {
            var photosFolder = fbdPhotosFolder.SelectedPath;

            var cameraUploadsPath = fbdUploadsFolder.SelectedPath;

            var archivePath = Path.Combine(cameraUploadsPath, "archive");

            if (!Directory.Exists(archivePath))
            {
                Directory.CreateDirectory(archivePath);
            }

            var files = Directory.GetFiles(cameraUploadsPath);

            foreach (var originalFilePath in files)
            {
                if (_ignoredFiles.Any(a => originalFilePath.EndsWith(a)))
                {
                    continue;
                }

                var extension = Path.GetExtension(originalFilePath);

                if (_ignoredExtensions.Contains(extension))
                {
                    continue;
                }

                var fileName = Path.GetFileName(originalFilePath);

                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilePath);

                DateTime dateTaken;

                if (!IsFileAMovie(originalFilePath) && CanGetDateFromImage(originalFilePath))
                {
                    dateTaken = GetDateTakenFromImage(Path.Combine(cameraUploadsPath, originalFilePath));
                }
                else if (CanGetDateFromFileName(fileNameWithoutExtension))
                {
                    dateTaken = GetDateFromFileName(fileNameWithoutExtension);
                }
                else if (CanGetDateFromUnderscoredFileName(fileNameWithoutExtension))
                {
                    dateTaken = GetDateFromUnderscoredFileName(fileNameWithoutExtension);
                }
                else
                {
                    dateTaken = File.GetCreationTime(originalFilePath);
                }

                var newFolderName = dateTaken.ToString("yyyy-MM-dd");

                if (!Directory.Exists(Path.Combine(photosFolder, newFolderName)))
                {
                    Directory.CreateDirectory(Path.Combine(photosFolder, newFolderName));
                }

                var newFileFullPath = Path.Combine(photosFolder, newFolderName, fileName);

                if (!File.Exists(newFileFullPath))
                {
                    File.Copy(originalFilePath, newFileFullPath, false);
                }

                var archiveFullPath = Path.Combine(archivePath, fileName);

                if (!File.Exists(archiveFullPath))
                {
                    File.Move(originalFilePath, archiveFullPath);
                }
            }
        }

        private bool IsFileAMovie(string filePath)
        {
            var extension = Path.GetExtension(filePath.ToLower());

            return extension == ".mov" || extension == ".mp4";
        }

        // 2011-02-11 19.22.56
        // IMG_20160529_184017
        private readonly string[] _dateTimeFormats =
        {
            "yyyy-MM-dd HH.mm.ss",
            "yyyyMMdd"
        };

        public bool CanGetDateFromFileName(string fileName)
        {
            DateTime date;
            return DateTime.TryParseExact(fileName, _dateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        public DateTime GetDateFromFileName(string fileName)
        {
            DateTime date;
            DateTime.TryParseExact(fileName, _dateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            return date;
        }

        public bool CanGetDateFromUnderscoredFileName(string fileName)
        {
            var strings = fileName.Split('_');

            if (strings.Length < 2)
            {
                return false;
            }

            DateTime date;
            return DateTime.TryParseExact(strings[1], _dateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        public DateTime GetDateFromUnderscoredFileName(string fileName)
        {
            var strings = fileName.Split('_');

            DateTime date;
            DateTime.TryParseExact(strings[1], _dateTimeFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            return date;
        }

        public static DateTime GetDateTakenFromVideo(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var myImage = Image.FromStream(fs, false, false))
            {
                var propItem = myImage.GetPropertyItem(36867);
                var dateTaken = R.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                return DateTime.Parse(dateTaken);
            }
        }

        public static bool CanGetDateFromImage(string path)
        {
            var extension = Path.GetExtension(path);

            if (extension == ".heic")
            {
                return false;
            }

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var myImage = Image.FromStream(fs, false, false))
            {
                return myImage.PropertyIdList.Contains(36867);
            }
        }

        public static DateTime GetDateTakenFromImage(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (var image = Image.FromStream(fileStream, false, false))
            {
                var propertyItem = image.GetPropertyItem(36867);
                var dateTaken = R.Replace(Encoding.UTF8.GetString(propertyItem.Value), "-", 2);
                return DateTime.Parse(dateTaken);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = fbdPhotosFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                lblSelectedPhotosLocation.Text = fbdPhotosFolder.SelectedPath;
            }
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            OrganizePhotos();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            MessageBox.Show("Done Organizing");
        }
    }
}
