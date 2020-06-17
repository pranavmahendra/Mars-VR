using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;


public class Touch_Input_Manager : MonoBehaviour
{
    [Serializable]
    public class FloatEvent : UnityEvent<float> { }

    [SerializeField]
    private AnimationCurve timerUpdateCurve;
 
    float delay = 2f;

    [SerializeField]private UnityEvent onTouch;
    [SerializeField]private UnityEvent onTouchCancel;
    [SerializeField]private FloatEvent onTouchTimerUpdate;
    [SerializeField]private UnityEvent onTouchTimerEnd;
    


    float timer;

    [SerializeField]
    Image progressImage;


    void Update()
    {
        if(Input.touchCount > 0)
        {
            switch(Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    timer = 0;
                    onTouch.Invoke();
                    break;

                case TouchPhase.Ended:
                    onTouchCancel.Invoke();
                    break;

                default:
                    timer += Time.deltaTime;
                    onTouchTimerUpdate.Invoke(timerUpdateCurve.Evaluate(Mathf.InverseLerp(0, delay, timer)));
                    if(timer > delay)
                    {
                        onTouchTimerEnd.Invoke(); 
                    }
                    break;
            }
        }

    }

}
