
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

    //�Զ�Ѱ·�㻺��
    private List<AutoSearchPoint> m_AutoSearchPointCache;
    public List<AutoSearchPoint> AutoSearchPosCache
    {
        get { return m_AutoSearchPointCache; }
    }

    //�Զ�Ѱ·Ŀ������
    private string m_AutoSearchTargetName;
    public string AutoSearchTargetName
    {
        get { return m_AutoSearchTargetName; }
        set { m_AutoSearchTargetName = value; }
    }

    //�Զ�Ѱ·�����¼�
    //���������һ����֮�󴥷�
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

    //�ҵ�����sceneId�е�һ����Ҫ�ﵽ�ĵ�
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

    //�Ƿ��Ѿ��ִ�·����
    public bool IsFinish(Vector3 pos)
    {
        //·����������1������Ϊδ����
        if (m_AutoSearchPointCache.Count > 1)
        {
            return false;
        }
        //·��Ϊ�գ���Ϊ�Ѿ�����
        else if (m_AutoSearchPointCache.Count <= 0)
        {
            return true;
        }

        //���Ŀǰ·����ȷʵֻ��һ���㣬���ж��Ƿ��Ѿ��ﵽҪ��
        return IsReachPoint(pos);
    }

    //�Ƿ񵽴�Ѱ··���е���һ��Ŀ���
    //������ƾ��ǵ�ǰ����Ϊ0�ĵ�
    public bool IsReachPoint(Vector3 pos)
    {
        if (m_AutoSearchPointCache.Count <= 0)
        {
            return false;
        }

        //���жϳ���ID

        //ֻ����2D�жϼ���

        //�жϾ��� С��1 true

        return false;
    }

    //�õ���һ����ҪѰ·�ĵ�
    //����null��ʾ·������
    public AutoSearchPoint GetNext()
    {
        if (m_AutoSearchPointCache.Count > 0)
        {
            return m_AutoSearchPointCache[0];
        }

        return null;
    }
}
