using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ConwaysGameOfLife
{
    class Cell : INotifyPropertyChanged
    {
        private bool alive;
        public bool Alive { get { return alive; } set { alive = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Alive")); } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
