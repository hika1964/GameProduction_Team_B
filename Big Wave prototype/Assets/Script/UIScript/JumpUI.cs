using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUI : MonoBehaviour
{
    [SerializeField] float Move_Y = 2f; // 目的のY座標
    [SerializeField] float MoveSpeed = 1f; // 補間速度

    private Vector3 startPos;
    private Vector3 targetPos;
    private float lerpTime;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, Move_Y, 0);
    }

    void Update()
    {
        if (lerpTime < 1f)
        {
            lerpTime += MoveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, targetPos, lerpTime);
        }
    }
}
