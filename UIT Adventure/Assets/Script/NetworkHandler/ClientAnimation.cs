using Unity.Netcode.Components;
using UnityEngine;


    public class ClientAnimation : NetworkAnimator
    {
   
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
