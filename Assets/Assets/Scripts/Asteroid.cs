using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int size= 3;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = Object.FindAnyObjectByType<GameManager>();
        if  (gameManager == null){
            Debug.LogError("GameManager not  found in the scene");
            return;
        }
;        // scale based on size
        transform.localScale=0.3f* size * Vector3.one;
       
       // add movement , The bigger the object the slower it is
       Rigidbody2D rb= GetComponent<Rigidbody2D>();
       Vector2  direction = new Vector2(Random.value ,Random.value ).normalized; 
       float spawnSpeed= Random.Range(4f -size, 5f - size);
       rb.AddForce (direction * spawnSpeed,ForceMode2D .Impulse );

       gameManager.asteroidCount++;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        //Asteroids destroyed only by bullets
        if (collision .CompareTag("Bullet")){
            gameManager.asteroidCount--;
            // Destroy Bullet
            Destroy(collision.gameObject);
            // if size is> 1 spawn smaller asteroids in 
            if (size >1){
                for (int i = 0; i < 1; i++){
                    Asteroid newAsteriod =Instantiate(this,transform.position ,Quaternion.identity);
                    newAsteriod.size = size -1;
                    newAsteriod.gameManager = gameManager;
                    }
                }
            }
                //Destroy this astariod
                Destroy (gameObject);
            }
        
    
}
