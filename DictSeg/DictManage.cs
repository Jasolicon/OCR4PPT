using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using KTDictSeg;

namespace DictManage
{
    public class SearchWordResult : IComparable
    {
        /// <summary>
        /// ����
        /// </summary>
        public T_DictStruct Word;

        /// <summary>
        /// ���ƶ�
        /// </summary>
        public float SimilarRatio;

        public override string ToString()
        {
            return Word.Word;
        }



        #region IComparable ��Ա

        public int CompareTo(object obj)
        {
            SearchWordResult dest = (SearchWordResult)obj;

            if (this.SimilarRatio == dest.SimilarRatio)
            {
                return 0;
            }
            else if (this.SimilarRatio > dest.SimilarRatio)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        #endregion
    }

    /// <summary>
    /// �ֵ����
    /// �������룬�޸ģ�ɾ��������
    /// </summary>
    public class DictMgr
    {
        T_DictFile m_Dict = null;
        bool m_Approximate = false;
        Hashtable m_DictTbl = new Hashtable();

        /// <summary>
        /// �ֵ�
        /// </summary>
        public T_DictFile Dict
        {
            get
            {
                return m_Dict;
            }

            set
            {
                m_Dict = value;

                foreach (T_DictStruct w in m_Dict.Dicts)
                {
                    m_DictTbl[w.Word] = w;
                }
            }
        }

        /// <summary>
        /// �Ƿ�����ģ����ѯ
        /// </summary>
        public bool Approximate
        {
            get
            {
                return m_Approximate;
            }

            set
            {
                m_Approximate = value;
            }
        }

        /// <summary>
        /// ͨ��������ʽ����
        /// </summary>
        /// <returns></returns>
        private List<SearchWordResult> SearchByTraversal(String key)
        {
            Debug.Assert(m_Dict != null);

            List<SearchWordResult> result = new List<SearchWordResult>();

            foreach (T_DictStruct word in m_Dict.Dicts)
            {
                if (word.Word.Contains(key))
                {
                    SearchWordResult wordResult = new SearchWordResult();
                    wordResult.Word = word;
                    wordResult.SimilarRatio = (float)key.Length / (float)word.Word.Length;
                    result.Add(wordResult);
                }
            }

            return result;
        }

        private List<SearchWordResult> SearchByLucene(String key)
        {
            return null;
        }

        public List<SearchWordResult> Search(String key)
        {
            if (Approximate)
            {
                return SearchByLucene(key);
            }
            else
            {
                return SearchByTraversal(key);
            }
        }

        public List<SearchWordResult> SearchByPos(int Pos)
        {
            Debug.Assert(m_Dict != null);

            List<SearchWordResult> result = new List<SearchWordResult>();

            foreach (T_DictStruct word in m_Dict.Dicts)
            {
                if ((word.Pos & Pos) != 0)
                {
                    SearchWordResult wordResult = new SearchWordResult();
                    wordResult.Word = word;
                    wordResult.SimilarRatio = 0;
                    result.Add(wordResult);
                }
            }

            return result;
        }

        public List<SearchWordResult> SearchByLength(int length)
        {
            Debug.Assert(m_Dict != null);

            List<SearchWordResult> result = new List<SearchWordResult>();

            foreach (T_DictStruct word in m_Dict.Dicts)
            {
                if (word.Word.Length == length)
                {
                    SearchWordResult wordResult = new SearchWordResult();
                    wordResult.Word = word;
                    wordResult.SimilarRatio = 0;
                    result.Add(wordResult);
                }
            }

            return result;
        }

        public T_DictStruct GetWord(String word)
        {
            return (T_DictStruct)m_DictTbl[word];
        }

        public void InsertWord(String word, double frequency, int pos)
        {
            if (word == null)
            {
                return;
            }

            word = word.Trim();

            if (GetWord(word) != null)
            {
                return;
            }

            T_DictStruct w = new T_DictStruct();
            w.Word = word;
            w.Frequency = frequency;
            w.Pos = pos;

            m_Dict.Dicts.Add(w);
            m_DictTbl[word] = w;
        }

        public void UpdateWord(String word, double frequency, int pos)
        {
            word = word.Trim();

            T_DictStruct w = GetWord(word) ;

            if (w == null)
            {
                return;
            }
           
            w.Frequency = frequency;
            w.Pos = pos;
        }

        public void DeleteWord(String word)
        {
            word = word.Trim();

            T_DictStruct w = GetWord(word);

            if (w == null)
            {
                return;
            }

            m_DictTbl.Remove(w.Word);
            m_Dict.Dicts.Remove(w);
        }
    }

}
