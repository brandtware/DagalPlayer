using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DagalPlayer
{
    public class RPSceneTreeViewItem : TreeViewItem, IRPTreeViewItem
    {
        TextBlock headerText = new TextBlock();

        public RPSceneTreeViewItem()
        {
            this.headerText.Text = "Neue Szene";
            this.Header = headerText;
        }

        public string Text
        {
            get 
            {
                return headerText.Text;
            }
            set
            {
                headerText.Text = value;
            }
        }


        public string NodeType => "Szene";
        public List<RPAudioPlayer> Channels { get; set; } = new List<RPAudioPlayer>();
        public string Description { get; set; } = String.Empty;
    }
}
