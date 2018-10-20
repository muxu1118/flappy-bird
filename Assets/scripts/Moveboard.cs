using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveboard : MonoBehaviour {


    public Board board;

    internal static bool endbled;
    public enum Board
    {
        Board1,
        Board2,
        Board3,
    }

    private void Start()
    {
        switch (board)
        {
            case Board.Board1:
                transform.position = new Vector3(4f, Random.Range(-1f, 3f), 0);
                break;
            case Board.Board2:
                transform.position = new Vector3(8f, Random.Range(-1f, 3f), 0);
                break;
            case Board.Board3:
                transform.position = new Vector3(12f, Random.Range(-1f, 3f), 0);
                break;
            default: break;
        }
    }

    // Use this for initialization
    void Update()
    {
        if (!endbled) return;
        transform.Translate(-0.05f, 0, 0);//速度
        if (transform.position.x < -5f) //エンドポイント
        {
            float y = Random.Range(-1f, 3f);//上下ランダム

            transform.position = new Vector3(7f, y, 0);//スタートポイント
        }
    }

    

}
