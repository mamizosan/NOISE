using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSwitch : MonoBehaviour{

    private void Update( ) {
        if ( Input.GetKeyDown( KeyCode.Escape ) ) { 
            Application.Quit( );    
        }
    }

    private void unLoadScene( ) { 
        int cnt = 0;
        int max_scene = SceneManager.sceneCount;
        for( int i = 0; i < max_scene; i++ ) {
            Scene scene = SceneManager.GetSceneAt( i );
            if( scene.name != "Active_Scene" ) {
                if( cnt == i ) {
                   SceneManager.LoadScene( "Active_Scene" );
                    return;
                }
                SceneManager.UnloadSceneAsync( scene.name );
                cnt++;
            }
        }
        
    }

    private void loadScene( string str ) {
        SceneManager.LoadSceneAsync( str, LoadSceneMode.Additive );
    }

	public void SceneUpdate ( string str ) {
		unLoadScene( );
        loadScene( str );
	}

}
