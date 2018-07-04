using System;
using System.Collections.Generic;

namespace function.math
{

	public class FCons : Function
	{
		internal double cons;

		public const string ID = "constant";
		public const string Symbol = "cons";

		public FCons(double d)
        {
			cons = d;
			numSubNodes = 0;
			SubNodes = null;
			isConstant = true;
		}

		protected internal override List<FVar> GetVarList()
		{
			return null;
		}

		public virtual Function GetIntegral()
		{
			return null;
		}

		public override double GetValue()
		{
			return cons;
		}

		public override Function GetDerivative(FVar var)
		{
			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
		{
			return null;
		}

		public override string ToString()
		{
			if (cons - (double)(int)cons == 0)
			{
				return Convert.ToString((int)cons);
			}
			return Convert.ToString(cons);
		}

        public Boolean IsInteger()
        {
            if (cons - (double)(int)cons == 0)
            {
                return true;
            }
            return false;
        }

		public override string GetID()
		{
			return ID;
		}

		public override string GetSymbol()
		{
			return Symbol;
		}

		public override Function GetCopy()
		{
			return new FCons(cons);
		}

		public override Function GetSimplifiedFunction()
		{
			return GetCopy();
		}

        public override bool EqualsSymbolically(Function F)
        {
            throw new NotImplementedException();
        }

        public override bool EqualsNumerically(Function F)
        {
            throw new NotImplementedException();
        }
    }

}