using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
   public string interactDescription;
   public UnityEvent onInteract;

   public void Inteact()
   {
      if(onInteract != null)
         onInteract.Invoke();
   }
}
