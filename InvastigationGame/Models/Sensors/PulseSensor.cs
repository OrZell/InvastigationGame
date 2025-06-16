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
        public PulseSensor() : base("pulse")
        {
            this._AttackCounter = 0;
        }

        public override void Activate()
        {
            this._Active = true;
            this._AttackCounter = 0;
        }

        public void Disactive()
        {
            this._Active = false;
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
                this.Disactive();
            }
        }
    }
}
