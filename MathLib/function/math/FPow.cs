using System;

namespace function.math
{

	using FunctionList = list.FunctionList;


	public class FPow : TwoSidedFunction
	{

		public const string ID = "pow";
		public const string Symbol = "^";

		public FPow(Function LHS, Function RHS) : base(LHS, RHS)
		{
		}

		public FPow(Function RHS, Function LHS, int RL) : base(LHS, RHS)
		{
		}

		public override double GetValue()
        {
			return Math.Pow(Base().GetValue(), Exponent().GetValue());
		}

		public override Function GetDerivative(FVar var)
		{

			bool checkLHS = LHS().HasVariable(var);
			bool checkRHS = RHS().HasVariable(var);
			bool checkBoth = checkLHS && checkRHS;

            if (checkLHS && Exponent().GetID() == FCons.ID)
            {
                if (Exponent().GetValue() == 0)
                {
                    return new FCons(0);
                }

                if (Exponent().GetValue() == 1)
                {
                    return Base().GetDerivative(var);
                }
            }

            if (checkLHS && !checkRHS)
			{
				return new FMul(RHS().GetCopy(), new FMul(new FPow(LHS().GetCopy(), new FSub(RHS().GetCopy(), new FCons(1))), LHS().GetDerivative(var)));
			}

			if (!checkLHS && checkRHS)
			{
				return new FMul(this.GetCopy(), new FMul(new FLn(LHS().GetCopy()), RHS().GetDerivative(var)));
			}

			if (checkBoth)
			{
				return new FMul(this.GetCopy(), new FAdd(new FMul(RHS().GetDerivative(var), new FLn(LHS().GetCopy())), new FMul(new FDiv(RHS().GetCopy(), LHS().GetCopy()), LHS().GetDerivative(var))));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
        {
			return null;
		}


		public override string ToString()
		{
			bool checkLHS = LHS().GetID().Equals(FPow.ID, StringComparison.CurrentCultureIgnoreCase) || FunctionList.IsSingleOperandFunction(LHS().GetID());
			bool checkRHS = RHS().GetID().Equals(FPow.ID, StringComparison.CurrentCultureIgnoreCase) || FunctionList.IsSingleOperandFunction(RHS().GetID());
			bool checkBoth = checkLHS && checkRHS;

			if (checkBoth)
			{
				return LHS().ToString() + "^" + RHS().ToString();
			}

			if (checkLHS)
			{
				return LHS().ToString() + "^(" + RHS().ToString() + ")";
			}

			if (checkRHS)
			{
				return "(" + LHS().ToString() + ")^" + RHS().ToString();
			}

			return "(" + LHS().ToString() + ")^(" + RHS().ToString() + ")";
		}

		public override string GetID()
		{
			return ID;
		}

		public override string GetSymbol()
		{
			return Symbol;
		}

        public Function Base()
        {
            return (Function) SubNodes[0];
        }

        public Function Exponent()
        {
            return (Function)SubNodes[1];
        }

        public override Function GetCopy()
		{
			return new FPow(LHS().GetCopy(), RHS().GetCopy());
		}

        public override Function GetSimplifiedFunction()
        {
            Function newBase = Base().GetSimplifiedFunction();
            Function newExponent = Exponent().GetSimplifiedFunction();

            if (newBase.isConstant && newExponent.isConstant)
            {
                if (newBase.GetValue()!=0 && newExponent.GetValue()==0)
                {
                    return new FCons(1);
                }

                if (((FCons)newBase).IsInteger() && ((FCons)newExponent).IsInteger())
                {
                    return new FCons(GetValue());
                }
            }

            return new FPow(newBase, newExponent);
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