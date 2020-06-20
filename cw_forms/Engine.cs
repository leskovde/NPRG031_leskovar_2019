/* 
     CodeWars 
  	 Denis Leskovar, I. ročník
  	 letní semestr 2018/19 
  	 Programování II NPRG031
*/

using System;
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
            var moveSpeed = complexCommand.Player.GetAttrib("maxSpeed"); // rychlost slouží jako limit pro danou operaci
            int numberOfTimes, remainingUnits;
            switch (complexCommand.GetId())
            {
                case Instructions.Ahead:
                    numberOfTimes = complexCommand.MainStat / moveSpeed; // určíme počet jednoduchých instrukcí
                    remainingUnits = complexCommand.MainStat % moveSpeed; // nezapomeneme na to, co zbyde

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new Ahead(moveSpeed,
                            complexCommand.Player)); // frontu naplníme vícero instancemi dané instrukce

                    complexCommand.Player.InstructionQueue.Enqueue(new Ahead(remainingUnits,
                        complexCommand.Player)); // nakonec přidáme i zbytek
                    break;
                case Instructions.Back:
                    // všechny zbylé (kromě fire a game over) instrukce analogicky
                    numberOfTimes = complexCommand.MainStat / moveSpeed;
                    remainingUnits = complexCommand.MainStat % moveSpeed;

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new Back(moveSpeed,
                            complexCommand.Player));

                    complexCommand.Player.InstructionQueue.Enqueue(new Back(remainingUnits,
                        complexCommand.Player));
                    break;
                case Instructions.Left:
                    numberOfTimes = complexCommand.MainStat / (moveSpeed / 2);
                    remainingUnits = complexCommand.MainStat % (moveSpeed / 2);

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new TurnLeft(moveSpeed / 2,
                            complexCommand.Player));

                    complexCommand.Player.InstructionQueue.Enqueue(new TurnLeft(remainingUnits,
                        complexCommand.Player));
                    break;
                case Instructions.Right:
                    numberOfTimes = complexCommand.MainStat / (moveSpeed / 2);
                    remainingUnits = complexCommand.MainStat % (moveSpeed / 2);

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new TurnRight(moveSpeed / 2,
                            complexCommand.Player));

                    complexCommand.Player.InstructionQueue.Enqueue(new TurnRight(remainingUnits,
                        complexCommand.Player));
                    break;
                case Instructions.Fire:
                    // instrukce je okamžitá, nic nerozkládáme
                    complexCommand.Player.InstructionQueue.Enqueue(new Fire(complexCommand.MainStat,
                        complexCommand.Player));
                    break;
                case Instructions.GunLeft:
                    // pokud při parsování narazíme na var, přeneseme jej jako -1 zde
                    if (complexCommand.MainStat == -1)
                    {
                        // posíláme dále s -1, jinak pokračujeme analogicky
                        complexCommand.Player.InstructionQueue.Enqueue(new GunLeft(-1,
                            complexCommand.Player));
                        break;
                    }

                    numberOfTimes = complexCommand.MainStat / moveSpeed;
                    remainingUnits = complexCommand.MainStat % moveSpeed;

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new GunLeft(moveSpeed,
                            complexCommand.Player));

                    complexCommand.Player.InstructionQueue.Enqueue(new GunLeft(remainingUnits,
                        complexCommand.Player));
                    break;
                case Instructions.GunRight:
                    // případný var posíláme dále s -1, posíláme jako gunLeft, jelikož na směru nezáleží
                    if (complexCommand.MainStat == -1)
                    {
                        complexCommand.Player.InstructionQueue.Enqueue(new GunLeft(-1,
                            complexCommand.Player));
                        break;
                    }

                    numberOfTimes = complexCommand.MainStat / moveSpeed;
                    remainingUnits = complexCommand.MainStat % moveSpeed;

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new GunRight(moveSpeed,
                            complexCommand.Player));

                    complexCommand.Player.InstructionQueue.Enqueue(new GunRight(remainingUnits,
                        complexCommand.Player));
                    break;
                case Instructions.RadarLeft:
                    numberOfTimes = complexCommand.MainStat / (moveSpeed * 2);
                    remainingUnits = complexCommand.MainStat % (moveSpeed * 2);

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new RadarLeft(moveSpeed * 2,
                            complexCommand.Player));

                    complexCommand.Player.InstructionQueue.Enqueue(new RadarLeft(remainingUnits,
                        complexCommand.Player));
                    break;
                case Instructions.RadarRight:
                    numberOfTimes = complexCommand.MainStat / (moveSpeed * 2);
                    remainingUnits = complexCommand.MainStat % (moveSpeed * 2);

                    for (var i = 1; i <= numberOfTimes; i++)
                        complexCommand.Player.InstructionQueue.Enqueue(new RadarRight(moveSpeed * 2,
                            complexCommand.Player));

                    complexCommand.Player.InstructionQueue.Enqueue(new RadarRight(remainingUnits,
                        complexCommand.Player));
                    break;
                case Instructions.GameOver:
                    // instrukce opět okamžitá
                    complexCommand.Player.InstructionQueue.Enqueue(new GameOver(complexCommand.MainStat,
                        complexCommand.Player));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static bool Execute(Instruction instr) // vykoná jednoduchou instrukci
        {
            var playerIsNotDestroyed = true; // pro případ, kdyby hráč prohrál, abychom instrukci nevraceli do fronty
            switch (instr.GetId())
            {
                case Instructions.Ahead:
                    instr.Player.MoveForward(instr.MainStat);
                    break;
                case Instructions.Back:
                    instr.Player.MoveBackwards(instr.MainStat);
                    break;
                case Instructions.Left:
                    instr.Player.RotateVehicle(instr.MainStat);
                    break;
                case Instructions.Right:
                    instr.Player.RotateVehicle(-instr.MainStat);
                    break;
                case Instructions.Fire:
                    instr.Player.Fire(instr.MainStat);
                    break;
                case Instructions.GunLeft:
                    // řešíme případ s var, jelikož je bitmapa radaru otočená, je nutné s ní dělo srovnat
                    // proto orientaci násobíme -1 a odčítáme 180
                    if (instr.MainStat == -1)
                    {
                        instr.Player.ResetGunOrientation();
                        instr.Player.RotateGun(-1 * (instr.Player.GetAttrib("lastSpottedOrientation") - 180));
                    }

                    instr.Player.RotateGun(instr.MainStat);
                    break;
                case Instructions.GunRight:
                    instr.Player.RotateGun(-instr.MainStat);
                    break;
                case Instructions.RadarLeft:
                    instr.Player.RotateRadar(instr.MainStat);
                    break;
                case Instructions.RadarRight:
                    instr.Player.RotateRadar(-instr.MainStat);
                    break;
                case Instructions.GameOver:
                    // hráč byl vyřazen, proto ho vyjmeme ze seznamu aktivních hráčů a obarvíme černě
                    playerIsNotDestroyed = false;
                    instr.Player.GameOver();
                    CwForm.PlayerList.Remove(instr.Player); // hráčovy instrukce se nebudou dále vykonávat

                    // zbyde-li jediný hráč, vracíme true, což povede k ukončení programu
                    if (CwForm.PlayerList.Count == 1)
                    {
                        var lastPlayer = CwForm.PlayerList[0];
                        lastPlayer.InstructionQueue.Clear();
                        lastPlayer.InstructionQueue.Enqueue(new RadarLeft(lastPlayer.GetAttrib("maxSpeed") * 2,
                            lastPlayer));
                        return true;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (playerIsNotDestroyed)
                instr.Player.InstructionQueue.Enqueue(instr); // po provedení vracíme zpět do fronty
            return false;
        }

        public static void Prepare(Queue<Instruction> complexQueue)
        {
            // převede frontu těžkých instrukcí na frontu lehkých
            while (complexQueue.Count != 0)
            {
                var complexCommand = complexQueue.Dequeue();
                Deconstruct(complexCommand);
            }
        }

        public static bool RunSimulation(List<Player> playerList) // pro každého hráče provede jednu instrukci
        {
            // počítáme ticky hlavního timeru, po 150 sekundách vracíme true a hra končí
            if (_tickCount > 15000)
                return true;
            for (var i = playerList.Count - 1; i >= 0; i--)
            {
                var currentCommand = playerList[i].InstructionQueue.Dequeue();
                if (Execute(currentCommand))
                    // vrátil-li game over true (zbyl jeden hráč), vratíme true a hra končí
                    return true;
            }

            _tickCount++;
            return false;
        }
    }
}