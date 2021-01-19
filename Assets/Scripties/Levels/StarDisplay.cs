using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//***********************     Скрипт отображения количества звезд в меню уровней         ***********************
public class StarDisplay : MonoBehaviour {

    public string keyName="S"; // текстовый ключ для сохранения в реестре 
    private Image[] starScore;// массив спрайтов
    public Button[] btns; // массив кнопок
    public int levelChng = 0;// разблокирование следующего уровня при наборе 1,2 или 3 звезд
    public int numLev=1;
    void Awake() // метод для взятия компонентов картинок
    {
        starScore = GetComponentsInChildren<Image>();

    }

    void Start () {
       
        if (PlayerPrefs.GetInt(keyName) == 3)//если в реестре для данного уровня сохранено число 3 то отображать 3 звезды, разблокировать след уровень
        {
            int unlockLevel = levelChng + 1;
            btns[unlockLevel].interactable = true;
            starScore[1].color = new Color(starScore[1].color.r, starScore[1].color.g, starScore[1].color.b, 255);
            starScore[2].color = new Color(starScore[2].color.r, starScore[2].color.g, starScore[2].color.b, 255);
            starScore[3].color = new Color(starScore[3].color.r, starScore[3].color.g, starScore[3].color.b, 255);
           
        }
        if (PlayerPrefs.GetInt(keyName) == 2)
        {
            int unlockLevel = levelChng + 1;
            btns[unlockLevel].interactable = true;
            starScore[1].color = new Color(starScore[1].color.r, starScore[1].color.g, starScore[1].color.b, 255);
            starScore[2].color = new Color(starScore[2].color.r, starScore[2].color.g, starScore[2].color.b, 255);

        }
        if (PlayerPrefs.GetInt(keyName) == 1)
        {
            int unlockLevel = levelChng + 1;
            btns[unlockLevel].interactable = true;
            starScore[1].color = new Color(starScore[1].color.r, starScore[1].color.g, starScore[1].color.b, 255);



        }

    }
}
