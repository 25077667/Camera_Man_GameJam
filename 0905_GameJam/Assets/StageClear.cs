using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StageClear : MonoBehaviour
{
    Vector3 oriRot;
    Vector3 oriScale;
    public Image flash;
    public GameObject nextButton;

    void Start()
    {
        oriRot = transform.rotation.eulerAngles;
        oriScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        flash.transform.gameObject.SetActive(true);
        transform.DORotate(Vector3.zero,0.5f);
        transform.DOScale(new Vector3(1,1,1),0.5f).OnComplete(()=>nextButton.SetActive(true));
        flash.DOFade(0,0.25f);

    }
    void Complete()
    {

    }
}
