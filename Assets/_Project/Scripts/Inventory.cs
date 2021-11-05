using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField] private int diamondCount; 

    public static Inventory instance; 

    private void Awake() {
        instance = this; 
    }

    public void AddDiamond(int count) {
        diamondCount += count; 
    }
}
