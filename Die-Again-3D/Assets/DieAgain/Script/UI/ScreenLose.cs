using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenLose : MonoBehaviour
{

    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text txtLevel;
    [SerializeField] private TMP_Text txtIQ;

    [SerializeField] private Button Replay;
    [SerializeField] private Button Skip;

    [SerializeField] private GameObject playerRender;

    protected void OnEnable()
    {
        Observe.AddObserver("GameLose", OnUpdate);
        Replay.onClick.AddListener(RePlayGame);
        Skip.onClick.AddListener(SkipGamePlay);
    }

    protected void OnDisable()
    {
        Observe.RemoveListener("GameLose", OnUpdate);
        Replay.onClick.RemoveListener(RePlayGame);
        Skip.onClick.RemoveListener(SkipGamePlay);
    }

    protected void OnUpdate(object[] data)
    {
        Lose();
    }

    private IEnumerator DisPLaytextLose()
    {
        int oldIQ = Pref.IQ;
        txtLevel.text = "Level " + Pref.leveltxt.ToString();
        txtIQ.text = Pref.IQ.ToString() + " IQ";

        yield return new WaitForSeconds(1F);
        
        Pref.IQ -= 1;
        DisPLaytextLoseAnim(oldIQ, Pref.IQ);
    }



    private void Lose()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.Lose);
        panel.SetActive(true);
        playerRender.SetActive(true);
        StartCoroutine(DisPLaytextLose());
    }

    private void RePlayGame()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.Btn);
        SceneController.Instance.LoadNextScene("GamePlay");
    }

    private void SkipGamePlay()
    {
        Pref.level++;
        AudioController.Instance.PlaySound(AudioController.Instance.Btn);
        SceneController.Instance.LoadNextScene("GamePlay");
    }

    private void DisPLaytextLoseAnim(int startValue, int endValue)
    {
        DOTween.To(() => startValue, x =>
        {
            txtIQ.text = x.ToString() + " IQ"; 
        }, endValue, 0.5f); 
    }
}
