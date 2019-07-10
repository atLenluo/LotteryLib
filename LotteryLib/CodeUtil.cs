using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var nums = new int[10];
            for (int i = 0; i < count; i++) {
                int c = int.Parse(list[i].codes[pos].ToString());
                nums[c]++;
            }
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
            var nums = new int[10];
            for (int i = 0; i < count; i++) {
                int c = int.Parse(list[i].codes[pos].ToString());
                nums[c]++;
            }
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
            var nums = new int[10];
            for (int i = 0; i < count; i++) {
                int c = int.Parse(list[i].codes[pos].ToString());
                nums[c]++;
            }
            float times = count / 10.0f * 0.5f;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] <= times) {
                    lenCode.Add(i.ToString());
                }
            }

            return lenCode;

        }

    }
}
