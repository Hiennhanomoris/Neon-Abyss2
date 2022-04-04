using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private int scene;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            string next = "scene" + scene;
            SceneManager.LoadScene(next);
            DontDestroyOnLoad(PlayerStatus.Instance.gameObject);
        }
    }
}
