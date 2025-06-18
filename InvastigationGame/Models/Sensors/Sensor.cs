using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class Sensor
    {
        protected string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        protected bool _Active;
        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        public Sensor(string type)
        {
            this._Type = type;
            this._Active = false;
        }

        public virtual bool IsActive()
        {
            return this._Active;
        }

        public virtual void Activate()
        {
            this._Active = true;
        }
    }
}