using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace TellerMachine
{
    class Sounds
    {
        private SoundPlayer soundPlayer = new SoundPlayer();

        public void buttonClick()
        {
            try
            {
                soundPlayer.SoundLocation = "Resources\\button-fx.wav";
                soundPlayer.LoadAsync();
                soundPlayer.Play();
            }
            catch (Exception ex)
            { }
        }
        public void dispensingCash()
        {
            try
            {
                soundPlayer.SoundLocation = "Resources\\dispensing-fx.wav";
                soundPlayer.LoadAsync();
                soundPlayer.Play();
            }
            catch (Exception ex)
            { }
        }
        public void transactionFailed()
        {
            try
            {
                soundPlayer.SoundLocation = "Resources\\voice-access-denied.wav";
                soundPlayer.LoadAsync();
                soundPlayer.Play();
            }
            catch (Exception ex)
            { }
        }
        public void transactionSuccess()
        {
            try
            {
                soundPlayer.SoundLocation = "Resources\\voice-complete.wav";
                soundPlayer.LoadAsync();
                soundPlayer.Play();
            }
            catch (Exception ex)
            { }
        }
    }
}
