namespace LeonTools.Model
{
    public class ToolItem
    {
        public ToolItem(string name, string filePath, string fileName, byte[] icon)
        {
            Name = name;
            FilePath = filePath;
            FileName = fileName;
            Icon = icon;
        }

        public ToolItem()
        {
        }


        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public byte[] Icon { get; set; }
    }
}