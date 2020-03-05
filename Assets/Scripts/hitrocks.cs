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

        music = gameObject.AddComponent<AudioSource>();

        music.playOnAwake = false;

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

    }
}
