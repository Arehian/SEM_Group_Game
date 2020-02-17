using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFloater : MonoBehaviour
{
    private Transform seaPlane;
    private Cloth planeCloth;
    [SerializeField] private int closestVertexIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        seaPlane = GameObject.Find("Ocean").transform;
        planeCloth = seaPlane.GetComponent<Cloth>();
    }

    // Update is called once per frame
    void Update()
    {
        getClosestVertex();
    }

    void getClosestVertex(){
      for(int i=0; i < planeCloth.vertices.Length; i++){
        if(closestVertexIndex == -1){
          closestVertexIndex = i;
        }
        float distance = Vector3.Distance(planeCloth.vertices[i], transform.position);
        float closestDistance = Vector3.Distance(planeCloth.vertices[closestVertexIndex], transform.position);

        if(distance < closestDistance){
          closestVertexIndex = i;
        }
      }

      transform.localPosition = new Vector3(
      transform.localPosition.x, planeCloth.vertices[closestVertexIndex].y / 5,
      transform.localPosition.z
      );
    }
}
