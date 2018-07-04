using System;
using System.Collections.Generic;

namespace util
{

	public class StringStack
	{
		private const int UPPER_CAP = 100000;
		internal List<string> StackArray;

		public StringStack()
		{
			StackArray = new List<string>();
		}

		public virtual bool IsEmpty()
		{
			return StackArray.Count == 0;
		}

		public virtual int CurrentSize()
		{
			return StackArray.Count;
		}

		public virtual void MakeEmpty()
		{
			for (int i = 0; i < CurrentSize(); i++)
			{
				StackArray.RemoveAt(0);
			}
		}

		public virtual void Push(string S)
		{
			if (CurrentSize() < UPPER_CAP)
			{
				StackArray.Add(S);
			}
			else
			{
				Console.WriteLine("Error: Stack's too Heavy!");
			}
		}

		public virtual string Top()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Error: Stack is Empty!");
				return null;
			}
			return StackArray[CurrentSize() - 1];
		}

		public virtual void Pop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Error: Stack is Empty!");
			}
			else
			{
				StackArray.RemoveAt(CurrentSize() - 1);
			}
		}

		public virtual string TopAndPop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Error: Stack is Empty!");
				return null;
			}
			else
			{
				string S = StackArray[CurrentSize() - 1];
				StackArray.RemoveAt(CurrentSize() - 1);
				return S;
			}
		}
	}

}