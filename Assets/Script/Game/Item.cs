using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    bool itemHit;
    bool itemLook;
    bool gazeJudg;
    [SerializeField]
    Text text;
    [SerializeField]
    Text itemName;
    Data data = new Data();
    public enum itemNumber
    { Null, operation_Key,  mess, medical_Key, nurse_Note, locker_Key, escape_Key }; 
    itemNumber number;
	

	void Start () 
    {
		itemHit = false;
        itemLook = false;
        //data.init( );
    }

    //アイテムにあたったら
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
        if(other.gameObject.tag == "Player")
        {
            itemHit = false;
        }
        //data.getItem(this.gameObject.name);
        //Destroy(item);
    }

    //カメラに写ったら
    void OnBecameInvisible() 
    {
       itemLook = false;
    }

    //カメラから外れたとき
    void OnBecameVisible() 
    {
        itemLook = true;
    }

    //凝視判定
    void gazeJudgment()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            gazeJudg = true;
        }
        else
        {
            gazeJudg = false;
        }
    }

    //アイテムに近づいたらテキスト表示
    void Itemtext() 
    {
        gazeJudgment();

        if(itemHit == true && itemLook == true && gazeJudg == true)
        {
            text.text = "B 調べる";
            ItemName();
           
        }
        else
        {
            text.text = "";
            itemName.text = "";
        }
    }

    //アイテムの名前を取得
    void ItemName()
    {
        switch(number)
        {
            case itemNumber.Null:
                itemName.text = "";
                break;
            case itemNumber.operation_Key:

                itemName.text = "手術室のカギ";

            break;


            case itemNumber.mess:

                itemName.text = "メス";

            break;


            case itemNumber.medical_Key:

                itemName.text = "診察室のカギ";

            break;


            case itemNumber.nurse_Note:

                itemName.text = "ナースの手帳";

            break;


            case itemNumber.locker_Key:

                itemName.text = "ロッカーのカギ";

            break;


            case itemNumber.escape_Key:

                itemName.text = "非常口のカギ";

            break;

        }
    }

    void Update()
    {
        Itemtext();
    }


















}
