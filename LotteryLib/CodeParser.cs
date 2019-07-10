using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryLib {
    /// <summary>
    /// 解析各种彩种的开奖记录
    /// </summary>
    public class CodeParser {

        delegate List<CodeData> ParseMethod(string filePath, int len);

        private Dictionary<string, ParseMethod> parseMethodDic = new Dictionary<string,ParseMethod>();

        public CodeParser() {
            parseMethodDic.Add("TXFFC", ParseBySplitTab);
            parseMethodDic.Add("YZFFC", ParseBySplitTab);
            parseMethodDic.Add("YZ30SC", ParseBySplitTab);
        }

        private List<CodeData> ParseBySplitTab(string filePath, int len) {
            var task = new Task<List<CodeData>>(delegate() {
                var dataList = new List<CodeData>();
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(stream);
                string line = null;
                while ((line = reader.ReadLine()) != null) {
                    string[] str = line.Split('\t');
                    if (str.Length == 2) {
                        CodeData data;
                        data.issue = str[0];
                        data.codes = str[1].ToCharArray();
                        dataList.Add(data);
                    }
                    if (len > 0 && dataList.Count >= len) {
                        break;
                    }
                }
                stream.Close();
                reader.Close();
                return dataList;
            });
            task.Start();
            task.Wait();
            return task.Result;
        }

        private List<CodeData> ParseBySpace(string filePath, int len) {
            var task = new Task<List<CodeData>>(delegate() {
                var dataList = new List<CodeData>();
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(stream);
                string line = null;
                while ((line = reader.ReadLine()) != null) {
                    string[] str = line.Split(' ');
                    if (str.Length == 2) {
                        CodeData data;
                        data.issue = str[0];
                        data.codes = str[1].ToCharArray();
                        dataList.Add(data);
                    }
                    if (len > 0 && dataList.Count >= len) {
                        break;
                    }
                }
                stream.Close();
                reader.Close();
                return dataList;
            });
            task.Start();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// 解析开奖记录
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="len">解析的期数，默认全部解析</param>
        /// <returns></returns>
        public List<CodeData> Parse(string filePath, int len = -1) {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            ParseMethod method = null;
            if (parseMethodDic.TryGetValue(fileName, out method)) {
                return method(filePath, len);
            } else {
                return null;
            }
        }
    }
}
