using Task_NET01_2.Exceptions;

namespace Task_NET01_2.Entity
{
    class DiagonalaMatrix<T> : QuadraticMatrix<T>
    {
        public DiagonalaMatrix(int lenth): base(lenth)
        { }
        protected override void CheckSetIterators(int i, int j)
        {
            if (Order < i || i < 0 || i != j)
            {
                throw new InvalidIndexException(
                    "error: Index lower 0 either bigger row/column length or you refering to not diagonal's element");
            }
        }
    }
}
