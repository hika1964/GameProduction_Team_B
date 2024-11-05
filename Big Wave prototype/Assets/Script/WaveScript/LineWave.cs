using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWave : MonoBehaviour
{
    private LineInstantiate m_lineInstantiate;

    //生成時に呼び出す
    public void Method1(LineInstantiate lineInstantiate)
    {
        m_lineInstantiate = lineInstantiate;
    }

    //消去時に呼び出す
    public void Method2()
    {
        m_lineInstantiate.Method2();
    }
}
