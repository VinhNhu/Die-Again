using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCtrl : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag(GameTag.TAG_PLAYER))
        {
            StartCoroutine(Won());
        }
    }

    public IEnumerator Won()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.YouWin);
        GameManager.Instance.isWin = true;
        yield return new WaitForSeconds(1f);
        Observe.Notify("GameWon");
    }
}
