using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    private PlayerControl player;
    public GameObject EnemyPre;
    private float timer = 0;
    private float CD = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player.Hp <= 0)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > CD)
        {
            timer = 0;
            CD = Random.Range(1, 4);
            Instantiate(EnemyPre);//,transform.position,Quaternion.identity
        }
    }
}
