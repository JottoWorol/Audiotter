using System.Collections.Generic;
using Assets.Runtime.Components.Players.Base;
using UnityEngine;

namespace Assets.Runtime.Components.Players
{
    [AddComponentMenu("Audiotter/Players/Audiotter Random OneShot")]
    public class AudiotterRandomOneShot : AudiotterOneShotBase
    {
        [Space(10)]
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