using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BLL.BusinessModels
{
    public class Converter
    {
        private int _value = 0;
        public Converter(int val)
        {
            _value = val;
        }

        public int Value { get { return _value; } }
        public double GetConverter(int weight)
        {
            if (weight == 0)
                return 0;
            else return weight / 1000;
        }
    }
}
