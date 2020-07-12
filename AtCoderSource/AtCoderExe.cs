using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderSource
{
    class AtCoderExe
    {
        /// <summary>
        /// プログラムの実行用
        /// 検証用に戻り値の種類を指定
        /// exeCategoryにAtCoderCategoryを指定
        /// exeQuestionに各種カテゴリ内の問題名を指定
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    //戻り値の型を指定
        //    string exeReturn = exeReturnClassification.INT;

        //    //AtCoderのカテゴリ？を指定
        //    string exeCategory = AtCoderCategory.BeginnersSelection;

        //    //AtCoderの問題名を指定
        //    string exeQuestion = BeginnersSelection.ABC085B;

        //    answer result;

        //    result = AtCoderCategorySelect(exeCategory, exeQuestion);

        //    outputResult(result, exeReturn);

        //}

        /// <summary>
        /// 結果を表示するためのメソッド
        /// 結果がStringだったりIntだったりするため判定して表示する
        /// </summary>
        /// <param name="output"></param>
        /// <param name="exeReturn"></param>
        static void outputResult(answer output, string exeReturn)
        {
            exeReturnClassification exeReturnClassification = new exeReturnClassification();

            if (output.eFlg) { Console.WriteLine(exeReturnClassification.ERROR); }

            switch (exeReturn)
            {
                case exeReturnClassification.INT:

                    Console.WriteLine(output.intAns);

                    break;

                case exeReturnClassification.STRING:

                    Console.WriteLine(output.strAns);

                    break;
            }

            Console.ReadKey();
        }

        /// <summary>
        /// カテゴリ？に応じて実行する問題を割り振るメソッド
        /// 多分問題数が増えると縦に長くなると思ってカテゴリ別にした
        /// </summary>
        /// <param name="category"></param>
        /// <param name="question"></param>
        /// <returns></returns>
        static answer AtCoderCategorySelect(string category, string question)
        {

            switch (category)
            {
                case AtCoderCategory.BeginnersSelection:

                    return BeginnersSelectionExe(question);

                default:

                    return ErrorExe();
            }

        }

        /// <summary>
        /// カテゴリがBeginnersSelectionの問題を割り振りして実行する
        /// </summary>
        /// <param name="exeQuestion"></param>
        /// <returns></returns>
        static answer BeginnersSelectionExe(string exeQuestion)
        {
            BSAnswers BSa = new BSAnswers();
            answer ans = new answer();

            switch (exeQuestion)
            {
                case BeginnersSelection.ABC086A:

                    ans.strAns = BSa.ABC086A(1,21);
                    break;

                case BeginnersSelection.ABC081A:

                    ans.intAns = BSa.ABC081A("0123415241");
                    break;

                case BeginnersSelection.ABC081B:

                    ans.intAns = BSa.ABC081B(6, "382253568 723152896 37802240 379425024 404894720 471526144");
                    break;

                case BeginnersSelection.ABC087B:

                    ans.intAns = BSa.ABC087B(30,40,50,6000);
                    break;

                case BeginnersSelection.ABC083B:

                    ans.intAns = BSa.ABC083B("100 4 16");
                    break;

                case BeginnersSelection.ABC088B:

                    ans.intAns = BSa.ABC088B(4, "20 18 2 18");
                    break;

                case BeginnersSelection.ABC085B:

                    ans.intAns = BSa.ABC085B(4);
                    break;

            }

            return ans;

        }

        /// <summary>
        /// なんか上手くいかなかったらエラーにする
        /// </summary>
        /// <returns></returns>
        static answer ErrorExe()
        {
            answer ans = new answer();
            ans.eFlg = true;

            return ans;
        }
    }

    /// <summary>
    /// AtCoderのカテゴリ名を記入する
    /// コンテスト名とかでもよかったかも
    /// </summary>
    public class AtCoderCategory
    {
        public const string BeginnersSelection = "BeginnersSelection";
    }

    /// <summary>
    /// 解答の種類をClassにまとめた
    /// </summary>
    public class answer
    {
        public int intAns;
        public string strAns;
        public bool eFlg = false;
    }

    public class exeReturnClassification
    {
        public const string INT = "int";
        public const string STRING = "string";
        public const string ARRAY = "array";
        public const string LIST = "list";
        public const string ERROR = "エラーだよ";
    }
           
}
