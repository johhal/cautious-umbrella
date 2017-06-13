
using UnityEngine;

public class CarryManager : MonoBehaviour {

    //The objejct currently being carried. Null if nothing.
    public CarriableObject currentObject;

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

    //Drop the carriableObject if we are carrying it.
    public bool DropMe(CarriableObject carriedObject)
    {
        Debug.Log("CarryManager DropMe");
        if (carriedObject == null)
        {
            Debug.Log("CarryManager CarriedObject is null");
            return false;
        }

        if (IsCarrying())
        {
            Debug.Log("CarryManager IsCarrying");
            if (currentObject == carriedObject)
            {
                Debug.Log("CarryManager currentObjejct = carriedObjejct");
                if (currentObject.drop())
                {
                    Debug.Log("CarryManager dropped.");
                    currentObject = null;
                    return true;
                }                
            }
        }
        Debug.Log("CarryManager Failed and return false.");
        return false;
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
