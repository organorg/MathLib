using System;
using System.Collections.Generic;

namespace function.tree
{

	using FCons = math.FCons;
	using FVar = math.FVar;

	public class FunctionTree
	{
		protected internal Function rootNode;
		protected internal string[] postfixArray;
		internal List<FVar> varList;

		public FunctionTree(string s)
		{
			s = StringRefiner.RefineFunctionString(s);
			PostfixMaker.CreatePostfixArray(s, this);
			TreeMaker.CreateFunctionTree(postfixArray, this);
			this.varList = rootNode.varList;
			//Traverse(rootNode);
		}

		public FunctionTree(Function F)
		{
			this.rootNode = F;
			this.varList = rootNode.varList;

			VarFix(rootNode);
		}


		public virtual List<FVar> VarList
		{
			get
			{
				return varList;
			}
		}

		internal virtual Function RootNode()
		{
			return rootNode;
		}



		public double GetValue()
		{
			return rootNode.GetValue();
		}

		public virtual FunctionTree GetDerivative(FVar var)
		{
			if (rootNode.HasVariable(var))
			{
				return new FunctionTree(rootNode.GetDerivative(var));
			}
			return new FunctionTree(new FCons(0));
		}

		public virtual FunctionTree GetDerivative(string var)
		{
			FVar v = new FVar(@var);
			if (rootNode.HasVariable(v))
			{
				return new FunctionTree(rootNode.GetDerivative(v));
			}
			return new FunctionTree(new FCons(0));
		}

		public virtual double GetValue(params string[] str)
		{
            // parse and set values
            
			for (int i = 0; i < str.Length; i++)
			{

                int w = 0;
				char c;
				string s = "";
				int len = str[i].Length;

				while (w < len)
				{
					c = str[i][w];
					if (c == '=')
					{
						break;
					}
					s = s + char.ToString(c);

					//System.out.println(str[i] + " // " + s);

					w++;
				}

                FVar f = FindVariable(s);
				if (f != null && w < len)
				{
                    try
					{
						f.SetValue(Convert.ToDouble(str[i].Substring(++w)));
					}
					catch (FormatException)
					{
					}
				}
			}


			return rootNode.GetValue();
		}

		internal virtual FVar FindVariable(string varName)
		{
			foreach (FVar v in varList)
			{
				if (v.varName.Equals(varName))
				{
					return v;
				}
			}
			return null;
		}

		public virtual double GetValue(params double[] val)
		{
			// set Values

			for (int i = 0; i < varList.Count && i < val.Length; i++)
			{
				varList[i].SetValue(val[i]);
			}

			return rootNode.GetValue();
		}

		public virtual Function AddVariable(FVar @var)
		{
			this.varList.Add(@var);
			return @var;
		}

		public override string ToString()
		{
			return rootNode.ToString();

		}

		public virtual void VarFix(Function F)
		{
			//if(F==null)
			//{
			//	return;
			//}
			//System.out.println(F.toString());



			for (int i = 0; i < F.numSubNodes;i++)
			{
				Function Fnode = F.GetSubNode(i);

				if (Fnode.GetID() == FVar.ID)
				{


					FVar var = this.FindVariable(((FVar)Fnode).varName);
					if (var != null)
					{
						//System.out.println(((FVar)Fnode).getVarName());
						F.SetSubNode(i, var);
					}
					continue;
				}
				if (Fnode.GetID().Equals(FCons.ID))
				{
					continue;
				}
				VarFix(F.GetSubNode(i));
			}
		}

		public virtual void Simplify()
		{
			rootNode = rootNode.GetSimplifiedFunction();
			VarFix(rootNode);
		}

		public virtual FunctionTree GetSimplifiedFunction()
		{
			return new FunctionTree(rootNode.GetSimplifiedFunction());
		}
	}

}