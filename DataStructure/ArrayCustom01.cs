using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataStructure
{
    class ArrayCustom01
    {
        private int[] data;  //动态本质是封装的静态数组搭配扩容的能力
        private int _N;       // 实际存储的数量
        /*
         * 数组有三个 数值
         * 1.容量 capacity ,从创建数组时,便预分配,基本不变,除非扩容或者缩小 多数用作比较判断是否溢出数组
         * 2.元素数量 count,实际就是 该数组中存放的元素个数,从1 开始 ,多用作比较 ,在数组插入种 和索引进行比较,作为移动参照物
         * 3. 索引 index, 元素移动的指标,从0开始,数组借助索引可以访问数组元素,且 索引多用来 在循环中 表示 数据移动变化方向
         */

        //传入容量capacity,构造分配一定空间的未分配的数组
        public ArrayCustom01(int capacity)
        {
            data = new int[capacity];
            _N = 0; // N就是Count,真实存放是字段,借助 属性Count进行访问和修改;提高安全性
                    // 因为 Count随着数据的修改而改变,但容量基本不变,故,容量不单独设置字段了;基本是只读即可
        }

        public ArrayCustom01() : this(10) { }
        #region // ______设置3个公开的属性,便于外界访问 容量,数量,是否为空________

        public int Capacity
        {
            get { return data.Length; }
        }

        public int Count
        {
            get { return _N; }
            set { _N = value; }
        }

        public bool IsEmpty
        {
            get { return _N == 0; }
        }
        #endregion
        // 对数组元素是增删改查
        /// <summary>
        /// 指定位置插入特定元素
        /// N 是数量,从1开始
        /// </summary>
        /// <param name="index">待插入位置</param>
        /// <param name="element">待插入元素</param>
        public void Insert(int index, int element)
        {
            if (index < 0 || index > this.Count)
                throw new ArgumentException("数组索引越界");
           

            if (this.Count == this.Capacity)
                throw new ArgumentException("数组已满");
          
            for (int i = this.Count-1; i >= index; i--)
                data[i + 1] = data[i];

            if (data != null) data[index] = element;
            this.Count++; 
           

        }
        /// <summary>
        /// 尾插,头插
        /// </summary>
        /// <param name="element"></param>
        public void AddLast(int element)
        {
            Insert(this.Count, element);
        }

        public void AddFirst(int element)
        {
            Insert(0, element);
        }
        // 编写一个索引器,进行查找数组元素
        public int this[int index]
        {
            get
            {
                if(0 <=index && index < this.Count)
                    return this.data[index];
                return -1; // 对异常处理的简写,返回-1 就是出错
            }
        }

        public void ReSet(int index, int newElement)
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentException("数组索引越界");

            data[index] = newElement;
        }
        //查看元素是否包含在数组中
        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (data[i] == element)
                    return true;
            }

            return false;
        }
        // 查看第一个匹配的索引
        public int IndexOf(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (data[i] == element)
                    return i;
            }

            return -1;
        }
        //删除索引index位置的元素
        public int RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentException("索引超出数组界限");

            int del = data[index];

            for (int i = index + 1; i <= this.Count - 1; i++)
                data[i - 1] = data[i];

            this.Count--;
            data[this.Count] = default(int);

            return del;
        }

        public void Remove(int element)
        {
            int index = IndexOf(element);
            if (index != -1)
                RemoveAt(index);
        }
        //重写ToString方法
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append(string.Format("ArrayCustom01:  count={0}    capacity={1}\n", this.Count, this.Capacity)); // N,  data.Length
            res.Append("[");
            //for循环不要判断if,增加复杂度
            for (int i = 0; i < this.Count-1; i++)
            {
                res.Append(data[i]);
                res.Append(", ");
            }
            res.Append(string.Format("{0}]", data[this.Count - 1]));
            return res.ToString();
        }
    }

    public class ArrayCustom01_Test
    {
        public ArrayCustom01_Test()
        {
            ArrayCustom01 arrayCustom01 = new ArrayCustom01(20);

            for (int i = 0; i < 10; i++)
            {
                arrayCustom01.AddLast(i);
            }

            Console.WriteLine(arrayCustom01); // 此处隐式为arrayCustom01.ToString()

            arrayCustom01.AddFirst(66);
            Console.WriteLine(arrayCustom01);

            arrayCustom01.Insert(2, 77);
            Console.WriteLine(arrayCustom01);

            Console.WriteLine(arrayCustom01[3]);
            arrayCustom01.ReSet(3, 1000);
            Console.WriteLine(arrayCustom01);
            Console.WriteLine(arrayCustom01[18]); // count外,capacity内
            Console.WriteLine(arrayCustom01[28]); // capacity外
            Console.WriteLine(arrayCustom01);
            //[66, 0, 77, 1000, 2, 3, 4, 5, 6, 7, 8, 9]
            arrayCustom01.RemoveAt(2);
            arrayCustom01.RemoveAt(0);
            arrayCustom01.Remove(1000);

            Console.WriteLine(arrayCustom01);
        }
    }
}
