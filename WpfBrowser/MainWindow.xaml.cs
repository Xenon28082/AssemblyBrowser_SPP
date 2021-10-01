using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AssemblyBrowser;
using Microsoft.Win32;

namespace WpfBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnOpenFile_OnClick(object sender, RoutedEventArgs e)
        {
            tree.Items.Clear();
            HashSet<string> set = new HashSet<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                DLLReader reader = new DLLReader();
                reader.GetResult(path);
                foreach (var type in reader.typeList)
                {
                    TreeViewItem item = new TreeViewItem();
                    if (!set.Contains(type._nameSpace))
                    {
                        item.Header = type._nameSpace;
                        
                        foreach (var typeFrame in reader.typeList)
                        {
                            if (typeFrame._nameSpace == null)
                            {
                                TreeViewItem classItem = new TreeViewItem();
                                classItem.Header = typeFrame._class;
                                TreeViewItem propertiesItem = new TreeViewItem();
                                propertiesItem.Header = typeFrame.ToString();
                                classItem.Items.Add(propertiesItem);
                                item = classItem;
                            }
                            else
                            if (typeFrame._nameSpace.Equals(type._nameSpace))
                            {
                                TreeViewItem classItem = new TreeViewItem();
                                classItem.Header = typeFrame._class;
                                TreeViewItem propertiesItem = new TreeViewItem();
                                propertiesItem.Header = typeFrame.ToString();
                                classItem.Items.Add(propertiesItem);
                                item.Items.Add(classItem);
                                set.Add(type._nameSpace);
                            }
                            
                        }
                    }
                    tree.Items.Add(item);
                }

                Console.WriteLine(reader.ToString());
            }
        }
    }
}