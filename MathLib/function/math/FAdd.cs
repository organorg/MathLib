namespace function.math
{

    public class FAdd : TwoSidedFunction
	{

		public const string ID = "add";
		public const string Symbol = "+";

		public FAdd(Function LHS, Function RHS) : base(LHS, RHS)
		{
		}

		public FAdd(Function RHS, Function LHS, int RL) : base(LHS, RHS)
		{
		}

		public override double GetValue()
		{
				return LHS().GetValue() + RHS().GetValue();
		}

		public override Function GetDerivative(FVar @var)
		{
			bool checkLHS = LHS().HasVariable(var);
			bool checkRHS = RHS().HasVariable(var);
			bool checkBoth = checkLHS && checkRHS;

			if (checkLHS && !checkRHS)
			{
				return LHS().GetDerivative(var);
			}

			if (!checkLHS && checkRHS)
			{
				return RHS().GetDerivative(var);
			}

			if (checkBoth)
			{
				return new FAdd(LHS().GetDerivative(var), RHS().GetDerivative(@var));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
		{
			return null;
		}

		public override string ToString()
		{
			return LHS().ToString() + "+" + RHS().ToString();
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
			return new FAdd(LHS().GetCopy(), RHS().GetCopy());
		}

		public override Function GetSimplifiedFunction()
		{
            Function newLHS = LHS().GetSimplifiedFunction();
            Function newRHS = RHS().GetSimplifiedFunction();

			if (newLHS.isConstant && newRHS.isConstant)
			{
				return new FCons(newLHS.GetValue() + newRHS.GetValue());
			}

			if (newLHS.isConstant && newLHS.GetValue() == 0)
			{
                return newRHS;
			}

			if (newRHS.isConstant && newRHS.GetValue() == 0)
			{
				return newLHS;
			}

			return new FAdd(newLHS, newRHS);
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