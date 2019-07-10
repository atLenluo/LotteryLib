using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryLib {
    /// <summary>
    /// 开奖记录数据
    /// </summary>
    public struct CodeData {
        /// <summary>
        /// 期号
        /// </summary>
        public string issue;
        /// <summary>
        /// 开奖号
        /// </summary>
        public char[] codes;
    }

}
