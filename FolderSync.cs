using System.Text;

namespace FolderSync
{
    public partial class FolderSync : Form
    {
        bool isRunning = false;

        public FolderSync()
        {
            InitializeComponent();
            InitializeTrayIcon();
            timer.Start();
        }

        void InitializeTrayIcon()
        {
            contextMenu.Items.Add("Exit", null, OnExit);

            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.ContextMenuStrip = contextMenu;
            notifyIcon.Visible = true;
            notifyIcon.Text = "FolderSync";
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            Resize += new EventHandler(FormResize);
        }

        void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        void FormResize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        void OnExit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        void InitializeFileSystemWatchers()
        {
            foreach (FolderPairing folderPairing in flowLayoutPanel.Controls)
            {
                folderPairing.watcher = new FileSystemWatcher
                {
                    Path = folderPairing.source,
                    IncludeSubdirectories = true,
                    NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
                };

                folderPairing.watcher.Changed += (sender, e) => OnChanged(e, folderPairing.source, folderPairing.destination);
                folderPairing.watcher.Created += (sender, e) => OnChanged(e, folderPairing.source, folderPairing.destination);
                folderPairing.watcher.Deleted += (sender, e) => OnDeleted(e, folderPairing.source, folderPairing.destination);
                folderPairing.watcher.Renamed += (sender, e) => OnRenamed(e, folderPairing.source, folderPairing.destination);

                folderPairing.watcher.EnableRaisingEvents = true;
            }
        }

        void StopFileSystemWatchers()
        {
            foreach (FolderPairing folderPairing in flowLayoutPanel.Controls)
            {
                folderPairing.watcher.Changed -= (sender, e) => OnChanged(e, folderPairing.source, folderPairing.destination);
                folderPairing.watcher.Created -= (sender, e) => OnChanged(e, folderPairing.source, folderPairing.destination);
                folderPairing.watcher.Deleted -= (sender, e) => OnDeleted(e, folderPairing.source, folderPairing.destination);
                folderPairing.watcher.Renamed -= (sender, e) => OnRenamed(e, folderPairing.source, folderPairing.destination);
                folderPairing.watcher.EnableRaisingEvents = false;
            }
        }

        private void OnChanged(FileSystemEventArgs e, string sourceFolder, string destinationFolder)
        {
            string relativePath = Path.GetRelativePath(sourceFolder, e.FullPath);
            string destPath = Path.Combine(destinationFolder, relativePath);
            string destDir = Path.GetDirectoryName(destPath);

            if (File.Exists(e.FullPath))
            {
                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);

                if (File.Exists(destPath))
                    File.SetAttributes(destPath, File.GetAttributes(destPath) & ~FileAttributes.ReadOnly);

                File.Copy(e.FullPath, destPath, true);
                File.SetAttributes(destPath, FileAttributes.ReadOnly);

                notifyIcon.ShowBalloonTip(1000, "File Synced", $"{e.FullPath} to {destPath}", ToolTipIcon.Info);
            }
        }

        private void OnDeleted(FileSystemEventArgs e, string sourceFolder, string destinationFolder)
        {
            string relativePath = Path.GetRelativePath(sourceFolder, e.FullPath);
            string destPath = Path.Combine(destinationFolder, relativePath);

            if (File.Exists(destPath))
            {
                File.SetAttributes(destPath, File.GetAttributes(destPath) & ~FileAttributes.ReadOnly);
                File.Delete(destPath);
                //notifyIcon.ShowBalloonTip(1000, "File Deleted", $"{destPath}", ToolTipIcon.Warning);
            }
        }


        private void OnRenamed(RenamedEventArgs e, string masterFolder, string slaveFolder)
        {
            string oldRelativePath = Path.GetRelativePath(masterFolder, e.OldFullPath);
            string newRelativePath = Path.GetRelativePath(masterFolder, e.FullPath);
            string oldDestPath = Path.Combine(slaveFolder, oldRelativePath);
            string newDestPath = Path.Combine(slaveFolder, newRelativePath);

            if (File.Exists(oldDestPath))
            {
                File.SetAttributes(oldDestPath, File.GetAttributes(oldDestPath) & ~FileAttributes.ReadOnly);

                File.Move(oldDestPath, newDestPath);
                File.SetAttributes(newDestPath, FileAttributes.ReadOnly);

                notifyIcon.ShowBalloonTip(1000, "File Renamed", $"{oldDestPath} to {newDestPath}", ToolTipIcon.Info);
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            bool valid = true;

            if (!File.Exists(sourceFolder.Text) && !Directory.Exists(sourceFolder.Text))
            {
                sourceFolder.BackColor = Color.Red;
                valid = false;
            }

            if (!Directory.Exists(destinationFolder.Text))
            {
                destinationFolder.BackColor = Color.Red;
                valid = false;
            }

            if (valid)
            {
                flowLayoutPanel.Controls.Add(new FolderPairing(sourceFolder.Text, destinationFolder.Text, this));
            }
        }

        private void sourceFolder_Click(object sender, EventArgs e)
        {
            sourceFolder.BackColor = Color.White;
        }

        private void destinationFolder_Click(object sender, EventArgs e)
        {
            destinationFolder.BackColor = Color.White;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            InitializeFileSystemWatchers();
            isRunning = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            startButton.Enabled = !isRunning && flowLayoutPanel.Controls.Count > 0;
            stopButton.Enabled = isRunning;
            syncButton.Enabled = !isRunning && flowLayoutPanel.Controls.Count > 0;
            loadButton.Enabled = !isRunning;
            saveButton.Enabled = flowLayoutPanel.Controls.Count > 0;
        }

        public void RemovePairing(FolderPairing folderPairing)
        {
            flowLayoutPanel.Controls.Remove(folderPairing);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopFileSystemWatchers();
            isRunning = false;
        }

        private async void syncButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;

            foreach (FolderPairing folderPairing in flowLayoutPanel.Controls)
                await Synchronizer.Start(folderPairing.source, folderPairing.destination, syncButton);

            notifyIcon.ShowBalloonTip(1000, "Complete", "Source and destination are synced", ToolTipIcon.Info);

            startButton.Enabled = true;
            syncButton.Text = "Sync All";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileStream file = File.Create(saveFileDialog.FileName);

                string data = "";
                foreach (FolderPairing folderPairing in flowLayoutPanel.Controls)
                    data += folderPairing.source + "," + folderPairing.destination + "\n";

                data = data.Trim();

                file.Write(Encoding.UTF8.GetBytes(data));
                file.Close();
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                flowLayoutPanel.Controls.Clear();
                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                foreach (string line in lines)
                {
                    string[] terms = line.Split(',');
                    string source = terms[0];
                    string destination = terms[1];
                    flowLayoutPanel.Controls.Add(new FolderPairing(source, destination, this));
                }
            }
        }
    }
}
