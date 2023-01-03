
using UnityEngine;
using System.Collections;
using Games.GlobeDefine;
using Games.LogicObj;
using System.Collections.Generic;
using GCGame.Table;
using Games.Scene;

public struct MapConnectPath
{
    //��ʼ��
    private int m_SrcSceneId;
    public int SrcSceneId
    {
        get { return m_SrcSceneId; }
        set { m_SrcSceneId = value; }
    }

    //������
    private int m_DstSceneId;
    public int DstSceneId
    {
        get { return m_DstSceneId; }
        set { m_DstSceneId = value; }
    }

    //���͵�����X
    private float m_fTelePosX;
    public float TelePosX
    {
        get { return m_fTelePosX; }
        set { m_fTelePosX = value; }
    }

    //���͵�����Y
    private float m_fTelePosZ;
    public float TelePosZ
    {
        get { return m_fTelePosZ; }
        set { m_fTelePosZ = value; }
    }
}

public class AutoSearchAgent : MonoBehaviour
{
    // �Զ�Ѱ··��
    private AutoSearchPath m_Path;
    public AutoSearchPath Path
    {
        get { return m_Path; }
        set { m_Path = value; }
    }

    //�Ƿ��Զ�Ѱ·�б��λ
    private bool m_bIsAutoSearching;
    public bool IsAutoSearching
    {
        get { return m_bIsAutoSearching; }
        set { m_bIsAutoSearching = value; }
    }

    //����ʱ����
    private float m_fUpdateInterval = 0.50f;       //����ʱ��������λΪ�� 
    private float m_fLastUpdateTime = 0;        //��һ�θ���ʱ��
    private int m_bNotEnamyNpcFlag = 0;    // �ǵж�NPC��� ����NPC�������

    //Ѱ·��̾�������ֵ
    const int m_nMinDistanceMaxValue = 65535;

    private AutoSearchPoint m_EndPointCache;

    //����ͨ·ͼ����������Ϸ��ʼ���ʼ��
    private List<MapConnectPath> m_ConnectPath = null;
    //��ʼ������ͨ·ͼ
    public void InitMapConnectPath()
    {
        //��¼return
        //˵���Ѿ���ʼ�����������ٴε���Init������������Ϸ�����г�ʼ��һ�μ���
        //��������ͨ·ͼ
        //ѭ����ͼͨ·ͼ �ӱ��ж�ȡÿһ��Tab_MapConnection��Ϊ�յ� ��������

    }

    //��ʼ��
    void Awake()
    {
        m_Path = new AutoSearchPath();
        m_Path.ResetPath();

        m_bIsAutoSearching = false;

        m_EndPointCache = new AutoSearchPoint();
        //InitMapConnectPath();
    }

    // Update is called once per frame
    void Update()
    {
        //δѰ·��������
        if (!m_bIsAutoSearching)
        {
            return;
        }
       //�����
        //�ж��Ƿ��˸��¼��
        if (Time.time - m_fLastUpdateTime < m_fUpdateInterval)
        {
            return;
        }
        else
        {
            m_fLastUpdateTime = Time.time;
        }

        //Ѱ·�������ж��Ƿ����Finish();
        //Ѱ�¸���  GotoNextPoint();


        //�����ʱδ�ƶ�����ǰ����һ����
        // ��ʼ����һ�� ���µ��ƶ�
        //����Ѱ·�ҹִ���

        FindEnamyTick();
        
    }

    // Ѱ·�ҹִ���
    private Obj_NPC objNpc;
    void FindEnamyTick()
    {
        if (m_bNotEnamyNpcFlag != 0)
        {
            return;
        }
        //�����Ŀ��������Ѱ�Ҹ�Ŀ�꣬���н���   //����Ŀ��NPC������ȷ���ǶԻ����ǹ���
        
    }
    public void StartAutoCombat()
    {

        //����ǵط�NPC����ʼ����
        //ֹͣ�Զ�Ѱ·
        //��ҽ����Զ�ս����
        //�����Զ�ս��״̬
        //�Զ�Ѱ·����� ���
        //�Զ�Ѱ·��������
    
    }

    //����һ��·����������Update���ж��Ƿ�ִ�
    public void BuildPath(AutoSearchPoint endPoint)
    {
        // ͬһ���㣬ֱ������
        if (m_EndPointCache.SceneID == endPoint.SceneID
            && m_EndPointCache.PosX == endPoint.PosX
            && m_EndPointCache.PosZ == endPoint.PosZ)
        {
            return;
        }

        //ֹͣ���ڽ��е��ƶ�
      

        m_EndPointCache = endPoint;
        m_Path.ResetPath();
        m_bNotEnamyNpcFlag = 0;
        //�ж������Ƿ����


        //����ǵ�ǰ��������ֱ�����ɵ���·���������ƶ�
        //�����Զ�Ѱ·����  //���ÿ�ʼ�Զ�Ѱ·  return


        //���ݵ�ǰ���Ŀ�ĵص���ȷ��·��
        //���λ�ñ��AutoSearchPoint ����
        //FindPath����С·��  ���������յ�
       
    }

    //�������������ͨ·����
    int GetDisBySceneID(int srcId, int dstId)
    {
        foreach (MapConnectPath path in m_ConnectPath)
        {
            if (path.SrcSceneId == srcId && path.DstSceneId == dstId)
            {
                return 1;
            }
        }

        return m_nMinDistanceMaxValue;
    }

    class PathNodeInfo
    {
        public PathNodeInfo()
        {
            sceneId = -1;
            dis = m_nMinDistanceMaxValue;
            prevNode = -1;
        }
        public int sceneId;
        public int dis;
        public int prevNode;
    }

    //����·���㷨������DJ�㷨�������·��
    bool FindPath(AutoSearchPoint startPoint, AutoSearchPoint endPoint)
    {
        List<int> path = new List<int>();       //������ɵ����·��ͼ

        //ͳ�����нڵ㣬����srcid�����ٽֱ�����nodeMap��
        Dictionary<int, PathNodeInfo> nodeMap = new Dictionary<int, PathNodeInfo>();
        foreach (MapConnectPath connectPath in m_ConnectPath)
        {
            if (false == nodeMap.ContainsKey(connectPath.SrcSceneId))
            {
                PathNodeInfo info = new PathNodeInfo();
                info.sceneId = connectPath.SrcSceneId;
                info.dis = GetDisBySceneID(startPoint.SceneID, info.sceneId);
                info.prevNode = startPoint.SceneID;
                nodeMap.Add(info.sceneId, info);
            }

            if (false == nodeMap.ContainsKey(connectPath.DstSceneId))
            {
                PathNodeInfo info = new PathNodeInfo();
                info.sceneId = connectPath.DstSceneId;
                info.dis = GetDisBySceneID(startPoint.SceneID, info.sceneId);
                info.prevNode = startPoint.SceneID;
                nodeMap.Add(info.sceneId, info);
            }
        }

        List<int> openList = new List<int>();
        List<int> closeList = new List<int>();

        //���뿪ʼ��
        openList.Add(startPoint.SceneID);

        while (openList.Count > 0)
        {
            int minPt = openList[0];
            int minDis = m_nMinDistanceMaxValue;

            foreach (int openPoint in openList)
            {
                if (!nodeMap.ContainsKey(openPoint))
                {
                    continue;
                }

                if (nodeMap[openPoint].dis < minDis)
                {
                    minPt = openPoint;
                    minDis = nodeMap[openPoint].dis;
                }
            }

            int minDisNode = minPt;
            openList.Remove(minDisNode);
            closeList.Add(minDisNode);

            //չ���ýڵ�,���������ڽӱ�ľ��룬������һ�����򼸸������·���ϵĵ����openList��
            
        }


        if (!nodeMap.ContainsKey(endPoint.SceneID))
        {
            return false;
        }

        //�����������·������һ�������ţ�������ڽӱ��Ѿ���¼�����·����Ϣ
        if (nodeMap[endPoint.SceneID].dis < m_nMinDistanceMaxValue)
        {
            path.Insert(0, endPoint.SceneID);
            int backId = nodeMap[endPoint.SceneID].prevNode;
            while (backId != -1)
            {
                if (backId == startPoint.SceneID)
                {
                    //int nextScn = path[0];
                    path.Insert(0, backId);
                    break;
                }

                path.Insert(0, backId);
                backId = nodeMap[backId].prevNode;
            }
        }

        if (path.Count > 1)
        {
            //����·��
            int beginScene = path[0];
            int endScene = -1;
            for (int i = 1; i < path.Count; ++i)
            {
                endScene = path[i];
                foreach (MapConnectPath connectPath in m_ConnectPath)
                {
                    if (connectPath.SrcSceneId == beginScene && connectPath.DstSceneId == endScene)
                    {
                        AutoSearchPoint point = new AutoSearchPoint(connectPath.SrcSceneId, connectPath.TelePosX, connectPath.TelePosZ);
                        m_Path.AutoSearchPosCache.Add(point);

                        beginScene = endScene;
                    }
                }
            }

            //������Ŀ���
            m_Path.AutoSearchPosCache.Add(endPoint);
            return true;
        }

        return false;
    }

    //ֹͣ�Զ�Ѱ·
    public void Stop()
    {
        //����·��
        //�յ����
        //ֹͣ��ҵ����Ч
     
    }

    //�����µ��ƶ�
    void BeginMove()
    {
        if (m_Path.AutoSearchPosCache.Count > 0)
        {
            //���ȼ�ⳡ���Ƿ��Ӧ�����������ֱ�ӷ���
            //�����
            //�������µ�
           
           
        }
    }

    //���ﵱǰ��
    void GotoNextPoint()
    {
        //�Ƴ���һ����
        m_Path.AutoSearchPosCache.RemoveAt(0);

        //��������һ�������
        BeginMove();
    }

    //�Զ�Ѱ·����
    void Finish()
    {
        //ֹͣ���ͷ������Զ�Ѱ· ����Զ�Ѱ·״̬�ı�

        //����н�����Ļص��¼���ص�


        //�����Ŀ��������Ѱ�Ҹ�Ŀ�꣬���н���   //����Ŀ��NPC������ȷ���ǶԻ����ǹ���  
        //����ǵط�NPC����ʼ���� 

        //������ѷ�NPC����ʼ�Ի�

      
    }

    //���Զ�Ѱ·�������������͵�
    public void ProcessTelepoint(TeleportPoint telePoint)
    {
        //���͵������쳣������
        if (null == telePoint || null == telePoint.gameObject)
        {
            return;
        }

        //���Զ�Ѱ·״̬������
        if (false == m_bIsAutoSearching)
        {
            return;
        }

        //�Զ�Ѱ·״̬������·��������ֵ
        if (m_Path.AutoSearchPosCache.Count > 0)
        {
            //�ж��ǲ��Ǳ��ο糡��Ѱ·���贫�͵�
            Vector2 autoSearchPoint = new Vector2(m_Path.AutoSearchPosCache[0].PosX, m_Path.AutoSearchPosCache[0].PosZ);
            Vector2 telePortPoint = new Vector2(telePoint.gameObject.transform.position.x, telePoint.gameObject.transform.position.z);
            //����У�飬��Ϊ�Զ�Ѱ·��Ϊ2D������ת��Ϊ2D������֤
            if (Vector2.Distance(autoSearchPoint, telePortPoint) <= telePoint.ActiveRadius + 2.0f)
            {
                m_Path.AutoSearchPosCache.RemoveAt(0);

                //�����ʱ·�����������ݣ�������Զ�Ѱ·
                if (m_Path.AutoSearchPosCache.Count == 0)
                {
                    Finish();
                }
            }
        }
    }
}
