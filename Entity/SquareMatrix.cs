using System;

namespace Task_NET01_2.Entity
{
    /// <summary>
    /// Template quadratic matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class SquareMatrix<T>
    {
        protected int _rank;
        public int Rank
        {
            get
            {
                return _rank;
            }
            protected set
            {
                const int SIZE = 1;
                if (value < SIZE)
                {
                    throw new Exception($"Rank lower {SIZE}");
                }
            }
        }
        protected T[] Matrix { get; set; }
        public event ChangeHandler NotifyChange;
        public delegate void ChangeHandler(ChangeEventArgs<T> e);

        public SquareMatrix() { }
        public SquareMatrix(int rank)
        {
            Rank = rank;
            Matrix = new T[_rank * _rank];
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
        public virtual T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);

                return Matrix[i * _rank + j];
            }
            set
            {
                CheckIndexes(i, j);

                if (!Matrix[i * _rank + j].Equals(value))
                {
                    InvokeNotify(new ChangeEventArgs<T>(i, j, Matrix[i * _rank + j]));
                }

                Matrix[i * _rank + j] = value;
            }
        }
        protected virtual void CheckIndexes(int rowIndex, int colIndex)
        {
            if (_rank <= rowIndex || _rank <= colIndex || rowIndex < 0 || colIndex < 0) 
            {
                throw new IndexOutOfRangeException("Index lower 0 either bigger row/column length");
            }
        }
        protected void InvokeNotify(ChangeEventArgs<T> changeEventArgs)
        {
            NotifyChange?.Invoke(changeEventArgs);
        }
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