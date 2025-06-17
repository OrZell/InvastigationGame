using InvastigationGame.Models.Terrorists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvastigationGame.Models.Sensors
{
    public class SignalSensor : Sensor
    {
        public SignalSensor(Terrorist terrorist) : base("signal", terrorist)
        {

        }
    }
}
