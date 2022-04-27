using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("AudioManager"));
        SceneManager.LoadScene("GameScene");
    }
}
