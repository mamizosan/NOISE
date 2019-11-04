using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    
    //シーン移動　ActiveSwitchを取得
    ActiveSwitch activeswitch;

    // Use this for initialization
    void Start()
    {
        activeswitch = new ActiveSwitch();
    }

    // Update is called once per frame
    void Update( ) {
        if ( Input.GetButtonDown( "Space" ) ) {
            TitelSwitch( );
        }
    }
    //タイトルシーンに移動
    public void TitelSwitch( )
    {
        activeswitch.SceneUpdate("Title_Scene");
    }

   
}
