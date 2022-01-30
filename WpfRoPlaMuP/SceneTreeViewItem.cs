using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DagalPlayer
{
    public class SceneTreeViewItem : TreeViewItem, IRPTreeViewItem
    {
        public SceneTreeViewItem()
        {
            this.Header = "Neue Szene";
        }

        public string Text
        {
            get { return this.Header?.ToString() ?? String.Empty; }
            set { this.Header = value; }
        }

        public string NodeType => "Szene";
        public List<RPAudioTrack> Tracks { get; set; } = new List<RPAudioTrack>();
        public string Description { get; set; } = String.Empty;
    }
}
