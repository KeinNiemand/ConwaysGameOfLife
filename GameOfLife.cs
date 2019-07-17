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
            InitSpielfeld(50,50);
        }
        private byte CheckNeighbours(ushort x, ushort y)
        {
            byte neigbourCount = 0;
            //Links
            if (x > 0)
                if (spielfeld[x - 1][y].Alive) neigbourCount++;
            //Oben
            if (y > 0)
                if (spielfeld[x][y - 1].Alive) neigbourCount++;
            //Rechts
            if (x < spielfeld.Length - 1)
                if (spielfeld[x + 1][y].Alive) neigbourCount++;
            //Unten
            if (y < spielfeld[0].Length - 1)
                if (spielfeld[x][y + 1].Alive) neigbourCount++;
            //Links-Oben
            if (x > 0 && y > 0)
                if (spielfeld[x - 1][y - 1].Alive) neigbourCount++;
            //Links-Unten
            if (x > 0 && y < spielfeld[0].Length - 1)
                if (spielfeld[x - 1] [y + 1].Alive) neigbourCount++;
            //Recht-Oben
            if (x < spielfeld.Length - 1 && y > 0)
                if (spielfeld[x + 1][y - 1].Alive) neigbourCount++;
            //Rechts-Unten
            if (x < spielfeld.Length - 1 && y < spielfeld[0].Length - 1)
                if (spielfeld[x + 1][y + 1].Alive) neigbourCount++;


            return neigbourCount;
        }

        private void InitSpielfeld (ushort xSize, ushort ySize)
        {
            spielfeld = new Cell[xSize][];
            for (ushort i = 0; i<spielfeld.Length; i++)
            {
                spielfeld[i] = new Cell[ySize];
                for (ushort j = 0; j<spielfeld[i].Length; j++)
                {
                    spielfeld[i][j] = new Cell();
                }
            }
            spielfeld[0][0].Alive = true;
        }
        public void StepLife()
        {
            Cell[][] neuesSpielFeld = CopySpielfeld();
            for (ushort x = 0; x < spielfeld.Length; x++)
            {
                for (ushort y = 0; y < spielfeld[0].Length; y++)
                {
                    //Lebende Zellen
                    if (spielfeld[x][y].Alive)
                    {
                        //Wenn die zelle nicht überlebt (wenn nicht die richtige anzahl an nachtban vorhanden sind)
                        if (!survive.Contains(CheckNeighbours(x, y)))
                            neuesSpielFeld[x][y].Alive = false;
                    }
                    else //Tote Zellen
                    {
                        //Wenn eine neue Zelle Geborten werden soll
                        if (birth.Contains(CheckNeighbours(x, y)))
                            neuesSpielFeld[x][y].Alive = true;
                    }
                }
            }
            UpdateSpielfeldValues(neuesSpielFeld);
        }

        private Cell[][] CopySpielfeld()
        {
            //Erstelle ein neues Cell[][] mit der gleichen größe wie das alte spielfeld
            Cell[][] neuesSpielFeld = new Cell[spielfeld.Length][];
            int a = 1;
            //Gehe durch alle spalten
            for (short x = 0; x < spielfeld.Length; x++)
            {
                //Erstelle ein neues Cell[] mit der gleichen größe wie das alte spielfeld
                neuesSpielFeld[x] = new Cell[spielfeld[x].Length];
                for (short y = 0; y < spielfeld[x].Length; y++)
                {
                    //Clone every cell from the old spielfeld into the new one
                    neuesSpielFeld[x][y] = (Cell)spielfeld[x][y].Clone();
                }
            }
            //return the new spielfeld
            return neuesSpielFeld;
        }

        private void UpdateSpielfeldValues(Cell[][] neuesSpielfeld)
        {
            for (short x = 0; x<spielfeld.Length; x++)
            {
                for (short y = 0; y<spielfeld.Length; y++)
                {
                    spielfeld[x][y].Alive = neuesSpielfeld[x][y].Alive;
                }
            }
        }

        
    }
}
