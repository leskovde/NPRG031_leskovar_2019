/* 
     CodeWars 
  	 Denis Leskovar, I. ročník
  	 letní semestr 2018/19 
  	 Programování II NPRG031
*/
using System.Collections.Generic;

namespace CodeWars.Forms
{
    internal class Engine // prostředí pro spouštění událostí diskretní simulace
    {
        private static int _tickCount;
        public static int GetTickCount()
        {
            return _tickCount;
        }
        private static void Deconstruct(Instruction complexCommand)
        {
            // rozkládá instrukce, které nelze vykonat okamžitě, na snazší operace
            int moveSpeed = complexCommand.player.GetAttrib("maxSpeed"); // rychlost slouží jako limit pro danou operaci
            int numberOfTimes, remainingUnits;
            switch (complexCommand.GetId())
            {
                case 1:
                    // instrukce ahead
                    numberOfTimes = complexCommand.mainStat / moveSpeed; // určíme počet jednoduchých instrukcí
                    remainingUnits = complexCommand.mainStat % moveSpeed; // nezapomeneme na to, co zbyde

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new Ahead(moveSpeed,
                            complexCommand.player)); // frontu naplníme vícero instancemi dané instrukce
                    }

                    complexCommand.player.instructionQueue.Enqueue(new Ahead(remainingUnits,
                            complexCommand.player)); // nakonec přidáme i zbytek
                    break;
                case 2:
                    // instrukce back - všechny zbylé (kromě fire a game over) instrukce analogicky
                    numberOfTimes = complexCommand.mainStat / moveSpeed;
                    remainingUnits = complexCommand.mainStat % moveSpeed;

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new Back(moveSpeed,
                            complexCommand.player));
                    }

                    complexCommand.player.instructionQueue.Enqueue(new Back(remainingUnits,
                            complexCommand.player));
                    break;
                case 3:
                    // instrukce left
                    numberOfTimes = complexCommand.mainStat / (moveSpeed / 2);
                    remainingUnits = complexCommand.mainStat % (moveSpeed / 2);

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new TurnLeft(moveSpeed / 2,
                            complexCommand.player));
                    }

                    complexCommand.player.instructionQueue.Enqueue(new TurnLeft(remainingUnits,
                            complexCommand.player));
                    break;
                case 4:
                    // instrukce right
                    numberOfTimes = complexCommand.mainStat / (moveSpeed / 2);
                    remainingUnits = complexCommand.mainStat % (moveSpeed / 2);

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new TurnRight(moveSpeed / 2,
                            complexCommand.player));
                    }

                    complexCommand.player.instructionQueue.Enqueue(new TurnRight(remainingUnits,
                            complexCommand.player));
                    break;
                case 5:
                    // instrukce fire - je okamžitá, nic nerozkládáme
                    complexCommand.player.instructionQueue.Enqueue(new Fire(complexCommand.mainStat,
                            complexCommand.player));
                    break;
                case 6:
                    // instrukce gun left
                    // pokud při parsování narazíme na var, přeneseme jej jako -1 zde
                    if (complexCommand.mainStat == -1)
                    {
                        // posíláme dále s -1, jinak pokračujeme analogicky
                        complexCommand.player.instructionQueue.Enqueue(new GunLeft(-1,
                            complexCommand.player));
                        break;
                    }

                    numberOfTimes = complexCommand.mainStat / moveSpeed;
                    remainingUnits = complexCommand.mainStat % moveSpeed;

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new GunLeft(moveSpeed,
                            complexCommand.player));
                    }

                    complexCommand.player.instructionQueue.Enqueue(new GunLeft(remainingUnits,
                            complexCommand.player));
                    break;
                case 7:
                    // instrukce gun right
                    // případný var posíláme dále s -1, posíláme jako gunLeft, jelikož na směru nezáleží
                    if (complexCommand.mainStat == -1)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new GunLeft(-1,
                            complexCommand.player));
                        break;
                    }

                    numberOfTimes = complexCommand.mainStat / moveSpeed;
                    remainingUnits = complexCommand.mainStat % moveSpeed;

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new GunRight(moveSpeed,
                            complexCommand.player));
                    }

                    complexCommand.player.instructionQueue.Enqueue(new GunRight(remainingUnits,
                            complexCommand.player));
                    break;
                case 8:
                    // instrukce radar left
                    numberOfTimes = complexCommand.mainStat / (moveSpeed * 2);
                    remainingUnits = complexCommand.mainStat % (moveSpeed * 2);

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new RadarLeft(moveSpeed * 2,
                            complexCommand.player));
                    }

                    complexCommand.player.instructionQueue.Enqueue(new RadarLeft(remainingUnits,
                            complexCommand.player));
                    break;
                case 9:
                    // instrukce radar right
                    numberOfTimes = complexCommand.mainStat / (moveSpeed * 2);
                    remainingUnits = complexCommand.mainStat % (moveSpeed * 2);

                    for (int i = 1; i <= numberOfTimes; i++)
                    {
                        complexCommand.player.instructionQueue.Enqueue(new RadarRight(moveSpeed * 2,
                            complexCommand.player));
                    }

                    complexCommand.player.instructionQueue.Enqueue(new RadarRight(remainingUnits,
                            complexCommand.player));
                    break;
                case 10:
                    // instrukce game over - opět okamžitá
                    complexCommand.player.instructionQueue.Enqueue(new GameOver(complexCommand.mainStat,
                           complexCommand.player));
                    break;
            }
        }
        public static bool Execute(Instruction instr) // vykoná jednoduchou instrukci
        {
            bool gameNotOver = true; // pro případ, kdyby hráč prohrál, abychom instrukci nevraceli do fronty
            switch (instr.GetId())
            {
                case 1:
                    // ahead
                    instr.player.MoveForward(instr.mainStat);
                    break;
                case 2:
                    // back
                    instr.player.MoveBackwards(instr.mainStat);
                    break;
                case 3:
                    // left
                    instr.player.RotateVehicle(instr.mainStat);
                    break;
                case 4:
                    // right
                    instr.player.RotateVehicle(-instr.mainStat);
                    break;
                case 5:
                    // fire
                    instr.player.Fire(instr.mainStat);
                    break;
                case 6:
                    // gun left
                    // řešíme případ s var, jelikož je bitmapa radaru otočená, je nutné s ní dělo srovnat
                    // proto orientaci násobíme -1 a odčítáme 180
                    if (instr.mainStat == -1)
                    {
                        instr.player.ResetGunOrientation();
                        instr.player.RotateGun(-1 * (instr.player.GetAttrib("lastSpottedOrientation") - 180));
                    }
                    instr.player.RotateGun(instr.mainStat);
                    break;
                case 7:
                    // gun right
                    instr.player.RotateGun(-instr.mainStat);
                    break;
                case 8:
                    // radar left
                    instr.player.RotateRadar(instr.mainStat);
                    break;
                case 9:
                    // radar right
                    instr.player.RotateGun(-instr.mainStat);
                    break;
                case 10:
                    // game over
                    // hráč byl vyřazen, proto ho vyjmeme ze seznamu aktivních hráčů a obarvíme černě
                    gameNotOver = false;
                    instr.player.GameOver();
                    CwForm.playerList.Remove(instr.player); // hráčovy instrukce se nebudou dále vykonávat

                    // zbyde-li jediný hráč, vracíme true, což povede k ukončení programu
                    if (CwForm.playerList.Count == 1)
                    {
                        return true;
                    }
                    break;
            }
            if (gameNotOver)
                instr.player.instructionQueue.Enqueue(instr); // po provedení vracíme zpět do fronty
            return false;
        }
        public static void Prepare(Queue<Instruction> complexQueue)
        {   // převede frontu těžkých instrukcí na frontu lehkých
            while (complexQueue.Count != 0)
            {
                Instruction complexCommand = complexQueue.Dequeue();
                Deconstruct(complexCommand);
            }
        }
        public static bool RunSimulation(List<Player> playerList) // pro každého hráče provede jednu instrukci
        {   // počítáme ticky hlavního timeru, po 150 sekundách vracíme true a hra končí
            if (_tickCount > 15000)
                return true;
            for (int i = playerList.Count - 1; i >= 0; i--)
            {
                Instruction currentCommand = playerList[i].instructionQueue.Dequeue();
                if (Execute(currentCommand))
                {
                    // vrátil-li game over true (zbyl jeden hráč), vratíme true a hra končí
                    return true;
                }
            }
            _tickCount++;
            return false;
        }
    }
}
