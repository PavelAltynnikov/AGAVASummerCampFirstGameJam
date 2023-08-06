using UnityEngine;
using TMPro;

public class СhangingTheInscriptionAboveTheDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text doorText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent(typeof(Player)))
        {
            doorText.text = "Welcome to the Club Buddy";
        }
    }
}
