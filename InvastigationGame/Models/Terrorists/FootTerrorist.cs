namespace InvastigationGame.Models.Terrorists
{
    public class FootTerrorist : Terrorist
    {
        public FootTerrorist() : base("foot")
        {
            this._Capacity = 2;
            this.AttackCounter = 0;
            this.MaxAttackCounter = 0;
        }
    }
}