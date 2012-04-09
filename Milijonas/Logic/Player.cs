using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milijonas.Logic
{
    public class Player
    {
        public int AnsweredQuestions
        {
            get;
            set;
        }

        public Stage CurrentStage
        {
            get;
            set;
        }

        public int Points
        {
            get;
            set;
        }


        public Player()
        {
            this.AnsweredQuestions = 0;
            this.Points = 0;
            this.CurrentStage = Stage.First;
        }

        public void AddCorrectAnswer()
        {
            this.AnsweredQuestions++;
            if (this.IsNewLevel()) 
                this.levelUp();
        }

        private void levelUp() 
        {
            switch(CurrentStage) {
                case Stage.First:
                    CurrentStage = Stage.Second;
                    break;
                case Stage.Second:
                    CurrentStage = Stage.Third;
                    break;
                case Stage.Third:
                    CurrentStage = Stage.Fourth;
                    break;
                case Stage.Fourth:
                    CurrentStage = Stage.Fifth;
                    break;
                case Stage.Fifth:
                    CurrentStage = Stage.Sixth;
                    break;
                case Stage.Sixth:
                    CurrentStage = Stage.Winner;
                    break;
                default:
                    break;
            }
        }



        public bool IsNewLevel()
        {
            switch (this.AnsweredQuestions)
            {
                case 4:
                case 8:
                case 12:
                case 15:
                case 17:
                case 18:
                    return true;
            }
            return false;
        }
    }
}
