using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOfBullet : MonoBehaviour
{
    //☆塩が書いた
    [SerializeField] float damage;//ダメージ量
    [SerializeField] bool ifHitDestroy=true;//プレイヤーに当たった時に弾を消すか
    Player player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.CompareTag("Player"))
        {
            player= t.GetComponent<Player>();

            if(player.Barrier==false)//無敵状態じゃない時プレイヤーにダメージを与える
            {
                player.Hp -= damage;
            }

            if(ifHitDestroy)//trueかつ当たった時弾が消える
            {
                Destroy(gameObject);
            }
        }
    }
}
