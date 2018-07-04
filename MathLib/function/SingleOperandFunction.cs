namespace function
{

	using Node = util.Node;

	public abstract class SingleOperandFunction : Function
	{

		public SingleOperandFunction(Function operand) : base()
		{
			numSubNodes = 1;
			this.SubNodes = new Node[numSubNodes];
			SetOperand(operand);
			AddVarsToList(operand);
		}

		public virtual Function Operand()
		{
			return (Function) SubNodes[0];
		}

        public void SetOperand(Function F)
        {
            SubNodes[0] = F;
        }

    }

}