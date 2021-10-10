using System;

namespace Task_NET01_2.Entity
{
    /// <summary>
    /// Template quadratic matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class QuadraticMatrix<T>
    {
        public QuadraticMatrix(int size)
        {
            Size = size;
        }
        /// <summary>
        /// Indexer for quadratic matrix
        /// </summary>
        /// <param name="i">row</param>
        /// <param name="j">column</param>
        /// <exception cref="System.IndexOutOfRangeException">
        ///  <paramref name="i" /> must be &gt 0 but &lt <see cref="_order"/>
        ///  <paramref name="j" /> must be &gt 0 but &lt <see cref="_order"/>
        /// </exception>
        /// <returns></returns>
        public T this[int i, int j]
        {
            get
            {
                if (_order <= i || _order <= j || i < 0 || j < 0)
                {
                    throw new IndexOutOfRangeException("Index lower 0 either bigger row or column length");
                }

                return Matrix[i * _order + j];
            }
            set
            {
                CheckSetIndexes(i, j);

                if (!Matrix[i * _order + j].Equals(value))
                {
                    NotifyChange?.Invoke(new ChangeEventArgs<T>(i, j, Matrix[i * _order + j]));
                }

                Matrix[i * _order + j] = value;
            }
        }
        protected virtual void CheckSetIndexes(int rowIndex, int colIndex)
        {
            if (_order <= rowIndex || _order <= colIndex || rowIndex < 0 || colIndex < 0) 
            {
                throw new IndexOutOfRangeException("Index lower 0 either bigger row/column length");
            }
        }

        public delegate void ChangeHandler(ChangeEventArgs<T> e);
        public event ChangeHandler NotifyChange;
        protected int _order;
        private int _size;
        /// <summary>
        /// Size of quadratic matrix
        /// </summary>
        /// <exception cref="System.ArgumentException">
        ///  <paramref name="value" /> must be &gt 0 and sqrt return integer/>
        /// </exception>
        public int Size 
        {
            get
            {
                return _size;
            }
            private set
            {
                if (value < 0 || Math.Sqrt(value) % 1 != 0)
                {
                    throw new ArgumentException("Invalid size for Quadratic matrix");
                }

                _order = (int)Math.Sqrt(value);
                _size = value;
                Matrix = new T[_size];
            }
        }
        public T[] Matrix { get; set; }
    }

    class ChangeEventArgs<T>
    {
        public int RowIndex { get; }
        public int ColumnIndex { get; }
        public T OldValue { get; }

        public ChangeEventArgs(int rowIndex, int columnIndex, T oldValue)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
            OldValue = oldValue;
        }
    }
}
