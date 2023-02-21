using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class ArrayDefault
    {
        internal ArrayDefault()
        {
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i;
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
            //此示例说明 动态数组ArrayList 不会报出 数组越界异常的错误,
            ArrayList arrayList = new ArrayList(10);
            for (int i = 0; i < 15; i++)
            {
                arrayList.Add(i);
                Console.Write(arrayList[i] + " ");
            }

            Console.WriteLine();
            List<int> list = new List<int>(10);
            for (int i = 0; i < 15; i++)
            {
                list.Add(i);
                Console.Write(list[i] + " ");
            }
            Console.ReadKey();
        }
    }

   public class ArrayDefault_Test
   {
       public ArrayDefault_Test()
       {
           new ArrayDefault();
       }
   }
}
