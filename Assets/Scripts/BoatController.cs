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
        music = gameObject.AddComponent<AudioSource>();

        music.playOnAwake = false;

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

    }

    void Steer(){
      horizontalInput = Input.GetAxis("Horizontal");
      steerFactor = Mathf.Lerp(steerFactor, horizontalInput, Time.deltaTime / movementThreshold);
      transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);

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

         hit_once = true;

    }
}
