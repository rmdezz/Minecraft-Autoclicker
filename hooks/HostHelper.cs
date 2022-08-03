using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Drown
{
    internal class HostHelper
    {
        internal static string newLine = Environment.NewLine;
        internal static readonly string System32Folder = Environment.GetFolderPath(Environment.SpecialFolder.System);
        internal static readonly string HostsFile = System32Folder + "\\drivers\\etc\\hosts";

        internal static void AddEntry(string entry)
        {
            try
            {
                File.AppendAllText(HostsFile, newLine + entry);
            }
            catch { }
        }
        internal static string SanitizeEntry(string entry)
        {
            // remove multiple white spaces and keep only one
            return Regex.Replace(entry, @"\s{2,}", " ");
        }
    }
}
