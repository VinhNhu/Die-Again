using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGame : MonoBehaviour
{
    [SerializeField] private Button btnJump;
    [SerializeField] private Button btnBackHome;

    private PlayerMovement playerMovement;

    private void OnEnable()
    {
        LevelController.OnPlayerSpawned += HandlePlayerSpawned;
        btnBackHome.onClick.AddListener(BackHome);
    }

    private void OnDisable()
    {
        LevelController.OnPlayerSpawned -= HandlePlayerSpawned;
    }

    private void HandlePlayerSpawned(GameObject player)
    {
        playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            btnJump.onClick.AddListener(playerMovement.Jump);
        }
    }

    private void BackHome()
    {
        SceneController.Instance.LoadNextScene("Home");
    }
}
