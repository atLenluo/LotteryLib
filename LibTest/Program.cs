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
            var list = parser.Parse("D:\\360极速浏览器下载\\摩登挂机软件\\OpenCode\\YZ30SC.txt");

            var hotCode = CodeUtil.GetHotCode(list, 0, 30);
            var wenCode = CodeUtil.GetWenCode(list, 0, 30);
            var lenCode = CodeUtil.GetLenCode(list, 0, 30);

            PrintCodeList(hotCode);
            PrintCodeList(wenCode);
            PrintCodeList(lenCode);
        }

        private static void PrintCodeList(List<string> codeList) {
            foreach (var c in codeList) {
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}
