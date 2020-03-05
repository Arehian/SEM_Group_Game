using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HP_Controller : MonoBehaviour
{
    public Slider Slider;
    static public int ScoreInt;
    static private int scoreInt = 0;
    public static Text txt;


    // Start is called before the first frame update
    void Start()
    {

       Slider.value = 100;
       txt = GameObject.Find("Score").GetComponent<Text>();
       txt.text = " 0 ";

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
   public void Score_decrease(){
           txt = GameObject.Find("Score").GetComponent<Text>();
           scoreInt -= 10;
           txt.text = scoreInt.ToString();

   }
   public void Score_increase(){
        txt = GameObject.Find("Score").GetComponent<Text>();
        scoreInt += 10;
        txt.text = scoreInt.ToString();


   }

}
