using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int Hp = 3;
    public int Score = 0;
    //获取button
    public GameObject StartButton;
    public float Atk = 40;
    public float Speed = 20f;
    //新版animation
    private Animation ani;
    //
    public Collider Trigger;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        //最开始不显示
        StartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(-vertical, 0, horizontal);
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0) && ani.IsPlaying("P_attack_R") == false)
        {
            ani.Play("P_attack_R");
            AudioManager.Instance.PlaySound("oni_player01");
            AudioManager.Instance.PlaySound("oni_player03");
            //激活攻击触发
            Trigger.enabled = true;
            //0.1s后失效
            Invoke("AttackEnd", 0.1f);
        }

        //如果没有在播放其他动画就播放idle动画
        if (ani.isPlaying == false)
        {
            ani.Play("P_run");
        }
    }

    void AttackEnd()
    {
        Trigger.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            //碰到就销毁敌人
            Destroy(collision.collider.gameObject);
            Hp--;

            //刷新UI 掉血
            UIControl.Instance.RefreshHp(Hp, 3);


            Debug.Log(Hp);
            AudioManager.Instance.PlaySound("oni_enemy02");
            if (Hp <= 0)
            {
                //显示按钮
                StartButton.SetActive(true);

                AudioManager.Instance.PlaySound("oni_enemy03");
                ani.Play("P_stop");
                //Destroy(gameObject, 2f); //因为要按按钮重新游戏所以把这个注释了，不用重新开始游戏的时候就死亡销毁gameObject

            }
        }
    }

    //重新开始游戏(重新加载场景or清空数据）
    public void RestartGame()
    {
        Debug.Log("restart");

        //清空数据
        Hp = 3;
        Score = 0;
        ani.Play("P_run");
        UIControl.Instance.RefreshHp(Hp, 3);
        UIControl.Instance.RefreshScore(Score);
        //重新隐藏按钮
        StartButton.SetActive(false);


    }
}
