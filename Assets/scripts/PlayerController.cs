using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    bool isDead = false;
    
    [SerializeField]
    private Score score;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) { return; }
        //死亡状態
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.ScoreUp(1);
    }
    public bool IsDead()
    {
        return isDead;
    }

    void Update()
    {
        //クリックしたら飛ぶよ
        if (Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }
    //rb2dのvelocityで羽ばたきたい
    public void Flap()
    {
        //死亡状態の確認
        if (isDead) { return; }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
    }
    public void SetKinematicFlg(bool _fig) {
        rb2d.isKinematic = _fig;
    }
}
