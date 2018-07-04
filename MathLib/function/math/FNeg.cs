namespace function.math
{


	public class FNeg : SingleOperandFunction
	{

		public const string ID = "neg";
		public const string Symbol = "~";


		public FNeg(Function operand) : base(operand)
		{
		}

		public override double GetValue()
		{
			return -Operand().GetValue();
		}

		public override Function GetDerivative(FVar var)
		{
			if (Operand().HasVariable(var))
			{
				return new FNeg(Operand().GetDerivative(var));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
		{
			return null;
		}

		public override string ToString()
		{
			return "-" + Operand().ToString();
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
			return new FNeg(Operand().GetCopy());
		}

        public override Function GetSimplifiedFunction()
        {
            Function newOperand = Operand().GetSimplifiedFunction();

            if (newOperand.GetID() == FNeg.ID)
            {
                return Operand().GetCopy();
            }

            if (newOperand.GetID() == FCons.ID)
            {
                if (newOperand.GetValue() == 0)
                {
                    return new FCons(0);
                }
            }

            return GetCopy();
        }

        public override bool EqualsSymbolically(Function F)
        {
            throw new System.NotImplementedException();
        }

        public override bool EqualsNumerically(Function F)
        {
            throw new System.NotImplementedException();
        }
    }

}