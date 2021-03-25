using UnityEngine;


namespace Galaxy
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject destinationPoint1;
        [SerializeField]
        private GameObject destinationPoint2;
        [SerializeField]
        private GameObject destinationPoint3;

        private GameObject currentDestination; //Target to move towards

        private Transform currentDestinationRotation; //Target to rotate towards

        private int destinationSwitchingIterator = 0;

        [SerializeField]
        private ScoreUpdateScript scoreScript;
        //Reference to a UI obj with ScoreUpdateScript attached


        private void Start()
        {
            destinationSetup();
        }


        // Destination changer
        private void destinationSetup()
        {

            switch (destinationSwitchingIterator)
            {
                case 0:
                    currentDestination = destinationPoint1;
                    currentDestinationRotation = currentDestination.transform;
                    break;
                case 1:
                    currentDestination = destinationPoint2;
                    currentDestinationRotation = currentDestination.transform;
                    break;
                case 2:
                    currentDestination = destinationPoint3;
                    currentDestinationRotation = currentDestination.transform;
                    break;
                default:
                    break;
            }

            if (destinationSwitchingIterator == 2)
            {
                destinationSwitchingIterator = 0;
            }
            else
            {
                destinationSwitchingIterator++;
            }
        }



        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "GoldCoin")
            { 
                Destroy(collision.gameObject, 0f);

                scoreScript.AddScore();
            }
        }



        // Moving to currentDestination & Rotating towards currentDestinationRotation  
        void FixedUpdate()
        {
            // The step size is equal to speed times frame time.
            float singleStep = 4f * Time.deltaTime;

            if (transform.position != currentDestination.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentDestination.transform.position, singleStep);
            }
            else
            {
                destinationSetup();
            }


            // Determine which direction to rotate towards
            Vector3 targetDirection = currentDestinationRotation.position - transform.position;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);


            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}