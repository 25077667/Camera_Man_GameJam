using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeCameraPivot : MonoBehaviour
{
    public Transform pivot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(Boss.Instance.stageClear)
            return;
        if(col.tag=="Player")
        {
            Camera.main.transform.DOMove(pivot.position,0.6f);
            Debug.Log("123");
        }
    }
}
