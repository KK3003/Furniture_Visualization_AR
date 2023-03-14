using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField]
    private Texture[] texture;

    private Renderer cuberenderer;
  
    public void ChnageTexture(int index)
    {
        cuberenderer = GameObject.FindGameObjectWithTag("Test").GetComponent<Renderer>();
        cuberenderer.material.mainTexture = texture[index];
    }
}
