using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Chest
{
    [RequireComponent(typeof(Animator))]
    public class Chest : MonoBehaviour, IChest
    {
        [SerializeField] private ChestInterface _chestInterface;
        [SerializeField] private ParticleSystem _coinstParticle;

        private Animator _animator;
        private bool _opened = false;

        public bool Opened => _opened;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Open()
        {
            _chestInterface.Enable();
            RunOpenAnimation();
            _opened = true;
            StartCoroutine(PlayCoinsEffect(0.3f));
        }

        public void Close()
        {
            _chestInterface.Enable();
            RunCloseAnimation();
            _opened = false;
        }

        private void RunOpenAnimation()
        {
            _animator.SetTrigger("Open");
        }

        private void RunCloseAnimation()
        {
            _animator.SetTrigger("Close");
        }

        private IEnumerator PlayCoinsEffect(float delay)
        {
            yield return new WaitForSeconds(delay);
            _coinstParticle.Play();
        }
    }
}