using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMenu : MonoBehaviour
{
    [SerializeField] private Button btn_Play;


    private void OnEnable()
    {
        btn_Play.onClick.AddListener(PlayGame);
    }

    private void OnDisable()
    {
        btn_Play.onClick.RemoveListener(PlayGame);
    }

    private void PlayGame()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.Btn);
        Observe.Notify("ScreenLevelOn");
    }
}
