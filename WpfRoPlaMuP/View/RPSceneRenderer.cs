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
            var title = new TextBlock() { Text = "Titel" };
            var tbTitle = new TextBox();

            var label = new TextBlock() { Text = "Beschreibung" };
            var textbox = new TextBox() { TextWrapping = TextWrapping.Wrap, AcceptsReturn = true, VerticalScrollBarVisibility = ScrollBarVisibility.Visible, Height = 64 };

            var addTrack = new Button() { Content = "Tonspur hinzufügen" };
            addTrack.Click += (s, e) => 
                                    {
                                        var chan = new RPAudioPlayer();
                                        stvi.Channels.Add(chan);
                                        AddChannelControls(chan, stvi.Channels.Count, container);
                                    };


            textbox.DataContext = stvi;
            textbox.SetBinding(TextBox.TextProperty,
                                new Binding ()
                                {
                                    Path = new PropertyPath("Description"),
                                    Mode = BindingMode.TwoWay
                                });

            tbTitle.DataContext = stvi;
            tbTitle.SetBinding(TextBox.TextProperty,
                                new Binding()
                                {
                                    Path = new PropertyPath("Text"),
                                    Mode = BindingMode.TwoWay
                                });
            // Bindung an TreeView
            tbTitle.TextChanged += (o,e) => { stvi.Text = (o as TextBox)?.Text ?? ""; };

            container.Children.Add(title);
            container.Children.Add(tbTitle);
            container.Children.Add(label);
            container.Children.Add(textbox);
            container.Children.Add(addTrack);

            for (int i = 0; i < stvi.Channels.Count; i++)
            {
                var channel = stvi.Channels[i];
                AddChannelControls(channel, i+1, container);
            }
        }

        protected void AddChannelControls(RPAudioPlayer ap, int pos, StackPanel container)
        {
            var trackName = new TextBlock() { Text = $"Spur { pos }" };
            var gv = new GridView();
            var lv = new ListView() { Height = 96, View = gv };
            gv.Columns.Add(new GridViewColumn() { DisplayMemberBinding = new Binding ("Path"), Header = "Pfad", Width = 300 });
            gv.Columns.Add(new GridViewColumn() { DisplayMemberBinding = new Binding ("Volume"), Header = "Lautstärke" });
            gv.Columns.Add(new GridViewColumn() { DisplayMemberBinding = new Binding("FadeInFrom"), Header = "Start ab" });
            gv.Columns.Add(new GridViewColumn() { DisplayMemberBinding = new Binding("FadeOutFrom"), Header = "Ende ab" });
            foreach (var t in ap.Tracks)
            {
                lv.Items.Add(t);
            }

            var cm = new ContextMenu();
            var mi = new MenuItem() { Header = "Dateien auswählen" };
            mi.Click += (o, e) =>
            {
                var ofd = new System.Windows.Forms.OpenFileDialog() { Filter = "Musik (*.mp3, *.ogg)|*.MP3;*.OGG" };
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var t = new RPAudioTrack(ofd.FileName);
                    ap.Tracks.Add(t);
                    lv.Items.Add(t);
                }
            };
            cm.Items.Add(mi);
            lv.ContextMenu = cm;

            container.Children.Add(trackName);
            container.Children.Add(lv);
        }
    }
}
