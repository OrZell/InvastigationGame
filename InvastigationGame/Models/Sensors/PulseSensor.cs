using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class PulseSensor : Sensor
    {
        private int _AttackCounter;
        public int AttackCounter
        {
            get { return _AttackCounter; }
            set { _AttackCounter = value; }
        }
        public PulseSensor(Terrorist terrorist) : base("pulse", terrorist)
        {
            this._AttackCounter = 0;
        }

        public override void Activate()
        {
            this._Active = true;
            this._AttackCounter = 0;
        }

        public void Countering()
        {
            if (this._AttackCounter < 2)
            {
                this._AttackCounter++;
            }
            else
            {
                this._AttackCounter = 0;
                this._Active = false;
            }
        }
    }
}
