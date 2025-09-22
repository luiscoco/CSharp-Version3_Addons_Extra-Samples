using System; using System.Collections.Generic;
class Program
{
    static void Main()
    {
        // Classic closure pitfall in C# 3.0: foreach loop variable is captured once
        var actions = new List<System.Action>();
        foreach (int i in new int[]{1,2,3})
        {
            actions.Add(() => System.Console.WriteLine("Captured i = " + i));
        }
        System.Console.WriteLine("Incorrect (all 3 lines will print '3'):");
        foreach (var a in actions) a();

        // Fix: copy to a local inside the loop
        var fixedActions = new List<System.Action>();
        foreach (int j in new int[]{1,2,3})
        {
            int local = j;
            fixedActions.Add(() => System.Console.WriteLine("Fixed local = " + local));
        }
        System.Console.WriteLine("\nCorrect (1,2,3):");
        foreach (var a in fixedActions) a();
    }
}
