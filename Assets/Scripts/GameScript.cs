using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public GameObject coinObject;
    public GameObject armObject;
    public int minCoinSpawnDelay, maxCoinSpawnDelay;
    public Vector2 bottomLeftOfCoinSpawn, topRightOfCoinSpawn;
    public Vector2 bottomLeftOfScreen, topRightOfScreen;

    private float timeSinceLastCoin;
    private float coinDelay;

    private float coinXCoord, coinYCoord;
    private float armXCoord, armYCoord;
    private int armSide;

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
        coinXCoord = Random.Range(bottomLeftOfCoinSpawn.x, topRightOfCoinSpawn.x);
        coinYCoord = Random.Range(bottomLeftOfCoinSpawn.y, topRightOfCoinSpawn.y);

        GameObject coin = Instantiate (coinObject, new Vector3(coinXCoord, coinYCoord, 0), coinObject.transform.rotation);
        coin.transform.localScale = new Vector3(0.25f, 0.25f, 1);
        SpawnArm();
    }

    private void SpawnArm()
    {
        armSide = Random.Range(1,5);
        switch (armSide)
        {
            case 1: //top edge
                armXCoord = Random.Range(bottomLeftOfScreen.x, topRightOfScreen.x);
                armYCoord = topRightOfScreen.y;
                break;
            case 2: //right edge
                armXCoord = topRightOfScreen.x;
                armYCoord = Random.Range(bottomLeftOfScreen.y, topRightOfScreen.y);
                break;
            case 3: //bottom edge
                armXCoord = Random.Range(bottomLeftOfScreen.x, topRightOfScreen.x);
                armYCoord = bottomLeftOfScreen.y;
                break;
            case 4: //left edge
                armXCoord = bottomLeftOfScreen.x;
                armYCoord = Random.Range(bottomLeftOfScreen.y, topRightOfScreen.y);
                break;
        }
        
        GameObject arm = Instantiate(armObject, new Vector3(armXCoord, armYCoord, 0), armObject.transform.rotation);
    }
}
