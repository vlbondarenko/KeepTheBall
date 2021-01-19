using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public float speedTime;
    bool musOn;
    public LevelMenu save;

    public void NumberLevel(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = speedTime;
        musOn = true;
        save.savePosition();
    }

	void Update () {
        if (musOn == true && PlayerPrefs.GetString("Music") == "yes")
        {
            GameObject.Find("ClickAudio").gameObject.GetComponent<AudioSource>().Play();
            musOn = false;
        }
    }
}
