using System.Collections.Generic;
using Audiotter.Runtime.Components.Players.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audiotter.Runtime.Components.Players
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