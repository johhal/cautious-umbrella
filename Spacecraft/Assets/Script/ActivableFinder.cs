using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableFinder : MonoBehaviour {
    public float MaxDistance = 3;
    // Use this for initialization
    //The new activeable
    public ActivableObject active;
    //The previous one. Used to identify if it has changed.
    public ActivableObject oldActive;
      //Flag to indicate if Coroutine is running
    public bool isActiveCoroutineStarted;
    //The manager of the player this activable finder is bound to
    public PlayerManager playerManager;
    // Minimum detection angle
    public float minDetectionAngle = 45;
    //List of all activables inside the "cone of reach"
    public List<ActivableObject> activables;
    private void Start()
    {
        isActiveCoroutineStarted = false;
        activables = new List<ActivableObject>();
    }

    void Update() {
        //Find nearest ActivableObject within range.
        FindObject();
        //Toggle focus from old (if any) to new (if any)
        Focus();
        //Activate the object if the user is pressing button_a
        Activate();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Collision Enter");
        ActivableObject temp = coll.gameObject.GetComponent<ActivableObject>();
        if (temp != null)
        {
            activables.Add(temp);
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        Debug.Log("Collision Leave");
        ActivableObject temp = coll.gameObject.GetComponent<ActivableObject>();
        if (temp != null)
        {
            activables.Remove(temp);
        }
    }

    private void FindObject()
    {
        if (playerManager.carryManager.IsCarrying())
        {
            active = playerManager.carryManager.currentObject;
        }
        else
        {
            active = getCloseActivable();
        }
        
    }

    private void Focus()
    {
        //If no new was found and no old was used simply exit.
        if (oldActive == null && active == null)
        {
            return;
        }
        //If no old was used and a new was found activate the new one and store it as old.
        if(oldActive == null && active != null)
        {
            oldActive = active;
            active.FocusGained();
        }else if(oldActive != null && active == null)
        {
            //If old was used and no new was found deactivate the old one and set it to null (the new one).
            oldActive.FocusLost();
            oldActive = active;
        }else
        {
            if (!oldActive.Equals(active))
            {
                oldActive.FocusLost();
                active.FocusGained();
                oldActive = active;
            }
        }
    }

    private void Activate()
    {
        if (active != null)
        {
            if (isActiveCoroutineStarted != true)
            {
                StartCoroutine(ActiveCoRoutine());
            }
        }
    }

    public IEnumerator ActiveCoRoutine()
    {
        
        isActiveCoroutineStarted = true;
        float delay;
        while (playerManager.playerMovement.button_a)
        {
            delay = active.Activate(playerManager);
            yield return new WaitForSeconds(delay);
        }
        isActiveCoroutineStarted = false;
    }

    ActivableObject getCloseActivable()
    {

         ActivableObject closest = null;
        float closestDistance=float.MaxValue;
        //ActivableObject[] activables = GameObject.FindObjectsOfType(typeof(ActivableObject)) as ActivableObject[];

        foreach (ActivableObject activable in activables)
        {
            //Debug.Log(Vector3.Angle(transform.up, activable.transform.position - transform.position).ToString());
            //if (Vector3.Angle(transform.up, activable.transform.position - transform.position) < minDetectionAngle)
            //{
                float dist = Vector3.Distance(activable.transform.position, transform.position);
                if (closest == null)
                {
                    closest = activable;
                    closestDistance = dist;
                }
                else
                {
                    if (dist < closestDistance)
                    {
                        closest = activable;
                        closestDistance = dist;
                    }
                }
            //}

        }

        if (closestDistance <= MaxDistance)
        {
            return closest;
        }
        else
        {
            return null;
        }

    }
}
