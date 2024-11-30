using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//敵の死亡モーション
//数秒モーションさせた後、爆発させてモデルの方を非表示にする
public class EnemyDeadMotion : MonoBehaviour
{
    [SerializeField] Animator _enemy_animator;
    [SerializeField] string _deadTriggerName;
    [Header("敵のモデル")]
    [SerializeField] HideObject _enemy;
    [Header("水しぶき")]
    [SerializeField] HideObject _waterSplash;
    bool _startMotion=false;

    public void Trigger()
    {
        _enemy_animator.SetTrigger(_deadTriggerName);
        _startMotion = true;
    }

    void Update()
    {
        _enemy.UpdateDeleteTime(_startMotion);
        _waterSplash.UpdateDeleteTime(_startMotion);
    }



    [System.Serializable]
    class HideObject
    {
        [SerializeField] GameObject _hideObject;
        [Header("何秒後に消すか")]
        [SerializeField] float _hideTime;
        float _currentDeleteTime = 0;

        public void UpdateDeleteTime(bool start)
        {
            if (!start) return;

            _currentDeleteTime += Time.deltaTime;

            if (_currentDeleteTime >= _hideTime)
            {
                _hideObject.SetActive(false);
            }
        }
    }
}


