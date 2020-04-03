using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private Text message;
    private Text manholeNumText; //Rabitnumbertext
    private Text manholeText; //マンホールに関してのテキスト

    public GameObject panel; //画面全体のやつ
    public GameObject manholePanel; //中心テキスト表示用のパネル
    // Start is called before the first frame update
    void Start()
    {
        this.message = GameObject.Find("UICanvas/message").GetComponent<Text>();
        this.manholeNumText = GameObject.Find("UICanvas/ManholeNumText").GetComponent<Text>();
        this.panel = GameObject.Find("UICanvas/Panel");
        this.panel.SetActive(false);
        this.manholeText = GameObject.Find("UICanvas/ManholeText").GetComponent<Text>();
        this.manholePanel = GameObject.Find("UICanvas/ManholePanel");
        this.manholePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ManholeTextSet(string message, int fontSize)
    {
        this.manholeText.text = message;
        this.manholeText.fontSize = fontSize;
    }

    public void ManholeNumTextSet(string message, int fontSize)
    {
        this.manholeNumText.text = message;
        this.manholeNumText.fontSize = fontSize;
    }


    public void messageSet(string message, int fontSize)
    {
        this.message.text = message;
        this.message.fontSize = fontSize;
    }
}
