using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public enum Mode
    {
        Degree90,Degree180,none,return90,return_90,_switch,return180,return_180,Degree_90
    }
    public Mode mode;
    public bool turning = false;
    public float coolTime;
    public float wait;
    public GameObject[] _switch1;
    public GameObject[] _switch2;
    bool _return;
    Vector3 originRot;
    Quaternion oriRot;
    
    
    void Start()
    {
        originRot = transform.rotation.eulerAngles;
        oriRot = transform.rotation;
        foreach(GameObject obj in _switch1)
        {
                obj.SetActive(false);
        }
        foreach(GameObject obj in _switch2)
        {
            obj.SetActive(false);
        }
        Invoke("RotateDir",wait );

    }


    void Update()
    { 
        
    }
    void RotateDir()
    {
        if(Boss.Instance.stageClear)
            return;







        transform.DOMove(transform.position+transform.up*0.3f,0.1f).OnComplete(()=>transform.DOMove(transform.position-transform.up*0.3f,0.1f));
        if(mode == Mode.Degree90)
        {
            turning = true;
            transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*90,0.2f).OnComplete(()=>turning = false);
        }
        else if(mode == Mode.Degree180)
        {
            turning = true;
            transform.DORotate(transform.localRotation.eulerAngles + Vector3.up*180,0.2f).OnComplete(()=>turning = false);
        }
        else if(mode == Mode.return90)
        {
            turning = true;
            if(!_return)
            {
                transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*90,0.2f).OnComplete(()=>turning = false);
                _return = true;
            }
            else
            {
                transform.DORotate(originRot,0.2f).OnComplete(()=>turning = false);
                _return = false;
            }
        }
        else if(mode == Mode.return_90)
        {
            turning = true;
            if(!_return)
            {
                transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*-90,0.2f).OnComplete(()=>turning = false);
                
                _return = true;
            }
            else
            {
                transform.DORotate(originRot,0.2f).OnComplete(()=>turning = false);
                _return = false;
            }
        }
        else if(mode==Mode._switch)
        {
            //turning = true;
            StartCoroutine(_SwitchTrigger());

        }
        else if(mode == Mode.return180)
        {
            turning = true;
            if(!_return)
            {
                transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*90,0.2f).OnComplete(()=>turning = false);
                Vector3 targetRot = originRot+Vector3.up*90*2;
                Vector3 selfRot = transform.localRotation.eulerAngles + Vector3.up*90;
                if( (originRot+Vector3.up*90*2).y>360 )
                    targetRot -=Vector3.up*360;
                if(selfRot.y>360)
                    selfRot -= Vector3.up*360;
                if(targetRot == selfRot)
                {
                    _return = true;
                }
            }
            else
            {
                transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*-90,0.2f).OnComplete(()=>turning = false);
                if(Quaternion.Euler(originRot).eulerAngles == Quaternion.Euler(transform.localRotation.eulerAngles + Vector3.up*-90).eulerAngles)
                {
                    _return = false;
                }
            }
        }
        else if(mode == Mode.return_180)
        {
            turning = true;
            if(!_return)
            {
                transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*-90,0.2f).OnComplete(()=>turning = false);
                Vector3 targetRot = originRot+Vector3.up*-90*2;
                Vector3 selfRot = transform.localRotation.eulerAngles + Vector3.up*-90;
                if( (originRot+Vector3.up*-90*2).y<-360 )
                    targetRot +=Vector3.up*360;
                if(selfRot.y<-360)
                    selfRot += Vector3.up*360;
                if(targetRot == selfRot)
                {
                    _return = true;
                }
                // if(originRot + Vector3.up*-90*2 == transform.localRotation.eulerAngles + Vector3.up*-90)
                // {
                //     _return = true;
                // }
            }
            else
            {
                transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*90,0.2f).OnComplete(()=>turning = false);
                if(Quaternion.Euler(originRot).eulerAngles == Quaternion.Euler(transform.localRotation.eulerAngles + Vector3.up*90).eulerAngles)
                {
                    _return = false;
                }
            }
        }
        else if(mode == Mode.Degree_90)
        {
            turning = true;
            transform.DORotate(transform.localRotation.eulerAngles+ Vector3.up*-90,0.2f).OnComplete(()=>turning = false);
        }

        Invoke("RotateDir",coolTime);
    }

    IEnumerator _SwitchTrigger()
    {
        
        if(!_return)
        {
            _return = true;
            foreach(GameObject obj in _switch1)
            {
                obj.SetActive(false);
            }
            yield return new WaitForSeconds(0.2f);
            foreach(GameObject obj in _switch2)
            {
                obj.SetActive(true);
            }
            
        }
        else
        {
            _return = false;
            foreach(GameObject obj in _switch2)
            {
                obj.SetActive(false);
            }
            yield return new WaitForSeconds(0.2f);
            foreach(GameObject obj in _switch1)
            {
                obj.SetActive(true);
            }
        }

    }
    
}
