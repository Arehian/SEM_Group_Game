﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// [RequireComponent (typeof(FloatObjectScript))]
public class BoatController : MonoBehaviour
{
    // Start is called before the first frame update
    // public float speed = 0.5f;
    public Vector3 point;
    public Transform boat_transform;

    public HP_Controller other_HP;
    public Random_Create treasure;

    // [Space (15)]
    public float speed = 1.0f;
    public float steerSpeed = 1.0f;
    public float movementThreshold = 5.0f;


    public bool hit_once = true;


    float verticalInput;
    float horizontalInput;
    float steerFactor;
    float movementFactor;
    float y = 0.0f;
    public AudioSource music;
    public AudioClip AC;


    private void Awake()
    {
        //给对象添加一个AudioSource组件
        music = gameObject.AddComponent<AudioSource>();
        //设置不一开始就播放音效
        music.playOnAwake = false;
        //加载音效文件，我把跳跃的音频文件命名为jump
        AC = Resources.Load<AudioClip>("Sounds/Hitrocks");
    }

    void Start()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = transform.forward * speed;


    }

    // Update is called once per frame
    void Update()
    {
      Balance();

      Movement();
      Steer();
      MouseMove();
    }

    void MouseMove(){
        float rotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, 1.0f * rotation, 0);
        /*float updown = Input.GetAxis("Mouse Y");
        // clamp allowed rotation to 30
        if (y + updown > 0 || y + updown < -40)
        {
            updown = 0;
        }
        y += updown;
        Camera.main.transform.RotateAround(transform.position,
           transform.right,
            updown);*/
        Camera.main.transform.LookAt(transform);


    }

    void Balance(){
      if(!boat_transform){
        boat_transform = new GameObject("COM").transform;
        boat_transform.SetParent(boat_transform);
      }

      boat_transform.position = point + transform.position;
      boat_transform.position = point;
      GetComponent<Rigidbody>().centerOfMass = boat_transform.position;
    }

    void Movement(){
      verticalInput = Input.GetAxis("Vertical");
      movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThreshold);
      transform.Translate(0.0f, 0.0f, movementFactor * speed);
      //sDebug.Log(Input.GetAxis("Vertical"));
    }

    void Steer(){
      horizontalInput = Input.GetAxis("Horizontal");
      steerFactor = Mathf.Lerp(steerFactor, horizontalInput, Time.deltaTime / movementThreshold);
      transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
      //Debug.Log(Input.GetAxis("Horizontal"));
      // if(Input.GetKey("left")){
      //   // transform.RotateAround(point, Vector3.left, 20 * Time.deltaTime);
      //
      //   transform.RotateAround(boat_transform.position, Vector3.down, 20 * Time.deltaTime);
      //   transform.position = transform.forward *speed;
      //   boat_transform.position = point;
      // }else if(Input.GetKey("right")){
      //   transform.RotateAround(boat_transform.position, Vector3.up, 20 * Time.deltaTime);
      //   transform.position = transform.forward * speed;
      //   boat_transform.position = point;
      //   // transform.RotateAround(point, Vector3.right, 20 * Time.deltaTime);
      //   // transform.Rotate(0, -1, 0);
      // }

    }
    void OnTriggerEnter(Collider other){
        //get the treasure
        //destroy the treasure and create new one
        Destroy(treasure.Treasure_now);
        //add Score
        other_HP.Score_increase();

        treasure.if_create = true;




    }
    void OnCollisionEnter(Collision collision) {
        music.clip = AC;
        music.Play();
        if(other_HP .Slider.value>20){
            other_HP.HP_decrease();
            hit_once = false;
            movementFactor = 0.0f;
            steerFactor = 0.0f;

        }else{
            SceneManager.LoadScene("GameOver");
        }

    }

    void OnCollisionExit(Collision collision) {
       // TimeCount = DateTime.Now - TimeNow;
        //if(TimeCount >= 5){
            hit_once = true;
           // MyTimer.Stop(); //停止计时
        //}

    }
}
