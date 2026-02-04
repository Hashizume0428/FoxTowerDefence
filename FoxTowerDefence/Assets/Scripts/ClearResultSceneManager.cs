using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClearResultSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundsManager.I.PlayBGM(BGMType.ClearTheme);
    }

    void Update()
    {
        
    }
    public void OnTittleButton()
    {
        SoundsManager.I.PlaySE(SEType.ButtonClick);
        SceneManager.LoadScene("TittleScene");
    }
    public void OnGameButton()
    {
        SoundsManager.I.PlaySE(SEType.ButtonClick);
        SceneManager.LoadScene("GameScene");
    }
}

