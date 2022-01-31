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
        public RPSceneTreeViewItem()
        {
            this.Text = "Neue Szene";
            this.DataContext = this;
            this.SetBinding(TreeViewItem.HeaderProperty,
                    new Binding()
                    {
                        Path = new PropertyPath("Text"),
                        Mode = BindingMode.TwoWay
                    });
        }

        public string Text { get; set; }

        public string NodeType => "Szene";
        public List<RPAudioPlayer> Channels { get; set; } = new List<RPAudioPlayer>();
        public string Description { get; set; } = String.Empty;
    }
}
