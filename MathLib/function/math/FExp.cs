using System;

namespace function.math
{


	public class FExp : SingleOperandFunction
	{
		public const string ID= "exp";
		public const string Symbol = "e^";


		public FExp(Function operand) : base(operand)
		{
		}

		public override double GetValue()
		{
			return Math.Exp(Operand().GetValue());
		}

		public override Function GetDerivative(FVar var)
		{
			if (Operand().HasVariable(var))
			{
				return new FMul(this.GetCopy(), Operand().GetDerivative(var));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
		{
			return null;
		}

		public override string ToString()
		{
			return "exp(" + Operand().ToString() + ")";
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
			return new FExp(Operand().GetCopy());
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