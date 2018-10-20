using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int tokuten = 0; //得点

 

    // Use this for initialization
    void Start () {
        GetComponent<Text>().text = " score : " + tokuten.ToString();
    }
	
	// Update is called once per frame


    public void ScoreUp(int point)
    {
        tokuten += point;
        GetComponent<Text>().text = " score : " + tokuten.ToString();
    }

}
