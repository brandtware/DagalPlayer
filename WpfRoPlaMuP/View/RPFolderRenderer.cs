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
    public class RPFolderRenderer
    {
        public RPFolderRenderer(RPFolderTreeViewItem ftvi, StackPanel container)
        {
            var label = new TextBlock() { Text = "Beschreibung" };
            var textbox = new TextBox() { Text = ftvi.Description, TextWrapping = TextWrapping.Wrap, AcceptsReturn = true, VerticalScrollBarVisibility = ScrollBarVisibility.Visible, Height = 64 };

            //TODO Binding

            container.Children.Add(label);
            container.Children.Add (textbox); 
        }
    }
}
