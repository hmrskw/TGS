using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataManager : MonoBehaviour {
    [SerializeField,Tooltip("時間制限")]
    int timeLimit;

    [SerializeField]
    GameObject inGamePanel;

    [SerializeField]
    Text timeText;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    GameObject resultPanel;

    [SerializeField]
    Text resultScoreText;

    [SerializeField]
    Text resultExplosionNumText;

    //経過時間
    float time;
    //獲得した得点
    int score;
    //爆発させた花火
    int explosionNum;

    //ゲームが終了しているか
    bool isGameEnd;
    public bool IsGameEnd{get {return isGameEnd;}}

    // Use this for initialization
    void Start () {
        resultPanel.SetActive(false);
        inGamePanel.SetActive(true);
        isGameEnd = false;
        time = 0;
        score = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (!isGameEnd)
        {
            time += Time.deltaTime;
            if (timeLimit > time)
            {
                timeText.text = "残り時間:" + (timeLimit - (int)time).ToString().PadLeft(2, '0');
            }
            else
            {
                timeText.text = "残り時間:00";
                isGameEnd = true;
            }

            scoreText.text = "スコア:" + score.ToString().PadLeft(3, '0');
        }
        else
        {
            if (!resultPanel.activeInHierarchy)
            {
                GameObject[] gos;
                gos = GameObject.FindGameObjectsWithTag("FireWorksSeed");

                if (gos.Length == 0)
                {
                    inGamePanel.SetActive(false);
                    resultScoreText.text = "スコア:" + score.ToString().PadLeft(3, '0');
                    resultExplosionNumText.text = "爆発させた花火の数:" + explosionNum.ToString().PadLeft(2, '0');
                    resultPanel.SetActive(true);
                }            }
        }
    }

    public void AddScore(int score)
    {
        explosionNum++;
        this.score += score;
    }
}
