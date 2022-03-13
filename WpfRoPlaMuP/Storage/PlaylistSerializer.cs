using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DagalPlayer.Storage
{
    public class PlaylistSerializer
    {
        public static bool Load(string path, TreeView trv)
        { 
            var lines = File.ReadAllLines(path);
            var root = trv.Items[0] as IRPTreeViewItem;
            if (root != null)
            {
                root.Items.Clear();
                LoadRecursive(root, lines, 0);
                return true;
            }
            return false;
        }

        public static IRPTreeViewItem LoadRecursive(IRPTreeViewItem parent, string[] lines, int row)
        {
            var parts = lines[row].Split('|');

            //if (lines[row].StartsWith ("F"))
            return null;
        }

        public static bool Save(string path, IRPTreeViewItem node)
        {
            var nodePath = "1"; // TODO
            File.AppendAllText(path, $"{nodePath}|{node.ToString()}");
            if (node.Items.Count > 0)
            {
                foreach (IRPTreeViewItem item in node.Items)
                {
                    Save(path, item);
                }
            }
            return true;
        }


    }
}
