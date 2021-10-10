using System;

namespace Task_NET01_2.Entity
{
    class DiagonalaMatrix<T> : QuadraticMatrix<T>
    {
        public DiagonalaMatrix(int lenth) : base(lenth)
        { }
        protected override void CheckSetIndexes(int i, int j)
        {
            if (_order < i || i < 0 || i != j)
            {
                throw new ArgumentException(
                    "Index lower 0 either bigger row/column length or you refering to not diagonal's element");
            }
        }
    }
}
