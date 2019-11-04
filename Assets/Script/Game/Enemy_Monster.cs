using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_Monster : MonoBehaviour {

    GameObject _player;
    NavMeshAgent _enemy_monster_nav;

    public static bool visibility = false;
    Vector3 _enemy_pos;
    Vector3 _check_pos;
    Vector3 _check_pos_past;
    public Transform [ ]MovePos;

    //シーン移動　ActiveSwitchを取得
    ActiveSwitch activeswitch;

    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag( "Player" );
        _enemy_monster_nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        if ( _enemy_monster_nav.pathStatus != NavMeshPathStatus.PathInvalid  ) {
            if ( _enemy_pos.x <= _check_pos.x + 0.2 && _enemy_pos.x >= _check_pos.x - 0.2 &&
                 _enemy_pos.z <= _check_pos.z + 0.2 && _enemy_pos.z >= _check_pos.z - 0.2 ) {

                _check_pos = MovePos[ Random.Range( 0, MovePos.Length ) ].transform.position;
            }
            if ( visibility && RayTest( ) ) {
                _check_pos = _player.transform.position;
                Data.setEnemyVisit( true );
            }

            if ( _check_pos != _check_pos_past ) {
                _enemy_monster_nav.SetDestination( _check_pos );
                _check_pos_past = _check_pos;
                Data.setEnemyVisit( false );
            }

        }

        _enemy_pos = this.transform.position;

	}

    bool RayTest()
    {
        var distance = (this.gameObject.transform.position - _player.transform.position).sqrMagnitude;
        Ray ray = new Ray(this.gameObject.transform.position, _player.transform.position - this.gameObject.transform.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "Player")
            {
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 0, false);
                return true;
            }
            if (hit.collider.tag == "wall")
            {
                Debug.Log("wall");
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 0, false);
                return false;
            }

        }
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green, 0, true);
        return false;
    }

    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.tag == "Player"  ) {

            //触れたらゲームオーバーシーンに移動
            activeswitch.SceneUpdate("GameOver");

        }
    }

}
