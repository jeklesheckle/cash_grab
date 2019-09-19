using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public GameObject coinObject;
    public int minCoinSpawnDelay, maxCoinSpawnDelay;

    private float timeSinceLastCoin;
    private float coinDelay;

    private void Start()
    {
        timeSinceLastCoin = 0;
        coinDelay = setCoinDelay();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenShop()
    {
        SceneManager.LoadScene(3);
    }

    private void Update()
    {
        if (timeSinceLastCoin  > coinDelay)
        {
            coinDelay = setCoinDelay();
            SpawnCoin();
        }
    }

    private void FixedUpdate()
    {
        timeSinceLastCoin += Time.deltaTime;
    }

    private float setCoinDelay()
    {
        return Random.Range(minCoinSpawnDelay, maxCoinSpawnDelay);
    }
    private void SpawnCoin()
    {
        timeSinceLastCoin = 0;
        GameObject coin = Instantiate (coinObject, new Vector3(0, 0, 0), coinObject.transform.rotation);
        coin.transform.localScale = new Vector3(0.25f, 0.25f, 1);
    }
}
