using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int Hp = 3;
    public int Score = 0;
    //��ȡbutton
    public GameObject StartButton;
    public float Atk = 40;
    public float Speed = 20f;
    //�°�animation
    private Animation ani;
    //
    public Collider Trigger;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animation>();
        //�ʼ����ʾ
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
            //���������
            Trigger.enabled = true;
            //0.1s��ʧЧ
            Invoke("AttackEnd", 0.1f);
        }

        //���û���ڲ������������Ͳ���idle����
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
            //���������ٵ���
            Destroy(collision.collider.gameObject);
            Hp--;

            //ˢ��UI ��Ѫ
            UIControl.Instance.RefreshHp(Hp, 3);


            Debug.Log(Hp);
            AudioManager.Instance.PlaySound("oni_enemy02");
            if (Hp <= 0)
            {
                //��ʾ��ť
                StartButton.SetActive(true);

                AudioManager.Instance.PlaySound("oni_enemy03");
                ani.Play("P_stop");
                //Destroy(gameObject, 2f); //��ΪҪ����ť������Ϸ���԰����ע���ˣ��������¿�ʼ��Ϸ��ʱ�����������gameObject

            }
        }
    }

    //���¿�ʼ��Ϸ(���¼��س���or������ݣ�
    public void RestartGame()
    {
        Debug.Log("restart");

        //�������
        Hp = 3;
        Score = 0;
        ani.Play("P_run");
        UIControl.Instance.RefreshHp(Hp, 3);
        UIControl.Instance.RefreshScore(Score);
        //�������ذ�ť
        StartButton.SetActive(false);


    }
}
