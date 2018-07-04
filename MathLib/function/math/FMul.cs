using System;

namespace function.math
{
	using FunctionList = list.FunctionList;
    using Function = function.Function;

	public class FMul : TwoSidedFunction
	{
		public const string ID = "mul";
		public const string Symbol = "*";

		public FMul(Function LHS, Function RHS) : base(LHS, RHS)
		{
		}

		public FMul(Function RHS, Function LHS, int RL) : base(LHS, RHS)
		{
		}

		public override double GetValue()
		{
			return LHS().GetValue() * RHS().GetValue();
		}

		public override Function GetDerivative(FVar var)
		{
			bool checkLHS = LHS().HasVariable(var);
			bool checkRHS = RHS().HasVariable(var);
			bool checkBoth = checkLHS && checkRHS;

			if (checkLHS && !checkRHS)
			{
				return new FMul(LHS().GetDerivative(var), RHS().GetCopy());
			}

			if (!checkLHS && checkRHS)
			{
				return new FMul(LHS().GetCopy(), RHS().GetDerivative(var));
			}

			if (checkBoth)
			{
				return new FAdd(new FMul(LHS().GetDerivative(var), RHS().GetCopy()), new FMul(LHS().GetCopy(), RHS().GetDerivative(var)));
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
			bool checkLHS = LHS().GetID().Equals(FMul.ID, StringComparison.CurrentCultureIgnoreCase) || FunctionList.IsSingleOperandFunction(LHS().GetID());
            bool checkRHS = RHS().GetID().Equals(FMul.ID, StringComparison.CurrentCultureIgnoreCase) || FunctionList.IsSingleOperandFunction(RHS().GetID());
			bool checkBoth = checkLHS && checkRHS;

			if (checkBoth)
			{
				return LHS().ToString() + "*" + RHS().ToString();
			}

			if (checkLHS)
			{
				return LHS().ToString() + "*(" + RHS().ToString() + ")";
			}

			if (checkRHS)
			{
				return "(" + LHS().ToString() + ")*" + RHS().ToString();
			}

			return "(" + LHS().ToString() + ")*(" + RHS().ToString() + ")";
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
			return new FMul(LHS().GetCopy(), RHS().GetCopy());
		}

		public override Function GetSimplifiedFunction()
		{
            Function newLHS = LHS().GetSimplifiedFunction();
            Function newRHS = RHS().GetSimplifiedFunction();

            bool checkZero = newLHS.GetID() == FCons.ID && newLHS.GetValue() == 0 || newRHS.GetID() == FCons.ID && newRHS.GetValue() == 0;

			if (checkZero)
			{
				return new FCons(0);
			}

			bool checkLHS = newLHS.GetID() == FCons.ID && newLHS.GetValue() == 1;
			bool checkRHS = newRHS.GetID() == FCons.ID && newRHS.GetValue() == 1;

			if (checkLHS && !checkRHS)
			{
                return newRHS;       
            }

			if (!checkLHS && checkRHS)
			{
                return newLHS;
			}

			if (checkLHS && checkRHS)
			{
				return new FCons(1);
			}

            return new FMul(newLHS, newRHS);
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