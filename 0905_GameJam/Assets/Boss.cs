using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Boss : MonoBehaviour
{
    private static Boss instance;
    public static Boss Instance
    {
        get
        {
            return instance;
        }
    }
    public GameObject Clear;
    public Transform cameraPivot;
    public bool stageClear;
    void Start()
    {
        instance = this;
        Invoke("Jump",1);
    }
    void Update()
    {
        
    }
    void Jump()
    {
        transform.DOMove(transform.position + transform.up*0.5f,0.1f).OnComplete( ()=> transform.DOMove(transform.position - transform.up*0.5f,0.1f));
        Invoke("Jump",1f);
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag =="Player")
        {
            Clear.SetActive(true);
            stageClear = true;
            Camera.main.transform.position = cameraPivot.position;
            AudioManager.instance.play("Camera");
            Destroy(transform.gameObject);
        }
        
    }
}
