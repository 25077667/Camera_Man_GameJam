using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    public ShakeTransformEventData shakes;
    Enemy enemy;
    BoxCollider col;
    MeshRenderer render;

    void Start()
    {
        col = transform.GetComponent<BoxCollider>();
        enemy = transform.GetComponentInParent<Enemy>();
        render = transform.GetComponent<MeshRenderer>();
    }


    void Update()
    {
        if(enemy.turning)
            render.enabled = false;
        else
            render.enabled = true;
    }
    public void OnTriggerEnter(Collider col)
    {
        //Debug.Log("123");
        if(enemy.turning)
            return;
        
        if(col.tag == "Player")
        {
            Destroy(col.gameObject);
            Debug.Log("GameOver");
        }
    }
    public void OnTriggerStay(Collider col)
    {
        //Debug.Log("123");
        if(enemy.turning)
            return;
        
        if(col.tag == "Player")
        {
            Destroy(col.gameObject);
            Camera.main.GetComponentInParent<ShakeTranform>().AddShakeEvent(shakes);
            AudioManager.instance.play("PlayerDead");
            Debug.Log("GameOver");
        }
    }

}
