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


    private void Start()
    {
        //Events will be invoked from OFM on adding and removing.
        ObjectFocusManager.Instance.ObjectAdded += takeEvents; 
        ObjectFocusManager.Instance.ObjectRemoved += ignoreEvents;
    }


    private void takeEvents()
    {
        gameObject.SetActive(true);
    }


    private void ignoreEvents()
    {
        gameObject.SetActive(false);
        //Cancel();
    }

    private void Cancel()
    {
        timer = 0;
        onTouchTimerUpdate.Invoke(timerUpdateCurve.Evaluate(Mathf.InverseLerp(0, delay, timer)));
        onTouchCancel.Invoke();
    }

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
                    //Cancel();
                    if(timer > delay)
                    {
                        onTouchTimerEnd.Invoke(); 
                    }
                    break;
            }
        }

    }

}
