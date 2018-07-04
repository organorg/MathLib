namespace function.tree
{

	using FunctionList = function.list.FunctionList;

	public class StringRefiner
	{
		public static string RefineFunctionString(string s)
		{
			int size = s.Length;

			int i;
			string c;

			i = 0;
			while (i < s.Length)
			{
				if (s[i] == ' ')
				{
					s = ReplaceSection(s, i, i + 1, "");
					continue;
				}
				i++;
			}

			i = 0;
			while (i < s.Length - 2)
			{
				c = s.Substring(i, 3);
				//System.out.println(c);

				if (c[1] == '.' && !(IsNumber(c[0]) && IsNumber(c[2])))
				{
					s = ReplaceSection(s, i + 1, i + 2, "*");
					continue;
				}
				i++;
			}

			// remove operators at end
			i = s.Length - 1;
			while (i >= 0)
			{

				if (IsOperator(s[i]))
				{
					s = s.Substring(0, s.Length - 1);
				}
				else
				{
					break;
				}
				i--;
			}

			// replace negators
			i = 0;
			while (i < s.Length - 1)
			{
				c = s.Substring(i, 2);
				//System.out.println(c);

				if ((IsOperator(c[0]) || c[0] == '(') && c[1] == '-')
				{
					s = ReplaceSection(s, i + 1, i + 2, "~");
					continue;
				}

				if ((IsAlphabet(c[0]) || IsNumber(c[0])) && c[1] == '~')
				{
					s = ReplaceSection(s, i + 1, i + 1, "*");
					continue;
				}

				if (c[0] == '~' && c[1] == '+')
				{
					s = ReplaceSection(s, i, i + 2, "~");
					continue;
				}

				if (c[0] == '~' && c[1] == '-')
				{
					s = ReplaceSection(s, i, i + 2, "+");
					continue;
				}

				i++;
			}

			i = 0;
			while (i < s.Length - 1)
			{
				c = s.Substring(i, 2);
				//System.out.println(c);

				// check for functions

				if (IsAlphabet(c[0]))
				{
					if ((i + 5) < s.Length && FunctionList.IsFunction(s.Substring(i, 6), 6))
					{
						i += 6;
						continue;
					}
					if ((i + 4) < s.Length && FunctionList.IsFunction(s.Substring(i, 5), 5))
					{
						i += 5;
						continue;
					}
					if ((i + 3) < s.Length && FunctionList.IsFunction(s.Substring(i, 4), 4))
					{
						i += 4;
						continue;
					}

					if ((i + 2) < s.Length && FunctionList.IsFunction(s.Substring(i, 3), 3))
					{
						i += 3;
						continue;
					}
					if ((i + 1) < s.Length && FunctionList.IsFunction(s.Substring(i, 2), 2))
					{
						i += 2;
						continue;
					}
				}

				// remove excessive plus and minus signs

				if ((IsOperator(c[0]) || c[0] == '(') && c[1] == '+')
				{
					s = ReplaceSection(s, i, i + 2, c.Substring(0, 1));
					continue;
				}
				if (c.Equals("--"))
				{
					s = ReplaceSection(s, i, i + 2, "+");
					continue;
				}
				if (c.Equals("+-"))
				{
					s = ReplaceSection(s, i, i + 2, "-");
					continue;
				}
				if (c.Equals("-+"))
				{
					s = ReplaceSection(s, i, i + 2, "-");
					continue;
				}

				// insert necessary multiplication signs

				if (IsNumber(c[0]) && IsAlphabet(c[1]))
				{
					s = ReplaceSection(s, i + 1, i + 1, "*");
					continue;
				}

				if (c[0] == ')' && (IsAlphabet(c[1]) || IsNumber(c[1])))
				{
					s = ReplaceSection(s, i + 1, i + 1, "*");
					continue;
				}

				if ((IsAlphabet(c[0]) || IsNumber(c[0])) && c[1] == '(')
				{
					s = ReplaceSection(s, i + 1, i + 1, "*");
					continue;
				}



				i++;
			}

			// remove plus from beginning

			if (s.Length > 0 && s[0] == '+')
			{
				s = s.Substring(1);
			}

			// replace minus sign from beginning

			if (s.Length > 0 && s[0] == '-')
			{
				s = "~" + s.Substring(1);
			}



			return s;
		}

		private static string ReplaceSection(string s, int st, int end, string rep)
		{
			//System.out.println("p1 = " + s.substring(0, st));
			//System.out.println("p2 = " + rep);
			//System.out.println("p3 = " + s.substring(end));
			return s.Substring(0, st) + rep + s.Substring(end);
		}

		private static bool IsAlphabet(char c)
		{
			if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
			{
				return true;
			}
			return false;
		}

		private static bool IsNumber(char c)
		{
			if ((c >= '0' && c <= '9'))
			{
				//System.out.println("number: " + c);
				return true;
			}
			return false;
		}

		private static bool IsOperator(char c)
		{
			if (c == '+' || c == '-' || c == '*' || c == '/' || c == '.' || c == '^')
			{
				return true;
			}
			return false;
		}
	}

}