using System;
using Task_NET01_2.Exceptions;

namespace Task_NET01_2.Entity
{
    class QuadraticMatrix<T>
    {
        public QuadraticMatrix(int lenth)
        {
            if (lenth < 0 || Math.Sqrt(lenth) % 1 != 0) {
                throw new InvalidMatrixException("Invalid lenth for Quadratic matrix");
            }

            Order = (int)Math.Sqrt(lenth);
            Matrix = new T[lenth];
        }
        public T this[int i, int j]
        {
            get
            {
                if (Order <= i || Order <= j || i < 0 || j < 0)  {
                    throw new InvalidIndexException("error: Index lower 0 either bigger row or column length");
                }

                return Matrix[i * Order + j];
            }
            set
            {
                CheckSetIterators(i, j);

                if (!Matrix[i * Order + j].Equals(value)) {
                    NotifyChange?.Invoke(new ChangeEventArgs<T>(i, j, Matrix[i * Order + j]));
                }

                Matrix[i * Order + j] = value;
            }
        }
        protected virtual void CheckSetIterators(int rowIndex, int colIndex)
        {
            if (Order <= rowIndex || Order <= colIndex || rowIndex < 0 || colIndex < 0)  {
                throw new InvalidIndexException("error: Index lower 0 either bigger row/column length");
            }
        }

        public delegate void ChangeHandler(ChangeEventArgs<T> e);
        public event ChangeHandler NotifyChange;
        public T[] Matrix { get; set; }
        public int Order { get; }
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
