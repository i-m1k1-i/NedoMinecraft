using UnityEngine;

public class BuildPreview : MonoBehaviour
{
    public bool Enabled => gameObject.activeSelf;

    /*private void Awake()
    {
        Vector3 globalScale = Vector3.one;
        globalScaleInLocalScale = new Vector3(globalScale.x / transform.lossyScale.x,
                                              globalScale.y / transform.lossyScale.y,
                                              globalScale.z / transform.lossyScale.z);
        transform.localScale = globalScaleInLocalScale;
    }*/

    public void Enable()    
    {
        gameObject.SetActive(true);
    }

    public void Disable()    
    {
        gameObject.SetActive(false);
    }

    public void SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}
