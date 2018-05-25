using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    //计算升级所需的经验值
    public static int GetRequireByLevel(int level)
    {
        //等差数列
        if (level == 1) return level * 100;
       return (int)((level - 1) * (100f + (100f + 10f * (level - 2f))) / 2f);
    }
}
