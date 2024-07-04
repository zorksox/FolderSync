namespace FolderSync
{
    partial class FolderSync
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            sourceFolder = new TextBox();
            destinationFolder = new TextBox();
            addButton = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            startButton = new Button();
            saveButton = new Button();
            loadButton = new Button();
            notifyIcon = new NotifyIcon(components);
            contextMenu = new ContextMenuStrip(components);
            stopButton = new Button();
            timer = new System.Windows.Forms.Timer(components);
            syncButton = new Button();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // sourceFolder
            // 
            sourceFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sourceFolder.BorderStyle = BorderStyle.FixedSingle;
            sourceFolder.Location = new Point(12, 12);
            sourceFolder.Name = "sourceFolder";
            sourceFolder.Size = new Size(595, 23);
            sourceFolder.TabIndex = 0;
            sourceFolder.Text = "c:\\source";
            sourceFolder.WordWrap = false;
            sourceFolder.Click += sourceFolder_Click;
            // 
            // destinationFolder
            // 
            destinationFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            destinationFolder.BorderStyle = BorderStyle.FixedSingle;
            destinationFolder.Location = new Point(12, 41);
            destinationFolder.Name = "destinationFolder";
            destinationFolder.Size = new Size(595, 23);
            destinationFolder.TabIndex = 1;
            destinationFolder.Text = "c:\\destination";
            destinationFolder.WordWrap = false;
            destinationFolder.Click += destinationFolder_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 70);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 2;
            addButton.Text = "Add item";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AutoScrollMinSize = new Size(0, 10);
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(12, 99);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(595, 263);
            flowLayoutPanel.TabIndex = 3;
            flowLayoutPanel.WrapContents = false;
            // 
            // startButton
            // 
            startButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startButton.Location = new Point(532, 375);
            startButton.Name = "startButton";
            startButton.Size = new Size(75, 39);
            startButton.TabIndex = 5;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            saveButton.Location = new Point(12, 375);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 39);
            saveButton.TabIndex = 3;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // loadButton
            // 
            loadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            loadButton.Location = new Point(93, 375);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 39);
            loadButton.TabIndex = 4;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.Text = "notifyIcon";
            notifyIcon.Visible = true;
            // 
            // contextMenu
            // 
            contextMenu.Name = "contextMenuStrip1";
            contextMenu.Size = new Size(61, 4);
            // 
            // stopButton
            // 
            stopButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            stopButton.Location = new Point(451, 375);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 39);
            stopButton.TabIndex = 6;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // syncButton
            // 
            syncButton.Anchor = AnchorStyles.Bottom;
            syncButton.Location = new Point(271, 375);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(75, 39);
            syncButton.TabIndex = 7;
            syncButton.Text = "Sync All";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += syncButton_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // FolderSync
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 426);
            Controls.Add(syncButton);
            Controls.Add(stopButton);
            Controls.Add(loadButton);
            Controls.Add(saveButton);
            Controls.Add(startButton);
            Controls.Add(flowLayoutPanel);
            Controls.Add(addButton);
            Controls.Add(destinationFolder);
            Controls.Add(sourceFolder);
            Name = "FolderSync";
            Text = "FolderSync";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox sourceFolder;
        private TextBox destinationFolder;
        private Button addButton;
        private FlowLayoutPanel flowLayoutPanel;
        private Button startButton;
        private Button saveButton;
        private Button loadButton;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        private Button stopButton;
        private System.Windows.Forms.Timer timer;
        private Button syncButton;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
    }
}
