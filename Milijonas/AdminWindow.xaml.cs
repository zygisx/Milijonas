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
using System.Windows.Shapes;

using Milijonas.Data;

namespace Milijonas
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        private MainWindow parent;

        public AdminWindow(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }



        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.questionTextBox.Text))
            {
                MessageBox.Show("Būtina įrašyti klausimą.", "Klaida", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (String.IsNullOrEmpty(this.answerTextBox.Text))
            {
                MessageBox.Show("Būtina įrašyti atsakymą.", "Klaida", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (String.IsNullOrEmpty(this.case1TextBox.Text) || String.IsNullOrEmpty(this.case2TextBox.Text))
            {
                MessageBox.Show("Būtina įrašyti variantus.", "Klaida", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            QuestionsStorage.AppendQuestions(
                this.questionTextBox.Text,
                this.answerTextBox.Text,
                this.case1TextBox.Text,
                this.case2TextBox.Text,
                this.difficultyComboBox.Text);
            this.clearFields();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            parent.Show();
            this.clearFields();
            //this.Hide();
            this.Close();
        }

        private void clearFields()
        {
            this.answerTextBox.Text = "";
            this.questionTextBox.Text = "";
            this.case2TextBox.Text = "";
            this.case1TextBox.Text = "";
        }

        private void adminWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
            this.clearFields();
            //this.Hide();
        }
       
    }
}
