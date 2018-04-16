using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProject
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Add(int a, int b, int c);
        string Mode { get; set; }
        event EventHandler PoweringUp;
    }
}
