using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public Animator lunaAnimater;
    public Transform lunaTrans;
    public Transform monsterTrans;
    private Vector3 monsterInitPos;
    private Vector3 lunaInitPos;
    public SpriteRenderer monsterSr;
    public SpriteRenderer lunaSr;
    public GameObject skillEffectGo;

    private void Awake()
    {
        monsterInitPos = monsterTrans.localPosition;
        lunaInitPos = lunaTrans.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Luna攻击
    /// </summary>
    public void LunaAttack()
    {
        StartCoroutine(PerformAttackLogic());
    }

    //玩家攻击逻辑
    IEnumerator PerformAttackLogic()
    {
        UIManager.Instance.ShowOrHideBattlePanel(false);
        lunaAnimater.SetBool("MoveState",true);
        lunaAnimater.SetFloat("MoveValue", -1f);
        lunaTrans.DOLocalMove(monsterTrans.localPosition + new Vector3(1f, 0f, 0f), 0.5f).OnComplete
            (
                () =>
                {
                    //攻击动画
                    lunaAnimater.SetBool("MoveState", false);
                    lunaAnimater.SetFloat("MoveValue", 0f);
                    lunaAnimater.CrossFade("Attack", 0.0f);
                    monsterSr.DOFade(0.3f, 0.5f).OnComplete(() => JudgeMonsterHP(20));
                }
            );
        yield return new WaitForSeconds(1.167f);
        //返回原位
        lunaAnimater.SetBool("MoveState", true);
        lunaAnimater.SetFloat("MoveValue", 1f);
        lunaTrans.DOLocalMove(lunaInitPos, 0.5f).OnComplete
            (
                () =>
                {
                    lunaAnimater.SetBool("MoveState", false);
                    lunaAnimater.SetFloat("MoveValue", 0f);
                }
            );
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PerformMonsterLogic());
    }

    /// 怪物攻击逻辑
    IEnumerator PerformMonsterLogic()
    {
        monsterTrans.DOLocalMove(lunaInitPos + new Vector3(-1.5f, 0f, 0f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        monsterTrans.DOLocalMove(lunaInitPos,0.1f).OnComplete
            (
                () =>
                {
                    monsterTrans.DOLocalMove(lunaInitPos + new Vector3(-1.5f, 0f, 0f), 0.2f);
                    lunaAnimater.CrossFade("Hit", 0.0f);
                    lunaSr.DOFade(0.3f, 0.25f).OnComplete( () => {lunaSr.DOFade(1f, 0.25f);} );
                    JudgePlayerHP(20);
                }
            );
        yield return new WaitForSeconds(0.6f);
        monsterTrans.DOLocalMove(monsterInitPos, 0.5f).OnComplete(() => {UIManager.Instance.ShowOrHideBattlePanel(true); });
    }

    /// <summary>
    /// Luna防御
    /// </summary>
    public void LunaDefend()
    {
        StartCoroutine(PerformDefendLogic());
    }

    IEnumerator PerformDefendLogic()
    {
        UIManager.Instance.ShowOrHideBattlePanel(false);
        lunaAnimater.SetBool("Defend",true);
        monsterTrans.DOLocalMove(lunaInitPos + new Vector3(-1.5f, 0f, 0f), 0.5f);
        yield return new WaitForSeconds(0.5f);
        monsterTrans.DOLocalMove(lunaInitPos, 0.1f).OnComplete
            (
                () =>
                {
                    monsterTrans.DOLocalMove(lunaInitPos + new Vector3(-1.5f, 0f, 0f), 0.2f);
                    lunaTrans.DOLocalMove(lunaInitPos + new Vector3(1.0f,0,0),0.2f).OnComplete
                        (
                            () => { lunaTrans.DOLocalMove(lunaInitPos, 0.2f); }
                        );
                }
            );
        yield return new WaitForSeconds(0.6f);
        monsterTrans.DOLocalMove(monsterInitPos, 0.5f).OnComplete
            (
                () => 
                {
                    UIManager.Instance.ShowOrHideBattlePanel(true);
                    lunaAnimater.SetBool("Defend", false);
                }
            );
    }

    /// <summary>
    /// luna技能使用
    /// </summary>
    public void LunaUseSkill()
    {
        if (!GameManager.Instance.CanUsePlayerMP(30))
        {
            return;
        }
        StartCoroutine(PerformSkillLogic());
    }

    IEnumerator PerformSkillLogic()
    {
        UIManager.Instance.ShowOrHideBattlePanel(false);
        lunaAnimater.CrossFade("Skill",0.0f);
        GameManager.Instance.AddOrDecreaseMP(-30);
        yield return new WaitForSeconds(0.3f);
        Instantiate(skillEffectGo,monsterInitPos, UnityEngine.Quaternion.identity);

    }

    /// <summary>
    /// 修改玩家血量
    /// </summary>
    /// <param name="value">减少的血量</param>
    public void JudgeMonsterHP(int value = 0)
    {
        monsterSr.DOFade(1f, 0.5f);
    }

    /// <summary>
    /// 修改怪物血量
    /// </summary>
    /// <param name="value">减少的血量</param>
    public void JudgePlayerHP(int value = 0)
    {
        
    }
}
