﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove scPlayerMove;

    static float inputHorizontal;
    static float inputVertical;
    Rigidbody rb;
    private Animator animator;

    float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      // animator.SetBool("FastRun", false);
        /*if (Input.GetKey(KeyCode.UpArrow)) {

            //inputHorizontal = Input.GetAxisRaw("Horizontal");
            animator.SetBool("FastRun",true);
           
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            //inputVertical = Input.GetAxisRaw("Vertical");
            animator.SetBool("FastRun", true);
        }*/
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

    }
    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }


    void Awake()
    {
        //スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
        if(scPlayerMove == null)
        {
            DontDestroyOnLoad(gameObject);
            scPlayerMove = this;
            
        }
        //既にPlayerMoveスクリプトがあればこのシーンの同じゲームオブジェクトを削除
        
        else
        {
            Destroy(gameObject);
        }
    }
    public static GameObject GetPlayer()
    {
        return scPlayerMove.gameObject;
    }
/*
*/

}
