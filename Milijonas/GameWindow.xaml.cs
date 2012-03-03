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
using Milijonas.Logic;

namespace Milijonas
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Game game;
        private MainWindow parent;

        public GameWindow(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
            game = new Game();
			this.showNextQuestion();
        }
		
		private void showNextQuestion() {
			this.questionBox.Text = game.CurrentQuestion.Problem;
            string[] answers = this.game.GetPossibleAnswers();
			this.case1Button.Content = answers[0];
			this.case2Button.Content = answers[1];
			this.case3Button.Content = answers[2];
		}

        private void gameWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //this.Close();
            parent.Show();
        }

        private void case1Choosed(object sender, System.Windows.RoutedEventArgs e)
        {
			
        	this.answerChoosed((string) this.case1Button.Content);
        }

        private void case2Choosed(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.answerChoosed((string) this.case2Button.Content);
        }

        private void case3Choosed(object sender, System.Windows.RoutedEventArgs e)
        {
        	this.answerChoosed((string) this.case3Button.Content);
        }
		
		private void answerChoosed(string guess) 
		{
			if (this.game.SubmitAnswer(guess))
			{
                this.game.GetNewQuestion();
				this.showNextQuestion();
			}
			else 
			{
				this.gameLosed();
			}
		}
		
		private void gameLosed() 
		{
			MessageBox.Show("Dėja jūs pralaimėjote", "");
			this.Close();
			this.parent.Show();
		}
    }
}
