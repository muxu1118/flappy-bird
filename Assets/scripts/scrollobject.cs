using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollobject : MonoBehaviour {
    //スクロールスクリプト
    public float Startpoint;
    public float Endpoint;
    public float speed;
    internal static bool endbled;




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!endbled) return;
        
        transform.Translate(-1 * speed * Time.deltaTime,0,0);

        if (transform.localPosition.x <= Endpoint){
            End();
        }
	}

    void End(){


        float rnd = Random.Range(-1f, 2f);


        transform.Translate(-1 * (Endpoint - Startpoint), 0, 0);

        

        //SendMessage("EndCallBack", SendMessageOptions.RequireReceiver);
    }
}
