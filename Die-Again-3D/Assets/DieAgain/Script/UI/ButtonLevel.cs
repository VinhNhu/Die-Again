using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonLevel : MonoBehaviour
{
    [SerializeField] private Sprite Lock;
    [SerializeField] private Sprite Unlock;

    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _txtlevel;
    [SerializeField] private int Level;

    private bool isUnlocked;

    private void OnEnable()
    {
        _button.onClick.AddListener(Click);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Click);
    }

    private void Start()
    {
        _txtlevel.text = Level.ToString();
        if (Level == 1)
        {
            isUnlocked = true;
            PlayerPrefs.SetInt($"LevelUnlocked_{Level}", 1);
            PlayerPrefs.Save();
        }
        else
        {
            isUnlocked = PlayerPrefs.GetInt($"LevelUnlocked_{Level}", 0) == 1;
        }

        CheckUnLock();
    }

    private void Click()
    {
        Pref.level = Level - 1;
        Pref.leveltxt = Level;

        AudioController.Instance.PlaySound(AudioController.Instance.Btn);
        SceneController.Instance.LoadNextScene("GamePlay");
    }

    private void CheckUnLock()
    {
        if (isUnlocked || Level < Pref.leveltxt)
        {
            _button.image.sprite = Unlock;
            _button.interactable = true;

            if (!isUnlocked)
            {
                isUnlocked = true;
                PlayerPrefs.SetInt($"LevelUnlocked_{Level}", 1);
                PlayerPrefs.Save();
            }
        }
        else
        {
            _button.image.sprite = Lock;
            _button.interactable = false;
        }
    }
}
