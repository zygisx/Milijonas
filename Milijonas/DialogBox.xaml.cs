using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Milijonas
{
	/// <summary>
	/// Interaction logic for DialogBox.xaml
	/// </summary>
	public partial class DialogBox : Window
	{

        public enum Type {
            INFO_DIALOG,
            QUESTION_DIALOG,
        }

        private GameWindow parent;

        public string Question
        {
            get
            {
                return this.content.Text;
            }
            set
            {
                this.content.Text = value;
            }
        }

		public DialogBox(GameWindow parent, string content, Type type)
		{
			this.InitializeComponent();
            this.parent = parent;
            this.content.Text = content;
            switch (type)
            {
                case Type.INFO_DIALOG:
                    this.noButton.Visibility = System.Windows.Visibility.Hidden;
                    this.yesButton.Content = "OK";
                    break;
                case Type.QUESTION_DIALOG:
                    break;
            }
		}

		private void yesClicked(object sender, System.Windows.RoutedEventArgs e)
		{
            this.DialogResult = true;
            
		}

		private void noClicked(object sender, System.Windows.RoutedEventArgs e)
		{
			this.DialogResult = false;
            
		}
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            this.Left = parent.Left + (parent.Width - this.ActualWidth) / 2;
            this.Top = parent.Top + (parent.Height - this.ActualHeight) / 2;
        }
	}
}