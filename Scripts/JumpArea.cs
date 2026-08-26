using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpArea : MonoBehaviour
{
    public Transform jumpPointA;
    public Transform jumpPointB;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Luna"))
        {
            // Luna父对象的移动
            LunaController lunaController = collision.transform.GetComponent<LunaController>();
            lunaController.Jump(true);
            float distanceA = Vector3.Distance(lunaController.transform.position, jumpPointA.position);
            float distanceB = Vector3.Distance(lunaController.transform.position, jumpPointB.position);
            Transform targetTrans;
            targetTrans = distanceA > distanceB ? jumpPointA : jumpPointB;
            lunaController.transform.DOMove(targetTrans.position, 0.5f).SetEase(Ease.Linear).OnComplete(() => { EndJump(lunaController); });
            Transform lunaLocalTrans = lunaController.transform.GetChild(0);

            // Luna子对象的跳跃动画
            Sequence sequence = DOTween.Sequence();
            sequence.Append(lunaLocalTrans.DOLocalMoveY(1.5f, 0.25f).SetEase(Ease.InOutSine));
            sequence.Append(lunaLocalTrans.DOLocalMoveY(0.7f, 0.25f).SetEase(Ease.InOutSine));
            sequence.Play();
        }
    }

    private void EndJump(LunaController lunaController)
    {
        lunaController.Jump(false);
    }
}
