using UnityEngine;
using System.Collections;

public class ChooseRandomMesh : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer> (true);
        MeshRenderer selectedMeshRenderer;
        Debug.Log (meshRenderers);
        selectedMeshRenderer = meshRenderers [Random.Range (0, meshRenderers.Length)];
        Debug.Log (selectedMeshRenderer);
        Debug.Log (selectedMeshRenderer.enabled);
        selectedMeshRenderer.enabled = true;
        Debug.Log (selectedMeshRenderer.enabled);
    }
	

}
