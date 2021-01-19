using UnityEngine;
using System.Collections;

public class TakeBall: MonoBehaviour {
    public GameObject icon;
    public Sprite[] balls;
    public GameObject watchVideoPanel;
    public int numberBall;
    public int selectBall;

	
	void Start () {
       
	}
	
   
    public void OnClickClose()
    {
        watchVideoPanel.SetActive(false);
 

    }
    public void OnClickSelect()
    {
        watchVideoPanel.SetActive(false);
        PlayerPrefs.SetInt("selectBall", selectBall);
        PlayerPrefs.SetInt("numberBall", numberBall);
       
    }



    void Update()
    {
     

        if (PlayerPrefs.GetInt("openBall") == 5&& PlayerPrefs.GetInt("watch") == 0)
        {
            watchVideoPanel.SetActive(true);
            icon.GetComponent<SpriteRenderer>().sprite = balls[0];
            PlayerPrefs.SetInt("watch", PlayerPrefs.GetInt("watch")+1);
            icon.GetComponent<SpriteRenderer>().color = new Color(0.78f, 1f, 0.83f);
            selectBall = 2;
            numberBall = 2;
        }
        else if (PlayerPrefs.GetInt("openBall") == 15 && PlayerPrefs.GetInt("watch") == 1)
        {
            watchVideoPanel.SetActive(true);
            icon.GetComponent<SpriteRenderer>().sprite = balls[1];
            PlayerPrefs.SetInt("watch", PlayerPrefs.GetInt("watch") + 1);
            selectBall = 3;
            numberBall = 3;
        }
        else if (PlayerPrefs.GetInt("openBall") == 25 && PlayerPrefs.GetInt("watch") == 2)
        {
            watchVideoPanel.SetActive(true);
            icon.GetComponent<SpriteRenderer>().sprite = balls[2];
            PlayerPrefs.SetInt("watch", PlayerPrefs.GetInt("watch") + 1);
            selectBall = 5;
            numberBall = 5;
        }
        else if (PlayerPrefs.GetInt("openBall") == 35 && PlayerPrefs.GetInt("watch") == 3)
        {
            watchVideoPanel.SetActive(true);
            icon.GetComponent<SpriteRenderer>().sprite = balls[3];
            icon.GetComponent<SpriteRenderer>().color = new Color(0.96f, 0.8f, 0.556f);
            PlayerPrefs.SetInt("watch", PlayerPrefs.GetInt("watch") + 1);
            selectBall = 6;
            numberBall = 6;
        }




    }
}
