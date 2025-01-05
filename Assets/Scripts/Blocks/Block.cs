using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = Vector3.zero;
    [SerializeField] private bool _canBuildOnTop = true;

    public Vector3 Offset => _offset;

    public void Destroy()
    {
        if (transform.parent != null && transform.parent.CompareTag(StartGround.Tag))
        {
            return;
        }    

        Destroy(gameObject);
    }
}
