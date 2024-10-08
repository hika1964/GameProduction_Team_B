using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_TrickCount : Score
{
    [Header("トリック一回ごとのスコア量")]
    [SerializeField] float scorePerOneTrick;//トリック一回ごとのスコア量
    private static float score_TrickCount = 0;//トリック回数のスコア

    public static float ScoreTrickCount
    {
        get { return score_TrickCount; }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore()//スコア加算(1回トリックをするごとに呼ぶ)
    {
        score += scorePerOneTrick;
    }

    public override void ReflectScore()//トリック回数のスコアを反映
    {
        score_TrickCount=score;
    }
}
