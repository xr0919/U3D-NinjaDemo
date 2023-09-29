using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    //更便捷的拿到这个对象
    public static UIControl Instance;
    //血条
    public Slider HpBar;
    //分数
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //刷新血量
    public void RefreshHp(int hp, int maxHp)
    {
        //血条显示百分比
        HpBar.value = hp / (float)maxHp;//其中一个要强转成float不然出不了小数
    }
    //刷新分数
    public void RefreshScore(int score)
    {
        ScoreText.text = "Score: " + score;
    }
}
