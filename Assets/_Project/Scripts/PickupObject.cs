using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    [SerializeField] private AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            Inventory.instance.AddDiamond(1);
            Destroy(gameObject);
        }
    }

}
