using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using System;

public class XRManager : MonoBehaviour
{
    static XRManager instance;

    private void Awake()
    {
        if(instance == false)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += ActiveSceneChanged;
    }

    private void ActiveSceneChanged(Scene arg0, Scene arg1)
    {
        InputTracking.Recenter();
    }


    // Start is called before the first frame update
    void Start()
    {
        InputTracking.Recenter();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
