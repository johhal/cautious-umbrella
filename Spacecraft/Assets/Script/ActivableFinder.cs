using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableFinder : MonoBehaviour {
    public float MaxDistance = 3;
    // Use this for initialization
    public ActivableObject active;

    //Access to the player movement
    public PlayerMovement playerMovement;
    //Access to the player stats
    public PlayerStatsManager playerStatsManager;

    // Update is called once per frame
    void Update() {
        active = getCloseActivable();

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
