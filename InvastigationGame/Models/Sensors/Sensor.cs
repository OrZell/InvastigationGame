using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvastigationGame.Models.Sensors
{
    public class Sensor
    {
        protected string _Type;
        //public string Type
        //{
        //    get { return _Type; }
        //    set { _Type = value; }
        //}

        protected bool _Activate;
        //public bool Activate
        //{
        //    get { return _Activate; }
        //    set { _Activate = value; }
        //}

        public Sensor(string type)
        {
            this._Type = type;
            this._Activate = false;
        }

        public void Active()
        {
            this._Activate = true;
        }
    }
}