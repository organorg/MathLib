using System.Collections.Generic;

namespace function.math
{

    public class FSqrt : SingleOperandFunction
    {
        public const string ID = "sqrt";
        public const string Symbol = "sqrt";

        public FSqrt(Function operand) : base(operand)
        {
        }

        public override Function GetCopy()
        {
            throw new System.NotImplementedException();
        }

        public override Function GetDerivative(FVar var)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string GetID()
        {
            throw new System.NotImplementedException();
        }

        public override Function GetIntegral(FVar var)
        {
            throw new System.NotImplementedException();
        }

        public override Function GetSimplifiedFunction()
        {
            throw new System.NotImplementedException();
        }

        public override string GetSymbol()
        {
            throw new System.NotImplementedException();
        }

        public override double GetValue()
        {
            throw new System.NotImplementedException();
        }

        public override bool HasVariable(FVar var)
        {
            return base.HasVariable(var);
        }

        public override Function Operand()
        {
            return base.Operand();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
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