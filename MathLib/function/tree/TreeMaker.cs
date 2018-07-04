using function.math;
using System;
using System.Collections.Generic;

namespace function.tree
{

	
	using FunctionStack = util.FunctionStack;

	public class TreeMaker
	{
		public static void CreateFunctionTree(string[] postfixArray, FunctionTree FTree)
		{
			FunctionStack fStk = new FunctionStack();
			string f;
			int i = 0;
			FTree.varList = new List<FVar>();

			while (i < postfixArray.Length)
			{
				f = postfixArray[i];
				//System.out.println("fff "+ f);
                
				if (f.Equals(FNeg.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FNeg.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FNeg(fStk.TopAndPop()));
				}
				else if (f.Equals(FAdd.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FAdd.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FAdd(fStk.TopAndPop(), fStk.TopAndPop(), 1));
				}
				else if (f.Equals(FSub.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FSub.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FSub(fStk.TopAndPop(), fStk.TopAndPop(), 1));
				}
				else if (f.Equals(FMul.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FMul.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FMul(fStk.TopAndPop(), fStk.TopAndPop(), 1));
				}
				else if (f.Equals(FDiv.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FDiv.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FDiv(fStk.TopAndPop(), fStk.TopAndPop(), 1));
				}
				else if (f.Equals(FPow.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FPow.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FPow(fStk.TopAndPop(), fStk.TopAndPop(), 1));
				}
				else if (f.Equals(FExp.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FExp.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FExp(fStk.TopAndPop()));
				}
				else if (f.Equals(FLn.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FLn.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FLn(fStk.TopAndPop()));
				}
				// sin()
				else if (f.Equals(FSin.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FSin.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FSin(fStk.TopAndPop()));
				}
				else if (f.Equals(FCos.ID, StringComparison.CurrentCultureIgnoreCase) || f.Equals(FCos.Symbol, StringComparison.CurrentCultureIgnoreCase))
				{
					fStk.Push(new FCos(fStk.TopAndPop()));
				}

				// add rest of the functions

				else if (IsConstant(f)) // double number
				{
					fStk.Push(new FCons(Convert.ToDouble(f)));
				}
				else
				{
					FVar @var = FTree.FindVariable(f);
					if (@var != null)
					{
						fStk.Push(@var);
					}
					else
					{
						fStk.Push(FTree.AddVariable(new FVar(f))); // variable
					}
				}

				i++;
			}




			FTree.rootNode = fStk.TopAndPop();
		}

		private static bool IsConstant(string f)
		{
			char c = f[0];
			if ((c >= '0' && c <= '9'))
			{
				//System.out.println("number: " + c);
				return true;
			}
			return false;
		}
	}

}