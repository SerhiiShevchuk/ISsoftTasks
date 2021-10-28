using System;
using Task_NET01_2.Entity;

namespace Task_NET01_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalaMatrix<int> diagonalaMatrix = new DiagonalaMatrix<int>(25);

            diagonalaMatrix.NotifyChange += (e) => {
                Console.WriteLine($"Old value: [{e.RowIndex}, {e.ColumnIndex}] = {e.OldValue}");
            };
        }
    }
}
