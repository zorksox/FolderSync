namespace FolderSync
{
    partial class FolderPairing
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sourceLabel = new Label();
            destinationLabel = new Label();
            deleteButton = new Button();
            SuspendLayout();
            // 
            // sourceLabel
            // 
            sourceLabel.AutoSize = true;
            sourceLabel.Font = new Font("Segoe UI", 12F);
            sourceLabel.Location = new Point(0, 0);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new Size(334, 21);
            sourceLabel.TabIndex = 0;
            sourceLabel.Text = "Source: svjvsdlvsdfksdalkvsdfklvgdskvdfslkbvn";
            // 
            // destinationLabel
            // 
            destinationLabel.AutoSize = true;
            destinationLabel.Font = new Font("Segoe UI", 12F);
            destinationLabel.Location = new Point(0, 21);
            destinationLabel.Name = "destinationLabel";
            destinationLabel.Size = new Size(312, 21);
            destinationLabel.TabIndex = 1;
            destinationLabel.Text = "Destination: sdgjsjdsgsdhgksdhglskdhgdskf";
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 15F);
            deleteButton.Location = new Point(518, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(42, 39);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "X";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // FolderPairing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(deleteButton);
            Controls.Add(destinationLabel);
            Controls.Add(sourceLabel);
            Name = "FolderPairing";
            Size = new Size(563, 46);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label sourceLabel;
        private Label destinationLabel;
        private Button deleteButton;
    }
}
