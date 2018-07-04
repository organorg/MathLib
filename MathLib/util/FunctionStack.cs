using System;
using System.Collections.Generic;

namespace util
{

	using Function = function.Function;

	public class FunctionStack
	{
		private const int UPPER_CAP = 100000;
		internal List<Function> StackArray;

		public FunctionStack()
		{
			StackArray = new List<Function>();
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

		public virtual void Push(Function F)
		{
			if (CurrentSize() < UPPER_CAP)
			{
				StackArray.Add(F);
			}
			else
			{
				Console.WriteLine("Error: Stack's too Heavy!");
			}
		}

		public virtual Function Top()
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

		public virtual Function TopAndPop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Error: Stack is Empty!");
				return null;
			}
			else
			{
				Function F = StackArray[CurrentSize() - 1];
				StackArray.RemoveAt(CurrentSize() - 1);
				return F;
			}
		}

	}

}