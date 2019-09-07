using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Sprite pointIn;
    public Sprite pointOut;
    Image _image;
    void Start()
    {
        _image = transform.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PointIn()
    {
        _image.sprite = pointIn;
    }
    public void PointOut()
    {
        _image.sprite = pointOut;
    }
    public void Click()
    {
        SceneManager.LoadScene("02");
    }
}
