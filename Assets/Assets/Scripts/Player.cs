using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    //private Bullet bulletPrefab;
    private bool thrusting = true;
    public float Speed = 5f;
    public float MaxSpeed = 5f;
    public float rotationSpeed = 180f;
    [SerializeField] private float bulletSpeed =8f;
    [SerializeField ]private Transform bulletSpawn;
    [SerializeField ]private Rigidbody2D bulletPrefab;

    private bool Alive = true ;

    

    private void Start()
    {
        //Get rigidbody attached to ship
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       handleShipSpeed();
       HandleRotation();
       Shoot();
    }

    private void FixedUpdate()
    {
        if(thrusting){
            rb.AddForce(Speed * transform.up);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
        }
    }

    private void handleShipSpeed(){
        //check if moving
        thrusting = Input.GetKey(KeyCode.UpArrow);
    }
    private void HandleRotation(){
        // SHIP  rotation
        if (Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(rotationSpeed * Time.deltaTime* transform.forward);
            }else if(Input.GetKey(KeyCode.RightArrow)){
                transform.Rotate(-rotationSpeed * Time.deltaTime* transform.forward);
            }
               
        }

    private void Shoot()
    {
      if (Input.GetKeyDown(KeyCode.Space)){
        Rigidbody2D bullet= Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        // inherit velocity of the ship
        Vector2 velocity = rb.velocity;
        Vector2 Diretion=transform.up;
        float ForwandSpeed= Vector2.Dot(velocity,Diretion);

        // innherit the opposite direction
        if(ForwandSpeed <0){
            ForwandSpeed=0;
        }
        
        // Add force to bullet
        bullet.AddForce(bulletSpeed* transform.up, ForceMode2D.Impulse);
      }
    }
     private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Asteriod")){
            Alive= false ;

            // Get refrence to the GameManager
            GameManager gameManager= FindAnyObjectByType<GameManager >();

            //Restart after Delay
            gameManager .GameOver();


            // Destroy player 
            Destroy (gameObject);
        
        }
     }

}

   
       
    

    
    


