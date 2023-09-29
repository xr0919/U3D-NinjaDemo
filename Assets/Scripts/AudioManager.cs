using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //������or��̬��----ֻ��ʵ������һ������
    public static AudioManager Instance;
    private AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player =GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(string name)
    {
        //ͨ���ļ���������Դ
        //Ҫ����Ƶ�ŵ�Resources�ļ����У��ļ������ܴ�����������������������
        AudioClip clip = Resources.Load<AudioClip>(name);
        player.PlayOneShot(clip);
    }
}
