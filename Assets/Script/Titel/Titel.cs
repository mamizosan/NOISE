using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Titel : MonoBehaviour{

    //シーン移動　ActiveSwitchを取得
    ActiveSwitch activeswitch;
    

    void Start()
    {
        activeswitch = new ActiveSwitch();
    }

    private void Update( ) {
        if ( Input.GetButtonDown( "Space" ) ) {
            TitelSwitch( );
        }
    }

    //チュートリアルシーンに移動
    public void TitelSwitch(  )
    {
        activeswitch.SceneUpdate("Tutorial_Scene");
    }

}
