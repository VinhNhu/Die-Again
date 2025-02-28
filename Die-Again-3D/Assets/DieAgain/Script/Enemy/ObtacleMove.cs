using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.ComponentModel;

public class ObtacleMove : MonoBehaviour
{
    private bool hasMoved = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GameTag.TAG_PLAYER) && !hasMoved)
        {
             hasMoved = true;
             transform.DOMoveY(transform.position.y - 4f, 2f).SetEase(Ease.OutQuad);
            AudioController.Instance.PlaySound(AudioController.Instance.Poof);
        }
    }
}
