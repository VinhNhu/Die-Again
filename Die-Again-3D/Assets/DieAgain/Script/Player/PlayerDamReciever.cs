using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReciever : DamageReceiver
{
    private Animator anim;
    private bool isDie = false;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    protected override void OnDead()
    {
        isDie = true;
        GameManager.Instance.isLose = true;
        StartCoroutine(IDisActiveObject());
       
    }

    private IEnumerator IDisActiveObject()
    {
        yield return new WaitForSeconds(2f);
        Observe.Notify("GameLose");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(GameTag.TAG_DEADZONE) && isDie)
        {
            anim.SetBool(AnimationString.IsDead, true);
            AudioController.Instance.PlaySound(AudioController.Instance.Dead);

        }
    }
}
