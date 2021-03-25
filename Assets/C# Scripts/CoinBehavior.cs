using UnityEngine;


public class CoinBehavior : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * 200f);
    }


    // Will trigger after coin CLONE creation
    private void Awake()
    {
        CoinDestruction(5f);
    }



    private void CoinDestruction(float _destroyTime)
    {
        Destroy(this.gameObject, _destroyTime);
    }
}
