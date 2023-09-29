using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    //����ݵ��õ��������
    public static UIControl Instance;
    //Ѫ��
    public Slider HpBar;
    //����
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
    //ˢ��Ѫ��
    public void RefreshHp(int hp, int maxHp)
    {
        //Ѫ����ʾ�ٷֱ�
        HpBar.value = hp / (float)maxHp;//����һ��Ҫǿת��float��Ȼ������С��
    }
    //ˢ�·���
    public void RefreshScore(int score)
    {
        ScoreText.text = "Score: " + score;
    }
}
