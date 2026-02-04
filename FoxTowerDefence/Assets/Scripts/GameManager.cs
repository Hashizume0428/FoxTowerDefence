using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTime=60f;
    [SerializeField] private float gameTimer;
    [SerializeField] private GameObject timerText;

    public static bool GameIsComplete = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameTimer = gameTime;
        SoundsManager.I.PlayBGM(BGMType.IngameTheme);
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount();
    }
    void TimeCount()
    {
        gameTimer -= Time.deltaTime;
        TimeText();
        if (gameTimer <= 0f)
        {
            Debug.Log("Game End");
            GameEnd();
        }
    }
    void TimeText()
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
        
        textComponent.text = "Time: " + Mathf.CeilToInt(gameTimer).ToString() + "s";
    }
    void GameEnd()
    {
        SceneManager.LoadScene("ClearResultScene");
    }
    public void GameOver()
    {
        GameIsComplete = false;
        SceneManager.LoadScene("GameOverResultScene");
    }
}
