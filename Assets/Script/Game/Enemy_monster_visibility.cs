using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_monster_visibility : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Enemy_Monster.visibility = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if( other.gameObject.tag == "Player" ) {
            Enemy_Monster.visibility = false;
        }
    }
}
