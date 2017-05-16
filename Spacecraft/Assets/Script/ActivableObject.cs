using UnityEngine;

public class ActivableObject : MonoBehaviour {

    //Overide this to make the object activable for the player
    //Return delay before this object can be active again
    public virtual float Activate(PlayerStats playerStats)
    {
        return -1;
    }
    //Overide this to make the object know  it is active
    //Return true if focus was gained without errors.
    public virtual bool FocusGained()
    {
        return false;
    }
    //Overide this to make the object know it is no longer active
    //Return true if focus was lost without errors.
    public virtual bool FocusLost()
    {
        return false;
    }
}
