using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainText : MonoBehaviour {

    [SerializeField]
    private Text text;
    bool itemHit = false;

    private void OnWillRenderObject( )   {
        if ( itemHit ) {
            text.text = this.name + "\n〇で拾う";
            if ( Input.GetButton( "Space" ) ) {
                Data.getItem( this.name );
                text.text = "";

                Destroy( this.gameObject );
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            itemHit = true;
        }
    }

    //アイテムに触れるのをやめたとき
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            itemHit = false;
        }
    }
}
