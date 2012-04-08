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
            this.labels[0].Foreground = Brushes.Turquoise;
            this.removeAnswerHelpsLeftLabel.Content = Game.REMOVE_INCORRECT_ANSWERS_HELPS;
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
                if (this.game.IsWin())
                {
                    this.showCongratsDialog();
                    return;
                }
                if (this.game.IsNewLevel())
                    this.showNewLevelDialog();
                
                this.game.NewQuestion();
                
                
                this.labels[this.game.GetAnsweredQuestions()].Foreground = Brushes.Turquoise;
                this.labels[this.game.GetAnsweredQuestions() - 1].Foreground = Brushes.White;
				this.showQuestion();
			}
			else 
			{
				this.gameLost();
			}
		}

        private void showCongratsDialog()
        {
            DialogBox dialog = new DialogBox(this,
                "Sveikiname Jūs laimėjote.\nNorite žaisti dar kartą?",
                DialogBox.Type.QUESTION_DIALOG);
            dialog.Owner = this;
            bool? result = dialog.ShowDialog();
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


        private void showNewLevelDialog()
        {
            DialogBox dialog = new DialogBox(this,
                "Sveikiname! Jūs pereinate į aukštensnį lygi.",
                DialogBox.Type.INFO_DIALOG);
            dialog.Owner = this;
            dialog.ShowDialog();
        }
		
		private void gameLost() 
		{
            DialogBox dialog = new DialogBox(this, 
                "Dėja Jūs pralaimėjote.\nNorite žaisti dar kartą?", 
                DialogBox.Type.QUESTION_DIALOG);
            dialog.Owner = this;
            bool? result = dialog.ShowDialog();
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
                l.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF373737");
            }
            labels[0].Foreground = Brushes.Turquoise;
            this.showQuestion();
            this.shiftHelpButton.IsEnabled = true;
            this.helpRemoveButton.IsEnabled = true;
            this.removeAnswerHelpsLeftLabel.Content = Game.REMOVE_INCORRECT_ANSWERS_HELPS;
            this.changeQuestionHelpsLeft.Content = Game.CHANGE_QUESTION_HELPS;
        }

        private void skipQuestionHelpSelected(object sender, System.Windows.RoutedEventArgs e)
        {
            this.changeQuestionHelpsLeft.Content = 0;
            this.game.UseSkipQuestionHelp();
            this.showQuestion();
            this.shiftHelpButton.IsEnabled = false;
        }

        private void removeIncorrectAnswerHelpSelected(object sender, System.Windows.RoutedEventArgs e)
        {
            this.game.UseRemoveIncorrectAnswerHelp();
            this.removeAnswerHelpsLeftLabel.Content = this.game.RemoveInncorectAnswerHelp;
            this.showQuestion();
            if (this.game.RemoveInncorectAnswerHelp <= 0)
                this.helpRemoveButton.IsEnabled = false;
            if (((string)this.case1Button.Content) == "")
            {
                this.case1Button.IsEnabled = false;
            if (((string)this.case2Button.Content) == "")
                this.case2Button.IsEnabled = false;
            if (((string)this.case3Button.Content) == "")
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