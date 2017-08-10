using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    public int playerId = 1;
    public PlayerMovement playerMovement;
    public PlayerStatsManager playerStatsManager;
    public ActivableFinder activableFinder;
    public GameObject carryingPosition;
    public CarryManager carryManager;
    public Animator animator;
    private void Start()
    {
        playerMovement.joystickNumber = playerId;
    }

    public void Update()
    {
        if(animator != null)
        {
            if (playerMovement != null)
            {
                animator.SetBool("Walking", playerMovement.moving);
            }

            if (carryManager != null)
            {
                animator.SetBool("Carry", carryManager.IsCarrying());
            }            
        }
    }

   

}
