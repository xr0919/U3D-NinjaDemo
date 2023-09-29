using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //单例类or静态类----只能实例化出一个对象
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
        //通过文件名加载资源
        //要把音频放到Resources文件夹中，文件名不能错！！！！！！！！！！！！
        AudioClip clip = Resources.Load<AudioClip>(name);
        player.PlayOneShot(clip);
    }
}
