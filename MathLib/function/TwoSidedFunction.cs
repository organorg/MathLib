namespace function
{

	using Node = util.Node;

	public abstract class TwoSidedFunction : Function
	{

		public TwoSidedFunction(Function LHS, Function RHS) : base()
		{
			this.numSubNodes = 2;
			this.SubNodes = new Node[numSubNodes];
			SetLHS(LHS);
			AddVarsToList(LHS);
			SetRHS(RHS);
			AddVarsToList(RHS);
		}

		public Function LHS()
		{
			return (Function) SubNodes[0];
		}

		public Function RHS()
		{
			return (Function) SubNodes[1];
		}

        public void SetLHS(Function F)
        {
            SubNodes[0] = F;
        }

        public void SetRHS(Function F)
        {
            SubNodes[1] = F;
        }

    }

}