namespace FussballManagerLogic
{
    public class Player
    {
        public string Name { get; init; }
        public byte Speed { get; set; }
        public byte Precision { get; set; }
        public byte Duel { get; set; }
        public PlayerPositions Positions { get; set; }


        public Player()
        {

        }

        public Player(string pName, byte pSpeed, byte pPrecision, byte pDuel, PlayerPositions pPositions)
        {
            Name = pName;
            Speed = pSpeed;
            Precision = pPrecision;
            Duel = pDuel;
            Positions = pPositions;
        }
    }
}