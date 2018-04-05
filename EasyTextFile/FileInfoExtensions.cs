using System.IO;

namespace EasyTextFile
{
    public static class FileInfoExtensions
    {
        public static string[] ReadContent(this FileInfo fileInfo)
        {
            return fileInfo.FullName.LoadFile();
        }
    }
}