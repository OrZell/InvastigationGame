using InvastigationGame.Models.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvastigationGame.Models.Terrorists
{
    public class Terrorist
    {
        private List<Sensor> _WeaknesSensors;
        public List<Sensor> WeaknesSensors
        {
            get { return _WeaknesSensors; }
            set { _WeaknesSensors = value; }
        }

        private List<string> _Touched;
        public List<string> Touched
        {
            get { return _Touched; }
            set { _Touched = value; }
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        public Terrorist(string type)
        {
            this._Type = type;
        }
    }
}
