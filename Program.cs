using System;
using System.Text;
using System.Diagnostics;

namespace quicksort
{
	class Program
	{
		public static void first_quicksort(int[] input, int low, int high, int[] stats)
		{
			if (high > low)
			{
				int i = low;
				for (int j = low + 1; j <= high; ++j) 
				{
					if (input[j] < input[low])
					{
						++stats[0];
						if (++i == j) continue;
						++stats[1];
						Utilities.Swap(ref input[i], ref input[j]);
					}
				}
				if (low != i)
                {
					++stats[1];
					Utilities.Swap(ref input[low], ref input[i]);
				}
				first_quicksort(input, low, i - 1, stats);
				first_quicksort(input, i + 1, high, stats);
			}
		}
		public static void last_quicksort(int[] input, int low, int high, int[] stats)
		{
			if (high > low)
			{
				int i = high;
				for (int j = high - 1; j >= low; --j)
				{
					if (input[j] > input[high])
					{
						++stats[0];
						if (--i == j) continue;
						++stats[1];
						Utilities.Swap(ref input[i], ref input[j]);
					}
				}
				if (high != i)
                {
					++stats[1];
					Utilities.Swap(ref input[high], ref input[i]);
				}
				last_quicksort(input, low, i - 1, stats);
				last_quicksort(input, i + 1, high, stats);
			}
		}
		public static int[] ReadDataset(string path)
        {
			return Array.ConvertAll(System.IO.File.ReadAllLines(path), int.Parse);
        }
		public static int[] GenerateDataset(int bound)
        {
			Random random = new Random();
			int[] dataSet = new int[bound];
			for (int a = 0; a < bound; a++)
			{
				dataSet[a] = random.Next(0, 1000);
			}
			return dataSet;
		}
		public static void random_quicksort(int[] input, int low, int high, int[] stats)
        {
			if (high > low)
			{
				Random r = new Random();
				int rand = low + r.Next() % (high - low);
				if (high != rand)
				{
					++stats[1];
					Utilities.Swap(ref input[high], ref input[rand]);
				}
				int i = low;
				for (int j = low + 1; j <= high; ++j)
				{
					if (input[j] < input[high])
					{
						++stats[0];
						if (++i == j) continue;
						++stats[1];
						Utilities.Swap(ref input[i], ref input[j]);
					}
				}
				if (high != i)
				{
					++stats[1];
					Utilities.Swap(ref input[high], ref input[i]);
				}
				random_quicksort(input, low, i - 1, stats);
				random_quicksort(input, i + 1, high, stats);
			}
		}
		public static void Main(string[] args)
		{
			int[] dataSet = ReadDataset(@"C:\Users\Public\Documents\dataset.txt");
			int[] stats = { 0, 0 };

			Stopwatch st = new Stopwatch();
			// Console.WriteLine($"Initial dataset: {Utilities.PrintArray(dataSet)}");
			st.Start();
			
			first_quicksort(dataSet, 0, dataSet.Length - 1, stats);
			
			long time = st.ElapsedMilliseconds;
			st.Stop();
			// Console.WriteLine($"Sorted dataset: {Utilities.PrintArray(dataSet)}");
			Console.WriteLine($"The resulting dataset is {(Utilities.ValidateArray(dataSet) ? "" : "NOT ")}sorted.");
			Console.WriteLine($"Comparisons: {stats[0]}, Swaps: {stats[1]}\nAlgorithm took {time} ms");
			Console.ReadLine();
		}
	}
}
