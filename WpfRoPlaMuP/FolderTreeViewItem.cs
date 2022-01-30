using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DagalPlayer
{
    public class FolderTreeViewItem : TreeViewItem, IRPTreeViewItem
    {
        TextBlock tb = new TextBlock() { Text = "Neuer Ordner" };

        public FolderTreeViewItem()
        {
            StackPanel sp = new StackPanel() { Orientation = Orientation.Horizontal };
            Image img = new Image() { Source = new BitmapImage(new Uri(@"/Icons/Folder.png", UriKind.RelativeOrAbsolute)) };
            sp.Children.Add(img);
            sp.Children.Add(tb);

            this.Header = sp;
            this.IsExpanded = true;
        }

        public string Text 
        {
            get { return tb.Text; }
            set { tb.Text = value; } 
        }

        public string NodeType => "Ordner";
        public string Description { get; set; } = String.Empty;
    }
}
