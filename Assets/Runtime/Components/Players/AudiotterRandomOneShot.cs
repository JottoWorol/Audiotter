using System.Collections.Generic;
using UnityEngine;

namespace Audiotter.Runtime.Components
{
    [AddComponentMenu("Audiotter/Players/Audiotter Random OneShot")]
    public class AudiotterRandomOneShot : AudiotterOneShotBase
    {
        [SerializeField] private List<AudioClip> _audioClipBank = new List<AudioClip>();

        protected override bool TryGetClip(out AudioClip audioClip)
        {
            if (_audioClipBank.Count != 0)
            {
                audioClip = _audioClipBank[Random.Range(0, _audioClipBank.Count)];
                return true;
            }

            audioClip = null;
            return false;
        }
    }
}