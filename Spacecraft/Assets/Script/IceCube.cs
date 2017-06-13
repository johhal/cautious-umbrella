
using UnityEngine;

public class IceCube : CarriableObject
{
    public SpriteRenderer spriteRenderer;
    public float currentIceLevel = 100;
    public float decreaseRate = 1;
    public Rigidbody2D rigidBody;

    public GameObject carryingPlayer;
    
    //Stores the mass when the object is picked up
    void Start()//int currentIceLevel, int recoveryRate, int labor)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        InvokeRepeating("DecreaseIceLevel", 1.0f, 0.1f);
    }

    //Used to regenerate player stamina
    void DecreaseIceLevel()
    {
        currentIceLevel -= decreaseRate;
        if(currentIceLevel < 0)
        {
            //Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		//if (carryingPlayer != null)
  //      {
  //          transform.position  = carryingPlayer.transform.position;
  //      }
	}

    public override bool FocusGained()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.blue;
            return true;
        }
        return base.FocusGained();
    }

    public override bool FocusLost()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            return true;
        }
        return base.FocusLost();
    }

    public override float Activate(PlayerManager playerManager)  // Skicka med ett mäniskoobjekt. 
    {
        Debug.Log("IceCube Activate");
        if (playerManager.carryManager.IsCarrying())
        {
            Debug.Log("IceCube is Carrying");
            if (playerManager.carryManager.DropMe(this))
            {
                return 1;
            }
            else
            {
                return 0.1f;
            }
        }

       //Check if the carrymanager could pick me up...
        if (playerManager.carryManager.PickMeUp(this))
        {
            Debug.Log("Was picked up.");
            return 1;
        }
        else
        {
            return 0.1f;
        }
               
    }
    public override bool pickUp(PlayerManager playerManager)
    {
        if (rigidBody != null)
        {
            rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
            rigidBody.velocity = Vector2.zero;
            rigidBody.angularVelocity = 0f;
            //rigidBody.
        }
        return true;
    }
    
    public override bool drop()
    {
        if (rigidBody != null)
        {
            rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous ;
            rigidBody.velocity = Vector2.zero;
            rigidBody.angularVelocity = 0f;
        }
        return true;
    }
}
