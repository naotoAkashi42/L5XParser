namespace Utilities
{
    public static class FileIo
    {
        public static FileInfo GetTargetFile(string ext)
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = ext;
                var result = form.ShowDialog();

                if (result == DialogResult.Cancel) return null;

                return new FileInfo(form.FileName);
            }
        }

        public static IReadOnlyList<FileInfo> GetTargetFiles(string ext)
        {
            var targetDir = GetTargetDir();
            var targetFiles = Directory.GetFiles(targetDir.FullName, ext, SearchOption.AllDirectories).Select(file => new FileInfo(file));
            return targetFiles.ToList();
        }

        private static DirectoryInfo GetTargetDir()
        {
            using (var form = new FolderBrowserDialog())
            {
                form.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var result = form.ShowDialog();

                if (result == DialogResult.Cancel) return null;

                return new DirectoryInfo(form.SelectedPath);
            }
        }
    }
}
