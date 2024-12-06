using UnityEngine;


namespace Assets.Scripts.Chest
{
    [RequireComponent(typeof(Canvas))]
    public class ChestInterface : MonoBehaviour
    {
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
