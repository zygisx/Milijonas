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
        private Label[] labels;
        //private DialogBox dialog;

        public GameWindow(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
            this.game = new Game();
			this.showQuestion();
            this.labels = new Label[18] {
                label1, label2, label3, label4, label5, label6, label7, label8, 
                label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, 
            };
            labels[0].Foreground = Brushes.Turquoise;            
        }
		
		private void showQuestion() {
			this.questionBox.Text = game.CurrentQuestion;
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
                this.enableButtons();
                this.game.NewQuestion();
                if (this.game.IsNewLevel())
                    this.showNewLevelDialog();
                this.labels[this.game.GetAnsweredQuestions()].Foreground = Brushes.Turquoise;
                this.labels[this.game.GetAnsweredQuestions() - 1].Foreground = Brushes.White;
				this.showQuestion();
			}
			else 
			{
				this.gameLost();
			}
		}

        private void showNewLevelDialog()
        {
            new DialogBox(this,
                "Sveikiname! Jūs pereinate į aukštensnį lygi.",
                DialogBox.Type.INFO_DIALOG).ShowDialog();
        }
		
		private void gameLost() 
		{
            bool? result = new DialogBox(this, 
                "Dėja Jūs pralaimėjote.\nNorite žaisti dar kartą?", 
                DialogBox.Type.QUESTION_DIALOG).ShowDialog();
            if (result.HasValue && result.Value)
            {
                this.restart();
            }
            else
            {
                this.Close();
                this.parent.Show();
            }
		}

        private void restart()
        {
            this.game = new Game();
            InitializeComponent();
            this.labels = new Label[18] {
                label1, label2, label3, label4, label5, label6, label7, label8, 
                label9, label10, label11, label12, label13, label14, label15, label16, label17, label18, 
            };
            foreach (Label l in labels)
            {
                l.Foreground = Brushes.Black;
            }
            labels[0].Foreground = Brushes.Turquoise;
            this.showQuestion();
        }

        private void skipQuestionHelpSelected(object sender, System.Windows.RoutedEventArgs e)
        {
            this.game.UseSkipQuestionHelp();
            this.showQuestion();
            this.shiftHelpButton.IsEnabled = false;
        }

        private void removeIncorrectAnswerHelpSelected(object sender, System.Windows.RoutedEventArgs e)
        {
            this.game.UseRemoveIncorrectAnswerHelp();
            this.showQuestion();
            this.helpRemoveButton.IsEnabled = false;
            if (((string)this.case1Button.Content) == "")
            {
                this.case1Button.IsEnabled = false;
            }
            else if (((string)this.case2Button.Content) == "")
            {
                this.case2Button.IsEnabled = false;
            }
            else if (((string)this.case3Button.Content) == "")
            {
                this.case3Button.IsEnabled = false;
            }
            
        }

        private void enableButtons()
        {
            this.case1Button.IsEnabled = true;
            this.case2Button.IsEnabled = true;
            this.case3Button.IsEnabled = true;
        }
    }
}