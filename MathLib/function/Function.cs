// ••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
//  File Name:  Function.cs
//
//  Features:    
// ••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••

using System.Collections.Generic;

namespace function
{

	using FVar = math.FVar;
	using Node = util.Node;

	public abstract class Function : Node
	{

        // abstract methods

        public abstract string GetID();
        public abstract string GetSymbol();
        public override abstract string ToString();
        public abstract double GetValue();
        public abstract Function GetCopy();
		public abstract Function GetDerivative(FVar var);
		public abstract Function GetIntegral(FVar var);
        public abstract Function GetSimplifiedFunction();
        public abstract bool EqualsSymbolically(Function F);
        public abstract bool EqualsNumerically(Function F);

        // "Function" SuperClass Data

        public int numSubNodes;             // stores number of SubNodes of the Function
		public bool isConstant = false;     // tells whether a Function is a Constant
		public bool isVariable = false;     // tells whether a Function is a Variable
        public List<FVar> varList;          // stores all the Variables (FVars) used in the Function and its SubNodes

        // defined methods

        protected internal Function()
		{
			varList = new List<FVar>();
		}

		protected internal virtual List<FVar> GetVarList()
		{
				return varList;
		}

		protected internal virtual FVar FindVariable(string varName)
		{
			foreach (FVar v in varList)
			{
				if (v.GetVarName().Equals(varName))
				{
					return v;
				}
			}
			return null;
		}

		public virtual bool HasVariable(FVar var)
		{
			foreach (FVar v in varList)
			{
				if (v.varName.Equals(var.varName))
				{
					return true;
				}
			}
			return false;

		}

		public void AddVarsToList(Function subFunction)
		{
			foreach (FVar var in subFunction.varList)
			{
				if (!this.HasVariable(var))
				{
					varList.Add(var);
				}
			}
		}

        public Function GetSubNode(int nodeNo)
		{
			if (nodeNo < numSubNodes)
			{
				return (Function) SubNodes[nodeNo];
			}
			return null;
		}

		public void SetSubNode(int nodeNo, Function F)
		{
			if (nodeNo < numSubNodes)
			{
				SubNodes[nodeNo] = F;
			}
		}

	}

}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 