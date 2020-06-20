using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//Script which will keep track of the items visible to the camera.
public class ObjectFocusManager : SingletonGeneric<ObjectFocusManager>
{
    public Touch_Input_Manager input_Manager;

    List<ObjectFocus> objectsInRange = new List<ObjectFocus>();

    public event Action ObjectAdded;
    public event Action ObjectRemoved;

    public int Count;
    public bool ObjectPresent;


    public void Add(ObjectFocus objectinFocus)
    {
        Count++;
        Instance.objectsInRange.Add(objectinFocus);  //Add in list
        ObjectAdded?.Invoke();
    }

    public void Remove(ObjectFocus objectFocus)
    {
        Instance.objectsInRange.Remove(objectFocus); //Remove from list.
        Count--;
        ObjectRemoved?.Invoke();
    }

    public void TriggerAction()
    {
        objectsInRange[0].ActionTrigger();
    }


#if DEBUG
    //private void OnGUI()
    //{
    //    GUIStyle myButton = new GUIStyle(GUI.skin.label);
    //    myButton.fontSize = 50;  
    //    myButton.normal.textColor = Color.black;

    //    GUILayout.Label("Objects in focus: " + Count.ToString(), myButton);
    //}
#endif

}