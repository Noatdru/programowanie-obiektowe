
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 4, 6, 7, 3, 2, 8, 9 };
           IEnumerable<int> evenNumbers = from n in ints
            where n % 2 == 0
            select n;
            Console.WriteLine(string.Join(", ", evenNumbers));
            //zapis LINQ które zwróci liczby większe od 5 z tablicy ints
            IEnumerable<int> moreThanFive =
            from n in ints
            where n > 5 
            select n;
            Console.WriteLine(string.Join(", ", moreThanFive));
            ////////////////////////////////////PREDYKAT
            Predicate<int> intPredicate = n =>
            {
                Console.WriteLine("Wywyołanie predykatu dla " + n);
                return n % 2 == 0;

            };

           // evenNumbers =
            evenNumbers =
            from n in evenNumbers
            where n > 5
            select n * 2;
            Console.WriteLine("wywołanie ewaluacji wyrażenia LINQ");
            Console.WriteLine(string.Join(", ", evenNumbers));
            Console.WriteLine(evenNumbers.Sum());

            //Oblicz średnia liczb z evennumbers
            Console.WriteLine(evenNumbers.Average());
            //Ile jest liczb w EvenNumbers
            Console.WriteLine(evenNumbers.Count());

            //Jaka jest najwieksza 
            Console.WriteLine(evenNumbers.Min());

            //Jaka jest najmniejsza 
            Console.WriteLine(evenNumbers.Max());
        }

    internal class Student
    {
        private int Number;
        private string Name;
        private int ECTS;

        public Student(int Number, string Name, int ECTS)
        {
            Student[] students =
            {
                new Student(1, "Ewa", 64),
                new Student(2, "Kasia", 66),
                new Student(3, "Karol", 69),
                new Student(4, "Jan", 67),
                new Student(5, "Tomasz", 67),
                new Student(6, "Sebastian", 67),
                new Student(7, "Wicek", 65),
                new Student(9, "Adam", 61),
                new Student(10, "Ewa", 62)
               };
            IEnumerable<string> enumerable =
                from s in students
                orderby s.ECTS orderby s.Name descending
                select s.Name + " " + s.ECTS;
            Console.WriteLine(string.Join("\n", enumerable));

                Console.WriteLine(string.Join(",", 
                    from i in ints
                    orderby i descending
                    select i ;
                );


                Random random = new Random();
                random.Next(5)
        }
           

    }
    }
}

