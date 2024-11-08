using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    //☆作成者:杉山
    [Header("波の生成位置")]
    [SerializeField] GameObject instantiateWavePos;//波の生成位置
    [Header("波のプレハブ")]
    [SerializeField] GameObject wavePrefab;//波のプレハブ
    [Header("初期以降の波の出現間隔")]
    [SerializeField] float waveInterval;//初期以降の波の出現間隔
    [Header("初期の波の出現間隔")]
    [Tooltip("ゲーム開始から1個目の波を出現させるまでの時間。1個目の波を生成したらそれ以降は上の初期以降の波の出現間隔に合わせて波を生成する")]
    [SerializeField] float firstWaveInterval;//初期の波の出現間隔
    [Header("GamePos")]
    [SerializeField] GameObject gamePos;//GamePos
    private float m_waveTime;//波の出現間隔を管理する時間(内部数値)
    JudgeGameStart judgeGameStart;
  [SerializeField]  LineInstantiate line;
    // Start is called before the first frame update
    void Start()
    {
       
        judgeGameStart=GameObject.FindWithTag("GameStartManager").GetComponent<JudgeGameStart>();
       
        //初期の波の出現間隔に合わせるために波の出現間隔を管理する時間をその分ずらす
        m_waveTime = 0 - (firstWaveInterval - waveInterval);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateWavePrefab();//波の生成
    }

    //波の生成、waveIntervalTimeの時間ごとに波を生成する
    void InstantiateWavePrefab()
    {
        if (!judgeGameStart.IsStarted) return;//まだゲーム開始されてなかったら波を生成しない

        m_waveTime += Time.deltaTime;//波の出現間隔を管理する時間を更新

        if (m_waveTime > waveInterval)
        {
            m_waveTime = 0f;//波の出現間隔を管理する時間をリセット
            GameObject wave = Instantiate(wavePrefab, instantiateWavePos.transform.position, transform.rotation, gamePos.transform);//波を生成
            wave.transform.localRotation = Quaternion.Euler(0, 180, 0);//波を後ろ向き(プレイヤー方向)にする
            if (line != null)
            {
                line.LineSet(wave.transform);
            }
        }
    }
}
