
using UnityEngine;
using System.Collections;
/// <summary>
/// �Զ�Ѱ·�ĵ� �г����±��λ��
/// </summary>
public class AutoSearchPoint
{
    public AutoSearchPoint()
    {
        m_nSceneID = -1;
    }

    public AutoSearchPoint(int sceneId, float posX, float posZ)
    {
        m_nSceneID = sceneId;
        m_fPosX = posX;
        m_fPosZ = posZ;
    }

    public void Clean()
    {
        m_nSceneID = -1;
        m_fPosX = 0;
        m_fPosZ = 0;
    }

    private int m_nSceneID;         //Ŀ��㳡��ID
    public int SceneID
    {
        get { return m_nSceneID; }
        set { m_nSceneID = value; }
    }
    private float m_fPosX;          //Ŀ���X����
    public float PosX
    {
        get { return m_fPosX; }
        set { m_fPosX = value; }
    }
    private float m_fPosZ;          //Ŀ���Z����
    public float PosZ
    {
        get { return m_fPosZ; }
        set { m_fPosZ = value; }
    }

    //����һ��obj����Ϣ������һ��AutoSearchPoint
    public static AutoSearchPoint MakePoint(GameObject obj)
    {
        if (null == obj)
        {
            return null;
        }

        AutoSearchPoint point = new AutoSearchPoint();
        point.SceneID = 1;
        point.m_fPosX = obj.transform.position.x;
        point.m_fPosZ = obj.transform.position.z;

        return point;
    }
}
