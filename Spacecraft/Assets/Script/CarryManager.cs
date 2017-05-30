
using UnityEngine;

public class CarryManager : MonoBehaviour {

    //The objejct currently being carried. Null if nothing.
    CarriableObject currentObject;

    //The playermanager belonging to the player
    public PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (currentObject != null)
        {
            currentObject.transform.position = playerManager.carryingPosition.transform.position;
            currentObject.transform.rotation = playerManager.transform.rotation;
        }
    }

    public bool IsCarrying()
    {
        return currentObject != null;
    }

    //Pick up the CarriableObject if it is valid and you are not carrying anything
    public bool PickMeUp(CarriableObject newObject)
    {
        if (IsCarrying())
        {
            return false;
        }

        if (newObject == null)
        {
            return false;
        }

        if (newObject.pickUp(playerManager))
        {
            currentObject = newObject;
            return true;
        }
        return false;
    }

}
