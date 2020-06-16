using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script which will keep track of the items visible to the camera.
public class ObjectFocusManager : SingletonGeneric<ObjectFocusManager>
{

    List<ObjectFocus> objectsInRange = new List<ObjectFocus>();

    public int Count;

    public void Add(ObjectFocus objectinFocus)
    {
        Count++;
        Instance.objectsInRange.Add(objectinFocus);  //Add in list
    }

    public void Remove(ObjectFocus objectFocus)
    {
        Instance.objectsInRange.Remove(objectFocus); //Remove from list.
        Count--;

    }

    public void TriggerAction()
    {
        objectsInRange[0].ActionTrigger();
    }

#if DEBUG
    private void OnGUI()
    {
        GUIStyle myButton = new GUIStyle(GUI.skin.label);
        myButton.fontSize = 50;  
        myButton.normal.textColor = Color.black;
      
        GUILayout.Label("Objects in focus: " + Count.ToString(), myButton);
    }
#endif

}
