using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Collections;
using System.Configuration;
using System.Runtime.InteropServices;
using GameTestOne;

namespace SinglePlayerDarts
{
    /// <summary>
    /// 02/10/2024  - Fix for input blank or enter on dart score entry (try.parse)
    ///             - Implemented Dart out chart
    ///             - moved console writes to splash screen
    ///             - added in player averages, darts thrown, and round counter
    ///             - update app.config for statistics (player1) and (GamesPlayed) - if not built will be in [your source]\bin\Debug\GameTestOne.exe.Config
    ///             - updated to change console font and bold *** ALLOWS UNSAFE *** if you do not want this
    ///                     comment out from internal unsafe struct CONSOLE_FONT_INFO_EX down and in main comment out line with SetConsoleFont(
    ///           
    /// </summary>

    public class Game
    {
        private static int outsAvailable = 0;
        private static int counter = 501;
        private static int dartsThrown = 0;
        private static decimal playerAverage = 0;
        private static int round = 0;
        private static ArrayList roundScore = new ArrayList();

        static void Main(string[] args)
        {
            //OutsTrainer.Trainer();
            Trainer.start();
            Console.ReadLine();





            SetConsoleFont("Consolas", 15, 30);
            splashScreen();
            int totalScore = 501;
            while (counter > 0)
            {

                // TODO: double to finish needs to happen. 
                // TODO: make sure any unwanted numbers aren't added to the totals DONE
                // TODO: tests add tests
                // TODO:

                // process starts in main
                // runs textQuery - prompts for 3 darts - checks


                round++;
                textQuery(ref totalScore); //ref keyword indicates a value that is passed by reference
                scoreKeeper(totalScore);
                roundScore.Add(totalScore);
                splashScreen();
                outs();
            }

        }

        public static void textQuery(ref int totalScore)
        {
            totalScore = totalAttemptScore(0);
            seeIfThereAreOuts(counter - totalScore);
            dartsThrown++;
            if (totalScore != counter)
            {
                totalScore = totalAttemptScore(totalScore);
                seeIfThereAreOuts(counter - totalScore);
                dartsThrown++;
                if (totalScore != counter)
                {
                    totalScore = totalAttemptScore(totalScore);
                    seeIfThereAreOuts(counter - totalScore);
                    dartsThrown++;
                }
            }
        }

        public static int scoreKeeper(int totalScore)
        {
            int Goal = counter;
            int Tally = Goal - totalScore;
            Console.WriteLine(Goal + " " + Tally + " " + counter);
            Console.ReadKey();
            if (Tally >= 1)

            {
                Console.WriteLine("");
                Console.WriteLine("Your total score for this round is " + totalScore);
                Console.WriteLine("");
                Console.WriteLine("Your current Tally is " + Tally);
                counter = Tally;
            }
            else if (Tally < 0)
            {
                Console.WriteLine(" Sorry you must finish on a double! The score " + totalScore + " has taken you past zero. Try again");
                Console.WriteLine("You need to score" + counter + " to win");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("CONGRATULATIONS! - YOU HAVE FINALLY REACHED " + Tally);
                Console.WriteLine("");
                counter = Tally;
                playerAverage = (501 / dartsThrown) * 3;

                Console.WriteLine("8b        d8                                           88              ");
                Console.WriteLine(" Y8,    , 8P                                           @@              ");
                Console.WriteLine("  Y8,  , 8P                                                            ");
                Console.WriteLine("   *8aa8*, adPPYba,  88       88    8b      Bull      d8 88 8b, dPPYba,  ");
                Console.WriteLine("    `88' a8*     *8a 88       88    `8b    d88b    d8' 88 88P'   `*8a  ");
                Console.WriteLine("     88  8b       d8 88       88     `8b  d8'`8b  d8'  88 88       88  ");
                Console.WriteLine("     88  *8a,   ,a8* *8a,   ,a88      `8bd8'  `8bd8'   88 88       88  ");
                Console.WriteLine("     88   `*YbbdP*'   `*YbbdP'Y8        YP      YP     88 88       88  ");
                Console.WriteLine("");
                Console.WriteLine("Stats:   Darts      Average");
                Console.WriteLine("----------------------------");
                Console.WriteLine("          " + dartsThrown + "         " + playerAverage);
                decimal playerAvg = Convert.ToDecimal(ConfigurationManager.AppSettings["Player1"].ToString());
                int gamesPlayed = Convert.ToInt32(ConfigurationManager.AppSettings["GamesPlayed"].ToString());

                playerAvg = playerAvg * gamesPlayed;
                playerAvg = playerAvg + playerAverage;
                gamesPlayed++;
                playerAvg = playerAvg / gamesPlayed;


                SetSettings("Player1", playerAvg.ToString());
                SetSettings("GamesPlayed", gamesPlayed.ToString());
                Console.ReadLine();
            }
            return totalScore;
        }

        public static int getScore() //a private method returning ints
        {
            Console.WriteLine("Please enter your score..");
            string input = Console.ReadLine();
            int throwScore = 0;

            bool isNumber = int.TryParse(input, out throwScore);
            if (isNumber)
            {

                if (throwScore > 60)
                {
                    Console.WriteLine(" This score isn't on the dart board! Enter what you actually scored! ");
                    Console.WriteLine("");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼");
                    Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
                    throwScore = getScore();
                }
                else
                {
                    return throwScore;
                }

                return throwScore;
            }
            else { getScore(); }
            return throwScore;
        }

        public static int totalAttemptScore(int throwinstanceScore)
        {
            // roundScore is the individual dart score
            int roundScore = getScore(); //this referes totalAttemptScore to getScore & is why you dont need to call it in Main
            Console.WriteLine(  roundScore + "roundScore");
            Console.WriteLine(counter + " counter score");
            throwinstanceScore = throwinstanceScore + roundScore;
            if (roundScore <= 20)
            {
                return throwinstanceScore;
            }
            else

            if (impossibleThrow(roundScore) == true)
            {
                Console.WriteLine("This number isn't on the dartboard at all!");
                Console.WriteLine("");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼");
                Console.WriteLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");

            }

            return throwinstanceScore;

        }
        ////identifies all possible doubles and tripples if number not there returns true
        public static bool impossibleThrow(int roundScore)
        { //missing numbers are anything below T20 that cannot be a multiple of 2 or 3 up to 20
            int throwTest = roundScore;
            //if (throwTest > 22)
            int i = 1;
            while (i <= 21)
            {
                int throwTestDouble = i * 2;
                int throwTestTriple = i * 3;
                if (throwTestDouble == roundScore || throwTestTriple == roundScore) //if x = roundscore or y = roundscore

                {
                    return false;
                }

                i++;
            }
            while (roundScore > 20)
            {
                if (roundScore == 25 || roundScore == 50)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public static void splashScreen()
        {
            Console.Clear();
            Console.WriteLine("**************************************************************************************************************");
            Console.WriteLine("**   88888888ba,        Bull        88888888ba 888888888888 ad88888ba                                         **");
            Console.WriteLine("**   88      `*8b      d88b       88      *8b     88     d8*     *8b                                        **");
            Console.WriteLine("**   88        `8b    d8'`8b      88      ,8P     88     Y8,                                                **");
            Console.WriteLine("**   88         88   d8'  `8b     88aaaaaa8P'     88     `Y8aaaaa,                                          **");
            Console.WriteLine("**   88         88  d8YaaaaY8b    88****88'       88       `*****8b,                                        **");
            Console.WriteLine("**   88         8P d8********8b   88    `8b       88             `8b                                        **");
            Console.WriteLine("**   88       .a8P d8'       `8b  88     `8b      88     Y8a     a8P                                        **");
            Console.WriteLine("**   88888888Y*' d8'          `8b 88      `8b     88      *Y88888P*                                         **");
            Console.WriteLine("**************************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("**************************************************************************************************************");
            Console.WriteLine("**                           Welcome to the single player Darts game 501!                                   **");
            Console.WriteLine("**                           New graphics coming soon!                                                      **");
            Console.WriteLine("**************************************************************************************************************");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("         Player 1 score  ");
            Console.WriteLine("**************************************************************************************************************");
            Console.WriteLine("                     501      ");
            Console.WriteLine("");
            int i = 1;
            int remaining = 501;
            while (i <= round)
            {
                remaining = remaining - Convert.ToInt32(roundScore[i - 1]);
                playerAverage = ((501 - remaining) / (i));
                Console.WriteLine("Round " + i + ":   " + Convert.ToInt32(roundScore[i - 1]) + "       " + remaining + "   Average: " + ((501 - remaining) / (i)).ToString());
                Console.WriteLine("");
                i++;
            }
        }

        public static void outs()
        {
            if (counter < 171)
            {
                outsAvailable = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                switch (counter)
                {
                    case 170:
                        Console.WriteLine("T20 , T20 , Bull");
                        break;
                    case 169:
                        Console.WriteLine("bogey");
                        break;
                    case 168:
                        Console.WriteLine("bogey");
                        break;
                    case 167:
                        Console.WriteLine("T20 , T19 , Bull");
                        break;
                    case 166:
                        Console.WriteLine("bogey");
                        break;
                    case 165:
                        Console.WriteLine("bogey");
                        break;
                    case 164:
                        Console.WriteLine("T20 , T18, Bull");
                        break;
                    case 163:
                        Console.WriteLine("bogey");
                        break;
                    case 162:
                        Console.WriteLine("bogey");
                        break;
                    case 161:
                        Console.WriteLine("T20 , T17, Bull");
                        break;
                    case 160:
                        Console.WriteLine("T20 , T20 , D20");
                        break;
                    case 159:
                        Console.WriteLine("bogey");
                        break;
                    case 158:
                        Console.WriteLine("T20 , T20 , D19");
                        break;
                    case 157:
                        Console.WriteLine("T19 , T20 , D20");
                        break;
                    case 156:
                        Console.WriteLine("T20 , T20 , D18");
                        break;
                    case 155:
                        Console.WriteLine("T20 , T19 , D19");
                        break;
                    case 154:
                        Console.WriteLine("T20 , T18, D20");
                        break;
                    case 153:
                        Console.WriteLine("T20 , T19 , D18");
                        break;
                    case 152:
                        Console.WriteLine("T20 , T20 , D16");
                        break;
                    case 151:
                        Console.WriteLine("T20 , T17, D20");
                        break;
                    case 150:
                        Console.WriteLine("T20 , T18, D18");
                        break;
                    case 149:
                        Console.WriteLine("T20 , T19 , D16");
                        break;
                    case 148:
                        Console.WriteLine("T20 , T16 , D20");
                        break;
                    case 147:
                        Console.WriteLine("T20 , T17, D18");
                        break;
                    case 146:
                        Console.WriteLine("T20 , T18, D16");
                        break;
                    case 145:
                        Console.WriteLine("T20 , T15 , D20");
                        break;
                    case 144:
                        Console.WriteLine("T20 , T20 , D12");
                        break;
                    case 143:
                        Console.WriteLine("T20 , T17, D16");
                        break;
                    case 142:
                        Console.WriteLine("T20 , T14 , D20");
                        break;
                    case 141:
                        Console.WriteLine("T20 , T19 , D12");
                        break;
                    case 140:
                        Console.WriteLine("T20 , T16 , D16");
                        break;
                    case 139:
                        Console.WriteLine("T19 , T14 , D20");
                        break;
                    case 138:
                        Console.WriteLine("T20 , T18, D12");
                        break;
                    case 137:
                        Console.WriteLine("T19 , T16 , D16");
                        break;
                    case 136:
                        Console.WriteLine("T20 , T20 , D8");
                        break;
                    case 135:
                        Console.WriteLine("T20 , T17, D12");
                        break;
                    case 134:
                        Console.WriteLine("T20 , T14 , D16");
                        break;
                    case 133:
                        Console.WriteLine("T20 , T19 , D8");
                        break;
                    case 132:
                        Console.WriteLine("T20 , T16 , D12");
                        break;
                    case 131:
                        Console.WriteLine("T20 , T13 , D16");
                        break;
                    case 130:
                        Console.WriteLine("T20 , T20 , D5");
                        Console.WriteLine("20 , T20 , Bull");
                        break;
                    case 129:
                        Console.WriteLine("T19 , T20 , D6");
                        Console.WriteLine("19 , T20 , Bull");
                        break;
                    case 128:
                        Console.WriteLine("T18, T18, D10");
                        Console.WriteLine("18 , T20 , Bull");
                        break;
                    case 127:
                        Console.WriteLine("T20 , T17, D8");
                        Console.WriteLine("20 , T19 , Bull");
                        break;
                    case 126:
                        Console.WriteLine("T19 , T19 , D6");
                        Console.WriteLine("19 , T19 , Bull");
                        break;
                    case 125:
                        Console.WriteLine("T18, T17, D10");
                        Console.WriteLine("18 , T19 , Bull");
                        Console.WriteLine("25 , Bull , Bull");
                        Console.WriteLine("25 , T20 , D20");
                        break;
                    case 124:
                        Console.WriteLine("T20 , T16 , D8");
                        Console.WriteLine("20 , T18, Bull");
                        Console.WriteLine("T20 , T14 , D11");
                        Console.WriteLine("T20 , 14 , Bull");
                        break;
                    case 123:
                        Console.WriteLine("T19 , T16 , D9");
                        Console.WriteLine("19 , T18, Bull");
                        break;
                    case 122:
                        Console.WriteLine("T18, T20 , D4");
                        Console.WriteLine("18 , T18, Bull");
                        break;
                    case 121:
                        Console.WriteLine("T17, 30 , D20");
                        Console.WriteLine("17 , T18, Bull");
                        break;
                    case 120:
                        Console.WriteLine("T20 , 20 , D20");
                        break;
                    case 119:
                        Console.WriteLine("T19 , T14 , D10");
                        Console.WriteLine("19 , T20 , D20");
                        break;
                    case 118:
                        Console.WriteLine("T20 , 18 , D20");
                        Console.WriteLine("20 , T20 , D19");
                        break;
                    case 117:
                        Console.WriteLine("T20 , 17 , D20");
                        Console.WriteLine("20 , T19 , D20");
                        break;
                    case 116:
                        Console.WriteLine("T19 , 19 , D20");
                        break;
                    case 115:
                        Console.WriteLine("T19 , 18 , D20");
                        Console.WriteLine("19 , T20 , D18");
                        break;
                    case 114:
                        Console.WriteLine("T20 , 18 , D18");
                        Console.WriteLine("20 , T18, D20");
                        break;
                    case 113:
                        Console.WriteLine("T20 , 13 , D20");
                        Console.WriteLine("20 , T19 , D18");
                        break;
                    case 112:
                        Console.WriteLine("T20 , 12 , D20");
                        Console.WriteLine("20 , T20 , D16");
                        break;
                    case 111:
                        Console.WriteLine("T18, 14 , D20");
                        Console.WriteLine("19 , T20 , D16");
                        break;
                    case 110:
                        Console.WriteLine("T20 , 18 , D16");
                        Console.WriteLine("20 , T18, D18");
                        break;
                    case 109:
                        Console.WriteLine("T20 , 17 , D16");
                        Console.WriteLine("20 , T19 , D16");
                        break;
                    case 108:
                        Console.WriteLine("T18, 19 , D16");
                        Console.WriteLine("19 , T18, D16");
                        break;
                    case 107:
                        Console.WriteLine("T19 , 18 , D16");
                        Console.WriteLine("19 , T20 , D14");
                        break;
                    case 106:
                        Console.WriteLine("T20 , 14 , D16");
                        Console.WriteLine("20 , T18, D16");
                        break;
                    case 105:
                        Console.WriteLine("T19 , 16 , D16");
                        Console.WriteLine("19 , T18, D16");
                        break;
                    case 104:
                        Console.WriteLine("T18, 18 , D16");
                        Console.WriteLine("18 , T18, D16");
                        break;
                    case 103:
                        Console.WriteLine("T20 , 11 , D16");
                        Console.WriteLine("20 , T17, D16");
                        break;
                    case 102:
                        Console.WriteLine("T20 , 10 , D16");
                        Console.WriteLine("20 , T14 , D20");
                        break;
                    case 101:
                        Console.WriteLine("T19 , 12 , D16");
                        Console.WriteLine("19 , T14 , D20");
                        break;
                    case 100:
                        Console.WriteLine("T20 , D20 ");
                        Console.WriteLine("20 , T20 , D10");
                        break;
                    case 99:
                        Console.WriteLine("T19 , 10 , D16");
                        Console.WriteLine("19 , T20 , D10");
                        break;
                    case 98:
                        Console.WriteLine("T20 , D19 ");
                        Console.WriteLine("20 , T18, D12 ");
                        break;
                    case 97:
                        Console.WriteLine("T19 , D20 ");
                        Console.WriteLine("19 , T18, D12");
                        break;
                    case 96:
                        Console.WriteLine("T20 , D18 ");
                        Console.WriteLine("20 , T20 , D8 ");
                        break;
                    case 95:
                        Console.WriteLine("T19 , D19 ");
                        Console.WriteLine("19 , T20 , D8");
                        break;
                    case 94:
                        Console.WriteLine("T18, D20 ");
                        Console.WriteLine("18 , T20 , D8 ");
                        break;
                    case 93:
                        Console.WriteLine("T19 , D18 ");
                        Console.WriteLine("19 , T14 , D16 ");
                        break;
                    case 92:
                        Console.WriteLine("T20 , D16 ");
                        Console.WriteLine("20 , T16 , D12 ");
                        break;
                    case 91:
                        Console.WriteLine("T17, D20 ");
                        Console.WriteLine("17 , T14 , D16 ");
                        break;
                    case 90:
                        Console.WriteLine("T18, D18 ");
                        Console.WriteLine("18 , T16 , D12 ");
                        break;
                    case 89:
                        Console.WriteLine("T19 , D16 ");
                        Console.WriteLine("19 , T18, D8 ");
                        break;
                    case 88:
                        Console.WriteLine("T20 , D14 ");
                        Console.WriteLine("20 , 60, D4 ");
                        break;
                    case 87:
                        Console.WriteLine("T17, D18 ");
                        Console.WriteLine("17 , T18, D8 ");
                        break;
                    case 86:
                        Console.WriteLine("T18, D16 ");
                        Console.WriteLine("18 , 18 , Bull");
                        break;
                    case 85:
                        Console.WriteLine("T15 , D20 ");
                        Console.WriteLine("15 , 54, D8");
                        break;
                    case 84:
                        Console.WriteLine("T20 , D12 ");
                        Console.WriteLine("20 , 14 , Bull");
                        break;
                    case 83:
                        Console.WriteLine("T17, D16 ");
                        Console.WriteLine("17 , T18, D6");
                        break;
                    case 82:
                        Console.WriteLine("T14 , D20 ");
                        Console.WriteLine("14 , T20 , D4");
                        break;
                    case 81:
                        Console.WriteLine("T19 , D12 ");
                        Console.WriteLine("19 , T14 , D10");
                        break;
                    case 80:
                        Console.WriteLine("T20 , D10 ");
                        Console.WriteLine("20 , 20 , D20");
                        break;
                    case 79:
                        Console.WriteLine("T19 , D11 ");
                        Console.WriteLine("19 , 20 , D20");
                        break;
                    case 78:
                        Console.WriteLine("T18, D12 ");
                        Console.WriteLine("18 , 20 , D20");
                        break;
                    case 77:
                        Console.WriteLine("T19 , D10 ");
                        Console.WriteLine("19 , 18 , D20");
                        break;
                    case 76:
                        Console.WriteLine("T20 , D8 ");
                        Console.WriteLine("20 , T16 , D4");
                        Console.WriteLine("20 , 16 , D20");
                        break;
                    case 75:
                        Console.WriteLine("T17, D12 ");
                        Console.WriteLine("17 , 18 , D20");
                        break;
                    case 74:
                        Console.WriteLine("T14 , D16 ");
                        Console.WriteLine("14 , 20 , D20");
                        break;
                    case 73:
                        Console.WriteLine("T19 , D8 ");
                        Console.WriteLine("19 , 14 , D20");
                        break;
                    case 72:
                        Console.WriteLine("T16 , D12 ");
                        Console.WriteLine("16 , T16 , D4");
                        Console.WriteLine("16 , 24(T8) , D16");
                        Console.WriteLine("16 , 16 , D20");
                        break;
                    case 71:
                        Console.WriteLine("T13 , D16 ");
                        Console.WriteLine("13 , 18 , D20");
                        break;
                    case 70:
                        Console.WriteLine("T18, D8 ");
                        Console.WriteLine("18 , 20 , D16");
                        break;
                    case 69:
                        Console.WriteLine("T15 , D12 ");
                        Console.WriteLine("15 , 14 , D20");
                        break;
                    case 68:
                        Console.WriteLine("T20 , D4 ");
                        Console.WriteLine("20 , 16 , D16");
                        break;
                    case 67:
                        Console.WriteLine("T17, D8 ");
                        Console.WriteLine("17 , 18 , D16");
                        break;
                    case 66:
                        Console.WriteLine("T14 , D12 ");
                        Console.WriteLine("14 , 20 , D16");
                        break;
                    case 65:
                        Console.WriteLine("T11 , D16 ");
                        Console.WriteLine("11 , 12 , D16");
                        break;
                    case 64:
                        Console.WriteLine("T16 , D8 ");
                        Console.WriteLine("16 , 16 , D16");
                        break;
                    case 63:
                        Console.WriteLine("T17, D6 ");
                        Console.WriteLine("17 , 14 , D16");
                        break;
                    case 62:
                        Console.WriteLine("T14 , D10 ");
                        Console.WriteLine("14 , D16 ");
                        break;
                    case 61:
                        Console.WriteLine("T15 , D8 ");
                        Console.WriteLine("15 , 14 , D16");
                        break;
                    case 60:
                        Console.WriteLine("20 , D20 ");
                        break;
                    case 59:
                        Console.WriteLine("19 , D20 ");
                        break;
                    case 58:
                        Console.WriteLine("18 , D20 ");
                        break;
                    case 57:
                        Console.WriteLine("17 , D20 ");
                        break;
                    case 56:
                        Console.WriteLine("16 , D20 ");
                        break;
                    case 55:
                        Console.WriteLine("15 , D20 ");
                        break;
                    case 54:
                        Console.WriteLine("14 , D20 ");
                        break;
                    case 53:
                        Console.WriteLine("13 , D20 ");
                        break;
                    case 52:
                        Console.WriteLine("20 , D16 ");
                        break;
                    case 51:
                        Console.WriteLine("19 , D16 ");
                        break;
                    case 50:
                        Console.WriteLine("18 , D16 ");
                        break;
                    case 49:
                        Console.WriteLine("17 , D16 ");
                        break;
                    case 48:
                        Console.WriteLine("16 , D16 ");
                        break;
                    case 47:
                        Console.WriteLine("15 , D16 ");
                        break;
                    case 46:
                        Console.WriteLine("14 , D16 ");
                        break;
                    case 45:
                        Console.WriteLine("13 , D16 ");
                        break;
                    case 44:
                        Console.WriteLine("12 , D16 ");
                        break;
                    case 43:
                        Console.WriteLine("11 , D16 ");
                        break;
                    case 42:
                        Console.WriteLine("10 , D16 ");
                        break;
                    case 41:
                        Console.WriteLine("9 , D16 ");
                        break;
                    case 40:
                        Console.WriteLine("D20 ");
                        break;
                    case 39:
                        Console.WriteLine("7 , D16");
                        break;
                    case 38:
                        Console.WriteLine("6 , D16 ");
                        break;
                    case 37:
                        Console.WriteLine("5 , D16 ");
                        break;
                    case 36:
                        Console.WriteLine("D18 ");
                        break;
                    case 35:
                        Console.WriteLine("3 , D16 ");
                        break;
                    case 34:
                        Console.WriteLine("2 , D16 ");
                        break;
                    case 33:
                        Console.WriteLine("1 , D16 ");
                        break;
                    case 32:
                        Console.WriteLine("D16 ");
                        break;
                    case 31:
                        Console.WriteLine("15 , D8 ");
                        break;
                    case 30:
                        Console.WriteLine("14 , D8 ");
                        break;
                    case 29:
                        Console.WriteLine("13 , D8 ");
                        break;
                    case 28:
                        Console.WriteLine("12 , D8 ");
                        break;
                    case 27:
                        Console.WriteLine("11 , D8 ");
                        break;
                    case 26:
                        Console.WriteLine("10 , D8 ");
                        break;
                    case 25:
                        Console.WriteLine("9 , D8 ");
                        break;
                    case 24:
                        Console.WriteLine("D12 ");
                        break;
                    case 23:
                        Console.WriteLine("7 , D8 ");
                        break;
                    case 22:
                        Console.WriteLine("6 , D8 ");
                        break;
                    case 21:
                        Console.WriteLine("5 , D8 ");
                        break;
                    case 20:
                        Console.WriteLine("D10");
                        break;
                    case 19:
                        Console.WriteLine("3 , D8");
                        break;
                    case 18:
                        Console.WriteLine("D9");
                        break;
                    case 17:
                        Console.WriteLine("1 , D8");
                        break;
                    default:
                        Console.WriteLine("figure it out " + counter);
                        break;
                }
                Console.ResetColor();

            }
        }

        public static void SetSettings(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void seeIfThereAreOuts(int left)
        {
            if (left < 171)
            {
                outsAvailable = 1;
                Console.ForegroundColor = ConsoleColor.Red;
                switch (left)
                {
                    case 170:
                        Console.WriteLine("T20 , T20 , Bull");
                        break;
                    case 169:
                        Console.WriteLine("bogey");
                        break;
                    case 168:
                        Console.WriteLine("bogey");
                        break;
                    case 167:
                        Console.WriteLine("T20 , T19 , Bull");
                        break;
                    case 166:
                        Console.WriteLine("bogey");
                        break;
                    case 165:
                        Console.WriteLine("bogey");
                        break;
                    case 164:
                        Console.WriteLine("T20 , T18, Bull");
                        break;
                    case 163:
                        Console.WriteLine("bogey");
                        break;
                    case 162:
                        Console.WriteLine("bogey");
                        break;
                    case 161:
                        Console.WriteLine("T20 , T17, Bull");
                        break;
                    case 160:
                        Console.WriteLine("T20 , T20 , D20");
                        break;
                    case 159:
                        Console.WriteLine("bogey");
                        break;
                    case 158:
                        Console.WriteLine("T20 , T20 , D19");
                        break;
                    case 157:
                        Console.WriteLine("T19 , T20 , D20");
                        break;
                    case 156:
                        Console.WriteLine("T20 , T20 , D18");
                        break;
                    case 155:
                        Console.WriteLine("T20 , T19 , D19");
                        break;
                    case 154:
                        Console.WriteLine("T20 , T18, D20");
                        break;
                    case 153:
                        Console.WriteLine("T20 , T19 , D18");
                        break;
                    case 152:
                        Console.WriteLine("T20 , T20 , D16");
                        break;
                    case 151:
                        Console.WriteLine("T20 , T17, D20");
                        break;
                    case 150:
                        Console.WriteLine("T20 , T18, D18");
                        break;
                    case 149:
                        Console.WriteLine("T20 , T19 , D16");
                        break;
                    case 148:
                        Console.WriteLine("T20 , T16 , D20");
                        break;
                    case 147:
                        Console.WriteLine("T20 , T17, D18");
                        break;
                    case 146:
                        Console.WriteLine("T20 , T18, D16");
                        break;
                    case 145:
                        Console.WriteLine("T20 , T15 , D20");
                        break;
                    case 144:
                        Console.WriteLine("T20 , T20 , D12");
                        break;
                    case 143:
                        Console.WriteLine("T20 , T17, D16");
                        break;
                    case 142:
                        Console.WriteLine("T20 , T14 , D20");
                        break;
                    case 141:
                        Console.WriteLine("T20 , T19 , D12");
                        break;
                    case 140:
                        Console.WriteLine("T20 , T16 , D16");
                        break;
                    case 139:
                        Console.WriteLine("T19 , T14 , D20");
                        break;
                    case 138:
                        Console.WriteLine("T20 , T18, D12");
                        break;
                    case 137:
                        Console.WriteLine("T19 , T16 , D16");
                        break;
                    case 136:
                        Console.WriteLine("T20 , T20 , D8");
                        break;
                    case 135:
                        Console.WriteLine("T20 , T17, D12");
                        break;
                    case 134:
                        Console.WriteLine("T20 , T14 , D16");
                        break;
                    case 133:
                        Console.WriteLine("T20 , T19 , D8");
                        break;
                    case 132:
                        Console.WriteLine("T20 , T16 , D12");
                        break;
                    case 131:
                        Console.WriteLine("T20 , T13 , D16");
                        break;
                    case 130:
                        Console.WriteLine("T20 , T20 , D5");
                        Console.WriteLine("20 , T20 , Bull");
                        break;
                    case 129:
                        Console.WriteLine("T19 , T20 , D6");
                        Console.WriteLine("19 , T20 , Bull");
                        break;
                    case 128:
                        Console.WriteLine("T18, T18, D10");
                        Console.WriteLine("18 , T20 , Bull");
                        break;
                    case 127:
                        Console.WriteLine("T20 , T17, D8");
                        Console.WriteLine("20 , T19 , Bull");
                        break;
                    case 126:
                        Console.WriteLine("T19 , T19 , D6");
                        Console.WriteLine("19 , T19 , Bull");
                        break;
                    case 125:
                        Console.WriteLine("T18, T17, D10");
                        Console.WriteLine("18 , T19 , Bull");
                        Console.WriteLine("25 , Bull , Bull");
                        Console.WriteLine("25 , T20 , D20");
                        break;
                    case 124:
                        Console.WriteLine("T20 , T16 , D8");
                        Console.WriteLine("20 , T18, Bull");
                        Console.WriteLine("T20 , T14 , D11");
                        Console.WriteLine("T20 , 14 , Bull");
                        break;
                    case 123:
                        Console.WriteLine("T19 , T16 , D9");
                        Console.WriteLine("19 , T18, Bull");
                        break;
                    case 122:
                        Console.WriteLine("T18, T20 , D4");
                        Console.WriteLine("18 , T18, Bull");
                        break;
                    case 121:
                        Console.WriteLine("T17, 30 , D20");
                        Console.WriteLine("17 , T18, Bull");
                        break;
                    case 120:
                        Console.WriteLine("T20 , 20 , D20");
                        break;
                    case 119:
                        Console.WriteLine("T19 , T14 , D10");
                        Console.WriteLine("19 , T20 , D20");
                        break;
                    case 118:
                        Console.WriteLine("T20 , 18 , D20");
                        Console.WriteLine("20 , T20 , D19");
                        break;
                    case 117:
                        Console.WriteLine("T20 , 17 , D20");
                        Console.WriteLine("20 , T19 , D20");
                        break;
                    case 116:
                        Console.WriteLine("T19 , 19 , D20");
                        break;
                    case 115:
                        Console.WriteLine("T19 , 18 , D20");
                        Console.WriteLine("19 , T20 , D18");
                        break;
                    case 114:
                        Console.WriteLine("T20 , 18 , D18");
                        Console.WriteLine("20 , T18, D20");
                        break;
                    case 113:
                        Console.WriteLine("T20 , 13 , D20");
                        Console.WriteLine("20 , T19 , D18");
                        break;
                    case 112:
                        Console.WriteLine("T20 , 12 , D20");
                        Console.WriteLine("20 , T20 , D16");
                        break;
                    case 111:
                        Console.WriteLine("T18, 14 , D20");
                        Console.WriteLine("19 , T20 , D16");
                        break;
                    case 110:
                        Console.WriteLine("T20 , 18 , D16");
                        Console.WriteLine("20 , T18, D18");
                        break;
                    case 109:
                        Console.WriteLine("T20 , 17 , D16");
                        Console.WriteLine("20 , T19 , D16");
                        break;
                    case 108:
                        Console.WriteLine("T18, 19 , D16");
                        Console.WriteLine("19 , T18, D16");
                        break;
                    case 107:
                        Console.WriteLine("T19 , 18 , D16");
                        Console.WriteLine("19 , T20 , D14");
                        break;
                    case 106:
                        Console.WriteLine("T20 , 14 , D16");
                        Console.WriteLine("20 , T18, D16");
                        break;
                    case 105:
                        Console.WriteLine("T19 , 16 , D16");
                        Console.WriteLine("19 , T18, D16");
                        break;
                    case 104:
                        Console.WriteLine("T18, 18 , D16");
                        Console.WriteLine("18 , T18, D16");
                        break;
                    case 103:
                        Console.WriteLine("T20 , 11 , D16");
                        Console.WriteLine("20 , T17, D16");
                        break;
                    case 102:
                        Console.WriteLine("T20 , 10 , D16");
                        Console.WriteLine("20 , T14 , D20");
                        break;
                    case 101:
                        Console.WriteLine("T19 , 12 , D16");
                        Console.WriteLine("19 , T14 , D20");
                        break;
                    case 100:
                        Console.WriteLine("T20 , D20 ");
                        Console.WriteLine("20 , T20 , D10");
                        break;
                    case 99:
                        Console.WriteLine("T19 , 10 , D16");
                        Console.WriteLine("19 , T20 , D10");
                        break;
                    case 98:
                        Console.WriteLine("T20 , D19 ");
                        Console.WriteLine("20 , T18, D12 ");
                        break;
                    case 97:
                        Console.WriteLine("T19 , D20 ");
                        Console.WriteLine("19 , T18, D12");
                        break;
                    case 96:
                        Console.WriteLine("T20 , D18 ");
                        Console.WriteLine("20 , T20 , D8 ");
                        break;
                    case 95:
                        Console.WriteLine("T19 , D19 ");
                        Console.WriteLine("19 , T20 , D8");
                        break;
                    case 94:
                        Console.WriteLine("T18, D20 ");
                        Console.WriteLine("18 , T20 , D8 ");
                        break;
                    case 93:
                        Console.WriteLine("T19 , D18 ");
                        Console.WriteLine("19 , T14 , D16 ");
                        break;
                    case 92:
                        Console.WriteLine("T20 , D16 ");
                        Console.WriteLine("20 , T16 , D12 ");
                        break;
                    case 91:
                        Console.WriteLine("T17, D20 ");
                        Console.WriteLine("17 , T14 , D16 ");
                        break;
                    case 90:
                        Console.WriteLine("T18, D18 ");
                        Console.WriteLine("18 , T16 , D12 ");
                        break;
                    case 89:
                        Console.WriteLine("T19 , D16 ");
                        Console.WriteLine("19 , T18, D8 ");
                        break;
                    case 88:
                        Console.WriteLine("T20 , D14 ");
                        Console.WriteLine("20 , 60, D4 ");
                        break;
                    case 87:
                        Console.WriteLine("T17, D18 ");
                        Console.WriteLine("17 , T18, D8 ");
                        break;
                    case 86:
                        Console.WriteLine("T18, D16 ");
                        Console.WriteLine("18 , 18 , Bull");
                        break;
                    case 85:
                        Console.WriteLine("T15 , D20 ");
                        Console.WriteLine("15 , 54, D8");
                        break;
                    case 84:
                        Console.WriteLine("T20 , D12 ");
                        Console.WriteLine("20 , 14 , Bull");
                        break;
                    case 83:
                        Console.WriteLine("T17, D16 ");
                        Console.WriteLine("17 , T18, D6");
                        break;
                    case 82:
                        Console.WriteLine("T14 , D20 ");
                        Console.WriteLine("14 , T20 , D4");
                        break;
                    case 81:
                        Console.WriteLine("T19 , D12 ");
                        Console.WriteLine("19 , T14 , D10");
                        break;
                    case 80:
                        Console.WriteLine("T20 , D10 ");
                        Console.WriteLine("20 , 20 , D20");
                        break;
                    case 79:
                        Console.WriteLine("T19 , D11 ");
                        Console.WriteLine("19 , 20 , D20");
                        break;
                    case 78:
                        Console.WriteLine("T18, D12 ");
                        Console.WriteLine("18 , 20 , D20");
                        break;
                    case 77:
                        Console.WriteLine("T19 , D10 ");
                        Console.WriteLine("19 , 18 , D20");
                        break;
                    case 76:
                        Console.WriteLine("T20 , D8 ");
                        Console.WriteLine("20 , T16 , D4");
                        Console.WriteLine("20 , 16 , D20");
                        break;
                    case 75:
                        Console.WriteLine("T17, D12 ");
                        Console.WriteLine("17 , 18 , D20");
                        break;
                    case 74:
                        Console.WriteLine("T14 , D16 ");
                        Console.WriteLine("14 , 20 , D20");
                        break;
                    case 73:
                        Console.WriteLine("T19 , D8 ");
                        Console.WriteLine("19 , 14 , D20");
                        break;
                    case 72:
                        Console.WriteLine("T16 , D12 ");
                        Console.WriteLine("16 , T16 , D4");
                        Console.WriteLine("16 , 24(T8) , D16");
                        Console.WriteLine("16 , 16 , D20");
                        break;
                    case 71:
                        Console.WriteLine("T13 , D16 ");
                        Console.WriteLine("13 , 18 , D20");
                        break;
                    case 70:
                        Console.WriteLine("T18, D8 ");
                        Console.WriteLine("18 , 20 , D16");
                        break;
                    case 69:
                        Console.WriteLine("T15 , D12 ");
                        Console.WriteLine("15 , 14 , D20");
                        break;
                    case 68:
                        Console.WriteLine("T20 , D4 ");
                        Console.WriteLine("20 , 16 , D16");
                        break;
                    case 67:
                        Console.WriteLine("T17, D8 ");
                        Console.WriteLine("17 , 18 , D16");
                        break;
                    case 66:
                        Console.WriteLine("T14 , D12 ");
                        Console.WriteLine("14 , 20 , D16");
                        break;
                    case 65:
                        Console.WriteLine("T11 , D16 ");
                        Console.WriteLine("11 , 12 , D16");
                        break;
                    case 64:
                        Console.WriteLine("T16 , D8 ");
                        Console.WriteLine("16 , 16 , D16");
                        break;
                    case 63:
                        Console.WriteLine("T17, D6 ");
                        Console.WriteLine("17 , 14 , D16");
                        break;
                    case 62:
                        Console.WriteLine("T14 , D10 ");
                        Console.WriteLine("14 , D16 ");
                        break;
                    case 61:
                        Console.WriteLine("T15 , D8 ");
                        Console.WriteLine("15 , 14 , D16");
                        break;
                    case 60:
                        Console.WriteLine("20 , D20 ");
                        break;
                    case 59:
                        Console.WriteLine("19 , D20 ");
                        break;
                    case 58:
                        Console.WriteLine("18 , D20 ");
                        break;
                    case 57:
                        Console.WriteLine("17 , D20 ");
                        break;
                    case 56:
                        Console.WriteLine("16 , D20 ");
                        break;
                    case 55:
                        Console.WriteLine("15 , D20 ");
                        break;
                    case 54:
                        Console.WriteLine("14 , D20 ");
                        break;
                    case 53:
                        Console.WriteLine("13 , D20 ");
                        break;
                    case 52:
                        Console.WriteLine("20 , D16 ");
                        break;
                    case 51:
                        Console.WriteLine("19 , D16 ");
                        break;
                    case 50:
                        Console.WriteLine("18 , D16 ");
                        break;
                    case 49:
                        Console.WriteLine("17 , D16 ");
                        break;
                    case 48:
                        Console.WriteLine("16 , D16 ");
                        break;
                    case 47:
                        Console.WriteLine("15 , D16 ");
                        break;
                    case 46:
                        Console.WriteLine("14 , D16 ");
                        break;
                    case 45:
                        Console.WriteLine("13 , D16 ");
                        break;
                    case 44:
                        Console.WriteLine("12 , D16 ");
                        break;
                    case 43:
                        Console.WriteLine("11 , D16 ");
                        break;
                    case 42:
                        Console.WriteLine("10 , D16 ");
                        break;
                    case 41:
                        Console.WriteLine("9 , D16 ");
                        break;
                    case 40:
                        Console.WriteLine("D20 ");
                        break;
                    case 39:
                        Console.WriteLine("7 , D16");
                        break;
                    case 38:
                        Console.WriteLine("6 , D16 ");
                        break;
                    case 37:
                        Console.WriteLine("5 , D16 ");
                        break;
                    case 36:
                        Console.WriteLine("D18 ");
                        break;
                    case 35:
                        Console.WriteLine("3 , D16 ");
                        break;
                    case 34:
                        Console.WriteLine("2 , D16 ");
                        break;
                    case 33:
                        Console.WriteLine("1 , D16 ");
                        break;
                    case 32:
                        Console.WriteLine("D16 ");
                        break;
                    case 31:
                        Console.WriteLine("15 , D8 ");
                        break;
                    case 30:
                        Console.WriteLine("14 , D8 ");
                        break;
                    case 29:
                        Console.WriteLine("13 , D8 ");
                        break;
                    case 28:
                        Console.WriteLine("12 , D8 ");
                        break;
                    case 27:
                        Console.WriteLine("11 , D8 ");
                        break;
                    case 26:
                        Console.WriteLine("10 , D8 ");
                        break;
                    case 25:
                        Console.WriteLine("9 , D8 ");
                        break;
                    case 24:
                        Console.WriteLine("D12 ");
                        break;
                    case 23:
                        Console.WriteLine("7 , D8 ");
                        break;
                    case 22:
                        Console.WriteLine("6 , D8 ");
                        break;
                    case 21:
                        Console.WriteLine("5 , D8 ");
                        break;
                    case 20:
                        Console.WriteLine("D10");
                        break;
                    case 19:
                        Console.WriteLine("3 , D8");
                        break;
                    case 18:
                        Console.WriteLine("D9");
                        break;
                    case 17:
                        Console.WriteLine("1 , D8");
                        break;
                    default:
                        Console.WriteLine("figure it out " + counter);
                        break;
                }
                Console.ResetColor();
            }
        }

        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }

        internal struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int dwType);


        public static void SetConsoleFont(string fontName = "Lucida Console", short fontSizeX = 8, short fontSizeY = 16)
        {
            unsafe
            {
                IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
                if (hnd != INVALID_HANDLE_VALUE)
                {
                    CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);

                    CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    newInfo.dwFontSize = new COORD(fontSizeX, fontSizeY);
                    newInfo.FontWeight = 700; // Bold font
                    SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }


    }



}


