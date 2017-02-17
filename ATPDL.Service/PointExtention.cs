using System;
using System.Text;
using ATPDL.Specification.Game;

namespace ATPDL.Service
{
    public static class GameExtention
    {
        public static void Rise(this Game game, Won won)
        {
            var point = won == Won.Top ? game.Top : game.Bottom;

            switch (point)
            {
                case Point.Nil:
                    point = Point.Fifteen;
                    break;
                case Point.Fifteen:
                    point = Point.Thirty;
                    break;
                case Point.Thirty:
                    point = Point.Forty;
                    break;
                case Point.Forty:
                    point = Point.Ad;
                    break;
                case Point.Ad:
                    point = Point.Win;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(point), point, null);
            }

            if (won == Won.Top)
            {
                game.Top = point;
            }
            else
            {
                game.Bottom = point;
            }
        }
    }


    public static class PointExtention
    {

        public static string String(this Point point)
        {
            switch (point)
            {
                case Point.Nil:
                    return "0";
                case Point.Fifteen:
                    return "15";
                case Point.Thirty:
                    return "30";
                case Point.Forty:
                    return "40";
                case Point.Ad:
                    return "Ad";
                default:
                    throw new ArgumentOutOfRangeException(nameof(point), point, null);
            }
        }

        public static string String(this Match match)
        {
            var top = new StringBuilder();
            var bottom = new StringBuilder();

            foreach (var set in match.Sets)
            {
                top.AppendFormat("{0}|", set.Top);
                bottom.AppendFormat("{0}|", set.Bottom);
            }

            top.AppendFormat(match.TieBrake ? match.CurrentGame.TieBrakeTop.ToString() : match.CurrentGame.Top.String());
            bottom.AppendFormat(match.TieBrake ? match.CurrentGame.TieBrakeBottom.ToString() : match.CurrentGame.Bottom.String());

            var result = top + "\n" + bottom + "\n";

            return result;
        }

        public static void FinishPoint(this Match match, bool top)
        {
            if (match.TieBrake)
            {
                if (top)
                {
                    match.CurrentGame.TieBrakeTop++;
                }
                else
                {
                    match.CurrentGame.TieBrakeBottom++;
                }
            }
            else
            {
                if (top)
                {
                    match.CurrentGame.Rise(Won.Top);
                }
                else
                {
                    match.CurrentGame.Rise(Won.Bottom);
                }
            }

            if (match.IsFinishGame())
            {
                match.FinishGame(top);

                //if (match.IsFinishSet)
                //{
                //    match.FinishSet(top);
                //    if (match.FinishMatch)
                //    {

                //    }
                //}
            }


        }

        public static bool IsFinishGame(this Match match)
        {
            var game = match.CurrentGame;
            var result = false;
            if (match.TieBrake)
            {
                // if
            }
            else
            {

            }

            return result;
        }
    }

    public interface IMatchChanger
    {
        void Change(Match match, Won won);
    }

    public class MatchChanger : IMatchChanger
    {
        public void Change(Match match, Won won)
        {
            var gameChanger = new GameChanger();
            gameChanger.Change(match.CurrentGame, match.TieBrake, won);
        }
    }

    public interface IGameChanger
    {
        void Change(Game matchCurrentGame, bool matchTieBrake, Won won);
    }

    public class GameChanger : IGameChanger
    {
        public void Change(Game matchCurrentGame, bool matchTieBrake, Won won)
        {
            if (matchTieBrake)
            {
                if (won == Won.Top)
                {
                    matchCurrentGame.TieBrakeTop++;
                }
                else
                {
                    matchCurrentGame.TieBrakeBottom++;
                }
            }
            else
            {
                if (won == Won.Top)
                {
                    matchCurrentGame.Rise(won);
                }
                else
                {
                    matchCurrentGame.Rise(won);
                }
            }

            Console.WriteLine("Change");
        }
    }
}