using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoA : MonoBehaviour {

    //シーン移動　ActiveSwitchを取得
    ActiveSwitch activeswitch;

    // Use this for initialization
    void Start()
    {

        activeswitch = new ActiveSwitch();

    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Space"))
        {
            TitelSwitch();
        }
    }
    //タイトルシーンに移動
    public void TitelSwitch()
    {
        activeswitch.SceneUpdate("GameClear");
    }

}
