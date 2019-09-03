using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.QuizeCore
{
    internal class QuizeDB
    {

        private Question[] questions { get; set; }

        public QuizeDB()
        {
            questions = Load();
        }

        private Question[] Load()
        {
            Level level1 = new Level { LevelNum = 1, ScoreTotal = 20 };

            Question question1 = CreateQuestion("Сколько пальцев на руке?", 10, level1, 
                           new Answer { AnswerText = "4", Char='A', IsTrue = false},
                           new Answer { AnswerText = "1", Char = 'Б', IsTrue = false },
                           new Answer { AnswerText = "2", Char = 'В', IsTrue = false },
                           new Answer { AnswerText = "5", Char = 'Г', IsTrue = true },
                           new Answer { AnswerText = "3", Char = 'Д', IsTrue = false }
                           );

            return new Question[] { question1 };
        }


        private Question CreateQuestion(string text, int score, Level level, params Answer[] answers)
        {
            return new Question
            {
                QuestionText = text,
                Score = score,
                Level = level,
                Answers = answers
            };
        }

        public Question[] GetQuestionsByLevel (Level level)
        {
          return questions.Where(x => x.Level.LevelNum == level.LevelNum).ToArray();
        }
    }
}
