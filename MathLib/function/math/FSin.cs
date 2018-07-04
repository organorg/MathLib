using System;

namespace function.math
{

	public class FSin : SingleOperandFunction
	{
		public const string ID = "sine";
		public const string Symbol = "sin";

		public FSin(Function operand) : base(operand)
		{
		}


		public override double GetValue()
		{
			return Math.Sin(Operand().GetValue());
		}

		public override Function GetDerivative(FVar var)
		{
			if (Operand().HasVariable(var))
			{
				return new FMul(new FCos(Operand().GetCopy()), Operand().GetDerivative(var));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
		{
			// TODO Auto-generated method stub
			return null;
		}

		public override string ToString()
		{
			return "sin(" + Operand().ToString() + ")";
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
			return new FSin(Operand().GetCopy());
		}

        public override Function GetSimplifiedFunction()
        {
            throw new NotImplementedException();
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