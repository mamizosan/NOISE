using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLight : MonoBehaviour {


    //ライトの点滅
    [SerializeField]
    Light blueLight;
    bool lightCount;
    //点滅時間
    [SerializeField]
    float lightTime = 0.1f;
    //明るさ
    [SerializeField]
    float lightPower = 1f;
    //大きさ
    [SerializeField]
    float lightSize = 50f;


    // Use this for initialization
    void Start()
    {
        blueLight = GetComponent<Light>();
        lightCount = true;
        blueLight.range = lightSize;
    }

    //ライトの点滅
    public void LightFlashing()
    {
        switch (lightCount)
        {
            //時間ごとにライトを暗くする
            case true:
                if (blueLight.intensity > 0)
                {
                    blueLight.intensity -= lightTime;
                }
                else
                {
                    lightCount = false;

                }
                break;

            //時間ごとにライトを明るくする
            case false:
                if (blueLight.intensity < lightPower)
                {
                    blueLight.intensity += lightTime;
                }
                else
                {
                    lightCount = true;
                }
                break;
        }


    }

    void Update()
    {
        LightFlashing();
    }
}
