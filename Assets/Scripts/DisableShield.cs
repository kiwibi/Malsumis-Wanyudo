using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShield : MonoBehaviour
{
    private MeshRenderer renderer;
    private CircleCollider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<CircleCollider2D>();
    }

    public void SetState(bool enable)
    {
        renderer.enabled = enable;
        collider.enabled = enable;
    }
}
