using LotteryLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTest {

    class Program {
        static void Main(string[] args) {
            var parser = new CodeParser();
            var list = parser.Parse("D:\\360极速浏览器下载\\摩登挂机软件\\OpenCode\\YZ30SC.txt");

            var strategy = new CodeStrategy();
            for (int i = 0; i < 5; i++) {
                PrintCodeList(strategy.UniformRandom(list, i));
            }
            
        }

        private static void PrintCodeList(List<string> codeList) {
            foreach (var c in codeList) {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
