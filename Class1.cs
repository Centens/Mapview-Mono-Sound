using System.Collections.Generic;
using UnityEngine;

namespace MapviewMonoSound
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class LemonGrass : MonoBehaviour
    {
        public void Start()
        {
            GameEvents.OnMapEntered.Add(MapviewToMono);
            GameEvents.OnMapExited.Add(MapviewToStereo);           
        }

        

        /*MIT License
         * 
         * Copyright () 2018 LemonGrass
         * 
         * Permission is hereby granted, free of charge, to any person obtaining a copy
         * of this software and associated documentation files (the "Software"), to deal
         * in the Software without restriction, including without limitation the rights
         * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
         * copies of the Software, and to permit persons to whom the Software is
         * furnished to do so, subject to the following conditions:
         * 
         * The above copyright notice and this permission notice shall be included in all
         * copies or substantial portions of the Software.
         * 
         * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
         * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
         * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
         * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
         * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
         * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
         * SOFTWARE. 
        */


        /* Version       : 1.0.1
         * Date Modified : 20 / 02 / 2018
        */

        List<AudioSource> playingSources;


        private void MapviewToMono()
        {
            CurrentAudio();
            foreach (AudioSource a in playingSources)
            {
                a.spatialBlend = 0;
            }            
        }

        private void MapviewToStereo()
        {
            CurrentAudio();
            foreach (AudioSource a in playingSources)
            {
                a.spatialBlend = 1;
            }
        }

        private void CurrentAudio()
        {
            playingSources = new List<AudioSource>();
            AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (AudioSource a in sources)
            {
                if (a.isPlaying && !a.name.Contains("Music") )
                {
                    playingSources.Add(a);
                }
            }
        }
    }
}
