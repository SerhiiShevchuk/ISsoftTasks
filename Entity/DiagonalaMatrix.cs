using System;

namespace Task_NET01_2.Entity
{
    class DiagonalaMatrix<T> : SquareMatrix<T>
    {
        public DiagonalaMatrix(int rank)
        {
            Rank = rank;
            Matrix = new T[rank];
        }

        public override T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                if (i != j)
                {
                    return default(T);
                }

                return Matrix[i];
            }
            set
            {
                CheckIndexes(i, j);
                if (i != j)
                {
                    throw new ArgumentException(
                   "You refering to not diagonal's element");
                }

                if (!Matrix[i].Equals(value))
                {
                    InvokeNotify(new ChangeEventArgs<T>(i, j, Matrix[i]));
                }

                Matrix[i] = value;
            }
        }
    }
}
