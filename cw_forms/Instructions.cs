/* 
     CodeWars 
  	 Denis Leskovar, I. ročník
  	 letní semestr 2018/19 
  	 Programování II NPRG031
*/
namespace CodeWars.Forms
{
    public enum Instructions
    {
        Ahead,
        Back,
        Left,
        Right,
        Fire,
        GunLeft,
        GunRight,
        RadarLeft,
        RadarRight,
        GameOver
    }
    // každá instukce má tento vzor
    public abstract class Instruction
    {
        protected Instructions id;
        public readonly Player player;
        public readonly int mainStat;

        protected Instruction(int value, Player instance)
        {
            player = instance;
            mainStat = value;
        }
        public Instructions GetId()
        {
            return id;
        }
    }


    // definice všech instrukcí podle vzoru a očíslovaní pro snažší práci v Engine
    public class Ahead : Instruction // pohyb vpřed
    {
        public Ahead(int speed, Player instance) : base(speed, instance)
        {
            id = Instructions.Ahead;
        }
    }
    public class Back : Instruction // pohyb vzad
    {
        public Back(int speed, Player instance) : base(speed, instance)
        {
            id = Instructions.Back;
        }
    }
    public class TurnLeft : Instruction // otočení vozidla podle hodinových ručiček
    {
        public TurnLeft(int speed, Player instance) : base(speed, instance)
        {
            id = Instructions.Left;
        }
    }
    public class TurnRight : Instruction // otočení vozidla proti hodinovým ručičkám
    {
        public TurnRight(int speed, Player instance) : base(speed, instance)
        {
            id = Instructions.Right;
        }
    }
    public class Fire : Instruction // střelba
    {
        public Fire(int projSpeed, Player instance) : base(projSpeed, instance)
        {
            id = Instructions.Fire;
        }
    }
    public class GunLeft : Instruction // otočení děla podle hodinových ručiček
    {
        public GunLeft(int degree, Player instance) : base(degree, instance)
        {
            id = Instructions.GunLeft;
        }
    }
    public class GunRight : Instruction // otočení děla proti hodinovým ručičkám
    {
        public GunRight(int degree, Player instance) : base(degree, instance)
        {
            id = Instructions.GunRight;
        }
    }
    public class RadarLeft : Instruction // otočení radaru podle hodinových ručiček
    {
        public RadarLeft(int degree, Player instance) : base(degree, instance)
        {
            id = Instructions.RadarLeft;
        }
    }
    public class RadarRight : Instruction // otočení radaru proti hodinovým ručičkám
    {
        public RadarRight(int degree, Player instance) : base(degree, instance)
        {
            id = Instructions.RadarRight;
        }
    }
    public class GameOver : Instruction // vyřazení zničeného robota - konec hry pro jednoho z hráčů
    {
        public GameOver(int speed, Player instance) : base(speed, instance)
        {
            id = Instructions.GameOver;
        }
    }
}
