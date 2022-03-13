using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DagalPlayer
{
    public class RPFolderTreeViewItem : TreeViewItem, IRPTreeViewItem
    {
        TextBlock tb = new TextBlock() { Text = "Neuer Ordner" };

        public RPFolderTreeViewItem()
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

        public override string ToString()
        {
            return $"F|{Text}|{Description.ReplaceLineEndings ("<br>")}\r\n";
        }

        public void FromString(string text)
        {
            var parts = text.Split('|');
            this.Text = parts[1];
            this.Description = parts[2].Replace ("<br>", Environment.NewLine);
        }
    }
}
