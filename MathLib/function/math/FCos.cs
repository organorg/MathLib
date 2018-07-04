using System;

namespace function.math
{

	public class FCos : SingleOperandFunction
	{

		public const string ID = "cosine";
		public const  string Symbol = "cos";

		public FCos(Function operand) : base(operand)
		{
		}

		public override double GetValue()
		{
			return Math.Cos(Operand().GetValue());
		}

		public override Function GetDerivative(FVar var)
		{
			if (Operand().HasVariable(var))
			{
				return new FMul(new FNeg(new FSin(Operand().GetCopy())), Operand().GetDerivative(var));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
        {
			return null;
		}

		public override string ToString()
		{
			return "cos(" + Operand().ToString() + ")";
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
			return new FCos(Operand().GetCopy());
		}

        public override Function GetSimplifiedFunction()
        {
            Function newOperand = Operand().GetSimplifiedFunction();

            if (newOperand.GetID() == FCons.ID)
            {
                if (newOperand.GetValue() == Math.PI)
                {
                    return new FCons(-1);
                }

            }

            return new FCos(newOperand);
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