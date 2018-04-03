using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EasyTextFile
{
    public static class EasyTextFileExtensions
    {
        public static void SaveToFile(this string[] lines, string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(lines.ToText());
            }
        }

        public static void SaveToFile(this string content, string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(content);
            }
        }

        public static string[] LoadFile(this string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd().ToLines();
            }
        }

        public static string[] ToLines(this string text)
        {
            return text.Split('\n');
        }

        public static string ToText(this string[] lines)
        {
            return string.Join("\n", lines);
        }

        public static string LoadFromEmbeddedResource(this string resourceName)
        {
            var namespc = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault()?.Namespace;
            using (var stream = Assembly
                .GetCallingAssembly()
                .GetManifestResourceStream($"{namespc}.{resourceName}"))
            {
                using (var reader = new StreamReader(stream ?? throw new InvalidOperationException()))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }
}