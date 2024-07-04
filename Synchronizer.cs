using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace FolderSync
{
    internal static class Synchronizer
    {
        public static int filesSynced;
        static Button button;

        public static void Start(string source, string destination, Button button)
        {
            Synchronizer.button = button;
            filesSynced = 0;

            if (File.Exists(source))
            {
                SyncFile(source, destination);
            }
            else if (Directory.Exists(source))
            {
                SyncDirectories(source, destination);
            }
            else
            {
                throw new FileNotFoundException($"The source path '{source}' does not exist.");
            }
        }

        private static void SyncFile(string sourceFilePath, string destFilePath)
        {
            string destDir = Path.GetDirectoryName(destFilePath);

            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            if (!File.Exists(destFilePath) || IsFileDifferent(sourceFilePath, destFilePath))
            {
                File.Copy(sourceFilePath, destFilePath, true);
                File.SetAttributes(destFilePath, FileAttributes.ReadOnly); // Set the copied file as read-only
                button.Text = (filesSynced++) + "";
            }
        }

        private static void SyncDirectories(string sourceDir, string destDir)
        {
            // Create the destination directory if it doesn't exist
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            // Copy and update files
            foreach (string sourceFilePath in Directory.GetFiles(sourceDir))
            {
                string fileName = Path.GetFileName(sourceFilePath);
                string destFilePath = Path.Combine(destDir, fileName);

                SyncFile(sourceFilePath, destFilePath);
            }

            // Copy and update subdirectories
            foreach (string sourceSubDir in Directory.GetDirectories(sourceDir))
            {
                string dirName = Path.GetFileName(sourceSubDir);
                string destSubDir = Path.Combine(destDir, dirName);

                // Recursively sync subdirectories
                SyncDirectories(sourceSubDir, destSubDir);
            }

            // Delete files and directories that no longer exist in the source
            foreach (string destFilePath in Directory.GetFiles(destDir))
            {
                string fileName = Path.GetFileName(destFilePath);
                string sourceFilePath = Path.Combine(sourceDir, fileName);

                if (!File.Exists(sourceFilePath))
                {
                    File.SetAttributes(destFilePath, FileAttributes.Normal); // Remove read-only attribute before deletion
                    File.Delete(destFilePath);
                    button.Text = (filesSynced++) + "";
                }
            }

            foreach (string destSubDir in Directory.GetDirectories(destDir))
            {
                string dirName = Path.GetFileName(destSubDir);
                string sourceSubDir = Path.Combine(sourceDir, dirName);

                if (!Directory.Exists(sourceSubDir))
                {
                    Directory.Delete(destSubDir, true);
                    button.Text = (filesSynced++) + "";
                }
            }
        }

        private static bool IsFileDifferent(string sourceFilePath, string destFilePath)
        {
            FileInfo sourceFileInfo = new FileInfo(sourceFilePath);
            FileInfo destFileInfo = new FileInfo(destFilePath);

            // Compare file sizes and last modified timestamps
            return sourceFileInfo.Length != destFileInfo.Length || sourceFileInfo.LastWriteTime != destFileInfo.LastWriteTime;
        }
    }
}
