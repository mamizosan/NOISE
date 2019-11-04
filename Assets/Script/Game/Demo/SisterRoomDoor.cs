using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterRoomDoor : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if( other.gameObject.tag == "Enemy" ) {
            Destroy( this.gameObject );
        }
    }
}
