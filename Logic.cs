using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP3._1
{
    using System;

    public class Logic
    {
        public int Value { get; private set; }

        public Logic(string number, int baseSystem)
        {
            Value = Convert.ToInt32(number, baseSystem);
        }

        public Logic(string number, int baseSystem, bool isNegative)
        {
            if (isNegative)
            {
                Value = 0 - Convert.ToInt32(number, baseSystem);
            }
            else
            {
                Value = Convert.ToInt32(number, baseSystem);
            }
        }
        private Logic(int value)
        {
            Value = value;
        }
        public static Logic operator +(Logic a, Logic b) => new Logic(a.Value + b.Value);
        public static Logic operator -(Logic a, Logic b) => new Logic(a.Value - b.Value);
        public static Logic operator *(Logic a, Logic b) => new Logic(a.Value * b.Value);
        public static bool operator <(Logic a, Logic b)
        {
            return a.Value < b.Value;
        }

        public static bool operator >(Logic a, Logic b)
        {
            return a.Value > b.Value;
        }

        public static bool operator ==(Logic a, Logic b)
        {
            return a.Value == b.Value;
        }
        public static bool operator !=(Logic a, Logic b)
        {
            return a.Value != b.Value;
        }

        private int CompareTo(Logic other) => Value.CompareTo(other.Value);

        private string ToBaseString(int baseSystem) => Convert.ToString(Value, baseSystem);
        public string Result(int baseSystem)
        {
            if (this.Value < 0)
            {
                Logic logic = new Logic(Convert.ToString(Math.Abs(this.Value)), 10);
                return ("-" + Convert.ToString(logic.Value, baseSystem));
            }
            else
            {
                return Convert.ToString(this.Value, baseSystem);
            }
        }
    }
}
