using System;
using System.IO;

namespace FussballManagerLogic
{
    public class Player
    {
        public string Name { get; set; }
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
        public Player(byte pSpeed, byte pPrecision, byte pDuel, PlayerPositions pPosition)
        {
            Name = GetRandomName();
            Speed = pSpeed;
            Precision = pPrecision;
            Duel = pDuel;
            Position = pPosition;
        }
        public static string GetRandomName() //TODO: Datei nur einmal in eine List laden, daraus Namen entnehmen und löschen. Im Moment wird für jeden Player immmer wieder die Datei geöffnet und doppelte Namen sind möglich
        {
            // Liste "RandomNames.txt" muss mit in das Projektverzeichnis kopiert werden, generiert mit http://names.drycodes.com/1000?nameOptions=boy_names&format=text
            Random rndGen = new Random();
            int r = rndGen.Next(1000);
            int count = 0;
            string currentName;
            using (var reader = new StreamReader("RandomNames.txt"))
            {
                while ((currentName = reader.ReadLine()) != null)
                {
                    if (count == r) return currentName;
                    count++;
                }
            }

            return "NoNameFound";
        }
    }
}