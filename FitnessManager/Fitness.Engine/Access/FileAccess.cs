namespace Fitness.Engine.Access
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Helper class for working with text files.
    /// </summary>
    public static class FileAccess
    {
        /// <summary>
        /// Read some Text file.
        /// </summary>
        /// <param name="filePath">The path to the Text file.</param>
        /// <returns>Returns a list of strings which represents all rows from the file.</returns>
        public static List<string> ReadText(string filePath)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("windows-1251")))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Add(line);
                    line = reader.ReadLine();
                }
            }

            return result;
        }

        /// <summary>
        /// Writes some string in an Text file.
        /// </summary>
        /// <param name="text">The string.</param>
        /// <param name="filePath">The path where the Text file will be saved.</param>
        /// <param name="append">To append data to the file use 'true' (default) or 'false' to overwrite it.</param>
        public static void WriteText(string text, string filePath, bool append = true)
        {
            using (var writer = new StreamWriter(filePath, append, Encoding.GetEncoding("windows-1251")))
            {
                writer.WriteLine(text);
            }
        }

        /// <summary>
        /// Writes some list of strings in an Text file.
        /// </summary>
        /// <param name="list">The list of strings.</param>
        /// <param name="filePath">The path where the Text file will be saved.</param>
        /// <param name="append">To append data to the file use 'true' (default) or 'false' to overwrite it.</param>
        public static void WriteText(List<string> list, string filePath, bool append = true)
        {
            using (var writer = new StreamWriter(filePath, append, Encoding.GetEncoding("windows-1251")))
            {
                foreach (var line in list) writer.WriteLine(line);
            }
        }
    }
}