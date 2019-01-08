using System;
using System.Collections.Generic;
using System.Threading;

namespace binSearch
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] a = { 1, 3, 5, 7, 9 };
      Console.WriteLine("Ищем -1: {0}", BinarySearch(a, -1));
      Console.WriteLine("Ищем  3: {0}", BinarySearch(a, 3));
      Console.WriteLine("Ищем  6: {0}", BinarySearch(a, 6));
      Console.WriteLine("Ищем  9: {0}", BinarySearch(a, 9));
      Console.WriteLine("Ищем 20: {0}", BinarySearch(a, 20));
      Console.ReadLine();
    }

    /// <summary>
    /// Бинарный поиск в отсортированном массиве.
    /// </summary>
    /// <param name="a">Отсортированный по возрастанию массив типа int[]</param>
    /// <param name="x">Искомый элемент.</param>
    /// <returns>Возвращает индекс искомого элемента либо null, если элемент не найден.</returns>
    private static int? BinarySearch(int[] a, int x)
    {
      // Проверить, имеет ли смыл вообще выполнять поиск:
      // - если длина массива равна нулю - искать нечего;
      // - если искомый элемент меньше первого элемента массива, значит, его в массиве нет;
      // - если искомый элемент больше последнего элемента массива, значит, его в массиве нет.
      if ((a.Length == 0) || (x < a[0]) || (x > a[a.Length - 1]))
        return null;

      // Приступить к поиску.
      // Номер первого элемента в массиве.
      int first = 0;
      // Номер элемента массива, СЛЕДУЮЩЕГО за последним
      int last = a.Length;

      // Если просматриваемый участок не пуст, first < last
      while (first < last)
      {
        int mid = first + (last - first) / 2;

        if (x <= a[mid])
          last = mid;
        else
          first = mid + 1;
      }

      // Теперь last может указывать на искомый элемент массива.
      if (a[last] == x)
        return last;
      else
        return null;
    }


    /*          
     *          // Рекурсивный бинарный поиск:
        private static void Main(string[] args)
        {
          int[] d = new int[5]; //задание массива из 5 элемемнтов, которые введены с клавиатуры
          for (int j = 0; j < d.Length; ++j)
          {
            Console.Write("({0}) ", j + 1); //вывод на экран массива
            d[j] = int.Parse(Console.ReadLine());
          }
          Array.Sort(d); //встроенная функция сортировки
          Console.WriteLine("Отсортированный массив: "); //вывод на экран отсортированного массива
          int index = 0;
          Array.ForEach(d, x =>
          {
            Console.WriteLine("[{0}]: {1}", index++, x);
          });

          Console.Write("\nНайти: ");
          int key = int.Parse(Console.ReadLine());
          int i = BinarySearch(d, key, 0, d.Length - 1); //обращение к классу BinarySearch для поиска индекса элемента
          if (i < d.Length)
            Console.WriteLine("Индекс искомого элемента: {0}", i);
          else
            Console.WriteLine("Элемент не найден");
          Console.ReadKey(true);
          }
          static int BinarySearch(int[] d, int key, int left, int right) //бинарный поиск
          {
          int mid = left + (right - left) / 2; //находим середину вычитая из последнего элемента первый и деля на 2
          if (left >= right)//проверка условия, если левая сторона больше правой, то возвращается значение
            return -(1 + left);

          if (d[mid] == key) //если оказалось. что середина равна искомому значнию, то возвращается это значение, и поиск завершается
            return mid;

          else if (d[mid] > key)//в противном случае если середина больше искомого значения, то возвращаемся к левой части и продолжаем там алгоритм
            return BinarySearch(d, key, left, mid);
          else
            return BinarySearch(d, key, mid + 1, right);// иначе, если середина меньше искомого значения, то продолжаем поиск в правой части, так же деля массив на две части
        }
    */
  }
}
