using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCanvas {

   static bool open_item_canvas = false;

    static string[ ] ItemList = { "diagnosisroom_key", "exit_key", "locker_key", "mes", "nurse_note", "nurse_note_page", "operating_key" };
    static GameObject canvas = GameObject.Find( "UI" ).transform.Find( "Item" ).gameObject;

    public static void itemCanvasPlay(  ) {
        canvas.SetActive( true );
        setImage( );
        open_item_canvas = true;
    }

    public static void itemCanvasExit( ) {
        canvas.SetActive(false);
        open_item_canvas = false;
    }

    public static bool getItemCanvas( ) {
        return open_item_canvas;
    }

    static void setImage( ) {
        for ( int i = 0; i < 7; i++ ) {
            GameObject Image = canvas.transform.Find( ItemList[i] ).gameObject;
            if ( Data.lookItem( ItemList[ i ] ) ) {
                Image.SetActive( true );
            } else {
                Image.SetActive( false );
            }
        }
    }

}
