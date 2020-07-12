using System;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderSource
{
    class problem
    {
        /// <summary>
        /// int型の貼り付け用エントリポイント
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int output = 0;

            //標準入力を受け取る
            int input1 = int.Parse(Console.ReadLine());
            //string input1 = Console.ReadLine();

            //問題を実行する
            output = ABC085B(input1);

            //答えを表示する
            Console.WriteLine(output);

        }
        static int ABC085B(int mochiNum)
        {
            List<int> mochiList = new List<int>();

            for (int i = 0; i < mochiNum; i++)
            {
                mochiList.Add(int.Parse(Console.ReadLine()));
            }

            //同じ大きさだけ排除すればOK
            return mochiList.Distinct().Count();
        }
    }
}
