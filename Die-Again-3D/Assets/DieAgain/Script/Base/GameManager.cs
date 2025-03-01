using UnityEditor;
using UnityEngine;
using Pattern;
using Sirenix.OdinInspector;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject[] _level;
    public bool isLose = false;
    public bool isWin = false;

    public CameraController cameraController;

    protected override void Awake()
    {
        Application.targetFrameRate = 60;
        LoadLevel();
    }

    void Start()
    {
        SpawnLevel(Pref.level);
    }


    private void LoadLevel()
    {
        if (Pref.level >= _level.Length)
        {
            Pref.level = Random.Range(1, _level.Length);
        }
    }

    private void SpawnLevel(int index)
    {
        if (index >= 0 && index < _level.Length)
        {
            Instantiate(_level[index], Vector3.zero, Quaternion.identity);
        }
    }

    [Button]
    private void LoadPrefabsLevel()
    {
#if UNITY_EDITOR
        string folderPath = "Assets/DieAgain/Prefabs/Level";
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new[] { folderPath });

        _level = new GameObject[guids.Length];
        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            _level[i] = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
        }

        Debug.Log($"{guids.Length} prefabs loaded from {folderPath}");
#endif
    }
}
