
using System;

using FunctionTree = function.tree.FunctionTree;


public class Test
{
	public static void Main(string[] args)
	{
        Console.WriteLine("Available Programs:");
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>");

        Console.WriteLine   (   "(1) Derivative Computer" + "\n" +
                                "(2) Derivative Computer" + "\n" +
                                ""
                            );

        int choice = int.Parse(Console.ReadLine());

        switch(choice)
        {
            case (1): MathPrograms.FunctionSimplifier(); break;
            case (2): MathPrograms.SimpleDerivativeComputer(); break;
            //default: Console.WriteLine("Invalid Choice.");
            default: Console.WriteLine("Error"); break;
        }

        Console.ReadKey();
    }
}

internal static class MathPrograms
{

    public static void SimpleDerivativeComputer()
    {
        Console.Write("\n\n\nEnter Function:\t\t");
        string s = Console.ReadLine();

        Console.Write("\nDerivate w.r.t. ?\t");
        string v = Console.ReadLine();

        Console.Write("\nDerivate at '" + v + "'= ?\t");
        double d = Double.Parse(Console.ReadLine());

        FunctionTree myFunc = new FunctionTree(s);

        Console.WriteLine("\nDerivative\t=\t" + myFunc.GetDerivative(v).GetSimplifiedFunction().ToString());
        Console.WriteLine("Value\t\t=\t" + myFunc.GetDerivative(v).GetValue(v + "=" + d));
        Console.WriteLine("\n\n\n");
    }

    public static void FunctionSimplifier()
    {
        Console.Write("\n\n\nEnter Function:\t\t");
        string s = Console.ReadLine();

        FunctionTree myFunc = new FunctionTree(s);

        Console.WriteLine("\nSimplification\t=\t" + myFunc.GetSimplifiedFunction().ToString());
        Console.WriteLine("\n\n\n");
    }
}


//		F = new FAdd(new FVar("x"), new FCons(1));
//		System.out.println(" " + F.getValue(3));
//		
//		FunctionStack S = new FunctionStack();
//		S.Push(F);
//		
//		System.out.println(" " + S.Top().getValue(6));
//		S.Pop();
//		System.out.println(" " + S.Top().getValue(6));
//		System.out.println(" " + S.TopAndPop().getValue(6));
//		
//		String s = "+++-(+4(~4 ~5.55  .  x).-x^(+-+4x)+33)567x(-sin(-x*~y+z+1-200))+pow(4,2)cosec(1)+2.1+ln(4)+cosh(1)+log10(4)+x(-3)+cosech(140)";
//		s = "A++++++++~-----g";
//		s = StringRefiner.RefineFunctionString(s);
//		System.out.println(s);

//		String s = "(4*~x^(~4*x)+33)*567*~(sin(x+1-200)) + pow(4,2)";

//		s = "4s";
//		Scanner scan = new Scanner(System.in);
//		s = scan.nextLine();

//		System.out.println(myFunc.toString());
//		String[] sp = new String[s.length()];
//		String[] sp = PostfixMaker.CreatePostfixArray(s);

//		int i=0;
//		while(i < sp.length)
//		{
//			System.out.println("sp.. "+sp[i]);
//			i++;
//		}
//		rootNode = TreeMaker.CreateFunctionTree(sp);
//		System.out.println(s);
//		System.out.println("check: " + Math.pow(-1, -4));
//		System.out.println("\nstr: " + myFunc.toString());
//		System.out.println("value: " + myFunc.getValue());
//		System.out.println("value: " + myFunc.getValue("x=1.1", "wyz=2", "t=3"));

//		System.out.println(myFunc.getDerivative(new FVar("x")).getValue("x=1"));
//		System.out.println(myFunc.getDerivative(new FVar("x")).getSimplifiedTree().toString());
//		System.out.println("\n\n\n");
//		FunctionTree f = new FunctionTree(new FAdd(new FSub(new FVar("A"), new FCons(-1)), new FSin(new FVar("A"))));
//		System.out.println("\nstr: " + f.toString());
//		System.out.println("value: " + f.getValue());
//		System.out.println(f.getDerivative(new FVar("A")).toString());
//		System.out.println("val check: " + rootNode.getValue(1));