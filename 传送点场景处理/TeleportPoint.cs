
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Games.GlobeDefine;
using Games.LogicObj;
using GCGame.Table;
using Games.Mission;
public class Tab_Teleport
{

}
public class TeleportPoint : MonoBehaviour
{
    //传送点id  半径
    public int TeleportID = -1;
    public int ActiveRadius = 3;

    private bool m_bValid = true;       //距离是否合法
    private float m_fLastInvaildTime = 0.0f;
    private GameObject m_HeadInfoBoard;        // 传送点面板
    public UnityEngine.GameObject HeadInfoBoard
    {
        get { return m_HeadInfoBoard; }

    }
    private GameObject m_NameBoard;            // teleport

    Transform m_MainPlayerTransform = null;
    Transform m_TeleportTransform = null;
    Tab_Teleport m_tabTeleport = null;

    private bool m_bEnterPKSceneCancel = false;
    //是否取消
    private bool m_bIsCancel = false;

    /// <summary>
    ///加载名字面板
    /// </summary>
    void InitNameBoard()
    {
        //ResourceManager.LoadHeadInfoPrefab(UIInfo.NPCHeadInfo, gameObject, "NPCHeadInfo", OnLoadNameBoard);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="objNameBoard"></param>
    void OnLoadNameBoard(GameObject objNameBoard)
    {
        m_HeadInfoBoard = objNameBoard;
        //传送点名字面板不为空
        if (null != m_HeadInfoBoard)
        {
            //找下面关键点
            Transform nameBoardOffset = m_HeadInfoBoard.transform.Find("NameBoardOffset");
            if (null != nameBoardOffset)
            {
                //设置位置
                nameBoardOffset.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                //找NameBoard
                Transform nameBoard = nameBoardOffset.Find("NameBoard");
                if (null != nameBoard)
                {
                    // 传送点进行赋值
                    m_NameBoard = nameBoard.gameObject;
                }
            }
            //获取名字面板上自带BillBoard  设置高度 
           
        }

      
        if (null != m_NameBoard)
        {
            UILabel nameBoardLabel = m_NameBoard.GetComponent<UILabel>();
            if (null != nameBoardLabel)
            {
                //获取传送点数据
               
            }
        }
    }

    void Start()
    {
        //如果是江夏和巨鹿剧情副本，则删除传送点
       
        Invoke("InitNB", 3.0f);
        if (null == m_TeleportTransform)
        {
            m_TeleportTransform = transform;
        }
        enabled = false;
    }
    void InitNB()
    {
        InitNameBoard();
    }
    void OnBecameVisible()
    {
        enabled = true;
    }
    void OnBecameInvisible()
    {
        enabled = false;
    }

    void FixedUpdate()
    {
        //3s内不能再次触发传送
        //给玩家位置
        //玩家存在
        //判断与传送点距离 《0.5f
        //通过传送点id获取数据
        //进行特殊判断  如果处于什么特殊任务 需要什么操作
        //如果超出传送点距离关闭弹窗
        
    }

    void FuncOKClicked()
    {
        //根据ID从表格中获取信息
        //传送
        Tab_Teleport teleport = null;
        SendChangeScene( teleport);
    }
    void FunccCanCalClicked()
    {
        m_bIsCancel = true;
    }

    void EnterNonePKValueSceneOK()
    {
        if (m_tabTeleport != null)
        {
            SendChangeScene(m_tabTeleport);
            m_tabTeleport = null;
            m_bEnterPKSceneCancel = false;
        }
    }

    void EnterNonePKValueSceneCancel()
    {
        m_bEnterPKSceneCancel = true;
    }

    void SendChangeScene(Tab_Teleport teleport)
    {

        //向服务器发起切场景请求
        //自动寻路处理

        
    }
    /// <summary>
    /// 打开副本
    /// </summary>
    public void SendOpenCopyScene()
    {
        //根据传送点id 获取传送点信息
        //玩家副本状态改变
        //发送消息传送点id 发送消息
       
    }
    public void SendLeaveCopyScene()
    {
        //发送消息传送点id 发送消息
        
    }
    public void CloseMessageBox()
    {

    }
    /// <summary>
    ///是否进行pk
    /// </summary>
    /// <param name="nSceneClassID">id</param>
    /// <returns></returns>
    public static bool IsCanPK(int nSceneClassID)
    {
        //获取场景Tab_SceneClass
        //通过id获得规则
        return false;
    }

    public static bool IsIncPKValue(int nSceneClassID)
    {
        //获取场景Tab_SceneClass
        //通过id获得规则
        return false;
    }
}
