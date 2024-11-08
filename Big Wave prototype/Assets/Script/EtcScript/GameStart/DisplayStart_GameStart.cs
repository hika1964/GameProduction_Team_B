using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山詩恩
//ゲームスタート時のスタートの瞬間の演出
public class DisplayStart_GameStart : MonoBehaviour
{
    [Header("表示させるテキスト")]
    [SerializeField] TMP_Text countDownText;//表示させるテキスト
    [Header("ゲーム開始時に表示する文字")]
    [SerializeField] string startText;//ゲーム開始時に表示する文字
    [Header("ゲーム開始の文字を出す時間")]
    [SerializeField] float displayTime_GameStart;//ゲーム開始の文字を出す時間
    [Header("ゲーム開始した瞬間に出す効果音")]
    [SerializeField] AudioClip gameStartSoundEffect;//ゲーム開始した瞬間に出す効果音
    private float remainingdisplayTime_GameStart;//ゲーム開始の文字を出す残り時間
    JudgeGameStart judgeGameStart;
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        judgeGameStart = GameObject.FindWithTag("GameStartManager").GetComponent<JudgeGameStart>();
        remainingdisplayTime_GameStart = displayTime_GameStart;//ゲーム開始の文字を出す残り時間を設定
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGameStart();
    }

    public void DisplayGameStart_Moment()//ゲーム開始した瞬間に一度だけ呼ばれる処理
    {
        countDownText.text = startText;//ゲーム開始の文字が出る
        audioSource.PlayOneShot(gameStartSoundEffect);//ゲーム開始時の効果音を出す
    }

    void DisplayGameStart()//ゲームが開始してからしばらくゲームスタートの文字を画面に表示する
    {
        bool display = countDownText.enabled;//文字を表示しているか

        if (!(judgeGameStart.IsStarted)||!display) return;//ゲームが開始していないもしくは文字が非表示になっている時以下の処理を呼ばない

        remainingdisplayTime_GameStart -= Time.deltaTime;//ゲーム開始の文字を出す残り時間を更新

        if (remainingdisplayTime_GameStart <= 0)//ゲーム開始の文字を出す残り時間がなくなったら
        {
            countDownText.enabled = false;//文字を非表示
        }
    }
}
