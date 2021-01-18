namespace FussballManagerLogic
{
    public class Player
    {
        private string name;
        private byte speed;
        private byte precision;
        private byte duel;
        private PlayerPositions _positions;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public byte Speed
        {
            get => speed;
            set => speed = value;
        }

        public byte Precision
        {
            get => precision;
            set => precision = value;
        }

        public byte Duel
        {
            get => duel;
            set => duel = value;
        }

        public PlayerPositions Positions
        {
            get => _positions;
            set => _positions = value;
        }


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