using UnityEngine;
using Pattern;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    [SerializeField] private CanvasGroup TransitionBG;


    protected override void Awake()
    {
        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    public void LoadNextScene(string sceneName)
    {
        TransitionBG.gameObject.SetActive(true);
        TransitionBG.DOFade(1, 0.4f).OnComplete(() =>
        {
            SceneManager.LoadScene(sceneName);
            TransitionBG.DOFade(0, 0.4f).OnComplete(() =>
            {
                TransitionBG.gameObject.SetActive(false);
            });

        });
    }
}
