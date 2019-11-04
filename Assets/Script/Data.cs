using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
    //ゲームメイン
    static bool playerGaze = false;
    static bool playerEar = false;
    static bool playerItem = false;
    static bool enemyVisibility = false;
    static Dictionary<string, bool> item;
    static Dictionary<string, bool> door;

    private void Start()
    {
        item = new Dictionary<string, bool>()
        {
            { "phone"            , false },
            { "DummyKey"         , false },
            { "diagnosisroom_key", false },
            { "exit_key"         , false },
            { "locker_key"       , true },
            { "mes"              , false },
            { "nurse_note"       , false },
            { "nurse_note_page"  , false },
            { "operating_key"    , false }
        };
        door = new Dictionary<string, bool>()
        {
            { "Operating_room_door" , false }
        };
    }

    //Player
    public static void setPlayerGaze(bool gaze)
    {
        playerGaze = gaze;
    }

    public static bool getPlayerGaze()
    {
        return playerGaze;
    }

    public static void setPlayerEar(bool ear)
    {
        playerEar = ear;
    }

    public static bool getPlayerEar()
    {
        return playerEar;
    }

    public static void setPlayerItem(bool item)
    {
        playerItem = item;
    }

    public static bool getPlayerItem()
    {
        return playerItem;
    }

    //Enemy
    public static void setEnemyVisit( bool visit )
    {
        enemyVisibility = visit;
    }

    public static bool getEnamyVisit()
    {
        return enemyVisibility;
    }

    //Item
    public static void getItem( string name )
    {
        item[name] = true;
    }

    void lostItem( string name )
    {
        item[name] = false;
    }

    public static bool lookItem( string name )
    {
        return item[name];
    }

    //door
    public static void openDoor(string name)
    {
        door[name] = true;
    }

    public static bool lookDoor(string name)
    {
        return door[name];
    }
}
