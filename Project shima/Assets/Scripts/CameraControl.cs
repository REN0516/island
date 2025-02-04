﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    GameObject targetObj;
 //   GameObject HeartBeatColor;
    Vector3 targetPos;
    Vector3 cameraOffset = new Vector3(0, 1.5f, -2);
 //   private float DecayTime;
 //   private float heartbeat;
   // public float heartbeatTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        targetObj = GameObject.Find("Player");
        targetPos = targetObj.transform.position;
        transform.position = targetPos + cameraOffset;
     //   HeartBeatColor = GameObject.Find(" Heartbeat");

    }

    // Update is called once per frame
    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;


/*        DecayTime = Time.deltaTime * 200f;
        heartbeat -= DecayTime;

        HeartBeatColor.GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, heartbeat / 255.0f);

        if (heartbeat <= 0.0f)
        {
            heartbeat = 100.0f;

            //HeartBeatColor.GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 100.0f / 255.0f);
            
        }*/

        // マウスの右クリックを押している間
        if (Input.GetMouseButton(1))
        {
            // マウスの移動量
            float mouseInputX = Input.GetAxis("Mouse X");
            float mouseInputY = Input.GetAxis("Mouse Y");
            // targetの位置のY軸を中心に、回転（公転）する
            transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 200f);
            // カメラの垂直移動（※角度制限なし、必要が無ければコメントアウト）
            transform.RotateAround(targetPos, transform.right, mouseInputY * Time.deltaTime * 200f);
        }
    }
}
