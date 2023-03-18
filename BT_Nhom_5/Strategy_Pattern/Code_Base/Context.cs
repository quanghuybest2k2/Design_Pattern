using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Base
{
    /// <summary>
    /// The 'Context' class
    /// </summary>

    public class Context
    {
        Strategy strategy;

        // Constructor

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
}
