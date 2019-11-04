using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Text_Tutorial : MonoBehaviour {

    [SerializeField]
    Text uiText;

    [SerializeField]
    AudioSource audio;

    public string[] sentences;

    [SerializeField][Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f; //一文字の表示にかける時間

    //シーン移動　ActiveSwitchを取得
    ActiveSwitch activeswitch = new ActiveSwitch();

    private string currentText = string.Empty; //現在の文字列
    private float timeUntilDisplay = 0; //表示にかかる時間
    private float timeElapsed = 1; 
    private int lastUpdateCharCount = -1; //表示中の文字数
    private int currentSentenceNum = 0;

    bool change = false;


    // Use this for initialization
    void Start () {

        NextText();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        ClickText();

    }

    void ClickText() {

        //マウスが押されたら
        if (currentSentenceNum < sentences.Length && Input.GetButtonDown("Space"))
        {
            NextText();

        }

        else if (change && Input.GetButtonDown("Space"))
        {

            TutorialSwitch();

        } else if ( Input.GetButtonDown( "Space" ) ) //マウスをクリックされたら文字をすべて表示
        {

            audio.PlayOneShot(audio.clip); //音が鳴る


            timeUntilDisplay = 0; //強制的に１になるようにする
            change = true;

        }

        //文字数の計算
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
        if (displayCharacterCount != lastUpdateCharCount)
        {
           uiText.text = currentText.Substring(0, displayCharacterCount);
           lastUpdateCharCount = displayCharacterCount;
        }


    }

    void NextText()
    {

        currentText = sentences[currentSentenceNum];

        // 想定表示時間と現在の時刻をキャッシュ
        timeUntilDisplay = currentText.Length * intervalForCharDisplay;

        timeElapsed = Time.time;
        currentSentenceNum++;
        // 文字カウントを初期化
        lastUpdateCharCount = -1;

    }

    //時間で見てあげている
    bool IsDisplay() {

        return Time.time > timeElapsed + timeUntilDisplay;

    }

    public void TutorialSwitch( ) {

        activeswitch.SceneUpdate("Main_Scene");

        audio.PlayOneShot(audio.clip);


    }

}
