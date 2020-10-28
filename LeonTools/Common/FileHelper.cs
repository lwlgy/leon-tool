using System.IO;

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
            // IWshShortcut _shortcut = null;
            // IWshShell_Class shell = new IWshShell_Class();
            // if (File.Exists(shortcut))
            //     _shortcut = shell.CreateShortcut(shortcut) as IWshShortcut;
            // return _shortcut.TargetPath;
            return shortcut;
        }
    }
}