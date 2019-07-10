﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryLib {
    /// <summary>
    /// 出号策略
    /// </summary>
    public class CodeStrategy {

        private Random random = new Random(new Guid().GetHashCode());

        /// <summary>
        /// 冷热温各随机一半
        /// </summary>
        /// <param name="list">历史记录</param>
        /// <param name="pos">位置</param>
        /// <param name="count">统计期数</param>
        /// <returns></returns>
        public List<string> LenHotWenRandomHalf(IList<CodeData>list, int pos, int count) {
            var hotCode = CodeUtil.GetHotCode(list, pos, count);
            var wenCode = CodeUtil.GetWenCode(list, pos, count);
            var lenCode = CodeUtil.GetLenCode(list, pos, count);

            var hotNum = (int)Math.Ceiling(hotCode.Count / 2.0f);
            var wenNum = (int)Math.Ceiling(wenCode.Count / 2.0f);
            var lenNum = (int)Math.Ceiling(lenCode.Count / 2.0f);

            var retCode = new List<string>();
            int index = 0;
            for (var i = 0; i < hotNum; i++) {
                index = random.Next(hotCode.Count);
                retCode.Add(hotCode[index]);
                hotCode.RemoveAt(index);
            }

            for (var i = 0; i < wenNum; i++) {
                index = random.Next(wenCode.Count);
                retCode.Add(wenCode[index]);
                wenCode.RemoveAt(index);
            }

            for (var i = 0; i < lenNum; i++) {
                index = random.Next(lenCode.Count);
                retCode.Add(lenCode[index]);
                lenCode.RemoveAt(index);
            }

            while (retCode.Count > 5) {
                retCode.RemoveAt(retCode.Count - 1);
            }

            return retCode;
        }

        /// <summary>
        /// 上期号码为分割线，左边随机一半+上期号码+右边随机一半
        /// </summary>
        /// <param name="list">历史记录</param>
        /// <param name="pos">位置</param>
        /// <returns></returns>
        public List<string> LeftMidRightRandomHalf(IList<CodeData>list, int pos)
        {
            var retCode = new List<string>();
            var midCode = list[0].codes[pos].ToString();
            retCode.Add(midCode);

            var mid = Convert.ToInt32(midCode);

            var leftCode = new List<string>();
            for (int i = 0; i < mid; i++)
            {
                leftCode.Add(i.ToString());
            }

            var rightCode = new List<string>();
            for (int i = mid + 1; i < 10; i++)
            {
                rightCode.Add(i.ToString());
            }

            var leftNum = (int) Math.Ceiling(leftCode.Count / 2.0f);
            var rightNum = (int) Math.Ceiling(rightCode.Count / 2.0f);

            int index = 0;
            for (var i = 0; i < leftNum; i++)
            {
                index = random.Next(leftCode.Count);
                retCode.Add(leftCode[index].ToString());
                leftCode.RemoveAt(index);
            }

            for (var i = 0; i < rightNum; i++)
            {
                index = random.Next(rightCode.Count);
                retCode.Add(rightCode[index].ToString());
                rightCode.RemoveAt(index);
            }

            while (retCode.Count > 5) {
                retCode.RemoveAt(retCode.Count - 1);
            }

            return retCode;
        }
    }
}