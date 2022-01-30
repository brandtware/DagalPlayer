using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DagalPlayer
{
    public class RPSceneTreeViewItem : TreeViewItem, IRPTreeViewItem
    {
        public RPSceneTreeViewItem()
        {
            this.Header = "Neue Szene";
        }

        public string Text
        {
            get { return this.Header?.ToString() ?? String.Empty; }
            set { this.Header = value; }
        }

        public string NodeType => "Szene";
        public List<RPAudioPlayer> Channels { get; set; } = new List<RPAudioPlayer>();
        public string Description { get; set; } = String.Empty;
    }
}
