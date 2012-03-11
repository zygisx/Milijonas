using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milijonas.Logic
{

    

    public class Question
    {
        private int correctAnswerIndex;

        public string Problem
        {
            get;
            set;
        }

        // make those private in future
        
        public string Answer
        {
            private get;
            set;
        }
        public string Case1
        {
            private get;
            set;
        }
        public string Case2
        {
            private get;
            set;
        }
        
        
        public Question()
        {
        }


        public Question(string question)
        {
            this.Problem = question;
        }

        public string[] GetRandomPossibleAnswers()
        {
            string[] answers = new string[3] {
                Answer,
                Case1,
                Case2,
            };
            Random rnd = new Random();
            string[] shuffledArray = answers.OrderBy(x => Guid.NewGuid()).ToArray();
            return shuffledArray;
        }

        public bool CheckAnswer(string answer)
        {
            return (answer.Equals(Answer));
        }

        public void RemoveIncorrectAnswer(string[] answers)
        {
            int rand = new Random().Next(2);
            string toRemove;
            if (rand == 0) toRemove = Case1;
            else toRemove = Case2;
            if (this.Case1 == "") toRemove = this.Case2;
            if (this.Case2 == "") toRemove = this.Case1;
            if (this.Case1 == toRemove) this.Case1 = "";
            else this.Case2 = "";
            System.Console.WriteLine(toRemove);
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == toRemove)
                    answers[i] = "";
            }
            toRemove = "";
        }
    }
}
