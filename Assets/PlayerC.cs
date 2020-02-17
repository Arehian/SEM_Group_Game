using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public float textspeed=10.1f;
    public float directspeed=30.1f;
  		// how smooth the camera movement is

    //private Vector3 m_TargetPosition;		// the position the camera is trying to be in)

    Transform follow;        //the position of Player
    // Start is called before the first frame update
    void Start()
    {
      //follow = GameObject.FindWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {


      if (Input.GetKey(KeyCode.A)) {
          print("move w");
          this.transform.Rotate(-Vector3.up  * Time.deltaTime * directspeed);
      }else if (Input.GetKey(KeyCode.D))
      {
          print("move s");
          this.transform.Rotate(Vector3.up  * Time.deltaTime * directspeed);
      }
      else if (Input.GetKey(KeyCode.S))
      {
          print("move a");
          this.transform.Translate(Vector3.left * Time.deltaTime * textspeed);
      }
      else if (Input.GetKey(KeyCode.W))
      {
          print("move d");
          this.transform.Translate(Vector3.right * Time.deltaTime * textspeed);
      }

      // make sure the camera is looking the right way!
      //transform.LookAt(follow);
    }
}
