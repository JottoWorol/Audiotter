using Assets.Runtime.Components.Players.Base;
using UnityEngine;

namespace Assets.Runtime.Components.Players
{
    [AddComponentMenu("Audiotter/Players/Audiotter Loop")]
    public class AudiotterLoop : AudiotterLoopBase
    {
        [Space(10)]
        [SerializeField] private AudioClip _audioClip;

        protected override void TryPlayLoop()
        {
            if (_audioClip == null)
                return;

            AudioSource.clip = _audioClip;
            AudioSource.loop = true;
            AudioSource.Play();
        }
    }
}