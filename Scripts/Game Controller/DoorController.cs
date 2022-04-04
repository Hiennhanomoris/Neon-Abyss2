using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private int coin;
    private void Awake() 
    {
        door.SetActive(false);    
    }

    private void Update() 
    {
        if(PlayerStatus.Instance.getCoin() > coin)
        {
            door.SetActive(true);
        }    
    }
}
