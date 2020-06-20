using System;
using System.Text.RegularExpressions;

namespace CodeWars.Forms
{
    internal class Parse
    {
        public static int Evaluate(string expression, Player player)
        {
            // funkce zamýšlená pro vyhodnocení infixních výrazů ve stringu a doplění proměnných
            // z časových důvodu slouží pro rozeznání proměnné var a odstranění závorek
            if (expression == "(var)")
            {
                return -1;
            }
            expression = expression.Substring(1, expression.IndexOf(")", StringComparison.Ordinal) - 1);
            int result = Convert.ToInt32(expression);
            return result;
        }
        public static void SendGrammar(string playerCode, Player player)
        { // rozklad kódu na řádky pomocí Split a středníku, následné zpracování řádky
            if (playerCode.Length == 0)
            {
                // je-li kód prázdný, začleníme do fronty alespoň něco, aby nebyla prázdná
                player.complexQueue.Enqueue(new RadarLeft(5, player));
                return;
            }

            // zbavíme se velkých písmen a bílých mezer
            playerCode = playerCode.ToLower();
            playerCode = Regex.Replace(playerCode, @"\s", "");
            string[] lines = playerCode.Split(';');

            foreach (string line in lines)
            {
                // jako příkaz chápeme substring před první závorkou, jako argument vše po první závorce včetně
                string command = line.Substring(0, Math.Max(0, line.IndexOf("(", StringComparison.Ordinal)));
                string expression = line.Substring(Math.Max(0, line.IndexOf("(", StringComparison.Ordinal)));
                if (command.Length == 0 || expression.Length == 0)
                {
                    continue;
                }
                int processedExpression = Evaluate(expression, player);

                switch (command)
                { // pokud příkaz rozeznáme, připravíme ho funkcí deconstruct
                    case "forward":
                        player.complexQueue.Enqueue(new Ahead(processedExpression, player));
                        break;
                    case "backwards":
                        player.complexQueue.Enqueue(new Back(processedExpression, player));
                        break;
                    case "turnleft":
                        player.complexQueue.Enqueue(new TurnLeft(processedExpression, player));
                        break;
                    case "turnright":
                        player.complexQueue.Enqueue(new TurnRight(processedExpression, player));
                        break;
                    case "fire":
                        player.complexQueue.Enqueue(new Fire(10, player));
                        break;
                    case "rotategunleft":
                        player.complexQueue.Enqueue(new GunLeft(processedExpression, player));
                        break;
                    case "rotategunright":
                        player.complexQueue.Enqueue(new GunRight(processedExpression, player));
                        break;
                    case "rotateradarleft":
                        player.complexQueue.Enqueue(new RadarLeft(processedExpression, player));
                        break;
                    case "rotateradarright":
                        player.complexQueue.Enqueue(new RadarRight(processedExpression, player));
                        break;
                }
            }
            if (player.complexQueue.Count == 0)
            {
                // pokud žádný příkaz nerozeznáme, pak je fronta prázdná a začleníme do ní alespoň něco
                player.complexQueue.Enqueue(new RadarLeft(5, player));
            }
        }
    }
}
