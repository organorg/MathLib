using System;

namespace function.math
{

	using FunctionList = list.FunctionList;

	public class FDiv : TwoSidedFunction
	{

		public const string ID = "div";
		public const string Symbol = "/";

		public FDiv(Function LHS, Function RHS) : base(LHS, RHS)
		{
		}

		public FDiv(Function RHS, Function LHS, int RL) : base(LHS, RHS)
		{
		}

		public override double GetValue()
		{
			return LHS().GetValue() / RHS().GetValue();
		}

		public override Function GetDerivative(FVar var)
		{
			bool checkLHS = LHS().HasVariable(var);
			bool checkRHS = RHS().HasVariable(var);
			bool checkBoth = checkLHS && checkRHS;

			if (checkLHS && !checkRHS)
			{
				return new FDiv(LHS().GetDerivative(var), RHS().GetCopy());
			}

			if (!checkLHS && checkRHS)
			{
				return new FDiv(new FNeg(new FMul(LHS().GetCopy(), RHS().GetDerivative(var))), new FPow(RHS().GetCopy(), new FCons(2)));
			}

			if (checkBoth)
			{
				return new FDiv(new FSub(new FMul(LHS().GetDerivative(var), RHS().GetCopy()), new FMul(LHS().GetCopy(), RHS().GetDerivative(var))), new FPow(RHS().GetCopy(), new FCons(2)));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar @var)
		{
			return null;
		}

		public override string ToString()
		{
			bool checkLHS = LHS().GetID().Equals(FDiv.ID, StringComparison.CurrentCultureIgnoreCase) || FunctionList.IsSingleOperandFunction(LHS().GetID());
			bool checkRHS = RHS().GetID().Equals(FDiv.ID, StringComparison.CurrentCultureIgnoreCase) || FunctionList.IsSingleOperandFunction(RHS().GetID());
			bool checkBoth = checkLHS && checkRHS;

			if (checkBoth)
			{
				return LHS().ToString() + "/" + RHS().ToString();
			}

			if (checkLHS)
			{
				return LHS().ToString() + "/(" + RHS().ToString() + ")";
			}

			if (checkRHS)
			{
				return "(" + LHS().ToString() + ")/" + RHS().ToString();
			}

			return "(" + LHS().ToString() + ")/(" + RHS().ToString() + ")";
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
			return new FDiv(LHS().GetCopy(), RHS().GetCopy());
		}

		public override Function GetSimplifiedFunction()
		{
            Function newLHS = LHS().GetSimplifiedFunction();
            Function newRHS = RHS().GetSimplifiedFunction();
            
            if (newLHS.GetID() == FVar.ID && newRHS.GetID() == FVar.ID)
			{

				if (((FVar) newLHS).varName.Equals(((FVar) newRHS).varName))
				{
					return new FCons(1);
				}
			}

			if (newLHS.GetID() == FCons.ID && newRHS.GetID() == FCons.ID)
			{
				if (newLHS.GetValue() == newLHS.GetValue())
				{
					return new FCons(1);
				}
			}

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