using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopScript : MonoBehaviour
{
    public void ReturnToGame()
    {
        SceneManager.LoadScene(1);
    }
}
