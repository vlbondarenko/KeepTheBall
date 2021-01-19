using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fan : MonoBehaviour {


    public Interface reload;
    public Vector3 newPosition;
    public string predName;
    public Transform newRotation;
    public int numLevel;

    public void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat(predName), PlayerPrefs.GetFloat(predName + "F"), transform.position.z);

        transform.Rotate(new Vector3(0, 180, PlayerPrefs.GetFloat(predName + "A")), Space.Self);

    }

    public void Awake()

    {
        if (PlayerPrefs.GetInt(reload.first) == 0)
        {
            newPosition = transform.position;
            PlayerPrefs.SetFloat(predName, newPosition.x);
            PlayerPrefs.SetFloat(predName + "F", newPosition.y);
            PlayerPrefs.SetFloat(predName + "A", newRotation.eulerAngles.z);
            PlayerPrefs.Save();
        }
    }

    public void savePosition()
    {
        newPosition = transform.position;
        PlayerPrefs.SetFloat(predName, newPosition.x);
        PlayerPrefs.SetFloat(predName + "F", newPosition.y);
        PlayerPrefs.SetFloat(predName + "A", newRotation.eulerAngles.z);
        PlayerPrefs.Save();

    }


    void Update () {
        Debug.Log(PlayerPrefs.GetFloat(predName + "A"));
        if (reload.raz == true)
        {
            savePosition();
            SceneManager.LoadScene(numLevel);
        }
      else  if (reload.raz1 == true)
        {
            savePosition();
        }
    }
}
