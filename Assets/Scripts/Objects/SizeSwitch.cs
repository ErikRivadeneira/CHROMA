using UnityEngine;

public class SizeSwitch : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    [SerializeField] ESizes requiredSize = ESizes.medium;
    [SerializeField] private AudioSource aSource;
    [SerializeField] private AudioClip openClip;
    [SerializeField] private AudioClip closeClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            ESizes otherSize = collision.gameObject.GetComponent<PlayerSize>().GetSize();
            if (otherSize >= requiredSize && gate.activeInHierarchy == true)
            {
                gate.SetActive(false);
                aSource.PlayOneShot(openClip);
            }
            else
            {
                aSource.PlayOneShot(closeClip);
            }
        }
    }
}
