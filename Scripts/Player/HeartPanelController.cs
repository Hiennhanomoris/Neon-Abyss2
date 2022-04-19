using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartPanelController : MonoBehaviour
{
    public static HeartPanelController heartPanelController;
    [SerializeField] private Image[] hearts;
    [SerializeField] private List<Image> listHeart;  
    
    private void Awake() {
        heartPanelController = this;
    }
    private void Start() 
    {
        listHeart = new List<Image>();
        LoadHeart();    
    }     

    private void AddHeart(Image image)
    {
        Image heart = Instantiate(image, transform.position, Quaternion.identity);
        listHeart.Add(heart);
        heart.transform.SetParent(transform);
        heart.transform.localScale = transform.localScale;
    }

    private void LoadHeart()
    {
        for(int i = 0; i < PlayerStatus.Instance.getMaxHealth()/2; i++)
        {
            AddHeart(hearts[0]);
        }
        if(PlayerStatus.Instance.getMaxHealth()%2 != 0)
        {
            AddHeart(hearts[1]);
        }
    }

    public void ChangeHeart()
    {
        //Debug.Log(PlayerStatus.Instance.getCurrentHealth());
        for(int i = 0; i < listHeart.Count; i++)
        {
            if(i < PlayerStatus.Instance.getCurrentHealth()/2)
            {
                listHeart[i].sprite = hearts[0].sprite;
            }
            else if(i == PlayerStatus.Instance.getCurrentHealth()/2 && PlayerStatus.Instance.getCurrentHealth() != 0)
            {
                if(PlayerStatus.Instance.getCurrentHealth()%2 != 0)
                {
                    listHeart[i].sprite = hearts[1].sprite;
                }
                else 
                {
                    listHeart[i].sprite = hearts[2].sprite;
                }
            }
            else
            {
                listHeart[i].sprite = hearts[2].sprite;
            }
        }
    }
}
