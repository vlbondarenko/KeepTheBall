using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Konveer : MonoBehaviour {
    public Vector3 newPosition;
    public Transform newRotation;
    public string predName;
    public bool pref;
    public Interface reload;//переменная для определения первый раз ли запускалась игра;отработка нажатия на кнопку Again на панели финиша
    public int level;
    public float speedSurf;

   
    public void Awake()
    {
        if (PlayerPrefs.GetInt(reload.first) == 0)
        {
            newPosition = transform.position;
            PlayerPrefs.SetFloat(predName, newPosition.x);
            PlayerPrefs.SetFloat(predName + "P", newPosition.y);
            PlayerPrefs.SetFloat(predName + "R", newRotation.eulerAngles.z);
            PlayerPrefs.SetFloat(predName + "s", GetComponent<SurfaceEffector2D>().speed);
            PlayerPrefs.Save();
        }

    }
    void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat(predName), PlayerPrefs.GetFloat(predName + "P"), transform.position.z);

        GetComponent<SurfaceEffector2D>().speed = PlayerPrefs.GetFloat(predName + "s");
        transform.Rotate(new Vector3(0, 0, PlayerPrefs.GetFloat(predName + "R")), Space.Self);


    }
    public void KonvsavePosition()
    {
        newPosition = transform.position;

        PlayerPrefs.SetFloat(predName, newPosition.x);
        PlayerPrefs.SetFloat(predName + "P", newPosition.y);
        PlayerPrefs.SetFloat(predName + "R", newRotation.eulerAngles.z);
        PlayerPrefs.SetFloat(predName + "s", GetComponent<SurfaceEffector2D>().speed);
        PlayerPrefs.Save();

    }

    void Update()
    {
       
        if (reload.raz == true)
        {
            PlayerPrefs.SetFloat(predName + "s", GetComponent<SurfaceEffector2D>().speed);
            KonvsavePosition();
            SceneManager.LoadScene(level);

        }
        else if (reload.raz1 == true)
        {
            PlayerPrefs.SetFloat(predName + "s", GetComponent<SurfaceEffector2D>().speed);
            KonvsavePosition();


        }
    }
}
