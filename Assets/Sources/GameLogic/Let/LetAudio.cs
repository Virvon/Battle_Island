using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleIsland.GameLogic
{
    [RequireComponent(typeof(Let))]
    public class LetAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource _hitAudio;
        [SerializeField] private AudioSource _dieAudio;

        private Let _let;

        private void OnEnable()
        {
            _let = GetComponent<Let>();

            _let.Hited += StartHitAudio;
            _let.Broked += StartDieAudio;
        }

        private void OnDisable()
        {
            _let.Hited -= StartHitAudio;
            _let.Broked -= StartDieAudio;
        }

        private void StartHitAudio()
        {
            _hitAudio.Play();
        }

        private void StartDieAudio()
        {
            _dieAudio.Play();
        }
    }
}