using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFunction : MonoBehaviour
{

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      


        enemyWalking();

    }


    void enemyWalking()
    {
     
          GetComponent<Animator>().SetBool("isWalking", true);
          
    }


    // What keeps character going
    // Is focus on the world or the character - Massive impact on the game itself
}
