using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            
            for (int i = 0; i < nums.Count()-1; i++)
            {
                for (int j = i + 1; j < nums.Count(); j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        int[] IndexList = {nums[i],nums[j]};
                        return IndexList;
                    }
                }
            }
                return null;
        }
    }
}
