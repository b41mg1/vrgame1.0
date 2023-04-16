using UnityEngine;

[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class camera : MonoBehaviour
{

  

    private MeshRenderer meshRenderer;
    private TextMesh textMesh;


   

    private void Update()
    {
      transform.LookAt(Camera.main.transform);
    }


}