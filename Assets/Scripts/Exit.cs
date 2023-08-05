using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private int _nextSceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent(typeof(Player)))
        {
            SceneManager.LoadScene(_nextSceneNumber);
        }
    }
}
