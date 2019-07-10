using System;
using System.Collections.Generic;

namespace LotteryLib {
    /// <summary>
    /// 出号策略
    /// </summary>
    public class CodeStrategy {
        private Random random = new Random(new Guid().GetHashCode());

        /// <summary>
        /// 冷热温各随机取一半
        /// </summary>
        /// <param name="list">历史记录</param>
        /// <param name="pos">位置</param>
        /// <param name="count">统计期数</param>
        /// <returns></returns>
        public List<string> LenHotWenRandomHalf(IList<CodeData> list, int pos, int count) {
            var hotCode = CodeUtil.GetHotCode(list, pos, count);
            var wenCode = CodeUtil.GetWenCode(list, pos, count);
            var lenCode = CodeUtil.GetLenCode(list, pos, count);

            var hotNum = (int) Math.Ceiling(hotCode.Count / 2.0f);
            var wenNum = (int) Math.Ceiling(wenCode.Count / 2.0f);
            var lenNum = (int) Math.Ceiling(lenCode.Count / 2.0f);

            var hotGetNum = 0;
            var wenGetNum = 0;
            var lenGetNum = 0;

            var retCode = new List<string>();
            while (retCode.Count < 5) {
                var index = 0;
                if (hotGetNum < hotNum) {
                    index = random.Next(hotCode.Count);
                    retCode.Add(hotCode[index]);
                    hotCode.RemoveAt(index);
                    hotGetNum++;
                }

                if (wenGetNum < wenNum && retCode.Count < 5) {
                    index = random.Next(wenCode.Count);
                    retCode.Add(wenCode[index]);
                    wenCode.RemoveAt(index);
                    wenGetNum++;
                }

                if (lenGetNum < lenNum && retCode.Count < 5) {
                    index = random.Next(lenCode.Count);
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
        /// <returns></returns>
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
                    index = random.Next(leftCode.Count);
                    retCode.Add(leftCode[index]);
                    leftCode.RemoveAt(index);
                    leftGetNum++;
                }

                if (rightGetNum < rightNum && retCode.Count < 5) {
                    index = random.Next(rightCode.Count);
                    retCode.Add(rightCode[index]);
                    rightCode.RemoveAt(index);
                    rightGetNum++;
                }
            }

            return retCode;
        }
    }
}
