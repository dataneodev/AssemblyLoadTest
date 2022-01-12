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
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for VersionSelect.xaml
    /// </summary>
    public partial class VersionSelect : Window
    {
        private VersionSelect()
        {
            InitializeComponent();
        }

        public static String GetVersion()
        {
            var window = new VersionSelect();
            window.ShowDialog();

            var selectedItem = window.cmVersion.SelectionBoxItem as string;
            if (String.IsNullOrWhiteSpace(selectedItem))
                return "V1";

            return selectedItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
