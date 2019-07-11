using LotteryLib;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibTest {

    class Program {
        static void Main(string[] args) {
            var parser = new CodeParser();
            var list = parser.Parse("D:\\360极速浏览器下载\\摩登挂机软件\\OpenCode\\TXFFC.txt");

//            var list = new List<CodeData>();
//            CodeData data;
//            data.issue = "";
//            data.codes = new char[]{'8','4','8','4','8'};
//            list.Add(data);
            var strategy = new CodeStrategy();
            for (int i = 0; i < 10; i++) {
                var retCode = strategy.UniformRandom(list, 0);
                for (int j = 0; j < retCode.Count; j++) {
                    Console.Write(retCode[j] + " ");
                }
                Console.WriteLine();
            }

//            var random = new Random(Guid.NewGuid().GetHashCode());
//            for (int i = 0; i < 10; i++) {
//                Console.WriteLine(random.Next(10));
//            }

        }
    }
}
