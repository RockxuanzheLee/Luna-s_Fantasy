using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject battleGo;
    public int lunaHP;
    public int lunaCurrentHP;
    public int lunaMP;
    public int lunaCurrentMP;
    public int monsterCurrentHP;

    private void Awake()
    {
        Instance = this;
        lunaHP = 100;
        lunaCurrentHP = 100;
        lunaMP = 100;
        lunaCurrentMP = 100;
        monsterCurrentHP = 50;
    }

    public void EnterOrExitBattle(bool enter = true)
    {
        battleGo.SetActive(enter);
    }

    /// <summary>
    /// luna血量改变
    /// </summary>
    /// <param name="Value">改变值</param>
    public void AddOrDecreaseHP(int Value)
    {
        lunaCurrentHP += Value;
        if (lunaCurrentHP >= lunaHP)
        {
            lunaCurrentHP = lunaHP;
        }
        else if(lunaCurrentHP <= 0)
        {
            lunaCurrentHP = 0;
        }
        UIManager.Instance.SetHPValue((float)lunaCurrentHP / lunaHP);
    }

    /// <summary>
    /// luna蓝量改变
    /// </summary>
    /// <param name="Value">改变值</param>
    public void AddOrDecreaseMP(int Value)
    {
        lunaCurrentMP += Value;
        if (lunaCurrentMP >= lunaMP)
        {
            lunaCurrentMP = lunaMP;
        }
        else if (lunaCurrentMP <= 0)
        {
            lunaCurrentMP = 0;
        }
        UIManager.Instance.SetMPValue((float)lunaCurrentMP / lunaMP);
    }

    /// <summary>
    /// 是否可以使用技能
    /// </summary>
    /// <param name="value">技能消耗蓝量</param>
    /// <returns></returns>
    public bool CanUsePlayerMP(int value)
    {
        return lunaCurrentMP >= value;
    }

    /// <summary>
    /// 怪物血量改变
    /// </summary>
    /// <param name="value"></param>
    public int AddOrDecreaseMonsterHP(int value = 0)
    {
        monsterCurrentHP += value;
        return monsterCurrentHP;
    }
}
