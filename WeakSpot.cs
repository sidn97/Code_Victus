using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
