using GameCore.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.QuizeCore
{
    public class CoreQuize
    {
        private QuizeDB db { get; set; }
        private Level level { get; set; }
        private Question[] levelQuestions { get; set; }
        public CoreQuize()
        {
            db = new QuizeDB();
            level = new Level { LevelNum = 1, ScoreTotal = 20 };
            levelQuestions = db.GetQuestionsByLevel(level);
        }

        public Question[] GetQuestions()
        {
            return levelQuestions;
        }
        
        public bool CheckPlayersResult(Player player)
        {
            if (level.ScoreTotal <= player.CurrentScore)
            {
                GoToNextLevel();
                player.CurrentLevel = level;
                player.CurrentScore = 0;

                return true;
            }
            else return false;
        }

        public bool IsFinish()
        {
            return levelQuestions.Count() == 0;
        }

        public bool ChechQuestion(Player player, Question question, char answerChar)
        {
            var answer = question.Answers.First(x => x.Char == answerChar);

            if (answer.IsTrue)
            {
                player.CurrentScore += question.Score;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GoToNextLevel()
        {
            this.level.LevelNum += 1;
            this.level.ScoreTotal += this.level.ScoreTotal; // Увеличиваем конечное количство очков в двое 

            levelQuestions = db.GetQuestionsByLevel(this.level);
        } 

    }
}
