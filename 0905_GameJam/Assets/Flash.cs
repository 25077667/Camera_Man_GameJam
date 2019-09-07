using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Flash : MonoBehaviour
{
    //Image m_Image;
    void Start()
    {
        //m_Image = transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        //m_Image.DOFade(1,0);
        Invoke("CloseFlash",0.1f);
    }
    void CloseFlash()
    {
        //m_Image.DOFade(0,0.2f).OnComplete(()=>transform.gameObject.SetActive(false));
        transform.gameObject.SetActive(false);
        
    }
}
