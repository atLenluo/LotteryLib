using LotteryLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTest {
    class Program {
        static void Main(string[] args) {
            var parser = new CodeParser();
//            var list = parser.Parse("D:\\360极速浏览器下载\\摩登挂机软件\\OpenCode\\TXFFC.txt");

            var list = new List<CodeData>();
            CodeData data;
            data.issue = "";
            data.codes = new char[]{'8','4','8','4','8'};
            list.Add(data);

            var strategy = new CodeStrategy();

            var retCode = strategy.LeftMidRightRandomHalf(list, 0);
            foreach (var item in retCode)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
