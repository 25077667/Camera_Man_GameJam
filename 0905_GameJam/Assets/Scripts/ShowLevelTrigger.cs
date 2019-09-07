using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLevelTrigger : MonoBehaviour
{
    public GameObject[] Open;
    public ShakeTransformEventData shake;
    bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in Open)
        {
            obj.SetActive(false);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(trigger)
            return;
        trigger = true;
        ShakeTranform.instance.AddShakeEvent(shake);
        foreach(GameObject obj in Open)
        {
            obj.SetActive(true);
        }
    }
}
