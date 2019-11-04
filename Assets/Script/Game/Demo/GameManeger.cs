using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour {
	
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject enemy;

    Vector3 setPos = new Vector3(0, 1.55f, 0);

    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + setPos;


        if ( Data.lookItem( "phone" ) ) { 
                enemy.SetActive( true );
        }
	}
}
