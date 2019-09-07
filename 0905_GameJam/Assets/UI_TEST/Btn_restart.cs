using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_restart : MonoBehaviour
{
    public string sceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
