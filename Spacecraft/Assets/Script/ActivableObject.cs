using UnityEngine;

public class ActivableObject : MonoBehaviour {

    //Overide this to make the object activable for the player
    public virtual bool Activate(PlayerStats playerStats)
    {
        return false;
    }
}
