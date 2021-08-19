using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public class Teleport : MonoBehaviour
    {

        GameObject currentCollision;
        bool inCollider;

        // Start is called before the first frame update
        void Start()
        {
            currentCollision = null;
        }

        // Update is called once per frame
        void Update()
        {
            if (inCollider == true) // In collider
            {
                Debug.Log(currentCollision.name.ToString());
            
                if (currentCollision.name == "ToBathroom" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(2.852f, -22.667f);
                    Debug.Log("in collider");
                }


                if (currentCollision.name == "FromBathroom" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(16.76f, -0.85f);

                }

                if (currentCollision.name == "ToGarbage" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(80.04f, 33.41f);

                }

                if (currentCollision.name == "FromGarbage" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(70.28f, -23.68f);

                }

                if (currentCollision.name == "ToScene1" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(-97.73f, 27.08f);

                }

                if (currentCollision.name == "FromScene1" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(-12.02f, 19.99f);

                }

                if (currentCollision.name == "ToScene2" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(82.95f, 43.9f);

                }

                if (currentCollision.name == "FromScene2" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(7.6f, 19.95f);

                }

                if (currentCollision.name == "ToScene3" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(4.04f, 49.57f);

                }

                if (currentCollision.name == "FromScene3" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(81.1f, 61.33f);

                }
                if (currentCollision.name == "ToScene4" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(4.04f, 49.57f);

                }

                if (currentCollision.name == "FromScene4" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(81.1f, 61.33f);

                }
                if (currentCollision.name == "ToScene5" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(4.04f, 49.57f);

                }

                if (currentCollision.name == "FromScene5" & Input.GetKeyDown(KeyCode.E))
                {
                    transform.position = new Vector3(81.1f, 61.33f);

                }
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Teleport"))
            {

                currentCollision = collision.gameObject;
                Debug.Log(currentCollision);

                inCollider = true;


            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            inCollider = false;
        }
    }
}
