﻿using System;
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
       

        /** private fields */
        private Question currentQuestion;
        private string[] randomAnswers;
        private Boolean skipQuestionHelp = true;
        private Boolean removeIncorrectAnswerHelp = true;
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

        public Boolean RemoveInncorectAnswerHelp
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
            //db = new QuestionsStorage("Questions.xml");
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

        public int GetAnsweredQuestions()
        {
            return this.GamePlayer.AnsweredQuestions;
        }

        public void NewQuestion() {
            this.currentQuestion = QuestionsStorage.GetRandomQuestion(GamePlayer.CurrentStage);
            this.randomAnswers = currentQuestion.GetRandomPossibleAnswers();
        }

        public void UseSkipQuestionHelp()
        {
            this.skipQuestionHelp = false;
            this.NewQuestion();
        }
        public void UseRemoveIncorrectAnswerHelp()
        {
            this.removeIncorrectAnswerHelp = false;
            this.currentQuestion.RemoveIncorrectAnswer(randomAnswers);
        }
    }
}
