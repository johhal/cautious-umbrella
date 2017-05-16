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
    //Access to the player movement
    public PlayerMovement playerMovement;
    //Access to the player stats
    public PlayerStatsManager playerStatsManager;

    // Update is called once per frame
    void Update() {
        //Find nearest ActivableObject within range.
        FindObject();
        //Toggle focus from old (if any) to new (if any)
        Focus();
        //Activate the object if the user is pressing button_a
        Activate();
    }

    private void FindObject()
    {
        active = getCloseActivable();
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
            if (oldActive.Equals(active))
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
            if (playerMovement.button_a)
            {
                active.Activate(playerStatsManager.playerStats);
            }
        }
    }

    ActivableObject getCloseActivable()
    {
        ActivableObject closest = null;
        float closestDistance=float.MaxValue;
        ActivableObject[] activables = GameObject.FindObjectsOfType(typeof(ActivableObject)) as ActivableObject[];

        foreach (ActivableObject activable in activables)
        {
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
