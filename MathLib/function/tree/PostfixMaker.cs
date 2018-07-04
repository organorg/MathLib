namespace function.tree
{
	using FunctionList = list.FunctionList;
	using StringStack = util.StringStack;

	public class PostfixMaker
	{
		public static void CreatePostfixArray(string infix, FunctionTree FTree)
		{
			StringStack opStk = new StringStack();

			// create a new char array to store the Postfix expression
			// and initialize it to NULL
			string[] postfix = new string[infix.Length + 1];

			int i = 0; // the index used to read the Infix expression
			int p = 0; // the index used to store to the Postfix expression

			string op; // holds value of current character from the Infix expression in each loop
			int opPr; // holds the Priority of current character from the Infix expression in each loop

			while (i < infix.Length) // while char array element != NULL
			{
				//System.out.println("i = " + i);
				//System.out.println(infix.length());
				op = infix[i] + ""; // assign current character from Infix expression
				opPr = Priority(op); // get and store Priority of current character 'op'
				//System.out.println("op char: "+ op);
				postfix[p] = "";
				//System.out.println("got " + opPr);
				if (op.Equals(" ") || op.Equals(","))
				{
				}
				else if (opPr == -1) // if current character is not an operator
				{
					while (opPr == -1) // put directly into the Postfix expression array until an operator is reached
					{
						postfix[p] = postfix[p] + op;
						i++;
						if (i == infix.Length)
						{
							break;
						}
						op = infix[i] + "";
						opPr = Priority(op);
					}
					if (FunctionList.IsFunction(postfix[p]))
					{
						//System.out.println("found function: " + postfix[p]);
						opStk.Push(postfix[p]);
					}
					else
					{
						p++;
					}
					continue;
				}

				else if (op.Equals(")")) // if current oprtr is 'closing bracket' then Pop Stack
				{ // values into Postfix expression until 'opening bracket'
					while (!(opStk.Top().Equals("(")))
					{
						postfix[p++] = opStk.TopAndPop();
					}
					opStk.Pop(); // Pop (remove) the 'opening bracket'
					if (!opStk.IsEmpty() && FunctionList.IsFunction(opStk.Top()))
					{
						postfix[p++] = opStk.TopAndPop();
					}
				}

				else if (opStk.IsEmpty() || op.Equals("(") || opStk.Top().Equals("("))
				{
					//System.out.println("wrong");
					opStk.Push(op); // Push current car (oprtr) into Stack for any of the above conditions
					;
				}

				else if (Priority(opStk.Top()) >= opPr)
				{
					// if Priority of current oprtr is less than / equal to priority
					// of oprtr in Top of Stack, then Pop all Stack values of Priority
					// greater than or equal to current oprtr until lower Priority oprtr 
					// OR an 'opening bracket' is reached OR Stack is Empty, and put the 
					// popped values into the Postfix Expression array. 
					// Then Push current oprtr onto the Stack.
					while (!opStk.IsEmpty())
					{
						postfix[p++] = opStk.TopAndPop();
						if (!opStk.IsEmpty())
						{
							if (opStk.Top().Equals("(") || Priority(opStk.Top()) < opPr)
							{
								break;
							}
						}
					}
					opStk.Push(op);
				}

				else if (Priority(opStk.Top()) < opPr)
				{
					// if Priority of current oprtr is greater than priority of oprtr in
					// Top of Stack, then simply Push current oprtr onto the Stack
					opStk.Push("" + op);
				}

				i++; // increment index for the next Infix array Character
			}

			// finally, Pop out the all remaining Stack values into the Postfix expression array
			while (!opStk.IsEmpty())
			{
				postfix[p++] = opStk.TopAndPop();
			}

			// Dispose Stack that is no longer needed
			opStk.MakeEmpty();

			//System.out.println("pppppp" + p);
			postfix = FixSize(postfix, p);

			// return the resultant Postix expression array
			FTree.postfixArray = postfix;
		}

		private static string[] FixSize(string[] postfix, int p)
		{
			string[] fix = new string[p];
			for (int i = 0; i < p; i++)
			{
				fix[i] = postfix[i];
			}
			return fix;
		}

		// following method returns Priority of given character as:
		// ')' , '('	Highest priority	(3);
		// '*' , '/'	Moderate priority	(2);
		// '+' , '-'	Lowest priority		(1);
		// other chars	No Priority		   (-1);
		private static int Priority(string op)
		{
			char o = op[0];

			switch (o)
			{
				case '^':
					return 5;

				case '(':
			case ')':
				return 3;

				case '*':
			case '/':
				return 2;

				case '+':
			case '-':
				return 1;

				case ',':
					return -2;

				case '~':
					return 4;

				default:
					return -1;
			}
		}
	}

}