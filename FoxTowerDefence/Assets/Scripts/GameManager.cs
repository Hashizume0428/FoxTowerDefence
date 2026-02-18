using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int gameTime = 60;
    [SerializeField] private int currentTime;
    [SerializeField] private GameObject timerText;

    public static bool GameIsComplete = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundsManager.I.PlayBGM(BGMType.IngameTheme);
        StartCoroutine(TimerCoroutine());
    }

    // Update is called once per frame
    // void Update()
    // {
    //     TimeCount();
    // }
    // void TimeCount()
    // {
    //     gameTimer -= Time.deltaTime;
    //     TimeText();
    //     if (gameTimer <= 0f)
    //     {
    //         Debug.Log("Game End");
    //         GameEnd();
    //     }
    // }
    IEnumerator TimerCoroutine()
    {
        int currentTime = gameTime;
        TimeText(currentTime);

        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            TimeText(currentTime);
        }
        yield return new WaitForSeconds(1f);
        GameClear();
    }

    void TimeText(int _currentime)
    {
        if (timerText == null)
        {
            Debug.LogError("timerTextがインスペクターで割り当てられていません");
            return;
        }
        
        TextMeshProUGUI textComponent = timerText.GetComponent<TextMeshProUGUI>();
        if (textComponent == null)
        {
            Debug.LogError("timerTextのGameObjectにTextMeshProUGUIコンポーネントが付いていません");
            return;
        }
        
        textComponent.text = "Time: " + _currentime.ToString() + "s";
    }

    void GameClear()
    {
        SceneManager.LoadScene("ClearResultScene");
    }

    public void GameOver()
    {
        GameIsComplete = false;
        SceneManager.LoadScene("GameOverResultScene");
    }
}
