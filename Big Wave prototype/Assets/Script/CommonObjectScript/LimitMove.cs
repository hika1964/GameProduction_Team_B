using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMove : MonoBehaviour
{
    //☆塩が書いた
    MoveManager movemanager;

    // Start is called before the first frame update
    void Start()
    {
        movemanager = GameObject.FindWithTag("MoveManager").GetComponent<MoveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLimit();//キャラの動きの制限
    }


    //キャラの動きの制限
    //Movemanagerのlimitrangeの値で動ける範囲が決まる
    void MoveLimit() 
    {
        Vector3 currentPlayerPos = transform.position;
        currentPlayerPos.x = Mathf.Clamp(currentPlayerPos.x, -movemanager.LimitRange, movemanager.LimitRange);
        transform.position = currentPlayerPos;
    }

}
