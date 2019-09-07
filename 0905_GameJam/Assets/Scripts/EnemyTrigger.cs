using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTrigger : MonoBehaviour
{
    public ShakeTransformEventData shakes;
    public GameObject flash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Player")
        {
            flash.SetActive(true);
            Camera.main.GetComponentInParent<ShakeTranform>().AddShakeEvent(shakes);
            AudioManager.instance.play("Dead");
            AudioManager.instance.play("Camera");
            Destroy(transform.parent.gameObject);
        }
    }
}
