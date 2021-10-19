using Audiotter.Runtime.Components.Players.Base;
using UnityEngine;

namespace Audiotter.Runtime.Components.Players
{
    [AddComponentMenu("Audiotter/Players/Audiotter Loop")]
    public class AudiotterLoop : AudiotterLoopBase
    {
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