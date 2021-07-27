using System;
using UnityEngine;

public class NitroManager : MonoBehaviour
{
   public GameObject nitroAnimation;
   
   public bool isNitroAvailable;
   private AudioManager am;

   public GameObject nitroReady;
   public GameObject nitroUsing;
   public GameObject nitroEmpty;

   private GameOverScript g;
   private void Start()
   {
      g = GameOverScript.Instance;
      isNitroAvailable = true;
      am = AudioManager.Instance;
      
      // prepare ui 
      nitroReady.SetActive(true);
      nitroUsing.SetActive(false);
      nitroEmpty.SetActive(false);
   }

   public void DisableNitro()
   {
      nitroReady.SetActive(false);
      nitroUsing.SetActive(true);
      nitroEmpty.SetActive(false);
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
      if (!g.gameover)
      {
         nitroAnimation.SetActive(false);
         DisableUI();
      }
   }

   void DisableUI()
   {
      nitroReady.SetActive(false);
      nitroUsing.SetActive(false);
      nitroEmpty.SetActive(true);
   }
   
}
