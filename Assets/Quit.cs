using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().Select();

        GameObject btnObj = GameObject.Find("Background/Canvas/Quit");

        Button btn = (Button)btnObj.GetComponent<Button>();

        btn.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onClick()
    {
        Application.Quit();
    }
}
