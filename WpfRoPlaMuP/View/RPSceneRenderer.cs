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
    public class RPSceneRenderer
    {
        public RPSceneRenderer(RPSceneTreeViewItem stvi, StackPanel container)
        {
            var label = new TextBlock() { Text = "Beschreibung" };
            var textbox = new TextBox() { Text = stvi.Description, TextWrapping = TextWrapping.Wrap, AcceptsReturn = true, VerticalScrollBarVisibility = ScrollBarVisibility.Visible, Height = 64 };

            //TODO Binding

            container.Children.Add(label);
            container.Children.Add(textbox);

            for (int i = 0; i < stvi.Channels.Count; i++)
            {
                var channel = stvi.Channels[i];
                var trackName = new TextBlock() { Text = $"Spur {i+1}" };
                ListView lv = new ListView();
                foreach (var t in channel.Tracks)
                {
                    lv.Items.Add(t);
                }
            }
        }
    }
}
