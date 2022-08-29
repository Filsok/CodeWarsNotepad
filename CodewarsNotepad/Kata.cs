using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodewarsNotepad
{
    internal class Kata
    {
        private static void Main(string[] args)
        {
            Console.ReadKey();
        }

        private static void HackerRankCSharpBasicFirst()
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        public static string MixedFraction(string s)
        {
            StringBuilder ret = new StringBuilder();
            List<int> num = new List<int>();
            string[] tmpStrings = s.Split('/');
            tmpStrings.ToList().ForEach(x => num.Add(Int32.Parse(x)));
            int numFir = Math.Abs(num.ElementAt(0));
            int numSec = Math.Abs(num.ElementAt(1));
            if (num.ElementAt(0) < 0 && num.ElementAt(1) >= 0 || num.ElementAt(0) >= 0 && num.ElementAt(1) < 0) ret.Append("-");
            int calosci = numFir / numSec;
            ret.Append(calosci > 0 ? calosci.ToString() : "");
            int licznik = numFir % numSec;
            if (!(licznik == 0))
            {
                if (calosci > 0) ret.Append(" ");
                int factor = (licznik == 0) ? 1 : licznik;
                while (factor > 1)
                {
                    if (licznik % factor == 0 && numSec % factor == 0) break;
                    factor--;
                }
                ret.Append($"{licznik / factor}/{numSec / factor}");
            }
            return (ret.ToString() == "-" || ret.Length == 0) ? "0" : ret.ToString();
        }

        private static List<object> JosephusPermutation(List<object> items, int k)
        {
            var result = new List<object>();
            int i = 1;
            int ik = k;

            while (items.Count > 0)
            {
                if (ik == 1)
                {
                    result.Add(items[i > 0 ? i - 1 : items.Count - 1]);
                    items.RemoveAt(i > 0 ? i - 1 : items.Count - 1);
                    ik = k;
                }
                else { i++; ik--; }
                if (items.Count < k && i > items.Count) i = 1;
                else if (i > items.Count) i -= items.Count;
            }
            return result;
        }

        private static string PigIt(string str)
        {
            String[] tmp = str.Split(' ');
            return String.Join(" ", tmp.Select(p => char.IsLetter(p.First<char>()) ? (p + p.First<char>().ToString() + $"ay").Substring(1) : p));
        }

        public static int RuneExpression(string expression)
        {
            //(number)[opperator](number)=(number)
            //Unknown digit will not be the same as any other digits used in expression
            int missingDigit = -1;
            char[] ops = { '-', '+', '*' };
            //char[] operat = expression.(x => if (ops.Contains(x)) x);
            //String[] numbers = expression.Split(operat[0],'=');
            Dictionary<string, bool> usedNum = new Dictionary<string, bool>();
            for (int i = 0; i <= 9; i++) usedNum.Add(i.ToString(), false);

            return missingDigit;
        }

        public void NieMetoda()
        {
            //zabawa atrybutami z Reflections FieldAttributes
            try
            {
                // Get the type handle of a specified class.
                Type myType = typeof(Kata);

                // Get the fields of the specified class.
                FieldInfo[] myField = myType.GetFields();

                Console.WriteLine("\nDisplaying fields attributes:\n");
                foreach (FieldInfo field in myField)
                {
                    Console.WriteLine($"Field:. {field.Name}  {field.Attributes} ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0} ", e.Message);
            }
        }

        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            Dictionary<string, List<int>> ret = new Dictionary<string, List<int>>();
            List<int> peaksList = new List<int>();
            List<int> posList = new List<int>();
            if (arr.Count() == 0) goto Finish;
            int[] ip = { 0, 0 };
            int[] ipp = { 0, 0 };
            int[] ispl = { 0, 0 };
            List<int[]> itemList = new List<int[]>();
            int iterator = 0;
            foreach (int i in arr)
            {
                if (ipp[1] < ip[1] && ip[1] > i)
                {
                }
                if (ip[1] == i) ispl = ip;
                else if (ipp[1] == ip[1] && ip[1] == ispl[1] && i < ip[1]) itemList.Add(ip);

                ipp = ip;
                //ip.Insert(0, iterator); ip.Insert(1, i);
                iterator++;
            }
            foreach (int[] it in itemList)
            {
                posList.Add(it[0]);
                peaksList.Add(it[1]);
            }
        Finish:
            ret.Add("pos", posList);
            ret.Add("peaks", peaksList);
            return ret;
        }

        public class NotesStore
        {
            private readonly List<String> States;
            private Dictionary<String, String> NotesList;

            public NotesStore()
            {
                NotesList = new Dictionary<String, String>();
                States = new List<String>() { "completed", "active", "others" };
            }

            public void AddNote(String state, String name)
            {
                if (String.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be empty");
                else
                {
                    if (!States.Contains(state)) throw new ArgumentException($"Invalid state {state}");
                    else NotesList.Add(name, state);
                }
            }

            public List<String> GetNotes(String state)
            {
                if (!States.Contains(state)) throw new ArgumentException($"Invalid state {state}");
                var ret = new List<String>();
                foreach (var it in NotesList)
                {
                    if (String.Equals(it.Value, state)) ret.Add(it.Key.ToString());
                }
                return ret;
            }
        }
    }
}