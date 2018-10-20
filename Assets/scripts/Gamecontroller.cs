using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class Gamecontroller : MonoBehaviour {
    
    public GameObject scoreText;    //スコアを表示させるゲームオブジェクト
    public AudioClip BGMOP;      //OPのBGM
    public AudioClip BGMPlay;    //プレイ中のBGM
    private AudioSource GameOverSE; //ゲームオーバー時のSE

    //ゲームのステート

    enum State
    {
        Ready,       //ゲーム開始
        Play,        //ゲーム中
        GameOver     //ゲームオーバー
    };

    State gameState; //現在のゲームの状態

    [SerializeField]
    PlayerController player; //プレイヤー
    [SerializeField]
    GameObject Boards;
    [SerializeField]
    Text GoalLabel;

    void LateUpdate()
    {
        //ゲームステートに応じてイベント
        switch (gameState) {
            case State.Ready:   //ゲーム開始
                //タッチしたらゲームスタート
                if (Input.GetMouseButtonDown(0)) {
                    GameState();
                }
                break;
            case State.Play:     //ゲーム中
                //プレイヤーが死亡しているかチェック
                if (player.IsDead()) {
                    GameOver();
                }
                break;
            case State.GameOver:    //ゲームオーバー
                if (Input.GetMouseButtonDown(0)) {
                    Reload();
                }

                break;
            default:
                break;
        }
    }

    private void Start()
    {
        GameReady();
    }
    void GameState() {
        //ゲーム中の状態へ変更
        gameState = State.Play;

        //各オブジェクトを有効にする
        player.SetKinematicFlg(false);
        GoalLabel.text = "";
        Boards.SetActive(true);
        //最初の一回だけはばたかせる
        player.Flap();
        scrollobject.endbled = true;
        Moveboard.endbled = true;
    }
    void GameReady() {
        //ゲーム開始状態へ変更;
        gameState = State.Ready;

        //各オブジェクトを無効にする
        player.SetKinematicFlg(true);
        Boards.SetActive(false);
        GoalLabel.text = "Click To START";
    }

    void GameOver() {
        gameState = State.GameOver;
        //シーン中のすべてのスクロールオブジェクトコンポーネントを探し出す
        scrollobject[] scrollObjects = GameObject.FindObjectsOfType<scrollobject>();
        Moveboard[] moveObject = GameObject.FindObjectsOfType<Moveboard>();
        GoalLabel.text = "GAME OVER";
        //
        foreach (scrollobject sc in scrollObjects) {
            scrollobject.endbled = false;
        }

        foreach (Moveboard mv in moveObject)
        {
            Moveboard.endbled = false;
        }
    }

    void Reload() {
        Scene loadscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadscene.name);
    }
    void OnTriggerEnter2D(Collider2D col){
        //Score(GUIText)のScoreUpメソッドを呼び出す
        scoreText.SendMessage("ScoreUp", 1);
    }
    
}
