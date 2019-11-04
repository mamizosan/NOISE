using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeDoor : MonoBehaviour {

    //シーン移動　ActiveSwitchを取得
    ActiveSwitch activeswitch = new ActiveSwitch();

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Data.lookItem( "DummyKey" ) )
        {
            Debug.Log("bbbbb");

            activeswitch.SceneUpdate("GameClear");

        }
    }

}

