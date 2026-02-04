using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundsManager.I.PlayBGM(BGMType.TittleTheme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartButton()
    {
        SoundsManager.I.PlaySE(SEType.ButtonClick);
        SceneManager.LoadScene("GameScene");
    }
}
