using System;

namespace Utility
{
    class Generator
    {
        public static int[] RandomArray( int size, int lRange, int uRange )
        {
            Random rn = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rn.Next(lRange, uRange);
            }

            return array;
        }
    }
    class Search
    {
        public static bool Linear( int[] array, int x )
        {
            for( int i = 0; i < array.Length; i++ )
            {
                if ( array[i] == x ) return true;
            }
            return false;
        }

        public static bool iBinary( int[] array, int x )
        {
            int start = 0;
            int end = array.Length - 1;
            int mid;

            while (end >= start)
            {
                mid = (start + end) / 2;
                
                if ( array[mid] == x ) return true;

                else if ( array[mid] > x ) end = mid - 1;

                else start = mid + 1;
            }
            return false;
        }

        public static bool Binary( int[] array, int x )
        {
            static bool BinarySearch(int[] array, int start, int end, int x)
            {
                int mid = start + (end - start) / 2;

                if (start > end) return false;

                else if (x == array[mid]) return true;
                
                else if (x < array[mid]) return BinarySearch(array, start, mid - 1, x);

                else return BinarySearch(array, mid + 1, end, x);
            }

            return BinarySearch(array, 0, array.Length - 1, x);
        }

        public static bool iTenary( int[] array, int x )
        {
            int start = 0;
            int end = array.Length - 1;
            int mid1, mid2, div;

            while (end >= start)
            {
                div = (end - start) / 3;
                mid1 = start + div;
                mid2 = end - div;

                if (x == array[mid1] || x == array[mid2]) return true;
                else if (x < array[mid1])
                {
                    end  = mid1 - 1;
                }
                else if (x < array[mid2])
                {
                    start = mid1 + 1;
                    end = mid2 - 1;
                }
                else
                {
                    start = mid2 + 1;
                }
            }
            return false;
        }

        public static bool Tenary( int [] array, int x)
        {
            static bool TenarySearch(int[] array, int start, int end, int x)
            {
                int div = (end - start) / 3;
                int mid1 = start + div;
                int mid2 = end - div;

                

                if (start > end) {return false;}

                else if (x == array[mid1] || x == array[mid2]) {return true;}               

                else if (x < array[mid1]) {return TenarySearch(array, start, mid1 - 1, x);}

                else if (x < array[mid2]) {return TenarySearch(array, mid1 + 1, mid2 - 1, x);}

                else {return TenarySearch(array, mid2 + 1, end, x);}
            }

            return TenarySearch(array, 0, array.Length - 1, x);
        }
    }


    class Util
    {
        public static void PrintArray( int[] array )
        {
            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        public static void PrintArray( double[] array )
        {
            Console.WriteLine("[" + string.Join(", ", array) + "]");
        }

        public static string Repeat(string str, int num)
        {
            string rep = "";

            for (int i = 0; i < num; i++)
            {
                rep += str;
            }

            return rep;
        }
    }
}