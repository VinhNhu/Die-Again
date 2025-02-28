using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject playerPoint;

    public static event Action<GameObject> OnPlayerSpawned;
    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab, playerPoint.transform.position, playerPoint.transform.rotation);
        OnPlayerSpawned?.Invoke(player);
    }
}
