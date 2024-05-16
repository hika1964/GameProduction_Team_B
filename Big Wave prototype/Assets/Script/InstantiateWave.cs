using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWave : MonoBehaviour
{
    [SerializeField] GameObject wave;//波のプレハブ
    [SerializeField] float waveIntervalTime = 0.1f;//波の出現間隔
    private float waveTime = 0f;//波の出現間隔を管理する時間
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate_Wave();//波の生成   
    }

    //波の生成
    //waveIntervalの時間ごとに波を生成する
    void Instantiate_Wave()
    {
        waveTime += Time.deltaTime;
        if (waveTime > waveIntervalTime)
        {
            Vector3 wavecurrentpos = transform.position;
            wavecurrentpos.y = 0.04f;
            waveTime = 0f;
            Instantiate(wave, wavecurrentpos, transform.rotation);
        }
    }
}
