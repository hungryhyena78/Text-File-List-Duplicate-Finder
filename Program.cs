using System.Runtime.CompilerServices;

namespace Counting_From_a_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayStats();
        }

        public static void DisplayStats()
        {
            String filepath = @"C:\Users\Hungr\source\repos\Counting From a File\ReadMe.txt";
            FileStream fs = new FileStream(filepath, FileMode.Open);
            StreamReader myReader = new StreamReader(fs);
            StreamWriter myWriter = new StreamWriter(fs);
            Stream s = new MemoryStream();
            List<String> Uniques = new List<String>();
            List<int> finalnums = new List<int>();

            //Adding Unique Entries to a List Called "Uniques"
            for (int i = 0; i < 166; i++)
            {
                String currentline = myReader.ReadLine();
                int flag = 0;
                foreach (String b in Uniques)
                {
                    if (b == currentline)
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    Uniques.Add(currentline);
                }
            }

            Uniques.Sort();
            Uniques.RemoveAt(0);
            //Assigning Dupe Numbers Properly This Time
            foreach (String a in Uniques)
            {
                ResetReader(myReader);
                int count = 0;
                for (int i = 0; i < 166; i++)
                {
                    String currentline = myReader.ReadLine();
                    //Console.WriteLine("DEBUG: THIS IS CURRENTLINE: " + currentline);
                    //Console.WriteLine("DEBUG: THIS IS A: " + a);
                    if (a == currentline)
                    {
                        count++;
                    }
                }
                finalnums.Add(count);
            }

            //Displaying All Bosses
            for (int i = 0; i < Uniques.Count; i++)
            {
                Console.WriteLine("{0}. " + Uniques[i] + ": " + finalnums[i], (i + 1));
            }

            //Summing All Numbers in FinalNums
            int sum = 0;
            foreach (int num in finalnums)
            {
                sum += num;
            }
            Console.WriteLine("Total Number of Bosses: " + sum);

            myWriter.Flush();
            myWriter.Close();
            myReader.Close();
        }

        private static void ResetReader(StreamReader reader)

        {
            reader.DiscardBufferedData();
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
        }
    }
}
