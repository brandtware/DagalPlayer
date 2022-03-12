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
            var title = new TextBlock() { Text = "Titel" };
            var tbTitle = new TextBox();

            var label = new TextBlock() { Text = "Beschreibung" };
            var textbox = new TextBox() { Text = ftvi.Description, TextWrapping = TextWrapping.Wrap, AcceptsReturn = true, VerticalScrollBarVisibility = ScrollBarVisibility.Visible, Height = 64 };

            textbox.DataContext = ftvi;
            textbox.SetBinding(TextBox.TextProperty,
                                new Binding()
                                {
                                    Path = new PropertyPath("Description"),
                                    Mode = BindingMode.TwoWay
                                });

            tbTitle.DataContext = ftvi;
            tbTitle.SetBinding(TextBox.TextProperty,
                                new Binding()
                                {
                                    Path = new PropertyPath("Text"),
                                    Mode = BindingMode.TwoWay
                                });
            // Bindung an TreeView
            tbTitle.TextChanged += (o, e) => { ftvi.Text = (o as TextBox)?.Text ?? ""; };

            container.Children.Add(title);
            container.Children.Add(tbTitle);
            container.Children.Add(label);
            container.Children.Add (textbox);
            
        }
    }
}
