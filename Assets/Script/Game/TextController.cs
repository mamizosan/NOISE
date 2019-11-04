using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    [SerializeField]
    Text uiText;

    public string[] sentences;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f; //一文字の表示にかける時間

    [SerializeField]
    Image image;

    private string currentText = string.Empty; //現在の文字列
    private float timeUntilDisplay = 0; //表示にかかる時間
    private float timeElapsed = 1;
    private int lastUpdateCharCount = -1; //表示中の文字数
    private int currentSentenceNum = 0;

    // Use this for initialization
    void Start()
    {
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        image.color = new Color(1f, 1f, 1f, 0);

        NextText();
    }

    // Update is called once per frame
    void Update()
    {

        ClickText();

    }


    void ClickText()
    {

        //マウスが押されたら
        if (currentSentenceNum < sentences.Length && Input.GetMouseButtonDown(0))
        {
            NextText();

        }

        else if (Input.GetMouseButtonDown(0)) //マウスをクリックされたら文字をすべて表示
        {

            timeUntilDisplay = 0; //強制的に１になるようにする

            image.color = new Color(1f, 1f, 1f, 1f);
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
    bool IsDisplay()
    {

        return Time.time > timeElapsed + timeUntilDisplay;

    }

}
