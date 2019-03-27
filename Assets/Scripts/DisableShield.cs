using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShield : MonoBehaviour
{
    private MeshRenderer renderMesh;
    private CircleCollider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        renderMesh = GetComponent<MeshRenderer>();
        col = GetComponent<CircleCollider2D>();
    }

    public void SetState(bool enable)
    {
        renderMesh.enabled = enable;
        col.enabled = enable;
    }
}
