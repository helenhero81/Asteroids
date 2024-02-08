using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]private Asteroid asteroiddPrefab;
    public int asteroidCount = 0;
    private int lvl =0;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
        // if No astriods spawn in more
        if (asteroidCount == 0){
            lvl++;

            //spawn X amount of astriods in
            // l=4, 2=>6, 3=>8, 4=>10....
            int  numAsteriods = 2+ (2* lvl);
            for ( int i = 0; i<numAsteriods ; i++){
                SpawnAstreiod();
            }
        }
    }
    private void SpawnAstreiod(){

        // How far
        float offset = Random.Range( 0F , 1F);
        Vector2 viewportSpawnPosition = Vector2 .zero;

        // with edge 
        int edge = Random .Range( 0, 4);
        if ( edge ==0){
            viewportSpawnPosition = new Vector2 ( offset, 0);      
        }else if (edge ==1){
            viewportSpawnPosition = new Vector2 ( offset, 1);
        } else if (edge ==2){
           viewportSpawnPosition = new Vector2 ( 0, offset );
        } else if (edge ==3){
           viewportSpawnPosition = new Vector2 (1, offset);

    }

    // Greate Asteroid
    Vector2 worldSpawnPosition = Camera.main . ViewportToWorldPoint( viewportSpawnPosition);
    Asteroid asteroid = Instantiate(asteroiddPrefab ,  worldSpawnPosition ,Quaternion.identity);
        }
    public void GameOver(){
        StartCoroutine(Restart());
    }

    private IEnumerator Restart(){
        Debug.Log( "Game Over");
        yield return new WaitForSeconds(2F);
        
        // wait a bit for restart 
        SceneManager. LoadScene( SceneManager.GetActiveScene ().buildIndex );
        yield return null;
    }
    }
