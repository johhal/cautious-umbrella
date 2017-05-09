using UnityEngine;

public class ActivableObject : MonoBehaviour {

    //Overide this to make the object activable for the player
    public bool Activate(float PlayerStats)
    {
        return false;
    }
}
