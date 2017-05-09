using UnityEngine;

public class ActivableObject : MonoBehaviour {

    //Overide this to make the object activable for the player
    public override bool Activate(float PlayerStats)
    {
        return false;
    }
}
