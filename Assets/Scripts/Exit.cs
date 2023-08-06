using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent(typeof(Player)))
        {
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
