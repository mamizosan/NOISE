using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookDoor : MonoBehaviour {

    [SerializeField]
    string keyName;
    Data dara;

	Animator _animator;

	void Start() {
	
		_animator = GetComponent<Animator> ();
	
	}

    //扉を開ける
    private void OnTriggerStay(Collider other){
        Debug.Log( other.gameObject.tag );
        if ( !Data.lookItem(keyName) ) {
            return;
        }
        if (other.gameObject.tag == "Player" ) {
            if( Input.GetButtonDown( "Space" ) ) {
                if( !Data.lookDoor( this.name ) ) {
                    Data.openDoor( this.name );

					Anim ();
                }
            }
        } else if(other.gameObject.tag == "Enemy") {
			
			Anim ();
        }
    }


	private void Anim() {

		_animator.Play ("Door",0 ,0.0f);

	}

}
