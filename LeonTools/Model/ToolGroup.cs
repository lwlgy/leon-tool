using System.Collections.Generic;

namespace LeonTools.Model
{
    public class ToolGroup
    {
        public string GroupName { get; set; }
        public int Index { get; set; }
        public List<ToolItem> Items { get; set; }
    }
}