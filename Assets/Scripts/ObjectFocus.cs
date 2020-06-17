using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ObjectFocus : MonoBehaviour
{

    [SerializeField]
    Transform reference;
    [SerializeField]
    float minAngle = 10; //10 or less label is fully opaque.
    [SerializeField]
    float maxAngle = 30; //Full transparent when it reaches 30 degree difference.

    public float fadeAmount; // 0 to 1 based according to camera //Affected by delta.
    public float delta; //to measure distances //Delta will effect fadeamount // Fadeamount will affect gradient.

    public bool isCounted;

    public event Action GotFocusAction;
    public event Action LostFocusAction;

    [SerializeField] UnityEvent onActionTrigger;

    void Awake()
    {
        reference = Camera.main.transform; //Reference to camera
    }
    
    void Start()
    {
       
    }

    void Update()
    {
        Fade();
        ObjectFocusing();

    }


    void Fade()
    {
        Vector3 d = (transform.position - reference.position).normalized;
        //Update delta
        Debug.DrawRay(reference.position, d, Color.red); // Shooting ray towards object camera is looking at.

        Debug.DrawRay(reference.position, reference.forward, Color.cyan); //Shooting from camera.

       
        delta = Vector3.Angle(d.normalized, reference.forward);

        fadeAmount = Mathf.InverseLerp(maxAngle, minAngle, delta);
    }

    void ObjectFocusing()
    {
        if(delta <= minAngle)
        {

            if(isCounted == false)
            {
                ObjectFocusManager.Instance.Add(this);
                GotFocus();
                isCounted = true;
            }

        }
        else if (delta > minAngle || delta < 0)
        {
            if(isCounted == true)
            {
                ObjectFocusManager.Instance.Remove(this);
                LostFocus();
                isCounted = false;
            }
    
        }
    }

    //Gain Focus
    public void GotFocus()
    {
        Debug.Log("Item got focus: " + gameObject.name);
        GotFocusAction?.Invoke();
    }

    public void LostFocus()
    {
        Debug.Log("Item Lost focus: " + gameObject.name);
        LostFocusAction?.Invoke();
    }


    public void ActionTrigger()
    {
        onActionTrigger.Invoke();
    }

    

#if DEBUG
    //private void OnGUI()
    //{
    //    GUIStyle myButton = new GUIStyle(GUI.skin.label);
    //    myButton.fontSize = 50;
    //    myButton.normal.textColor = Color.black;

    //    GUILayout.Label("Delta: " + delta.ToString(), myButton);
    //    GUILayout.Label("Fade Amount: " + fadeAmount.ToString(), myButton);

    //}
#endif
}
