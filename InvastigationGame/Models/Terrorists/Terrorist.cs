using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Models.Terrorists
{
    public class Terrorist
    {
        protected int _Capacity;
        public int Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }

        protected List<Sensor> _WeaknesSensors;
        public List<Sensor> WeaknesSensors
        {
            get { return _WeaknesSensors; }
            set { _WeaknesSensors = value; }
        }

        protected List<Sensor> _Touched;
        public List<Sensor> Touched
        {
            get { return _Touched; }
            set { _Touched = value; }
        }

        protected string _Type;
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
