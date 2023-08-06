using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent(typeof(Player)))
        {
            SceneManager.LoadScene(_nextSceneName);
        }
    }
}
