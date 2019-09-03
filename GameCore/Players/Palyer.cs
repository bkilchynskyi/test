using GameCore.QuizeCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Players
{
    public class Player
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Level CurrentLevel { get; set; }

        public int CurrentScore { get; set; }
        
    }
}
