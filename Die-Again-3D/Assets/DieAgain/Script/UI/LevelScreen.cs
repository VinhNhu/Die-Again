using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button back;

    private void OnEnable()
    {
        back.onClick.AddListener(LevelScreenOff);
        Observe.AddObserver("ScreenLevelOn", OnUpdate);
    }

    private void OnDisable()
    {
        back.onClick.RemoveListener(LevelScreenOff);
        Observe.AddObserver("ScreenLevelOn", OnUpdate);
    }

    protected void OnUpdate(object[] data)
    {
        LevelScreenShow();
    }

    public void LevelScreenShow()
    {
        panel.SetActive(true);
    }

    public void LevelScreenOff()
    {
        AudioController.Instance.PlaySound(AudioController.Instance.Btn);
        panel.SetActive(false);
    }
}
