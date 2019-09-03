using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.QuizeCore
{
    public class Question
    {
        public Level Level { get; set; }

        public string QuestionText { get; set; }

        public Answer[] Answers { get; set; }

        public int Score { get; set; }
    }
}
