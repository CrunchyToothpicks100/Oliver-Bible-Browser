using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace MSSU_CIS310_MVC
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

        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Keyword_Button_Click(object sender, RoutedEventArgs e)
        {
            KeywordUI window = new KeywordUI();
            window.ShowDialog();
        }
    }
}
