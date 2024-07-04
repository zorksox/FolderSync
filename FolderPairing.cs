namespace FolderSync
{
    public partial class FolderPairing : UserControl
    {
        public FolderSync folderSyncForm;
        public FileSystemWatcher watcher;
        public string source, destination;

        public FolderPairing(string source, string destination, FolderSync folderSyncForm)
        {
            InitializeComponent();
            this.source = source;
            this.destination = destination;
            sourceLabel.Text = "Source: " + source;
            destinationLabel.Text = "Destination: " + destination;
            this.folderSyncForm = folderSyncForm;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            folderSyncForm.RemovePairing(this);
            Dispose();
        }
    }
}
