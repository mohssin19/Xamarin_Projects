## Code to Implement for automated and manual ideas

```c#

static List<string> quotes = File.ReadAllLines("../../../../../../Dad/Reminders/quotes.txt").ToList();
        //static List<string> quotes = File.ReadAllLines("../../../../../../Dad/Reminders/RandomTechNotes.md").ToList();
        static List<string> batch = new List<string>();
        static int responseCode = 0;
        static int automaticTimePeriod = 0;
        static int batchLength = 0;
        static int proposedBatchLength = 0;

 


        public static void Main(string[] args)
        {

 

            setMode(); // Automatic 1 Manual 2.  Automatic has timer eg 2 secs
            getBatchLength();             
            while (true)
            {
                
                getBatch();  // get batchlength number of items
                displayBatch();  // display items to user
                batchLength += 10;
            }
        }

 

        static void setMode()
        {
            while (true)
            {
                Console.WriteLine("Which Mode : Automatic(1) or Manual(2)");
                int.TryParse(Console.ReadLine(), out responseCode);
                if (responseCode == 1)
                {
                    Console.WriteLine("What time span in seconds?");
                    int.TryParse(Console.ReadLine(), out automaticTimePeriod);
                }
                if (responseCode == 1 || responseCode == 2) break;
            }
        }

 

        /// <summary>
        /// Batch will contain a) Blank lines b) Lines beginning with a 'hash'
        /// which are not to be included in the output
        /// </summary>
        /// <returns>int batchLength</returns>
        static int getBatchLength() {
            Console.Clear();
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            Console.WriteLine("How Many Items For This Batch?");

 

            int.TryParse(Console.ReadLine(), out proposedBatchLength);
            if (proposedBatchLength == 0)
            {
                batchLength += 10;
            }
            else
            {
                batchLength = proposedBatchLength;
            }
            return batchLength;
        }

 

        /// <summary>
        /// gets items to display in this batch
        /// </summary>
        static void getBatch() {

 

            for (int i = 0; i < batchLength; i++)
            {
                if ((quotes[i] != null) && (quotes[i].Length > 0))
                {
                    if ((quotes[i][0].ToString() != " ") && (quotes[i][0].ToString() != "#"))
                    {
                        quotes[i] = quotes[i].Replace("///", Environment.NewLine);
                        batch.Add(quotes[i]);
                    }
                }
            }
        }

 

        static void displayBatch() { 
            var random = new Random();  // present items in random order
            while (batch.Count > 0)
            {
                var randomIndex = random.Next(batch.Count);
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(batch[randomIndex]);
                batch.RemoveAt(randomIndex);
                if (automaticTimePeriod > 0)
                {
                    Thread.Sleep(automaticTimePeriod * 1000);
                }
                else
                {
                    Console.ReadLine();
                }
            }
        }
```