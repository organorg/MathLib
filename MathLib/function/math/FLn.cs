using System;

namespace function.math
{

	public class FLn : SingleOperandFunction
	{
		public const string ID= "ln";
		public const string Symbol = "natlog";


		public FLn(Function operand) : base(operand)
		{
		}

		public override double GetValue()
		{
			return Math.Log(Operand().GetValue());
		}

		public override Function GetDerivative(FVar var)
		{
			if (Operand().HasVariable(var))
			{
				return new FMul(new FDiv(new FCons(1), Operand().GetCopy()), Operand(). GetDerivative(var));
			}

			return new FCons(0);
		}

		public override Function GetIntegral(FVar var)
		{
			return null;
		}

		public override string ToString()
		{
			return "ln(" + Operand().ToString() + ")";
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
			return new FLn(Operand().GetCopy());
		}

        public override Function GetSimplifiedFunction()
        {
            Function newOperand = Operand().GetSimplifiedFunction();

            if (newOperand.isConstant)
            {
               if (newOperand.GetValue() == 1)
               {
                    return new FCons(0);
               }

                if (newOperand.GetValue() == Math.E)
                {
                    return new FCons(1);
                }
            }

            return new FLn(newOperand);
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