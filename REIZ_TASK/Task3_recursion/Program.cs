using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // main 1st row 
            Branch Tree = new Branch(new List<Branch>());
            // recreates the example structure of depth 5
            RecreateTreeExample(Tree);

            // outputs the depth
            Console.WriteLine($"The depth of the provided structure is: {RecursionSearchInDepth(Tree, 1)}");
        }

        /// <summary>
        /// Recursion algorythm to search in depth
        /// </summary>
        /// <param name="Tree">Structure we will search depth of</param>
        /// <param name="initialDepth">depth of initial structure is 1 because strructure is created</param>
        /// <returns>int number of structure depth</returns>
        private static int RecursionSearchInDepth(Branch Tree, int initialDepth)
        {
            if (Tree.Branches.Count == 0)
                return initialDepth;
            int maxDepth = 0;
            for (int i = 0; i < Tree.Branches.Count; i++)
            {
                int result = RecursionSearchInDepth(Tree.Branches[i], initialDepth + 1);
                //checks if one branch length depth is bigger than saved ones.
                if (result > maxDepth)
                    maxDepth = result;
            }
            return maxDepth;
        }

        /// <summary>
        /// Recreates the Tree example in TASK 3
        /// </summary>
        /// <param name="Tree">Structure of tree</param>
        private static void RecreateTreeExample(Branch Tree)
        {
            // 2nd row
            Tree.Branches.Add(new Branch(new List<Branch>()));
            Tree.Branches.Add(new Branch(new List<Branch>()));

            // 3rd row
            Tree.Branches[0].Branches.Add(new Branch(new List<Branch>()));
            Tree.Branches[1].Branches.Add(new Branch(new List<Branch>()));
            Tree.Branches[1].Branches.Add(new Branch(new List<Branch>()));
            Tree.Branches[1].Branches.Add(new Branch(new List<Branch>()));

            // 4th row
            Tree.Branches[1].Branches[0].Branches.Add(new Branch(new List<Branch>()));
            Tree.Branches[1].Branches[1].Branches.Add(new Branch(new List<Branch>()));
            Tree.Branches[1].Branches[1].Branches.Add(new Branch(new List<Branch>()));

            // 5th row
            Tree.Branches[1].Branches[1].Branches[0].Branches.Add(new Branch(new List<Branch>()));
        }
    }

}
