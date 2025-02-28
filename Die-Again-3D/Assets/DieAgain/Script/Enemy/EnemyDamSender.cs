using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : MonoBehaviour
{
    [SerializeField]
    private DamageSender damageSender;

    private void Awake()
    {
        damageSender = GetComponent<DamageSender>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(GameTag.TAG_PLAYER))
        {
            damageSender.Send(collision.gameObject.transform);
        }
    }
}
