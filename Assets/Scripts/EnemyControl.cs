using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int Hp = 1;
    private Animation ani;
    //获取玩家血量
    private PlayerControl player;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            return;
        }
        //if(player.Hp <= 0)
        //{
        //    return;
        //}
        transform.Translate(Vector3.forward * 10 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Hp--;
            if (Hp <= 0)
            {
                //添加分数
                player.Score+= 1000;
                //刷新UI
                UIControl.Instance.RefreshScore(player.Score);

                //
                Destroy(gameObject, 3f);
                AudioManager.Instance.PlaySound("oni_player02");
                AudioManager.Instance.PlaySound("oni_enemy01");
                //关闭自身碰撞器
                //Destroy(this.GetComponent<Collider>());
                GetComponent<Collider>().enabled = false;
                //给一个向上的力
                GetComponent<Rigidbody>().AddForce(Vector3.up*500f);
                GetComponent<Rigidbody>().AddForce(Vector3.forward*500f);


            }
        }
    }
}
