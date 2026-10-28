using UnityEngine;


namespace Activity_7_Water
{
    public class Raft : MonoBehaviour
    {
        [SerializeField] int movementThreshold = 100;
        [SerializeField] float movementStrenght = 1.0f;
        int movFlag;
        bool goingDown;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            movFlag = movementThreshold;
        }

        // Update is called once per frame
        void Update()
        {
            Float();
            SeaWaves();
            Travel();
        }

        void Float()
        {
            if (movFlag <= 0)
            {
                movFlag = movementThreshold;
                goingDown = !goingDown;
                return;
            }
            --movFlag;
            if (goingDown)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 
                                        movementStrenght * 
                                        Time.deltaTime, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 
                                        movementStrenght * 
                                        Time.deltaTime, transform.position.z);
            }
        }
        void SeaWaves()
        {
            
        }
        void Travel()
        {
            
        }
    }
}