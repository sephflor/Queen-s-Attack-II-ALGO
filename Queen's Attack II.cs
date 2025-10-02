using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        
        int left = c_q - 1;
        int right = n - c_q;
        int up = n - r_q;
        int down = r_q - 1;
        int upLeft = Math.Min(up, left);
        int upRight = Math.Min(up, right);
        int downLeft = Math.Min(down, left);
        int downRight = Math.Min(down, right);
        
        foreach (var obs in obstacles)
        {
            int r_o = obs[0];
            int c_o = obs[1];
            
        
            if (r_o == r_q)
            {
                if (c_o < c_q)
                    left = Math.Min(left, c_q - c_o - 1);
                else
                    right = Math.Min(right, c_o - c_q - 1);
            }
            
            else if (c_o == c_q)
            {
                if (r_o < r_q)
                    down = Math.Min(down, r_q - r_o - 1);
                else
                    up = Math.Min(up, r_o - r_q - 1);
            }
            
            else if (Math.Abs(r_o - r_q) == Math.Abs(c_o - c_q))
            {
                int dr = r_o - r_q;
                int dc = c_o - c_q;
                
                if (dr > 0 && dc < 0)
                    upLeft = Math.Min(upLeft, dr - 1);
                else if (dr > 0 && dc > 0)
                    upRight = Math.Min(upRight, dr - 1);
                else if (dr < 0 && dc < 0)
                    downLeft = Math.Min(downLeft, -dr - 1);
                else if (dr < 0 && dc > 0)
                    downRight = Math.Min(downRight, -dr - 1);
            }
        }
        
        return left + right + up + down + upLeft + upRight + downLeft + downRight;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
        int n = Convert.ToInt32(firstMultipleInput[0]);
        int k = Convert.ToInt32(firstMultipleInput[1]);
        
        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
        int r_q = Convert.ToInt32(secondMultipleInput[0]);
        int c_q = Convert.ToInt32(secondMultipleInput[1]);
        
        List<List<int>> obstacles = new List<List<int>>();
        
        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ')
                .Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp))
                .ToList());
        }
        
        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);
        Console.WriteLine(result);
    }
}
