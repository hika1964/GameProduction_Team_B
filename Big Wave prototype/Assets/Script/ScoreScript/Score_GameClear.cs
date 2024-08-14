using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_GameClear : Score
{
    [Header("ゲームクリア時のスコア量")]
    [SerializeField] float score_GameClear;//ゲームクリア時のスコア量
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReflectScore(bool gameClear)//クリア時にゲームクリアボーナスのスコアを反映
    {
        if(gameClear)//クリア時
        {
            score += score_GameClear;
        }
        else//ゲームオーバー時
        {
            score = 0;
        }

        Score_GameClear = score;
    }
}
