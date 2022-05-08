using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public static class ParticleHelper
    {
        public static void PlayIfNotPlaying(this ParticleSystem particle)
        {
            if (!particle.isPlaying)
            {
                particle.Play();
            }
        }


        public static void StopIfPlaying(this ParticleSystem particle)
        {
            if (particle.isPlaying)
            {
                particle.Stop();
            }
        }
    }
}
