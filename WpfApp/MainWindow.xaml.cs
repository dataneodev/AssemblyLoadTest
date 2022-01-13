using LibTest;
using System;
using System.Windows;
using Tekla.Structures.Model;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tbMain.Text = new ModelTest().GetTest();

            try
            {
                var model = new Model().GetProjectInfo();
            }
            catch (Exception e)
            {

            }

        }
    }
}
