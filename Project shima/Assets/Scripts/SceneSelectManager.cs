﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSelectManager : MonoBehaviour
{
    public void PushPlayButton()
    {
        SceneManager.LoadScene("Rule");
        //transform.position = new Vector3(1f, 1f, 1f);
    }
}
