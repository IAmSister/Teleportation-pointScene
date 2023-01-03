
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoSearchPath
{
    public AutoSearchPath()
    {
        m_AutoSearchPointCache = new List<AutoSearchPoint>();
        m_FinishCallBackEvent = null;
        m_AutoSearchTargetName = "";
    }

    //自动寻路点缓存
    private List<AutoSearchPoint> m_AutoSearchPointCache;
    public List<AutoSearchPoint> AutoSearchPosCache
    {
        get { return m_AutoSearchPointCache; }
    }

    //自动寻路目标名字
    private string m_AutoSearchTargetName;
    public string AutoSearchTargetName
    {
        get { return m_AutoSearchTargetName; }
        set { m_AutoSearchTargetName = value; }
    }

    //自动寻路结束事件
    //当到达最后一个点之后触发
    private GameEvent m_FinishCallBackEvent;
    public GameEvent FinishCallBackEvent
    {
        get { return m_FinishCallBackEvent; }
        set { m_FinishCallBackEvent = value; }
    }

    public void AddPathPoint(AutoSearchPoint point)
    {
        if (null != m_AutoSearchPointCache)
        {
            m_AutoSearchPointCache.Add(point);
        }
    }

    public void ResetPath()
    {
        m_AutoSearchPointCache.Clear();
        if (null != m_FinishCallBackEvent)
        {
            m_FinishCallBackEvent.Reset();
        }
        if (m_AutoSearchTargetName != "")
        {
            m_AutoSearchTargetName = "";
        }
    }

    //找到场景sceneId中第一个需要达到的点
    public AutoSearchPoint GetPathPosition(int sceneId)
    {
        for (int i = 0; i < m_AutoSearchPointCache.Count; ++i)
        {
            if (m_AutoSearchPointCache[i].SceneID == sceneId)
            {
                return m_AutoSearchPointCache[i];
            }
        }

        return null;
    }

    //是否已经抵达路径点
    public bool IsFinish(Vector3 pos)
    {
        //路径数量大于1，则认为未到达
        if (m_AutoSearchPointCache.Count > 1)
        {
            return false;
        }
        //路径为空，认为已经到达
        else if (m_AutoSearchPointCache.Count <= 0)
        {
            return true;
        }

        //如果目前路径中确实只有一个点，则判断是否已经达到要求
        return IsReachPoint(pos);
    }

    //是否到达寻路路径中的下一个目标点
    //按照设计就是当前索引为0的点
    public bool IsReachPoint(Vector3 pos)
    {
        if (m_AutoSearchPointCache.Count <= 0)
        {
            return false;
        }

        //先判断场景ID

        //只用做2D判断即可

        //判断距离 小于1 true

        return false;
    }

    //得到下一个需要寻路的点
    //返回null表示路径结束
    public AutoSearchPoint GetNext()
    {
        if (m_AutoSearchPointCache.Count > 0)
        {
            return m_AutoSearchPointCache[0];
        }

        return null;
    }
}
