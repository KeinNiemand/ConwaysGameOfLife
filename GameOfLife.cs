using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class GameOfLife
    {
        public Cell[][] spielfeld;
        //Anzahl an Lebenden nachtbarn bei denen eine zelle überlebt
        private List<byte> survive = new List<byte> { 2, 3 };
        //Anzahl an Lebenden nachbarn bei dem eine tote zelle lebendig wird
        private List<byte> birth = new List<byte> { 3 };
        public GameOfLife()
        {
            initSpielfeld(100,100);
        }
        private byte CheckNeighbours(ushort x, ushort y)
        {
            byte neigbourCount = 0;
            //Links
            if (x > 0)
                if (spielfeld[x - 1][y].alive) neigbourCount++;
            //Oben
            if (y > 0)
                if (spielfeld[x][y - 1].alive) neigbourCount++;
            //Rechts
            if (x < spielfeld.GetLength(0) - 1)
                if (spielfeld[x + 1][y].alive) neigbourCount++;
            //Unten
            if (y < spielfeld.GetLength(1) - 1)
                if (spielfeld[x][y + 1].alive) neigbourCount++;
            //Links-Oben
            if (x > 0 && y > 0)
                if (spielfeld[x - 1][y - 1].alive) neigbourCount++;
            //Links-Unten
            if (x > 0 && y < spielfeld.GetLength(1) - 1)
                if (spielfeld[x - 1] [y + 1].alive) neigbourCount++;
            //Recht-Oben
            if (x < spielfeld.GetLength(0) - 1 && y > 0)
                if (spielfeld[x + 1][y - 1].alive) neigbourCount++;
            //Rechts-Unten
            if (x < spielfeld.GetLength(0) - 1 && y < spielfeld.GetLength(1) - 1)
                if (spielfeld[x + 1][y + 1].alive) neigbourCount++;


            return neigbourCount;
        }

        
        private void initSpielfeld (ushort xSize, ushort ySize)
        {
            spielfeld = new Cell[xSize][];
            for (ushort i = 0; i<spielfeld.GetLength(0); i++)
            {
                spielfeld[i] = new Cell[ySize];
            }
        }
        public void stepLife()
        {
            Cell[][] neuesSpielFeld = (Cell[][])spielfeld.Clone();
            for (ushort x = 0; x < spielfeld.GetLength(0); x++)
            {
                for (ushort y = 0; y < spielfeld.GetLength(1); y++)
                {
                    //Lebende Zellen
                    if (spielfeld[x][y].alive)
                    {
                        //Wenn die zelle nicht überlebt (wenn nicht die richtige anzahl an nachtban vorhanden sind)
                        if (!survive.Contains(CheckNeighbours(x, y)))
                            neuesSpielFeld[x][y].alive = !spielfeld[x][y].alive;
                    }
                    else //Tote Zellen
                    {
                        //Wenn eine neue Zelle Geborten werden soll
                        if (birth.Contains(CheckNeighbours(x, y)))
                            neuesSpielFeld[x][y].alive = !spielfeld[x][y].alive;
                    }
                }
            }
            spielfeld = neuesSpielFeld;
        }

    }
}
