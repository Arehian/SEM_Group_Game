using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HP_Controller : MonoBehaviour
{
    public Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
       GameObject btnObj = GameObject.Find ("Ocean/Boat/HP_Canvas/Add");
       GameObject btnObj_d = GameObject.Find ("Ocean/Boat/HP_Canvas/De");
       Button btn = (Button) btnObj.GetComponent<Button>();
       Button btn_d = (Button) btnObj_d.GetComponent<Button>();
       Slider.value = 100;
       btn.onClick.AddListener (HP_increase);
       btn_d.onClick.AddListener (HP_decrease);
    }

   // Update is called once per frame
   void Update()
   {

   }

   public void HP_decrease(){
        Slider.value -= 20;
   }
   public void HP_increase(){
        Slider.value += 20;
   }

}
