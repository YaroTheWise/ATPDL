using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ATPDL.Specification.Game
{
    public class Match
    {
        private readonly TypeMatch typeMatch;

        public Match(TypeMatch typeMatch)
        {
            this.typeMatch = typeMatch;
            Sets = new List<Set> { new Set() };
            TieBrake = false;
            EndMatch = false;
            CurrentGame = new Game();
        }

        public bool TieBrake { get; set; }
        public bool EndMatch { get; set; }



        public List<Set> Sets { get; set; }
        public Game CurrentGame { get; set; }


        public void FinishGame(bool top)
        {
            CurrentGame = new Game();
            var set = Sets.Last();
            if (top)
            {
                set.Top++;
            }
            else
            {
                set.Bottom++;
            }
        }

        public void FinishSet(bool top)
        {
            CurrentGame = new Game();
            Sets.Add(new Set());
        }

        public void FinishMatch(bool top)
        {
            EndMatch = true;
            CurrentGame = new Game();
        }
    }
}