namespace Utilities
{
    public static class FileIo
    {
        public static IReadOnlyList<FileInfo> GetTargetFiles(string ext)
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = ext;
                form.Multiselect = true;
                var result = form.ShowDialog();

                if (result == DialogResult.Cancel) return null;
                var targetList = new List<FileInfo>();
                
                form.FileNames.ForEach(fileName => targetList.Add(new FileInfo(fileName)));
                
                return targetList;
            }
        }

        //public static IReadOnlyList<FileInfo> GetTargetFiles(string ext)
        //{
        //    var targetDir = GetTargetDir();
        //    var targetFiles = Directory.GetFiles(targetDir.FullName, ext, SearchOption.AllDirectories).Select(file => new FileInfo(file));
        //    return targetFiles.ToList();
        //}

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
