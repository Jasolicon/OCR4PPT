﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace KTDictSeg
{
    /// <summary>
    /// 内部使用的词性
    /// </summary>
    public enum T_INNER_POS
    {
        /// <summary>
        /// 形容词 形语素
        /// </summary>
        POS_D_A = 30,	//	形容词 形语素

        /// <summary>
        /// 区别词 区别语素
        /// </summary>
        POS_D_B = 29,	//	区别词 区别语素

        /// <summary>
        /// 连词 连语素
        /// </summary>
        POS_D_C = 28,	//	连词 连语素

        /// <summary>
        /// 副词 副语素
        /// </summary>
        POS_D_D = 27,	//	副词 副语素

        /// <summary>
        /// 叹词 叹语素
        /// </summary>
        POS_D_E = 26,	//	叹词 叹语素

        /// <summary>
        /// 方位词 方位语素
        /// </summary>
        POS_D_F = 25,	//	方位词 方位语素

        /// <summary>
        /// 成语
        /// </summary>
        POS_D_I = 24,	//	成语

        /// <summary>
        /// 习语
        /// </summary>
        POS_D_L = 23,	//	习语

        /// <summary>
        /// 数词 数语素
        /// </summary>
        POS_A_M = 22,	//	数词 数语素

        /// <summary>
        /// 数量词
        /// </summary>
        POS_D_MQ = 21,	//	数量词

        /// <summary>
        /// 名词 名语素
        /// </summary>
        POS_D_N = 20,	//	名词 名语素

        /// <summary>
        /// 拟声词
        /// </summary>
        POS_D_O = 19,	//	拟声词

        /// <summary>
        /// 介词
        /// </summary>
        POS_D_P = 18,	//	介词

        /// <summary>
        /// 量词 量语素
        /// </summary>
        POS_A_Q = 17,	//	量词 量语素

        /// <summary>
        /// 代词 代语素
        /// </summary>
        POS_D_R = 16,	//	代词 代语素

        /// <summary>
        /// 处所词
        /// </summary>
        POS_D_S = 15,	//	处所词

        /// <summary>
        /// 时间词
        /// </summary>
        POS_D_T = 14,	//	时间词

        /// <summary>
        /// 助词 助语素
        /// </summary>
        POS_D_U = 13,	//	助词 助语素

        /// <summary>
        /// 动词 动语素
        /// </summary>
        POS_D_V = 12,	//	动词 动语素

        /// <summary>
        /// 标点符号
        /// </summary>
        POS_D_W = 11,	//	标点符号

        /// <summary>
        /// 非语素字
        /// </summary>
        POS_D_X = 10,	//	非语素字

        /// <summary>
        /// 语气词 语气语素
        /// </summary>
        POS_D_Y = 9,	//	语气词 语气语素

        /// <summary>
        /// 状态词
        /// </summary>
        POS_D_Z = 8,	//	状态词

        /// <summary>
        /// 人名
        /// </summary>
        POS_A_NR = 7,	//	人名

        /// <summary>
        /// 地名
        /// </summary>
        POS_A_NS = 6,	//	地名

        /// <summary>
        /// 机构团体
        /// </summary>
        POS_A_NT = 5,	//	机构团体

        /// <summary>
        /// 外文字符
        /// </summary>
        POS_A_NX = 4,	//	外文字符

        /// <summary>
        /// 其他专名
        /// </summary>
        POS_A_NZ = 3,	//	其他专名

        /// <summary>
        /// 前接成分
        /// </summary>
        POS_D_H = 2,	//	前接成分

        /// <summary>
        /// 后接成分
        /// </summary>
        POS_D_K = 1,	//	后接成分

        /// <summary>
        /// 未知词性
        /// </summary>
        POS_UNK = 0,   //  未知词性

    }

    [Flags]
    public enum T_POS
    {
        /// <summary>
        /// 形容词 形语素
        /// </summary>
        POS_D_A	= 0x40000000,	//	形容词 形语素

        /// <summary>
        /// 区别词 区别语素
        /// </summary>
        POS_D_B	= 0x20000000,	//	区别词 区别语素

        /// <summary>
        /// 连词 连语素
        /// </summary>
        POS_D_C	= 0x10000000,	//	连词 连语素

        /// <summary>
        /// 副词 副语素
        /// </summary>
        POS_D_D	= 0x08000000,	//	副词 副语素

        /// <summary>
        /// 叹词 叹语素
        /// </summary>
        POS_D_E	= 0x04000000,	//	叹词 叹语素

        /// <summary>
        /// 方位词 方位语素
        /// </summary>
        POS_D_F	= 0x02000000,	//	方位词 方位语素

        /// <summary>
        /// 成语
        /// </summary>
        POS_D_I	= 0x01000000,	//	成语

        /// <summary>
        /// 习语
        /// </summary>
        POS_D_L	= 0x00800000,	//	习语

        /// <summary>
        /// 数词 数语素
        /// </summary>
        POS_A_M	= 0x00400000,	//	数词 数语素

        /// <summary>
        /// 数量词
        /// </summary>
        POS_D_MQ= 0x00200000,	//	数量词

        /// <summary>
        /// 名词 名语素
        /// </summary>
        POS_D_N	= 0x00100000,	//	名词 名语素

        /// <summary>
        /// 拟声词
        /// </summary>
        POS_D_O	= 0x00080000,	//	拟声词

        /// <summary>
        /// 介词
        /// </summary>
        POS_D_P	= 0x00040000,	//	介词

        /// <summary>
        /// 量词 量语素
        /// </summary>
        POS_A_Q	= 0x00020000,	//	量词 量语素

        /// <summary>
        /// 代词 代语素
        /// </summary>
        POS_D_R	= 0x00010000,	//	代词 代语素

        /// <summary>
        /// 处所词
        /// </summary>
        POS_D_S	= 0x00008000,	//	处所词

        /// <summary>
        /// 时间词
        /// </summary>
        POS_D_T	= 0x00004000,	//	时间词

        /// <summary>
        /// 助词 助语素
        /// </summary>
        POS_D_U	= 0x00002000,	//	助词 助语素

        /// <summary>
        /// 动词 动语素
        /// </summary>
        POS_D_V	= 0x00001000,	//	动词 动语素

        /// <summary>
        /// 标点符号
        /// </summary>
        POS_D_W	= 0x00000800,	//	标点符号

        /// <summary>
        /// 非语素字
        /// </summary>
        POS_D_X	= 0x00000400,	//	非语素字

        /// <summary>
        /// 语气词 语气语素
        /// </summary>
        POS_D_Y	= 0x00000200,	//	语气词 语气语素

        /// <summary>
        /// 状态词
        /// </summary>
        POS_D_Z	= 0x00000100,	//	状态词

        /// <summary>
        /// 人名
        /// </summary>
        POS_A_NR= 0x00000080,	//	人名

        /// <summary>
        /// 地名
        /// </summary>
        POS_A_NS= 0x00000040,	//	地名

        /// <summary>
        /// 机构团体
        /// </summary>
        POS_A_NT= 0x00000020,	//	机构团体

        /// <summary>
        /// 外文字符
        /// </summary>
        POS_A_NX= 0x00000010,	//	外文字符

        /// <summary>
        /// 其他专名
        /// </summary>
        POS_A_NZ= 0x00000008,	//	其他专名

        /// <summary>
        /// 前接成分
        /// </summary>
        POS_D_H	= 0x00000004,	//	前接成分

        /// <summary>
        /// 后接成分
        /// </summary>
        POS_D_K	= 0x00000002,	//	后接成分

        /// <summary>
        /// 未知词性
        /// </summary>
        POS_UNK = 0x00000000,   //  未知词性
    }

    /// <summary>
    /// 二元词性组合
    /// </summary>
    public class T_POSBin : IComparable
    {
        public T_INNER_POS m_Pos1;
        public T_INNER_POS m_Pos2;
        public int m_Count;
        int m_HashCode;

        public int HashCode
        {
            get
            {
                return m_HashCode;
            }
        }

        public T_POSBin(T_INNER_POS pos1, T_INNER_POS pos2)
        {
            m_Pos1 = pos1;
            m_Pos2 = pos2;
            m_HashCode = (int)pos1 * 64 + (int)pos2;
        }

        #region IComparable 成员

        public int CompareTo(object obj)
        {
            T_POSBin dest = (T_POSBin)obj;
            if (dest.m_Count == m_Count)
            {
                return 0;
            }
            else if (dest.m_Count > m_Count)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        #endregion
    }
            
    /// <sum= mary>
    /// 词性= 处理
    /// </summary>
    public class CPOS
    {
        Hashtable m_PosTable; //单词对应词性表
        Hashtable m_OneCharTable; //单字符词表


        public static T_INNER_POS GetInnerPos(T_POS pos)
        {
            switch (pos)
            {
                case T_POS.POS_D_A:	//	形容词 形语素
                    return T_INNER_POS.POS_D_A;

                case T_POS.POS_D_B:	//	区别词 区别语素
                    return T_INNER_POS.POS_D_B;

                case T_POS.POS_D_C:	//	连词 连语素
                    return T_INNER_POS.POS_D_C;

                case T_POS.POS_D_D:	//	副词 副语素
                    return T_INNER_POS.POS_D_D;

                case T_POS.POS_D_E:	//	叹词 叹语素
                    return T_INNER_POS.POS_D_E;

                case T_POS.POS_D_F:	//	方位词 方位语素
                    return T_INNER_POS.POS_D_F;

                case T_POS.POS_D_I:	//	成语
                    return T_INNER_POS.POS_D_I;

                case T_POS.POS_D_L:	//	习语
                    return T_INNER_POS.POS_D_L;

                case T_POS.POS_A_M:	//	数词 数语素
                    return T_INNER_POS.POS_A_M;

                case T_POS.POS_D_MQ:   //	数量词
                    return T_INNER_POS.POS_D_MQ;

                case T_POS.POS_D_N:	//	名词 名语素
                    return T_INNER_POS.POS_D_N;

                case T_POS.POS_D_O:	//	拟声词
                    return T_INNER_POS.POS_D_O;

                case T_POS.POS_D_P:	//	介词
                    return T_INNER_POS.POS_D_P;

                case T_POS.POS_A_Q:	//	量词 量语素
                    return T_INNER_POS.POS_A_Q;

                case T_POS.POS_D_R:	//	代词 代语素
                    return T_INNER_POS.POS_D_R;

                case T_POS.POS_D_S:	//	处所词
                    return T_INNER_POS.POS_D_S;

                case T_POS.POS_D_T:	//	时间词
                    return T_INNER_POS.POS_D_T;

                case T_POS.POS_D_U:	//	助词 助语素
                    return T_INNER_POS.POS_D_U;

                case T_POS.POS_D_V:	//	动词 动语素
                    return T_INNER_POS.POS_D_V;

                case T_POS.POS_D_W:	//	标点符号
                    return T_INNER_POS.POS_D_W;

                case T_POS.POS_D_X:	//	非语素字
                    return T_INNER_POS.POS_D_X;

                case T_POS.POS_D_Y:	//	语气词 语气语素
                    return T_INNER_POS.POS_D_Y;

                case T_POS.POS_D_Z:	//	状态词
                    return T_INNER_POS.POS_D_Z;

                case T_POS.POS_A_NR://	人名
                    return T_INNER_POS.POS_A_NR;

                case T_POS.POS_A_NS://	地名
                    return T_INNER_POS.POS_A_NS;

                case T_POS.POS_A_NT://	机构团体
                    return T_INNER_POS.POS_A_NT;

                case T_POS.POS_A_NX://	外文字符
                    return T_INNER_POS.POS_A_NX;

                case T_POS.POS_A_NZ://	其他专名
                    return T_INNER_POS.POS_A_NZ;

                case T_POS.POS_D_H:	//	前接成分
                    return T_INNER_POS.POS_D_H;

                case T_POS.POS_D_K:	//	后接成分
                    return T_INNER_POS.POS_D_K;

                case T_POS.POS_UNK://  未知词性
                    return T_INNER_POS.POS_UNK;

                default:
                    return T_INNER_POS.POS_UNK;
            }
        }

        static public String GetChsPos(T_POS pos)
        {
            switch (pos)
            {
                case T_POS.POS_D_A	:	//	形容词 形语素
                    return "形容词 形语素";

                case T_POS.POS_D_B:	//	区别词 区别语素
                    return "区别词 区别语素";

                case T_POS.POS_D_C:	//	连词 连语素
                    return "连词 连语素";

                case T_POS.POS_D_D:	//	副词 副语素
                    return "副词 副语素";

                case T_POS.POS_D_E:	//	叹词 叹语素
                    return "叹词 叹语素";

                case T_POS.POS_D_F:	//	方位词 方位语素
                    return "方位词 方位语素";

                case T_POS.POS_D_I:	//	成语
                    return "成语";

                case T_POS.POS_D_L:	//	习语
                    return "习语";

                case T_POS.POS_A_M:	//	数词 数语素
                    return "数词 数语素";

                case T_POS.POS_D_MQ:   //	数量词
                    return "数量词";

                case T_POS.POS_D_N:	//	名词 名语素
                    return "名词 名语素";

                case T_POS.POS_D_O:	//	拟声词
                    return "拟声词";

                case T_POS.POS_D_P:	//	介词
                    return "介词";

                case T_POS.POS_A_Q:	//	量词 量语素
                    return "量词 量语素";

                case T_POS.POS_D_R:	//	代词 代语素
                    return "代词 代语素";

                case T_POS.POS_D_S:	//	处所词
                    return "处所词";

                case T_POS.POS_D_T:	//	时间词
                    return "时间词";

                case T_POS.POS_D_U:	//	助词 助语素
                    return "助词 助语素";

                case T_POS.POS_D_V:	//	动词 动语素
                    return "动词 动语素";

                case T_POS.POS_D_W:	//	标点符号
                    return "标点符号";

                case T_POS.POS_D_X:	//	非语素字
                    return "非语素字";

                case T_POS.POS_D_Y:	//	语气词 语气语素
                    return "语气词 语气语素";

                case T_POS.POS_D_Z:	//	状态词
                    return "状态词";

                case T_POS.POS_A_NR://	人名
                    return "人名";

                case T_POS.POS_A_NS://	地名
                    return "地名";

                case T_POS.POS_A_NT://	机构团体
                    return "机构团体";

                case T_POS.POS_A_NX://	外文字符
                    return "外文字符";

                case T_POS.POS_A_NZ://	其他专名
                    return "其他专名";

                case T_POS.POS_D_H:	//	前接成分
                    return "前接成分";

                case T_POS.POS_D_K:	//	后接成分
                    return "后接成分";

                case T_POS.POS_UNK://  未知词性
                    return "未知词性";

                default :
                    return "未知词性";

            }
        }

        public ArrayList GetPosList(int pos)
        {
            ArrayList ret = new ArrayList();

            if (pos == 0)
            {
                ret.Add(T_POS.POS_UNK);
                return ret;
            }

            int point = 0x40000000;

            while (point != 0)
            {
                if ((pos & point) == point)
                {
                    ret.Add((T_POS)point);
                }

                point = (int)(point >> 1);
            }

            return ret;

        }

        /// <summary>
        /// 增加单词的词性
        /// </summary>
        /// <param name="word">单词</param>
        /// <param name="pos">词性</param>
        public void AddWordPos(String word, int pos)
        {
            if (word == null)
            {
                return;
            }

            if (word.Length == 1)
            {
                m_OneCharTable[word] = true;
            }

            ArrayList list = GetPosList(pos);
            T_INNER_POS[] inPosList = new T_INNER_POS[list.Count];

            for (int i = 0 ; i < inPosList.Length; i++)
            {
            
                inPosList[i] = GetInnerPos((T_POS)list[i]);
            }

            m_PosTable[word] = inPosList;
        }

        /// <summary>
        /// 是否是未登录的单字词
        /// </summary>
        /// <param name="word">词</param>
        /// <returns></returns>
        public bool IsUnknowOneCharWord(String word)
        {
            if (word.Length > 1 || word.Length == 0)
            {
                return false;
            }
            else if (word[0] < 0x4e00 || word[0] > 0x9fa5)
            {
                return false;
            }
            else
            {
                return m_OneCharTable[word] == null;
            }
        }

        static public T_POS InnertPosToPos(T_INNER_POS inPos)
        {
            if (inPos == T_INNER_POS.POS_UNK)
            {
                return T_POS.POS_UNK;
            }

            return (T_POS)(0x01 << (int)inPos);
        }

        static public int GetPosFromInnerPosList(T_INNER_POS[] inPosList)
        {
            int retPos = 0;

            foreach (T_INNER_POS pos in inPosList)
            {
                if (pos == T_INNER_POS.POS_UNK)
                {
                    continue;
                }

                retPos |= 0x01 << (int)pos;
            }

            return retPos;
        }


        /// <summary>
        /// 获取单词的词性
        /// </summary>
        /// <param name="word">单词</param>
        /// <param name="isReg">是否是已登录词</param>
        /// <returns>单词词性</returns>
        public T_INNER_POS[] GetPos(String word, out bool isReg)
        {
            object obj = m_PosTable[word];
            if (obj == null)
            {
                isReg = false;
                return new T_INNER_POS[0];
            }
            else
            {
                isReg = true;
                return (T_INNER_POS[])obj;
            }
        }


        public CPOS()
        {
            m_PosTable = new Hashtable();
            m_OneCharTable = new Hashtable();

        }



    }
}
