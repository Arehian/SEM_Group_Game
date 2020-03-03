﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Random_Create : MonoBehaviour
{
    public GameObject tag;
    public GameObject Treasure_now;
    public bool if_create = true;

    // Start is called before the first frame update
    void Start()
    {
        if(if_create){
           Vector3 length = this.GetComponent<MeshFilter>().mesh.bounds.size;
           int xlength = (int)Math.Floor(length.x * transform.lossyScale.x/2);
           int ylength = (int)Math.Floor(length.y * transform.lossyScale.y/2);
           int zlength = (int)Math.Floor(length.z * transform.lossyScale.z/2);

                    int x  = UnityEngine.Random.Range(-xlength,xlength);
                    int z  = UnityEngine.Random.Range(-zlength,zlength);

           Treasure_now = Instantiate(tag,tag.transform.position = new Vector3(x,-4.44f,z),transform.rotation);
           if_create = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(if_create){
           Vector3 length = this.GetComponent<MeshFilter>().mesh.bounds.size;
           int xlength = (int)Math.Floor(length.x * transform.lossyScale.x/2);
           int ylength = (int)Math.Floor(length.y * transform.lossyScale.y/2);
           int zlength = (int)Math.Floor(length.z * transform.lossyScale.z/2);

                    int x  = UnityEngine.Random.Range(-xlength,xlength);
                    int z  = UnityEngine.Random.Range(-zlength,zlength);

           Treasure_now = Instantiate(tag,tag.transform.position = new Vector3(x,-4.44f,z),transform.rotation);
           if_create = false;
        }

    }
}
