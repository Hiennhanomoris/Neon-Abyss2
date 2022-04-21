using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Transform enemy1SpawnPoint;
    [SerializeField] private GameObject hidenGround;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private List<GameObject> listMap;
    [SerializeField] private GameObject player;
    private int currentLv;
    private bool enableToNextLv;
    
    private bool isHiden;
    private void Awake() 
    {
        currentLv = 0;
        ChangeMap(currentLv);
        enableToNextLv = true;
        Instantiate(player, Vector3.zero, Quaternion.identity);
    }

    private void Start() 
    {
        Instantiate(enemy1, enemy1SpawnPoint.position, Quaternion.identity);   
        StartCoroutine(SpawnEnemy2()); 
        isHiden = false;
        if(hidenGround != null)
        {
            StartCoroutine(Hide());
        }
    }

    private IEnumerator SpawnEnemy2()
    {
        while(PlayerStatus.Instance.getCurrentHealth() > 0)
        {
            for(int i = 0; i < 3; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-9f, 9f), 9f, 0f);
                Instantiate(enemy2, spawnPos, Quaternion.identity);
                
                yield return new WaitForSeconds(3f);
            }
        
            yield return new WaitForSeconds(15f);
        }
    }

    private IEnumerator Hide()
    {
        while(true)
        {
            hidenGround.SetActive(!isHiden);
            isHiden = !isHiden;

            yield return new WaitForSeconds(2f);
        }
    }

    private void Update() 
    {
        if(PlayerStatus.Instance.getCoin() %10 == 0 && PlayerStatus.Instance.getCoin() != 0 && enableToNextLv)
        {
            enableToNextLv = false;
            ChangeMap(currentLv);
        }
        if(PlayerStatus.Instance.getCoin()%5 == 0 && PlayerStatus.Instance.getCoin()%10 != 0)
        {
            enableToNextLv = true;
        }
    }

    private void ChangeMap(int index)
    {
        var thisMap = GameObject.FindGameObjectWithTag("Map");
        if(thisMap != null)
        {
            Destroy(thisMap);
        }
        var currentMap = Instantiate(listMap[index], Vector3.zero, Quaternion.identity);
        enemy1SpawnPoint = currentMap.transform.GetChild(3).transform;
        currentLv += 1;
    }
}
