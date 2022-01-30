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
        public MainWindow()
        {
            InitializeComponent();
            trvScenes.Items.Add(new FolderTreeViewItem() { Header = "Szenenliste", IsExpanded = true });
        }

        private void trvScenes_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void bNewItem_Click(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            TreeViewItem tvi = b.Name == "bNewFolder" ? new FolderTreeViewItem() : new SceneTreeViewItem();
            if (trvScenes.SelectedItem != null)
            {
                if (trvScenes.SelectedItem is FolderTreeViewItem ftvi)
                {
                    ftvi.Items.Add(tvi);
                }
                else
                {
                    if (((TreeViewItem)trvScenes.SelectedItem)?.Parent is FolderTreeViewItem f)
                    {
                        f.Items.Add(tvi);
                    }
                }
            }
            else
            {
                trvScenes.Items.Add(tvi);
            }
        }

        private void bNewScene_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            var t = trvScenes.SelectedItem as IRPTreeViewItem;
            if (t != null)
            {
                string frage;
                if (t.Items.Count > 0)
                {
                    frage = $"Möchten Sie den Ordner '{ t.Text }' inkl. der { (t as FolderTreeViewItem)?.Items.Count } Unterelemente löschen?";
                }
                else
                {
                    frage = $"Möchten Sie '{ t.Text }' wirklich löschen?";
                }
                if (MessageBox.Show(frage, "Löschen?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var tvi = t as TreeViewItem;
                    (tvi.Parent as TreeViewItem)?.Items.Remove(tvi);
                }
            }
        }

        private void bPlay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
