using System.Collections;
using UnityEngine;

//Script should spawn a Coin in a random place between destination points
public class CoinManagerScript : MonoBehaviour
{
    //Prefabs
    [SerializeField]
    private GameObject destinationPointA;
    [SerializeField]
    private GameObject destinationPointB;
    [SerializeField]
    private GameObject destinationPointC;

    [SerializeField]
    private GameObject coinPrafab;


    float destCAx;
    float destCAz;

    float destABx;
    float destABz;

    float destBCx;
    float destBCz;


    void Start()
    {
        StartCoroutine(SpawnCoins());
    }
    


    IEnumerator SpawnCoins()
    {
        while (true)
        {
            CA_CoinCreation();
            AB_CoinCreation();
            BC_CoinCreation();

            yield return new WaitForSeconds(5);
        }
    }



    private void CA_CoinCreation()
    {
        destCAx = Random.Range(destinationPointC.transform.position.x, destinationPointA.transform.position.x);
        destCAz = Random.Range(destinationPointC.transform.position.z, destinationPointA.transform.position.z);

        transform.position = new Vector3(destCAx, 2f, destCAz);

        CreateCoin(destCAx, destCAz);
    }

    private void AB_CoinCreation()
    {
        destABx = Random.Range(destinationPointA.transform.position.x, destinationPointB.transform.position.x);
        destABz = Random.Range(destinationPointA.transform.position.z, destinationPointB.transform.position.z);

        transform.position = new Vector3(destABx, 2f, destABz);

        CreateCoin(destABx, destABz);
    }

    private void BC_CoinCreation()
    {
        destBCx = Random.Range(destinationPointB.transform.position.x, destinationPointC.transform.position.x);
        destBCz = Random.Range(destinationPointB.transform.position.z, destinationPointC.transform.position.z);

        transform.position = new Vector3(destBCx, 2f, destBCz);

        CreateCoin(destBCx, destBCz);
    }


    private void CreateCoin(float _destinationX, float _destinationZ)
    {
        Instantiate (coinPrafab, new Vector3 (_destinationX, 8f, _destinationZ), Quaternion.Euler(90f, 0f, 0f) );

        // Destruction script should be separatelly attached to a prefab, so each Obj instance could delete
        // itself without deleting MAIN PREFAB. Which can cause reference error.
    }
}
