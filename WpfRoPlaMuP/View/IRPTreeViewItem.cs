using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DagalPlayer
{
    public interface IRPTreeViewItem
    {
        string Text { get; set; }
        string Description { get; set; }
        ItemCollection Items { get; }
        string NodeType { get; }
        DependencyObject Parent { get; }
        /// <summary>
        /// Needed for Save Method
        /// </summary>
        /// <returns></returns>
        string ToString();
        void FromString(string text);
    }
}
