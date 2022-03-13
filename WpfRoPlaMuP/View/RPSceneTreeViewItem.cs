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
            get { return headerText.Text; }
            set { headerText.Text = value; }
        }


        public string NodeType => "Szene";
        public List<RPAudioPlayer> Channels { get; set; } = new List<RPAudioPlayer>();
        public string Description { get; set; } = String.Empty;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("S|{0}|{1}{2}", this.Text, this.Description.ReplaceLineEndings("<br>"), Environment.NewLine);
            for (int i = 0; i < Channels.Count; i++)
            {
                sb.AppendFormat("{0}{1}", i, Environment.NewLine);
                foreach (var track in Channels[i].Tracks)
                {
                    sb.AppendFormat("{0}|{1}|{2}|{3}{4}", track.Path, track.FadeInFrom, track.FadeOutFrom, track.Volume, Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        public void FromString(string text)
        {
            var parts = text.Split('|');
            this.Text = parts[1];
            this.Description = parts[2].Replace("<br>", Environment.NewLine);
        }
    }
}
