using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static string UI_GO_NAME = "UICanvas";
    public static string SCORE_TEXT_GO_NAME = "ScoreText";
    public static string GAME_OVER_UI_NAME = "GameOverUI";

    public bool isGameOver = false;

    private GameObject scoreTextGO;
    private GameObject gameOverUI;
    private int score = 0;

    public class A
    {

    }

    public A a;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //Initialize
            isGameOver = false;
            GameObject uiGO = Functions.GetRootGameObject(UI_GO_NAME);
            scoreTextGO = Functions.FindChildGameObject(uiGO, SCORE_TEXT_GO_NAME);
            gameOverUI = Functions.FindChildGameObject(uiGO, GAME_OVER_UI_NAME);
            gameOverUI.SetActive(false);

            score = 0;
        }
        else
        {
            Functions.LogWarning("두 개 이상의 GameManager가 씬에 존재");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //게임 재시작
        if (isGameOver && Input.GetMouseButton(0))
        {
            Functions.LoadScene(Functions.GetActiveScene().name);
        }
    }

    public void AddScore(int addition)
    {
        if (isGameOver)
            return;

        score += addition;
        scoreTextGO.SetTMPText($"Score : {score}");
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);
    }
}
