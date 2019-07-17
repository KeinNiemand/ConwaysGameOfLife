using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ConwaysGameOfLife
{
    class Cell : INotifyPropertyChanged, ICloneable
    {
        private bool alive;
        public bool Alive { get { return alive; } set { alive = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alive")); } }

        public Cell()
        {
            alive = false;
        }
        private Cell(bool alive)
        {
            this.alive = alive;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        

        public object Clone()
        {
            return new Cell(alive);
        }
    }
}
