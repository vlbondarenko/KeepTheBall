using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class GetBallButton : MonoBehaviour
{
    public string zoneId;
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        if (_button) _button.onClick.AddListener(delegate () { ShowAdPlacement(); });
    }
    void Update()
    {
        if (_button)
        {
            if (string.IsNullOrEmpty(zoneId)) zoneId = null;
            _button.interactable = Advertisement.IsReady(zoneId);
        }
    }
    void ShowAdPlacement()
    {
        if (string.IsNullOrEmpty(zoneId)) zoneId = null;
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show(zoneId, options);
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                    PlayerPrefs.SetInt("selectBall", 1);
                   
                
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                break;
        }
    }
}