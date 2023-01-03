
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneData
{
    public static int SceneInst { set; get; }       // ��ǰ����ʵ��
    public static int SceneInstCount { set; get; }       // ������ʵ��
    public static List<int> SceneInstList = new List<int>();    // ����ʵ���б�
    public static List<int> ReachedScenes = new List<int>();    // ��Ҵﵽ���ĳ���

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
                // PK��������
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
        //������������
        //��ӷ�����������������Ϣ
       
    }

    public static void UpdateReachedScenes()//GC_SYNC_REACHEDSCENE packet
    {
        //������������
        //��ӷ�����������������Ϣ
    }

    public static void RequestChangeScene(int nChangeType, int nTeleportID, int nSceneClassID, int nSceneInstID, int nPosX = 0, int nPosZ = 0)
    {
        //������Ϣ�������� ˵˭Ҫ�л�����
        //�л����Ǹ�����id
        //������Ϣ
      
    }
}
