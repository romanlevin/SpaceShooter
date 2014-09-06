using UnityEngine;
using System.Collections;

public class ChooseRandomMesh : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer> (true);
        MeshRenderer selectedMeshRenderer;
        selectedMeshRenderer = meshRenderers [Random.Range (0, meshRenderers.Length)];
        selectedMeshRenderer.enabled = true;
    }
	

}
