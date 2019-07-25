using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LotteryLib {
    /// <summary>
    /// 出号策略
    /// </summary>
    public class CodeStrategy {
        private readonly Random _random = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// 冷热温各随机自定义胆码
        /// </summary>
        /// <param name="list">历史记录</param>
        /// <param name="pos">位置</param>
        /// <param name="count">统计期数</param>
        /// <param name="num">胆码数量</param>
        /// <returns></returns>
        public List<string> LenHotWenRandomCustom(IList<CodeData> list, int pos, int count, int num) {
            var hotCode = CodeUtil.GetHotCode(list, pos, count);
            var wenCode = CodeUtil.GetWenCode(list, pos, count);
            var lenCode = CodeUtil.GetLenCode(list, pos, count);

            var hotNum = (int) Math.Round(hotCode.Count / 10.0f * num);
            var wenNum = (int) Math.Round(wenCode.Count / 10.0f * num);
            var lenNum = (int) Math.Round(lenCode.Count / 10.0f * num);

            var hotGetNum = 0;
            var wenGetNum = 0;
            var lenGetNum = 0;

            var retCode = new List<string>();
            while (retCode.Count < num) {
                var index = 0;
                if (hotGetNum < hotNum) {
                    index = _random.Next(hotCode.Count);
                    retCode.Add(hotCode[index]);
                    hotCode.RemoveAt(index);
                    hotGetNum++;
                }

                if (wenGetNum < wenNum && retCode.Count < num) {
                    index = _random.Next(wenCode.Count);
                    retCode.Add(wenCode[index]);
                    wenCode.RemoveAt(index);
                    wenGetNum++;
                }

                if (lenGetNum < lenNum && retCode.Count < num) {
                    index = _random.Next(lenCode.Count);
                    retCode.Add(lenCode[index]);
                    lenCode.RemoveAt(index);
                    lenGetNum++;
                }
            }

            return retCode;
        }

        /// <summary>
        /// 上期号码为分割线，左边随机一半+上期号码+右边随机一半
        /// </summary>
        /// <param name="list">历史记录</param>
        /// <param name="pos">位置</param>
        public List<string> LeftMidRightRandomHalf(IList<CodeData> list, int pos) {
            var retCode = new List<string>();
            var midCode = list[0].codes[pos].ToString();
            retCode.Add(midCode);

            var mid = Convert.ToInt32(midCode);

            var leftCode = new List<string>();
            for (int i = 0; i < mid; i++) {
                leftCode.Add(i.ToString());
            }

            var rightCode = new List<string>();
            for (int i = mid + 1; i < 10; i++) {
                rightCode.Add(i.ToString());
            }

            var leftNum = (int) Math.Ceiling(leftCode.Count / 2.0f);
            var rightNum = (int) Math.Ceiling(rightCode.Count / 2.0f);
            int leftGetNum = 0;
            int rightGetNum = 0;
            int index = 0;
            while (retCode.Count < 5) {
                if (leftGetNum < leftNum) {
                    index = _random.Next(leftCode.Count);
                    retCode.Add(leftCode[index]);
                    leftCode.RemoveAt(index);
                    leftGetNum++;
                }

                if (rightGetNum < rightNum && retCode.Count < 5) {
                    index = _random.Next(rightCode.Count);
                    retCode.Add(rightCode[index]);
                    rightCode.RemoveAt(index);
                    rightGetNum++;
                }
            }

            return retCode;
        }

        /// <summary>
        /// 均匀随机胆码
        /// </summary>
        public List<string> UniformRandom(IList<CodeData> list, int pos) {
            var smallOddCode  = new List<string>(new []{"1", "3"});
            var smallEvenCode = new List<string>(new []{"0", "2", "4"});
            var bigOddCode    = new List<string>(new []{"5", "7", "9"});
            var bigEvenCode   = new List<string>(new []{"6", "8"});

            var retCode = new List<string>();

            smallOddCode.RemoveAt(_random.Next(smallOddCode.Count));
            smallEvenCode.RemoveAt(_random.Next(smallEvenCode.Count));
            bigOddCode.RemoveAt(_random.Next(bigOddCode.Count));
            bigEvenCode.RemoveAt(_random.Next(bigEvenCode.Count));
            
            retCode.AddRange(smallOddCode);
            retCode.AddRange(smallEvenCode);
            retCode.AddRange(bigOddCode);
            retCode.AddRange(bigEvenCode);

            return retCode;
        }
    }
}
