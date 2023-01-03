
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneData
{
    public static int SceneInst { set; get; }       // 当前场景实例
    public static int SceneInstCount { set; get; }       // 场景总实例
    public static List<int> SceneInstList = new List<int>();    // 场景实例列表
    public static List<int> ReachedScenes = new List<int>();    // 玩家达到过的场景

    private static Color ColorSceneNormal = Color.green;
    private static Color ColorSceneKillPower = Color.white;
    private static Color ColorSceneKillNoPower = Color.red;


    public static Color GetSceneNameColor(int scneneID)
    {
        if (!TeleportPoint.IsCanPK(scneneID))
        {
            return SceneData.ColorSceneNormal;
        }
        else
        {
            if (!TeleportPoint.IsIncPKValue(scneneID))
            {
                // PK不涨能量
                return ColorSceneKillNoPower;
            }
            else
            {
                return ColorSceneKillPower;
            }
        }
    }

    public static void UpdateSceneInst()//GC_UPDATE_SCENE_INSTACTIVATION packet
    {
        //场景集合清理
        //添加服务器传过来场景信息
       
    }

    public static void UpdateReachedScenes()//GC_SYNC_REACHEDSCENE packet
    {
        //场景集合清理
        //添加服务器传过来场景信息
    }

    public static void RequestChangeScene(int nChangeType, int nTeleportID, int nSceneClassID, int nSceneInstID, int nPosX = 0, int nPosZ = 0)
    {
        //发送消息给服务器 说谁要切换场景
        //切换到那个场景id
        //发送消息
      
    }
}
