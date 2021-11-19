using UnityEngine;

namespace Audiotter.Runtime.Components
{
    [AddComponentMenu("Audiotter/Players/Audiotter OneShot")]
    public class AudiotterOneShot : AudiotterOneShotBase
    {
        [SerializeField] private AudioClip _audioClip;

        protected override bool TryGetClip(out AudioClip audioClip)
        {
            if (_audioClip != null)
            {
                audioClip = _audioClip;
                return true;
            }

            audioClip = null;
            return false;
        }
    }
}