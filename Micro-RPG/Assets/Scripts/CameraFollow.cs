using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public GameObject target;

   private void LateUpdate()
   {
      transform.position = new Vector3(target.transform.position.x,target.transform.position.y, -10);
   }
}
