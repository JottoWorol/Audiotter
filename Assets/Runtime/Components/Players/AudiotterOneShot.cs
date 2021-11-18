using Assets.Runtime.Components.Players.Base;
using UnityEngine;

namespace Assets.Runtime.Components.Players
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