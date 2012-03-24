using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milijonas.Data;

namespace Milijonas.Logic
{
    /**
     * Helps:
     *  1 Change question
     *  2 Remove one answer
     *  
     */
    public enum Stage
    {
        First = 1,  // 100, 200, 400, 600
        Second = 2,  // 1000, 2000, 4000, 6000
        Third = 3,  // 10 000, 20 000, 40 000, 60 000
        Fourth = 4, // 100 000, 150 000, 200 000
        Fifth = 5,  // 300 000, 500 000
        Sixth = 6,  // 1 000 000
        Winner = 7,  // Winner  
    }


    public class Game
    {

        /** constants */
        public const int REMOVE_INCORRECT_ANSWERS_HELPS = 3;
        public const int CHANGE_QUESTION_HELPS = 1;

        /** private fields */
        private Question currentQuestion;
        private string[] randomAnswers;
        private int removedAnswers;
        private Boolean skipQuestionHelp = true;
        private int removeIncorrectAnswerHelp = REMOVE_INCORRECT_ANSWERS_HELPS;
        /** properties */
        public string CurrentQuestion
        {
            get {
                return currentQuestion.Problem;
            }
        }

        public Player GamePlayer
        {
            get;
            set;
        }

        public Boolean SkipQuestionHelp
        {
            get
            {
                return this.skipQuestionHelp;
            }
        }

        public int RemoveInncorectAnswerHelp
        {
            get
            {
                return this.removeIncorrectAnswerHelp;
            }
        }


        /** constructors */
        public Game()
        {
            GamePlayer = new Player();
            this.NewQuestion();
        }

        public string[] GetPossibleAnswers()
        {
            return this.randomAnswers;
        }

        public Boolean SubmitAnswer(string guess)
        {
            if (currentQuestion.CheckAnswer(guess))
            {
                this.GamePlayer.AddCorrectAnswer();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean IsNewLevel()
        {
            return GamePlayer.IsNewLevel();
        }
        public Boolean IsWin() 
        {
            return (GamePlayer.CurrentStage == Stage.Winner);
        }

        public int GetAnsweredQuestions()
        {
            return this.GamePlayer.AnsweredQuestions;
        }

        public void NewQuestion() {
            this.currentQuestion = QuestionsStorage.GetRandomQuestion(GamePlayer.CurrentStage);
            this.randomAnswers = currentQuestion.GetRandomPossibleAnswers();
            this.removedAnswers = 0;
        }

        public void UseSkipQuestionHelp()
        {
            this.skipQuestionHelp = false;
            this.NewQuestion();
        }
        public void UseRemoveIncorrectAnswerHelp()
        {
            if (this.removedAnswers == 2)
                return;
            this.removeIncorrectAnswerHelp--;
            this.removedAnswers++;
            this.currentQuestion.RemoveIncorrectAnswer(randomAnswers);
        }
    }
}
