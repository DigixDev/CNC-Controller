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
using CNC_Controller.Core;
using Microsoft.Win32;

namespace CNC_Controller
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


        private void LoadSettingButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Setting file (*.txt)|*.txt";
            dlg.FileName = "setting.txt";
            if (dlg.ShowDialog() == true)
            {
                SettingLoader.LoadSetting(dlg.FileName);
            }
        }

        private void LoadGCodeButton_OnClick(object sender, RoutedEventArgs e)
        {
            var dlg=new OpenFileDialog();
            dlg.Filter = "GCode file (*.nc)|*.nc";
            if (dlg.ShowDialog() == true)
            {
                GCodeLoader.Parser(dlg.FileName);
            }
        }

        private void RunWhealButton_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Handwheel();
        }
    }

    public class Data
    {
        public double Value { get; set; }
        public string Name { get; set; }
    }
}
