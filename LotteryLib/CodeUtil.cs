using System;
using System.Collections.Generic;

namespace LotteryLib {
    /// <summary>
    /// 号码统计工具
    /// </summary>
    public static class CodeUtil {
        /// <summary>
        /// 获取热号，大于等于概率1.5倍
        /// </summary>
        /// <param name="list">开奖记录</param>
        /// <param name="pos">位置</param>
        /// <param name="count">统计期数</param>
        /// <returns></returns>
        public static List<string> GetHotCode(IList<CodeData> list, int pos, int count) {
            var hotCode = new List<string>();
            var nums = GetAppearCount(list, pos, count);
            float times = count / 10.0f * 1.5f;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] >= times) {
                    hotCode.Add(i.ToString());
                }
            }

            return hotCode;
        }
        /// <summary>
        /// 获取温号
        /// </summary>
        /// <param name="list">开奖记录</param>
        /// <param name="pos">位置</param>
        /// <param name="count">统计期数</param>
        /// <returns></returns>
        public static List<string> GetWenCode(IList<CodeData> list, int pos, int count) {
            var wenCode = new List<string>();
            var nums = GetAppearCount(list, pos, count);
            float minTimes = count / 10.0f * 0.5f;
            float maxTimes = count / 10.0f * 1.5f;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] < maxTimes && nums[i] > minTimes) {
                    wenCode.Add(i.ToString());
                }
            }

            return wenCode;
        }
        /// <summary>
        /// 获取冷号，小于等于概率0.5倍
        /// </summary>
        /// <param name="list">开奖记录</param>
        /// <param name="pos">位置</param>
        /// <param name="count">统计期数</param>
        /// <returns></returns>
        public static List<string> GetLenCode(IList<CodeData> list, int pos, int count) {
            var lenCode = new List<string>();
            var nums = GetAppearCount(list, pos, count);
            float times = count / 10.0f * 0.5f;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] <= times) {
                    lenCode.Add(i.ToString());
                }
            }

            return lenCode;

        }

        /// <summary>
        /// 统计出现次数
        /// </summary>
        /// <param name="list">历史记录</param>
        /// <param name="pos">位置</param>
        /// <param name="count">统计期数</param>
        /// <returns></returns>
        public static int[] GetAppearCount(IList<CodeData> list, int pos, int count) {
            var appearCounts = new int[10];
            for (int i = 0; i < count && i < list.Count; i++) {
                var num = Convert.ToInt32(list[i].codes[pos].ToString());
                appearCounts[num]++;
            }
            return appearCounts;
        }

        /// <summary>
        /// 出现概率
        /// </summary>
        /// <returns></returns>
        public static float[] GetAppearRate(IList<CodeData> list, int pos, int count) {
            var counts = GetAppearCount(list, pos, count);
            var rates = new float[10];
            for (int i = 0; i < rates.Length; i++) {
                rates[i] = counts[i] * 1.0f / count;
            }

            return rates;
        }

    }
}
