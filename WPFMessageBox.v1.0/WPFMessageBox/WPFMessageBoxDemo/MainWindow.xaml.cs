using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBoxUtils;

namespace WPFMessageBoxDemo
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

        private MessageBoxResult _result;

        private void Error_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = WPFMessageBox.Show("message text", "caption", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);

            _result = WPFMessageBox.Show("message text", "caption", MessageBoxButton.YesNoCancel, MessageBoxImage.Error, MessageBoxResult.No, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.Yes, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.None);
        }

        private void Warning_Click(object sender, RoutedEventArgs e)
        {
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.No, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.Cancel, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.None);
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OKCancel, MessageBoxImage.Question, MessageBoxResult.Cancel, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK, MessageBoxOptions.None);
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.YesNoCancel, MessageBoxImage.Information, MessageBoxResult.No, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OKCancel, MessageBoxImage.Information, MessageBoxResult.Cancel, MessageBoxOptions.None);
            _result = WPFMessageBox.Show(this, "message text", "caption", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.None);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = WPFMessageBox.Show("כיתוב בעברית.", "כותרת.", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RightAlign);
            result = WPFMessageBox.Show("כיתוב בעברית.", "כותרת.", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RtlReading);
            result = WPFMessageBox.Show("כיתוב בעברית.", "כותרת.", MessageBoxButton.OKCancel, MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
        }
    }
}
