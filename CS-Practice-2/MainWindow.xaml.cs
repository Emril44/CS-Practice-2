using CS_Practice_2.Models;
using CS_Practice_2.Views;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace CS_Practice_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new NavView();
        }
    }
}
