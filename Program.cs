using System;
using System.Dynamic;

class ThisIsPerfectlyOkay
{
    static void Main(string[] args)
    {
        // uses a dynamically built dictionary as a node type
        dynamic createProblem1()
        {
            dynamic root = new ExpandoObject();
            var node = root;
            for (var i = 0; i < 10; i++)
            {
                node.Index = i;
                node.IsProblemSolved = false;
                node.Next = new ExpandoObject();
                node.Colour = i < 5 ? "red" : "green";
            }
            node.IsProblemSolved = true;
            return root;
        }

        // uses an anonymous but static object as a node type
        dynamic createProblem2()
        {
            return new
            {
                Index = "ahaha it's a string",
                IsProblemSolved = true // no Next node needed
            };
        }

        dynamic searchForward(dynamic node)
        {
            while (!node.IsProblemSolved)
            {
                node = node.Next;
            }
            return node.Index;
        }

        int colourGraph(dynamic node)
        {
            var redNodes = 0;
            while (!node.IsProblemSolved)
            {
                if (node.Colour == "red") redNodes++;
                node.Colour = "green";
                node = node.Next;
            }
            return redNodes;
        }

        var p1 = createProblem1();
        Console.WriteLine("searchForward(p1): " + searchForward(p1));
        Console.WriteLine("colourGraph(p1): " + colourGraph(p1));

        var p2 = createProblem2();
        Console.WriteLine("searchForward(p2): " + searchForward(p2));
        // Console.WriteLine("colourGraph(p2): " + colourGraph(p2)); // uncomment this line if you dare........
    }
}