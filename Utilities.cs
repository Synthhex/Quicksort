using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quicksort
{
    class Utilities
    {
		public static void Swap(ref int a, ref int b)
		{
			a ^= b;
			b ^= a;
			a ^= b;
		}
		public static string PrintArray(int[] arr)
		{
			var sb = new StringBuilder("");
			for (int i = 0; i < arr.Length; ++i)
				sb.Append(arr[i] + " ");
			return sb.ToString();
		}
		public static bool ValidateArray(int[] arr)
        {
			for (int i = 1; i < arr.Length; ++i)
            {
				if (arr[i] < arr[i - 1]) 
					return false;
            }
			return true;
        }
	}
}