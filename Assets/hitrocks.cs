using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hitrocks : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public AudioClip AC;

    void Start()
    {
        
    }
    private void Awake()
    { 
        //给对象添加一个AudioSource组件
        music = gameObject.AddComponent<AudioSource>();
        //设置不一开始就播放音效
        music.playOnAwake = false;
        //加载音效文件，我把跳跃的音频文件命名为jump
        AC = Resources.Load<AudioClip>("Sounds/Hitrocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision) {
         var name = collision.collider.name;
        music.clip = AC;
        music.Play();
        Debug.Log("The boat hit the rock " + name);
    }
}
