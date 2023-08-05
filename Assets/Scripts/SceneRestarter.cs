using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent(typeof(Player)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
