using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOCAC.BL
{
    class CLS_TIKFOLLOW
    {
        public StruFollow struFollow;
        public struct StruFollow
        {
            public int TickCount;
            public int CompCount;
            public int RequestCount;
            public int NoFlwCount;
            public int UnReadCount;
            public int ClsCount;
            public int Recved;
            public int UpdtFollow;
            public int UpdtColleg;
            public int UpdtOthrs;
            public int Esc1;
            public int Esc2;
            public int Esc3;
        }
    }
}
