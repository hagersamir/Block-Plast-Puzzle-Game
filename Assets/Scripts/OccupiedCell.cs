using UnityEngine;

public class OccupiedCell : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool occupied = false;   // is this cell filled already?

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
}
