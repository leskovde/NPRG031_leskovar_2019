/* 
     CodeWars 
  	 Denis Leskovar, I. ročník
  	 letní semestr 2018/19 
  	 Programování II NPRG031
*/
namespace CodeWars.Forms
{
    // každá instukce má tento vzor
    public abstract class Instruction
    {
        protected int id;
        public readonly Player player;
        public readonly int mainStat;

        protected Instruction(int value, Player instance)
        {
            player = instance;
            mainStat = value;
        }
        public int GetId()
        {
            return id;
        }
    }


    // definice všech instrukcí podle vzoru a očíslovaní pro snažší práci v Engine
    public class Ahead : Instruction // pohyb vpřed
    {
        public Ahead(int speed, Player instance) : base(speed, instance)
        {
            id = 1;
        }
    }
    public class Back : Instruction // pohyb vzad
    {
        public Back(int speed, Player instance) : base(speed, instance)
        {
            id = 2;
        }
    }
    public class TurnLeft : Instruction // otočení vozidla podle hodinových ručiček
    {
        public TurnLeft(int speed, Player instance) : base(speed, instance)
        {
            id = 3;
        }
    }
    public class TurnRight : Instruction // otočení vozidla proti hodinovým ručičkám
    {
        public TurnRight(int speed, Player instance) : base(speed, instance)
        {
            id = 4;
        }
    }
    public class Fire : Instruction // střelba
    {
        public Fire(int projSpeed, Player instance) : base(projSpeed, instance)
        {
            id = 5;
        }
    }
    public class GunLeft : Instruction // otočení děla podle hodinových ručiček
    {
        public GunLeft(int degree, Player instance) : base(degree, instance)
        {
            id = 6;
        }
    }
    public class GunRight : Instruction // otočení děla proti hodinovým ručičkám
    {
        public GunRight(int degree, Player instance) : base(degree, instance)
        {
            id = 7;
        }
    }
    public class RadarLeft : Instruction // otočení radaru podle hodinových ručiček
    {
        public RadarLeft(int degree, Player instance) : base(degree, instance)
        {
            id = 8;
        }
    }
    public class RadarRight : Instruction // otočení radaru proti hodinovým ručičkám
    {
        public RadarRight(int degree, Player instance) : base(degree, instance)
        {
            id = 9;
        }
    }
    public class GameOver : Instruction // vyřazení zničeného robota - konec hry pro jednoho z hráčů
    {
        public GameOver(int speed, Player instance) : base(speed, instance)
        {
            id = 10;
        }
    }
}
