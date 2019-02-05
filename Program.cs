using System;
using System.Collections.Generic;
using System.Linq;

namespace mass
{
    public class Program
    {
        static int[] input_Massive(int n)
        {
            int[] mass = new int[n];
            return mass;
        }

        static int count_array()
        {
            int n_ = 0;
            Console.Write("Введите кол.во элементов массивов ");
            while (n_ <= 0)
            {
                n_ = int.Parse(Console.ReadLine());
            }

            return n_;
        }

        public static void output_mass(int[] massive, int type)
        {
            if (type == 1)
            {
                for (int i = 0; i < massive.Length; i++)
                {
                    Console.WriteLine(massive[i]);
                }
            }
            else
            {
                for (int i = 0; i < massive.Length; i++)
                {
                    Console.Write(massive[i] + " ");
                }

                Console.Write("\n");
            }
        }

        static int[] who_will_update_mass(int[] massive, int n, int user)
        {
            int first, second;
            if (user == 0)
            {
                massive = update_mass_by_user(massive, n);
            }

            if (user == 1)
            {
                range(out first, out second);
                massive = update_random_int(massive, n, first, second);
            }

            return massive;
        }

        static void range(out int first, out int second)
        {
            Console.Write("Введите мин значение:");
            first = int.Parse(Console.ReadLine());
            Console.Write("Введите макс значение:");
            second = int.Parse(Console.ReadLine());

            if (first > second)
            {
                int c = first;
                first = second;
                second = c;
            }
        }

        static int[] update_mass_by_user(int[] massive, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("ВВедите {0}эл. м. ", i + 1);
                massive[i] = int.Parse(Console.ReadLine());
            }

            return massive;
        }

        static int[] update_random_int(int[] massive, int n, int first, int second)
        {
            massive = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                massive[i] = rnd.Next(first, second);
            }

            return massive;
        }

        //1 Задание поиск максимального элемента массива;
        static int find_max_in_array(int[] array, int n)
        {
            int max_ = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > max_)
                {
                    max_ = array[i];
                }
            }

            return max_;
        }

        //2 Задание сумму нечетных элементов массива;
        static int summ_odd_numbers_in_mass(int[] array, int n)
        {
            int _local = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] % 2 != 0)
                {
                    _local = array[i];
                }
            }

            return _local;
        }

        /**
         * (c) prog
         */
        public static int[] Eratosfen(int max)
        {
            if (max < 2) throw new Exception("Максимальное число меньше 2");
            List<int> glist = new List<int>();
            for (int i = 2; i <= max; ++i) glist.Add(i);

            for (int i = 0, tmp; i < glist.Count - 1; ++i)
            {
                int current = glist[i];
                tmp = current << 1;

                while (tmp <= max)
                {
                    int index = glist.FindIndex(i, delegate(int a) { return a == tmp; });
                    tmp += current;
                    if (index == -1) continue;
                    glist.RemoveAt(index);
                }
            }

            return glist.ToArray();
        }

        //3 Задание
        public static int[] get_simple_numbers_in_array(int[] array, int n)
        {
            Array.Sort(array, 0, n);
            int max = array[n - 1];
            int[] primes = Eratosfen(max);

            int ai = 0, pi = 0;
            while (primes[pi] < array[0]) ++pi;

            List<int> glist = new List<int>();

            while (ai < n && pi < primes.Length)
                if (array[ai] > primes[pi])
                    ++pi;
                else if (array[ai] < primes[pi]) ++ai;
                else glist.Add(array[ai++]);

            return glist.ToArray();
        }

        //4 Задание
        static int multiply_negative_numbers_in_array(int[] array, int n)
        {
            int _local = 0;
            for (int i = 0;
                i < n;
                i++)
            {
                if (array[i] < 0)
                {
                    _local = Math.Abs(_local * array[i]);
                }
            }

            return _local;
        }

//5 Задание
        static int get_averange_value(int[] array, int n)
        {
            int _local = 0;
            for (int i = 0;
                i < n;
                i++)
            {
                _local += array[i];
            }

            _local = _local / n;
            return _local;
        }

        public static bool isPrime(int n)
        {
            int k = n / 2 + 1;
            for (int i = 2; i <= k; ++i)
                if (n % i == 0)
                    return false;
            return true;
        }

        public static int[] test_from_desk(int[] array, int n)
        {
            List<int> glist = new List<int>();
            foreach (var i in array)
                if (isPrime(i))
                    glist.Add(i);
            return glist.ToArray();
        }

        public static void Main(string[] args)
        {
            Console.Write("Кто будет заполнять массив : 0 - user , 1 - random ");
            int user = int.Parse(Console.ReadLine());
            int n_ = count_array();
            int[] mass = input_Massive(n_);
            mass = who_will_update_mass(mass, n_, user);
/*
 * Задание второй части
 */

            Console.Write("Выберите тип вывода массива\n 0 - строчкой или 1 - столбиком ");
            int type = int.Parse(Console.ReadLine());
            ////// output_mass(mass, type);
            Console.WriteLine("Максимальное значение : {0}", find_max_in_array(mass, n_));
            Console.WriteLine("Cумма нечетных элементов массива : {0}", summ_odd_numbers_in_mass(mass, n_));

            Console.Write("Простые числа: ");
            foreach (var i in get_simple_numbers_in_array(mass,n_)) Console.Write(i + " ");
            Console.WriteLine();

//            long milliseconds = DateTime.Now.Ticks;
//            get_simple_numbers_in_array(mass, n_);
//            milliseconds -= DateTime.Now.Ticks;
//            milliseconds /= TimeSpan.TicksPerMillisecond;
//            Console.WriteLine("prog algo exec time: {0} ms", milliseconds);
//            
//            milliseconds = DateTime.Now.Ticks;
//            test_from_desk(mass, n_);
//            milliseconds -= DateTime.Now.Ticks;
//            milliseconds /= TimeSpan.TicksPerMillisecond;
//            Console.WriteLine("non-prog algo exec time: {0} ms", milliseconds);

            Console.Write("Простые числа 2: ");
            foreach (var i in test_from_desk(mass, n_)) Console.Write(i + " ");
            Console.WriteLine();

            Console.WriteLine("Произведение отрицательных элементов массива {0}",
                multiply_negative_numbers_in_array(mass, n_));
            Console.WriteLine("Среднее арифметическое элементов массива {0}", get_averange_value(mass, n_));
            Console.Read();
        }
    }
}