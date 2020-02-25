using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Button_default : MonoBehaviour
{
    void Awake(){

    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().Select();

        GameObject btnObj = GameObject.Find ("Background/Canvas/Start");

        Button btn = (Button) btnObj.GetComponent<Button>();

        btn.onClick.AddListener (onClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onClick ()
    {
    //To start the game, jump to scene 2
      Debug.Log ("click!");
      SceneManager.LoadScene("TreasureHuntScene");//level1为我们要切换到的场景
    }
}
