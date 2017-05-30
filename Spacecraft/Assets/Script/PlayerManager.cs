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

    private void Start()
    {
        playerMovement.joystickNumber = playerId;
    }
}
