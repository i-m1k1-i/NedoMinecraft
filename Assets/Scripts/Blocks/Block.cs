using UnityEngine;

public class Block : MonoBehaviour
{
    public void Destroy()
    {
        if (transform.parent != null && transform.parent.CompareTag(StartGround.Tag))
        {
            return;
        }    

        Destroy(gameObject);
    }   
}
