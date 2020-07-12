using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderSource
{
    /// <summary>
    /// 問題の集合
    /// </summary>
    public class BeginnersSelection
    {
        public const string ABC086A = "ABC086A";
        public const string ABC081A = "ABC081A";
        public const string ABC081B = "ABC081B";
        public const string ABC087B = "ABC087B";
        public const string ABC083B = "ABC083B";
        public const string ABC088B = "ABC088B";
        public const string ABC085B = "ABC085B";

    }

    /// <summary>
    /// BeginnersSelectionの各種問題の実装
    /// </summary>
    public class BSAnswers
    {
        /// <summary>
        /// aとbの積が偶数か奇数か判定
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>積が奇数なら Odd と、偶数なら Even と出力せよ。</returns>
        public string ABC086A(int a, int b)
        {
            return (a * b % 2 == 0) ? "Even" : "Odd";
        }

        /// <summary>
        /// ビー玉が置かれるマスの数を返す
        /// </summary>
        /// <param name="a"></param>
        /// <example>101 → 2</example>
        /// <returns></returns>
        public int ABC081A(string number)
        {
            int count = 0;

            foreach(char a in number) {
                //CHAR型は「'」でいける
                if (a == '1') { count += 1; }
            }

            return count;
        }

        /// <summary>
        /// 入力された整数群の全ての要素を2で割っていって、一つでも奇数になったらOUT
        /// ループさせてその回数を出力する
        /// </summary>
        /// <param name="count"></param>
        /// <param name="numbers"></param>
        /// <example>8 12 40 → 3</example>
        /// <returns></returns>
        public int ABC081B(int count, string numbers)
        {
            List<int> targetList = new List<int>(); 
            int resultCount = 0;

            //LIstの中身の型を全て変換できるConvertAllが便利
            targetList = numbers.Split(' ').ToList().ConvertAll(int.Parse);

            while (targetList.All(e => e % 2 == 0))
            {
                resultCount += 1;
                //Selectは非破壊的っぽい
                targetList = targetList.Select(e => e / 2).ToList();
            }

            return resultCount;

        }

        /// <summary>
        /// 500円、100円、50円の組み合わせで指定した合計値になるものが何種類あるか？
        /// </summary>
        /// <param name="fiveHundred"></param>
        /// <param name="hundred"></param>
        /// <param name="fifty"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int ABC087B(int fiveHundred, int hundred, int fifty, int sum)
        {
            int countResult = 0;

            //500円のループ
            for (int i = 0; i <= fiveHundred; i++)
            {
                //100円のループ
                for (int j = 0; j <= hundred; j++)
                {
                    //50円のループ
                    for (int k = 0; k <= fifty; k++)
                    {
                        if(500 * i + 100 * j + 50 * k == sum)
                        {
                            countResult += 1;
                        }
                    }
                }
            }

            return countResult;

        }

        /// <summary>
        /// 1以上N以下の整数のうち10進法での各桁の和がA以上B以下であるものの総和
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int ABC083B(string input)
        {
            List<int> inputList = input.Split(' ').ToList().ConvertAll(int.Parse);
            int compareNum = 0;
            int countResult = 0;

            for (int i = 0; i <= inputList.ElementAt(0); i++)
            {
                if(i >= 10)
                {
                    //比較対象の初期化が必要
                    compareNum = 0;

                    foreach (char c in i.ToString())
                    {
                        compareNum += int.Parse(c.ToString());
                    }

                }
                else
                {
                    compareNum = i;
                }

                if(inputList.ElementAt(1) <= compareNum
                   && compareNum <= inputList.ElementAt(2))
                {
                    //もとの数を足し合わせる
                    countResult += i;
                }

            }

            return countResult;
        }

        public int ABC088B(int cardNum, string cardArray)
        {
            List<int> cardList = new List<int>();
            cardList = cardArray.Split(' ').ToList().ConvertAll(int.Parse);

            var sortedList = cardList.OrderByDescending(x => x).ToList();

            //Aliceのカードはカードリスト（降順にソート済）の中の0,2,4･･･番目のカード
            var AliceCards = sortedList.Where((num, index) => index % 2 == 0).ToList();
            
            //Bobのカードはカードリスト（降順にソート済）の中の1,3,5･･･番目のカード
            var BobCards = sortedList.Where((num, index) => index % 2 == 1).ToList();

            return AliceCards.Sum() - BobCards.Sum();
        }

        /// <summary>
        /// 鏡餅の段数
        /// </summary>
        /// <example>4枚[10,8,8,6]→3段</example>
        /// <example>3枚[15,15,15]→1段</example>
        /// <param name="mochiNum"></param>
        /// <returns></returns>
        public int ABC085B(int mochiNum)
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
