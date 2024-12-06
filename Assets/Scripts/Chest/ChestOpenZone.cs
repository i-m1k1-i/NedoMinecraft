using UnityEngine;


namespace Assets.Scripts.Chest
{
    public class ChestOpenZone : MonoBehaviour
    {
        private static readonly KeyCode _chestOpenKey = KeyCode.E;

        private Chest _chest;
        private bool _hasOpener;



        private void Start()
        {
            _chest = GetComponentInParent<Chest>();
        }

        private void Update()
        {
            if (_hasOpener == false)
            {
                return;
            }

            if (Input.GetKeyUp(_chestOpenKey))
            {
                Debug.Log("Chest Open Key clicked");
                if (_chest.Opened == false)
                {
                    Debug.Log("Opening chest");
                    _chest.Open();
                    Debug.Log("Chest opnened");
                }
                else
                {
                    Debug.Log("Closing chest");
                    _chest.Close();
                    Debug.Log("Chest closed");
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ChestOpener>(out ChestOpener _))
            {
                _hasOpener = true;
                Debug.Log("Opener found"); ;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<ChestOpener>(out ChestOpener _))
            {
                _hasOpener = false;
                Debug.Log("Opener exit");
            }
        }
    }
}
