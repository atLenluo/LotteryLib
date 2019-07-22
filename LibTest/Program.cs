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

            var counts = new int[] { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300};
            for (int i = 0; i < counts.Length; i++) {
                var appears = CodeUtil.GetAppearRate(list, 0, counts[i]);
                Console.Write(counts[i] + "：  ");
                for (int j = 0; j < appears.Length; j++) {
                    Console.Write(j + "：" + appears[j].ToString("F2") + ", ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
