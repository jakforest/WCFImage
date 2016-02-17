using ImageClient.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ImageClient.Pages
{
    /// <summary>
    /// Interaction logic for ViewImagePage.xaml
    /// </summary>
    public partial class ViewImagePage : Page
    {
        public ViewImagePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileOk += Dlg_FileOk;
            dlg.Filter = "*.jpg|*.jpg";
            dlg.ShowDialog();
        }

        private void Dlg_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            OpenFileDialog dlg = sender as OpenFileDialog;
            if (dlg != null)
            {
                if (!string.IsNullOrWhiteSpace(dlg.FileName) && File.Exists(dlg.FileName))
                    ((ViewImageViewModel)DataContext).ImageData = File.ReadAllBytes(dlg.FileName);
            }
        }
    }
}
