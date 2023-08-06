using UnityEngine;

public class RandomFakePlatform : MonoBehaviour
{
    [SerializeField] private MeshCollider firstPlatformCollider;
    [SerializeField] private MeshCollider secondPlatformCollider;

    private void Start() {
        TurnOffRandomCollider();    
    }

    private void TurnOffRandomCollider() {
        int rand = Random.Range(0,2);
        Debug.Log("Rand "+ rand);
        if (rand == 0) {
            firstPlatformCollider.enabled = false;
            return;
        }
        secondPlatformCollider.enabled = false;
    }


}
