using System;
using System.Collections;
using System.Collections.Generic;

namespace StackMenu
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly int _initialCapacity=2;
        private T[] _elements;

        public Stack()
        {
            this._elements = new T[_initialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this._elements.Length)
            {
                Expand();
            }
            this._elements[this.Count] = item;
            this.Count++;
        }
        
        public T this[int index]
        {
            get
            {
                if (index<0||index>=this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this._elements[this.Count - index - 1];
            }
        }
        
        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        
            T element = this._elements[this.Count - 1];
            this._elements[this.Count - 1] = default(T);
            this.Count--;
            return element;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this._elements[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => this.GetEnumerator();
        
        private void Expand()
        {
            var newArray = new T[this._elements.Length * 2];
            for (int i = 0; i < _elements.Length;i++)
            {
                newArray[i] = _elements[i];
            }
            this._elements = newArray;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}