using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    public static int amount;
    public bool yesorno; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        amount++;

        // lo que esta en inspector
        Player.singleton = null;
        // Player myplayer = new Player();
        // myplayer.singleton = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
