using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activateable : MonoBehaviour {

    //Overide this to make the object activable for the player
    public bool Activate(float PlayerStats)
    {
        return false;
    }
}
