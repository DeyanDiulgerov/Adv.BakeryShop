using System;
using System.Collections.Generic;
using System.Linq;

namespace Adv._Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var BakeryResult = new Dictionary<string, int>
            {
                {"Croissant", 0 },
                { "Muffin", 0 },
                { "Baguette", 0},
                { "Bagel", 0 }
            };

            var water = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
            var flour = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();

            var waterQueue = new Queue<double>(water);
            var flourStack = new Stack<double>(flour);

            while (flourStack.Any() && waterQueue.Any())
            {
                var currentFlour = flourStack.Peek();
                var currentWater = waterQueue.Peek();

                if(CroissantMix(currentFlour, currentWater))
                {
                    BakeryResult["Croissant"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else if(MuffinMix(currentFlour, currentWater))
                {
                    BakeryResult["Muffin"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else if (BaguetteMix(currentFlour, currentWater))
                {
                    BakeryResult["Baguette"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else if (BagelMix(currentFlour, currentWater))
                {
                    BakeryResult["Bagel"]++;
                    flourStack.Pop();
                    waterQueue.Dequeue();
                }
                else
                {
                    var currentFlowerr = flourStack.Pop();
                    var currentWaterr = waterQueue.Dequeue();
                    var flourReduced = currentFlowerr - currentWater;
                    BakeryResult["Croissant"]++;
                    flourStack.Push(flourReduced);
                }
            }
            foreach (var item in BakeryResult.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            var flourLeft = flourStack.Count == 0 ? "None" : string.Join(", ", flourStack);
            var waterLeft = waterQueue.Count == 0 ? "None" : string.Join(", ", waterQueue);

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");
        }
        public static bool CroissantMix(double flour, double water)
        {
            var percentages = CalculatePercentages(flour, water);
            if (percentages[0] == 50 && percentages[1] == 50)
            {
                return true;
            }
            return false;
        }
        public static bool MuffinMix(double flour, double water)
        {
            var percentages = CalculatePercentages(flour, water);

            if (percentages[0] == 60 && percentages[1] == 40)
            {
                return true;
            }
            return false;
        }
        public static bool BaguetteMix(double flour, double water)
        {
            var percentages = CalculatePercentages(flour, water);

            if (percentages[0] == 70 && percentages[1] == 30)
            {
                return true;
            }
            return false;
        }
        public static bool BagelMix(double flour, double water)
        {
            var percentages = CalculatePercentages(flour, water);

            if (percentages[0] == 80 && percentages[1] == 20)
            {
                return true;
            }
            return false;
        }
        public static double[] CalculatePercentages(double flour, double water)
         {
                var returnResult = new double[2];
            var result = flour + water;
            returnResult[0] = (flour / result) * 100;
            returnResult[1] = (water / result) * 100;

            return returnResult;
         }
    }
}
