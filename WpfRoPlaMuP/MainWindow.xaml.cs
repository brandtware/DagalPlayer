using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DagalPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public RPSceneTreeViewItem? activeScene { get; set; } = null;
        public RPSceneTreeViewItem? selectedScene { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            trvScenes.Items.Add(new RPFolderTreeViewItem() { Header = "Szenenliste", IsExpanded = true });
        }

        private void trvScenes_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            spTracks.Children.Clear();
            if (e.NewValue is RPFolderTreeViewItem fld)
            {
                new RPFolderRenderer(fld, spTracks);
            }
            else if (e.NewValue is RPSceneTreeViewItem scn)
            {
                selectedScene = scn;
                new RPSceneRenderer (scn, spTracks);
            }
        }

        private void bNewItem_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            TreeViewItem tvi = b.Name == "bNewFolder" ? new RPFolderTreeViewItem() : new RPSceneTreeViewItem();
            if (trvScenes.SelectedItem != null)
            {
                if (trvScenes.SelectedItem is RPFolderTreeViewItem ftvi)
                {
                    ftvi.Items.Add(tvi);
                }
                else
                {
                    if (((TreeViewItem)trvScenes.SelectedItem)?.Parent is RPFolderTreeViewItem f)
                    {
                        f.Items.Add(tvi);
                    }
                }
            }
            else
            {
                ((TreeViewItem)trvScenes.Items[0]).Items.Add(tvi);
            }
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            var t = trvScenes.SelectedItem as IRPTreeViewItem;
            if (t != null && !(t.Parent is TreeView)) // Root-Level nicht löschbar
            {
                string frage;
                if (t.Items.Count > 0)
                {
                    frage = $"Möchten Sie den Ordner '{ t.Text }' inkl. der { (t as RPFolderTreeViewItem)?.Items.Count } Unterelemente löschen?";
                }
                else
                {
                    frage = $"Möchten Sie '{ t.Text }' wirklich löschen?";
                }
                if (MessageBox.Show(frage, "Löschen?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    (t.Parent as IRPTreeViewItem)?.Items.Remove(t);
                }
            }
        }

        private void bPlay_Click(object sender, RoutedEventArgs e)
        {
            if (activeScene != null)
            {
                foreach (var c in activeScene.Channels)
                {
                    c.Play();
                }
            }
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {
            if (activeScene != null)
            {
                foreach (var c in activeScene.Channels)
                {
                    c.Stop();
                }
            }
        }
    }
}
