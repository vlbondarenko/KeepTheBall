using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Buttons : MonoBehaviour
{
    public GameObject ExitPanel;//панель выхода в меню
    public GameObject HelpPanel,noAdsPanel,shopPanel;//панель помощи
    bool musOn;
    public GameObject musicOn,musicOff;//спрайты musOn musOf
    public string first;
    public Button ads;
   



    public void Awake()
    {
        if (PlayerPrefs.GetInt(first) == 0)
        {
            PlayerPrefs.SetString("Music", "yes");
            PlayerPrefs.SetInt(first, 1);
            PlayerPrefs.Save();
        }
    }

   
    void Start()//метод отображающий спрайт звука при перезагрузке игры
    {
        if (PlayerPrefs.GetString("Music") == "no")
        {
           
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else if(PlayerPrefs.GetString("Music") == "yes")
        {
          
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }

    public void  OnClickMusic()//метод кнопки "Музыка"
    {
        if (PlayerPrefs.GetString("Music") != "no")
        {
            PlayerPrefs.SetString("Music", "no");
            musicOn.SetActive(false);
            musicOff.SetActive(true);
            musOn = true;
        }
        else
        {
            PlayerPrefs.SetString("Music", "yes");
            musicOn.SetActive(true);
            musicOff.SetActive(false);
           
        }
       
        
    }


    public void OnClickPlay()//кнопка Play в главном меню
    {
        PlayerPrefs.SetFloat("m", 0);
        PlayerPrefs.SetFloat("mZ", 0);
        PlayerPrefs.SetFloat("mV", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        musOn = true;
    }


    public void OnClickYes()//кнопка выйти в главном меню
    {
        Application.Quit();
        musOn = true;
    }

    public void OnClickNo()//закрыть панель выхода
    {
        ExitPanel.SetActive(false);
        musOn = true;
    }
     
    public void OnClickHelp()//кнопка "?"
    {
        if (HelpPanel.activeSelf == false)
        {
            HelpPanel.SetActive(true);
        }
        musOn = true;
    }
    public void OnClickClose()
    {
        HelpPanel.SetActive(false);
        musOn = true;    
}
    public void OnclickNoAds()
    {
        noAdsPanel.SetActive(true);
        musOn = true;
    }

    public void OnclickCloseNoAdsPanel()
    {
        noAdsPanel.SetActive(false);
        musOn = true;
    }
    public void OnclickShopPanel()
    {
        shopPanel.SetActive(true);
        musOn = true;
    }
    public void OnclickCloseShopPanel()
    {
        shopPanel.SetActive(false);
        musOn = true;
    }



    void Update()
    { Time.timeScale = 1;
        if (musOn == true&&PlayerPrefs.GetString("Music")=="yes")
        {
            GameObject.Find("ClickAudio").gameObject.GetComponent<AudioSource>().Play();
            musOn = false;
        }

       
        if (PlayerPrefs.GetString("noAds") == "yes")
        {
            ads.interactable = false;      
        }

        if (Input.GetKeyDown(KeyCode.Escape) && ExitPanel.activeSelf == false&& HelpPanel.activeSelf == false)
        {
            ExitPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitPanel.SetActive(false);
        }
        if (HelpPanel.activeSelf == true&& Input.GetKeyDown(KeyCode.Escape))
        {
            HelpPanel.SetActive(false);
        }
    }

}
