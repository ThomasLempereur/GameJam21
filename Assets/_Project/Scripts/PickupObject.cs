using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    //[SerializeField] private Item item; 

    private bool isInRange; 
 //   private Text interactUI; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange) {
            TakeObject(); 
        }
    }

    private void TakeObject() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            //interactUI.enable = true; 
            isInRange = true; 
            Inventory.instance.AddDiamond(1); 
            Destroy(gameObject); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            //interactUI.enable = false; 
            isInRange = false; 
        }
    }
}
