using System;

namespace ATPDL.Main
{
    public static class Test
    {
        private static Random random;
        private static int xPoint;
        private static int yPoint;
        private static int xGame;
        private static int yGame;
        private static int xSet;
        private static int ySet;

        public static void GoMatch()
        {
            random = new Random();

            xSet = 0;
            ySet = 0;

            do
            {
                GoSet();
            } while (CheckMatch());
            Log();
            Console.ReadLine();
        }

        private static bool CheckMatch()
        {
            if (xSet == 2 || ySet == 2)
            {
                return false;
            }

            return true;
        }

        private static void GoSet()
        {
            do
            {
                GoGame();
            } while (CheckSet());
        }

        private static bool CheckSet()
        {
            if (xGame == 7 || xGame == 6 && yGame < 5)
            {
                xGame = 0;
                yGame = 0;
                xSet++;
                return false;
            }
            if (yGame == 7 || yGame == 6 && xGame < 5)
            {
                xGame = 0;
                yGame = 0;
                ySet++;
                return false;
            }

            return true;
        }

        private static void GoGame()
        {
            do
            {
                if (GoPoint())
                {
                    RiseYPoint();
                }
                else
                {
                    RiseXPoint();
                }

            } while (CheckGame());
        }

        private static void Log()
        {
            Console.WriteLine("******************");
            Console.WriteLine("{0} {1}  {2}", xSet, xGame, xPoint);
            Console.WriteLine("{0} {1}  {2}", ySet, yGame, yPoint);
            //Thread.Sleep(1000);
        }

        private static bool CheckGame()
        {
            var result = true;
            if (xPoint > yPoint + 15 && xPoint > 40)
            {
                xPoint = 0;
                yPoint = 0;
                xGame++;
                result = false;
            }

            if (yPoint > xPoint + 15 && yPoint > 40)
            {
                xPoint = 0;
                yPoint = 0;
                yGame++;
                result = false;
            }

            if (xPoint == 50 && yPoint == 50)
            {
                xPoint = 40;
                yPoint = 40;
            }

            Log();
            return result;
        }

        private static void RiseXPoint()
        {
            switch (xPoint)
            {
                case 0:
                    xPoint = 15;
                    return;
                case 15:
                    xPoint = 30;
                    return;
                case 30:
                    xPoint = 40;
                    return;
                case 40:
                    xPoint = 50;
                    return;
                case 50:
                    xPoint = 60;
                    return;
            }
        }

        private static void RiseYPoint()
        {
            switch (yPoint)
            {
                case 0:
                    yPoint = 15;
                    return;
                case 15:
                    yPoint = 30;
                    return;
                case 30:
                    yPoint = 40;
                    return;
                case 40:
                    yPoint = 50;
                    return;
                case 50:
                    yPoint = 60;
                    return;
            }
        }

        private static bool GoPoint()
        {
            var x = random.Next(100);
            Console.WriteLine(x);
            return x >= 50;
        }
    }
}