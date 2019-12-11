using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaGenerics
{

    public class GenericList<T>
    {
        private T[] elements;

        private int size;

        private int currentElemIdx = 0;

        public GenericList(int size)
        {
            this.currentElemIdx = 0;
            this.size = size;
            this.elements = new T[size];
        }

        public void Add(T value)
        {
            if (this.currentElemIdx == this.size)
            {
                Console.WriteLine("Size full");
            }
            this.elements[currentElemIdx] = value;
            this.currentElemIdx++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.currentElemIdx)
                {
                    throw new IndexOutOfRangeException("Index is not in range!");

                }
                return this.elements[index];

            }
            set
            {
                this.elements[index] = value;


            }
        }

        public T GetById(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is not in range!");
            }
            return this.elements[index];
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > this.currentElemIdx)
                throw new IndexOutOfRangeException("Index is not in range!");

            this.currentElemIdx++;


            Array.Copy(this.elements, index, this.elements, index + 1, this.currentElemIdx - index - 1);

            this.elements[index] = element;
        }

        public T Min()
        {
            return this.MinMax(false);
        }

        public T Max()
        {
            return this.MinMax(true);
        }
        private T MinMax(bool value)
        {
            T max = this.elements[0];

            for (int i = 1; i < this.currentElemIdx; i++)
                if (value ? (max < (dynamic)this.elements[i]) : (max > (dynamic)this.elements[i]))
                    max = this.elements[i];

            return max;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.currentElemIdx)
                throw new IndexOutOfRangeException("Index is out of range!");

            this.currentElemIdx--;


            Array.Copy(this.elements, index + 1, this.elements, index, this.currentElemIdx - index);

            this.elements[this.currentElemIdx] = default(T);
        }
        public bool Contains(T element)
        {
            return this.elements.Contains(element);
        }

        public int IndexOf(T element)
        {
            return Array.IndexOf(this.elements, element);
        }

        public void Clear()
        {
            this.currentElemIdx = 0;
            this.size = 1;

            this.elements = new T[this.size];
        }
        public override string ToString()
        {
            if (this.currentElemIdx == 0)
                return "Empty list!";

            StringBuilder result = new StringBuilder();
            result.Append("Element(s): ");

            for (int i = 0; i < this.currentElemIdx; i++)
            {
                result.AppendFormat("{0}", this.elements[i].ToString());
            }

            return result.ToString();
        }

    }
}
    