using IWshRuntimeLibrary;
using System.Drawing;
using System.IO;
using File = System.IO.File;

namespace LeonTools.Common
{
    public static class FileHelper
    {
        public static string GetFileRealPath(string filePathOrShortcutPath)
        {
            return Path.GetExtension(filePathOrShortcutPath).ToUpper().Equals(".LNK")
                ? GetRealPathByShortcut(filePathOrShortcutPath)
                : filePathOrShortcutPath;
        }

        private static string GetRealPathByShortcut(string shortcut)
        {
            if (File.Exists(shortcut))
            {
                var shell = new WshShell();
                var wshShortcut = (IWshShortcut)shell.CreateShortcut(shortcut);
                if (File.Exists(wshShortcut.TargetPath))
                {
                    return wshShortcut.TargetPath;
                }
                string fileName = Path.GetFileName(wshShortcut.TargetPath);
                string path = wshShortcut.WorkingDirectory;
                if (!Directory.Exists(path))
                {
                    path = Path.GetDirectoryName(wshShortcut.TargetPath);
                    if (!Directory.Exists(path))
                    {
                        return wshShortcut.TargetPath;
                    }
                }
                return Path.Combine(path, fileName);
            }

            return shortcut;
        }

        public static Icon GetShortcurIcoFromFilePath(string filepath)
        {
            if (File.Exists(filepath))
            {
                return System.Drawing.Icon.ExtractAssociatedIcon(filepath);
            }
            return null;
        }
    }
}