using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWin : MonoBehaviour
{
    protected void OnEnable()
    {
        Observe.AddObserver("GameWon", OnUpdate);
    }

    protected void OnDisable()
    {
        Observe.RemoveListener("GameWon", OnUpdate);
    }

    protected void OnUpdate(object[] data)
    {
        NextLevel();
    }

    public void NextLevel()
    {
        Pref.level++;
        Pref.leveltxt++;
        SceneController.Instance.LoadNextScene("GamePlay");
    }
}
