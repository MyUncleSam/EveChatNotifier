using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tulpep.NotificationWindow;
using NAudio;
using NAudio.Wave;
using System.Drawing;

namespace EveChatNotifier
{
    public sealed class Notifier
    {
        // singleton elements
        private static Notifier _instance = null;

        // class variables
        private IWavePlayer wp = new WaveOut();

        /// <summary>
        /// singleton private initializer
        /// </summary>
        private Notifier() { }

        /// <summary>
        /// returns the singleton instance of the notifier object
        /// </summary>
        public static Notifier GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Notifier();
            }
            return _instance;
        }

        /// <summary>
        /// sends a notification without audio
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        public void Notify(string title, string message)
        {
            Notify(title, message, null);
        }

        /// <summary>
        /// sends a notification
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="soundFile">null/empty if no sound should be played</param>
        public void Notify(string title, string message, string soundFile)
        {
            PopupNotifier pn = CreateNotify();
            pn.TitleText = title;
            pn.ContentText = message;
            pn.Size = Properties.Settings.Default.ToastSize;
            pn.Popup();

            // send audio notification
            if(!string.IsNullOrWhiteSpace(soundFile))
            {
                try
                {
                    if (wp.PlaybackState == PlaybackState.Stopped)
                    {
                        // try playing the file
                        AudioFileReader afr = new AudioFileReader(soundFile);
                        afr.Volume = Convert.ToSingle(Properties.Settings.Default.SoundVolume / 100.0);
                        wp.Init(afr);
                        wp.Play();
                    }
                }
                catch (Exception ex)
                {
                    Logging.WriteLine(string.Format("Unable to play sound file '{0}' - removing sound file:{1}{2}", soundFile, Environment.NewLine, ex.ToString()));

                    // fallback to windows sounds if we are unable to play the given sound file
                    Properties.Settings.Default.SoundFilePath = null;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
            }
        }

        /// <summary>
        /// stops current playback (if any)
        /// </summary>
        public void StopPlayback()
        {
            if(wp.PlaybackState != PlaybackState.Stopped)
            {
                wp.Stop();
            }
        }

        /// <summary>
        /// creates a new popup notification element
        /// </summary>
        /// <returns></returns>
        private PopupNotifier CreateNotify()
        {
            PopupNotifier pn = new PopupNotifier();
            ApplySettings(pn);
            pn.Click += Notifier_Click;

            return pn;
        }

        /// <summary>
        /// applies all notification settings
        /// </summary>
        /// <param name="Notifier"></param>
        private void ApplySettings(PopupNotifier Notifier)
        {
            // popup notifier settings
            Notifier.IsRightToLeft = false;
            Notifier.ShowCloseButton = true;
            Notifier.ShowGrip = false;
            Notifier.Image = Properties.Resources.eve_logo_landing2;

            Notifier.Delay = Properties.Settings.Default.ToastDelay;
            Notifier.AnimationDuration = 500;

            Notifier.BodyColor = Properties.Settings.Default.ToastBodyColor;
            Notifier.BorderColor = Properties.Settings.Default.ToastBorderColor;
            Notifier.ContentColor = Properties.Settings.Default.ToastContentColor;
            Notifier.ContentHoverColor = Properties.Settings.Default.ToastContentHoverColor;
            Notifier.HeaderColor = Properties.Settings.Default.ToastHeaderColor;
            Notifier.TitleColor = Properties.Settings.Default.ToastTitleColor;

            // font part
            Notifier.TitleFont = new Font(Notifier.TitleFont.FontFamily, Convert.ToSingle(Properties.Settings.Default.ToastFontSizeTitle));
            Notifier.ContentFont = new Font(Notifier.ContentFont.FontFamily, Convert.ToSingle(Properties.Settings.Default.ToastFontSizeContent));
        }

        /// <summary>
        /// closes the popup and stops playing the sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notifier_Click(object sender, EventArgs e)
        {
            try
            {
                PopupNotifier pn = (PopupNotifier)sender;
                pn.Hide();

                try
                {
                    if (wp.PlaybackState != PlaybackState.Stopped)
                    {
                        wp.Stop();
                    }
                }
                catch (Exception ex)
                {
                    Logging.WriteLine(string.Format("Unable to stop playback of sound file: {0}", ex.ToString()));
                }
            }
            catch { }
        }
    }
}
