//Attach this script to a GameObject
//Create an Image GameObject by going to Create>UI>Image. Attach this Image to the Image field in your GameObject’s Inspector window.
//This script creates a toggle that fades an Image in and out.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeEncryptEx : MonoBehaviour
{
    //Attach an Image you want to fade in the GameObject's Inspector
    public GameObject g_Image;

    private Image m_Image;
    //Use this to tell if the toggle returns true or false
    public bool m_Fading;
    private Color c;
    private void Start()
    {
        g_Image.SetActive(false);
        m_Image = g_Image.GetComponent<Image>();
        m_Image.CrossFadeAlpha(0,0.1f,false);
        g_Image.SetActive(true);
        Invoke("StartFadeIn",2);
        Invoke("StartFadeOut",5);
        Invoke("SceneChange",7);
    }

    void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }
    void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }
    
    IEnumerator FadeIn()
    {
        Debug.Log("fading in");
        m_Image.CrossFadeAlpha(1,2f,false);
        //m_Image.CrossFadeColor(new Color(255f,255f,255f,255f),2.0f,false, true);
        yield return null;
    }
    
    IEnumerator FadeOut()
    {
        Debug.Log("fading out");
        m_Image.CrossFadeAlpha(0,2f,false);
        //m_Image.CrossFadeColor(new Color(255f,255f,255f,0f),2.0f,false, true);
        yield return null;
    }

    void SceneChange()
    {
        SceneManager.LoadScene(1); //intro
    }
}