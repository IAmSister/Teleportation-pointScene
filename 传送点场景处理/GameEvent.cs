
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.GlobeDefine;

    public class GameEvent
    {
        public GameEvent()
        {
            Reset();
        }

        public GameEvent(GameDefine_Globe.EVENT_DEFINE nEventID)
        {
            Reset();
            m_idEvent = nEventID;
        }

        GameDefine_Globe.EVENT_DEFINE m_idEvent;
        public GameDefine_Globe.EVENT_DEFINE EventID
        {
            get { return m_idEvent; }
            set { m_idEvent = value; }
        }

        List<int> m_listIntParam;               //整数参数
        List<float> m_listFloatParam;           //浮点数参数
        List<string> m_listStringParam;         //字符串参数

        //延迟相关
        bool m_bIsDelay;                        //是否延迟处理，默认为false,当设置延迟时间的时候会进行置位
        public bool IsDelay
        {
            get { return m_bIsDelay; }
            set
            {
                m_bIsDelay = value;
                //当发现是延迟事件的时候，设置创建时间，准备更新的时候使用
                if (m_bIsDelay)
                {
                    m_fCreateTime = Time.time;
                }
            }
        }

        float m_fDelayTime;                     //延迟处理时间
        public float DelayTime
        {
            get { return m_fDelayTime; }
            set { m_fDelayTime = value; }
        }

        float m_fCreateTime;                    //创建时间
        //从事件创建到当前时间的流逝时间(秒)
        public float ElapsedTime
        {
            get { return Time.time - m_fCreateTime; }
        }
        public bool IsDelayFinish()
        {
            if (!m_bIsDelay)
            {
                return true;
            }

            if (ElapsedTime > m_fDelayTime)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            m_idEvent = GameDefine_Globe.EVENT_DEFINE.EVENT_INVALID;
            if (null == m_listIntParam)
            {
                m_listIntParam = new List<int>();
            }
            m_listIntParam.Clear();

            if (null == m_listFloatParam)
            {
                m_listFloatParam = new List<float>();
            }
            m_listFloatParam.Clear();

            if (null == m_listStringParam)
            {
                m_listStringParam = new List<string>();
            }
            m_listStringParam.Clear();

            m_bIsDelay = false;
            m_fDelayTime = 0.0f;
            m_fCreateTime = 0.0f;
        }

        public void AddIntParam(int nParam)
        {
            m_listIntParam.Add(nParam);
        }
        public int GetIntParam(int nIndex)
        {
            if (nIndex >= 0 && nIndex < m_listIntParam.Count)
            {
                return m_listIntParam[nIndex];
            }

         
            return GlobeVar.INVALID_ID;
        }

        public void AddFloatParam(float fParam)
        {
            m_listFloatParam.Add(fParam);
        }
        public float GetFloatParam(int nIndex)
        {
            if (nIndex >= 0 && nIndex < m_listFloatParam.Count)
            {
                return m_listFloatParam[nIndex];
            }
            return GlobeVar.INVALID_ID;
        }

        public void AddStringParam(string szParam)
        {
            m_listStringParam.Add(szParam);
        }
        public string GetStringParam(int nIndex)
        {
            if (nIndex >= 0 && nIndex < m_listStringParam.Count)
            {
                return m_listStringParam[nIndex];
            }
            return "";
        }
    
}
