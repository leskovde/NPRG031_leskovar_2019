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
            if (expression == "(var)") return -1;
            expression = expression.Substring(1, expression.IndexOf(")", StringComparison.Ordinal) - 1);
            var result = Convert.ToInt32(expression);
            return result;
        }

        public static void SendGrammar(string playerCode, Player player)
        {
            // rozklad kódu na řádky pomocí Split a středníku, následné zpracování řádky
            if (playerCode.Length == 0)
            {
                // je-li kód prázdný, začleníme do fronty alespoň něco, aby nebyla prázdná
                player.ComplexQueue.Enqueue(new RadarLeft(5, player));
                return;
            }

            // zbavíme se velkých písmen a bílých mezer
            playerCode = playerCode.ToLower();
            playerCode = Regex.Replace(playerCode, @"\s", "");
            var lines = playerCode.Split(';');

            foreach (var line in lines)
            {
                // jako příkaz chápeme substring před první závorkou, jako argument vše po první závorce včetně
                var command = line.Substring(0, Math.Max(0, line.IndexOf("(", StringComparison.Ordinal)));
                var expression = line.Substring(Math.Max(0, line.IndexOf("(", StringComparison.Ordinal)));
                if (command.Length == 0 || expression.Length == 0) continue;
                var processedExpression = Evaluate(expression, player);

                switch (command)
                {
                    // pokud příkaz rozeznáme, připravíme ho funkcí deconstruct
                    case "forward":
                        player.ComplexQueue.Enqueue(new Ahead(processedExpression, player));
                        break;
                    case "backwards":
                        player.ComplexQueue.Enqueue(new Back(processedExpression, player));
                        break;
                    case "turnleft":
                        player.ComplexQueue.Enqueue(new TurnLeft(processedExpression, player));
                        break;
                    case "turnright":
                        player.ComplexQueue.Enqueue(new TurnRight(processedExpression, player));
                        break;
                    case "fire":
                        player.ComplexQueue.Enqueue(new Fire(10, player));
                        break;
                    case "rotategunleft":
                        player.ComplexQueue.Enqueue(new GunLeft(processedExpression, player));
                        break;
                    case "rotategunright":
                        player.ComplexQueue.Enqueue(new GunRight(processedExpression, player));
                        break;
                    case "rotateradarleft":
                        player.ComplexQueue.Enqueue(new RadarLeft(processedExpression, player));
                        break;
                    case "rotateradarright":
                        player.ComplexQueue.Enqueue(new RadarRight(processedExpression, player));
                        break;
                }
            }

            if (player.ComplexQueue.Count == 0)
                // pokud žádný příkaz nerozeznáme, pak je fronta prázdná a začleníme do ní alespoň něco
                player.ComplexQueue.Enqueue(new RadarLeft(5, player));
        }
    }
}