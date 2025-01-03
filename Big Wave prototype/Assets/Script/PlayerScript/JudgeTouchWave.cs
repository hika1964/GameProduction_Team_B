using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//波に触っているか判断
public class JudgeTouchWave : MonoBehaviour
{
    public event Action<bool> SwitchTouchNowAction;//波の接触状態が切り替わった時に呼ぶ(trueだと触れた、falseだと離れた)
    public event Action TouchAction;//波に触れた瞬間に呼ぶ
    public event Action LeaveAction;//波から離れた瞬間に呼ぶ
    [SerializeField] OnTriggerActionEvent onTriggerActionEvent;
    [SerializeField] float touchBorderTime = 0.1f;//触った・触ってないの境界の時間
    private bool touchWaveNow=false;//今波に触っているか
    private float sinceLastTouchWaveTime = 0.1f;//最後に波に触ってからの時間
   
    public bool TouchWaveNow
    {
        get { return touchWaveNow; }
    }

    void Start()
    {
        onTriggerActionEvent.EnterAction += TouchWave;
        sinceLastTouchWaveTime = touchBorderTime;
    }

    void Update()
    {
        JudgeTouchWaveNow();//波に触れているか判定
    }

    public void TouchWave(Collider c)
    {
        if (c.gameObject.CompareTag("InsideWave") || c.gameObject.CompareTag("OutsideWave"))
        {
            sinceLastTouchWaveTime = 0f;//最後に波に触ってからの時間を更新
            touchWaveNow = true;
            //登録した処理を呼ぶ
            TouchAction?.Invoke();
            SwitchTouchNowAction?.Invoke(true);
        }
    }

    void JudgeTouchWaveNow()//波に触れているか判定
    {
        if (!touchWaveNow) return;

        sinceLastTouchWaveTime += Time.deltaTime;

        //最後に波に触れてからtouchBorderTime秒以上経ったら波から離れた判定とする
        if(sinceLastTouchWaveTime >= touchBorderTime)
        {
            touchWaveNow = false;
            //登録した処理を呼ぶ
            LeaveAction?.Invoke();
            SwitchTouchNowAction?.Invoke(false);
        }
    }
}
