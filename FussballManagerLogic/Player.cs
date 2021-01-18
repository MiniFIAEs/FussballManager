namespace FussballManagerLogic
{
    public class Player
    {
        public string Name { get; init; }
        public byte Speed { get; set; }
        public byte Precision { get; set; }
        public byte Duel { get; set; }
        public PlayerPositions Position { get; set; }


        public Player()
        {
            Name = "NoNamedPlayer";
        }

        public Player(string pName, byte pSpeed, byte pPrecision, byte pDuel, PlayerPositions pPosition)
        {
            Name = pName;
            Speed = pSpeed;
            Precision = pPrecision;
            Duel = pDuel;
            Position = pPosition;
        }
    }
}