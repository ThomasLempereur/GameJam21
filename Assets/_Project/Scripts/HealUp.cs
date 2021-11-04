using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUp : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
      {
         PlayerHealth player = collision.GetComponent<PlayerHealth>();

         if (player.GetActualHealth() != 3)
         {
            player.HealPlayer();
            Destroy(gameObject);
         }
      }
   }
}
