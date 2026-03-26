using UnityEngine;

public class ColoredGate : MonoBehaviour
{
    [SerializeField] Collider2D hardCollider;
    [SerializeField] Color color = Color.red;
    [SerializeField] SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Color otherColor = collision.gameObject.GetComponent<PlayerColor>().GetColor();
            if (otherColor == color)
            {
                hardCollider.enabled = false;
            }
            else
            {
                hardCollider.enabled = true;
            }
        }
    }
    
    void Start()
    {
        sr.color = new Color(color.r, color.g, color.b, 1f);
        sr.material.SetColor("BaseColor", color);
    }
}
