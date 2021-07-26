using System;
using UnityEngine;

public class NitroManager : MonoBehaviour
{
   public GameObject nitroAnimation;
   
   public bool isNitroAvailable;
   private AudioManager am;
   private void Start()
   {
      isNitroAvailable = true;
      am = AudioManager.Instance;
   }

   public void DisableNitro()
   {
      isNitroAvailable = false;
      //do an animation
      //do sound
      nitroAnimation.SetActive(true);
      Invoke("DisableAnimation",2);
      am.PlayNitro();   
      //ui feedback;
   }

   void DisableAnimation()
   {
      nitroAnimation.SetActive(false);
   }
   
}
