using System;

namespace function.list
{

	public class FunctionList
	{
		internal static string[] FList = new string[] 
        {
            "ln",
            "log",
            "neg",
            "add",
            "sum",
            "sub",
            "div",
            "mul",
            "pow",
            "exp",
            "abs",
            "sin",
            "cos",
            "tan",
            "csc",
            "sec",
            "cot",

            "sinh",
            "cosh",
            "tanh",
            "csch",
            "sech",
            "coth",

            "log10",
            "cosec",

            "cosech"
        };

		public static bool IsFunction(string F)
		{
			foreach (string s in FList)
			{
				if (F.Equals(s, StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsFunction(string F, int size)
		{
			switch (size)
			{
				case (2):
					for (int i = 0; i <= 0; i++)
					{
						if (F.Equals(FList[i], StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
					}
					break;
				case (3):
					for (int i = 1; i <= 16; i++)
					{
						if (F.Equals(FList[i], StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
					}
					break;
				case (4):
					for (int i = 17; i <= 22; i++)
					{
						if (F.Equals(FList[i], StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
					}
					break;
				case (5):
					for (int i = 23; i <= 24; i++)
					{
						if (F.Equals(FList[i], StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
					}
					break;
				case (6):
					for (int i = 25; i <= 25; i++)
					{
						if (F.Equals(FList[i], StringComparison.CurrentCultureIgnoreCase))
						{
							return true;
						}
					}
					break;
			}
			return false;
		}

		internal static string[] SOFList = new string[] {"constant", "variable", "ln", "log", "neg", "pow", "exp", "abs", "sin", "cos", "tan", "csc", "sec", "cot", "sinh", "cosh", "tanh", "csch", "sech", "coth", "log10", "cosec", "cosech"};

		public static bool IsSingleOperandFunction(string ID)
		{
			foreach (string s in SOFList)
			{
				if (ID.Equals(s, StringComparison.CurrentCultureIgnoreCase))
				{
					return true;
				}
			}
			return false;
		}


	}

}