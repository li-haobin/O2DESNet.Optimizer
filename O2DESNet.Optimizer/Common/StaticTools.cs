using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public static class StaticTools
    {
        public static bool IsFeasible(this IQuantitativeDomain domain, IList<double> decisions)
        {
            if (decisions.Count > domain.LowerBounds.Count) return false;
            if (decisions.Count > domain.UpperBounds.Count) return false;
            for (int i = 0; i < decisions.Count; i++)
            {
                if (decisions[i] < domain.LowerBounds[i]) return false;
                if (decisions[i] > domain.UpperBounds[i]) return false;
            }
            return true;
        }
    }
}
