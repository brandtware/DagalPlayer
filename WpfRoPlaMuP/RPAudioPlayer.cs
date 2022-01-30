using NAudio.Vorbis;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NVorbis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagalPlayer
{
    public class RPAudioPlayer : IDisposable
    {
        WaveOutEvent wo = null;
        ISampleProvider sp = null;
        int currentTrack = 0;
        bool closing = false;

        public RPAudioPlayer(List<RPAudioTrack> tracks, RPTrackPlayMode pm = RPTrackPlayMode.linear)
        {
            if (tracks.Count > 0)
            {
                Tracks = tracks;
                PlayMode = pm;
            }
            else
            {
                throw new ArgumentException("Tracks are empty");
            }
        }

        public void Init()
        {
            wo = new WaveOutEvent();
            if (PlayMode == RPTrackPlayMode.random)
            {
                CurrentTrack = App.rnd.Next(Tracks.Count);
            }
            wo.PlaybackStopped += Wo_PlaybackStopped; 
            SetTrack(currentTrack);
        }


        public void NextTrack()
        {
            if (PlayMode == RPTrackPlayMode.random)
            {
                currentTrack = App.rnd.Next(Tracks.Count);
            }
            else
            {
                if (currentTrack + 1 < Tracks.Count)
                {
                    currentTrack++;
                }
                else
                {
                    currentTrack = 0;
                }
            }
            SetTrack(currentTrack);
        }

        private void SetTrack(int pos)
        {
            DisposeReader();
            if (pos >= 0 && pos < Tracks.Count)
            {
                var track = Tracks[pos];
                TimeSpan tracklength;
                if (track.Path.EndsWith(".ogg"))
                {
                    sp = new VorbisWaveReader(track.Path);
                    tracklength = ((VorbisWaveReader)sp).TotalTime;
                }
                else
                {
                    sp = new AudioFileReader(track.Path);
                    tracklength = ((AudioFileReader)sp).TotalTime;
                }
                if (track.FadeOutFrom != -1)
                    sp = sp.Take(TimeSpan.FromSeconds(track.FadeOutFrom));
                if (track.FadeInFrom != 0)
                    sp = sp.Skip(TimeSpan.FromSeconds(track.FadeInFrom));
                FadeInOutSampleProvider fiosp = new FadeInOutSampleProvider(sp, true);
                fiosp.BeginFadeIn(5000);
                fiosp.BeginFadeOut(5000);
                wo.Init(sp);
                wo.Play();
            }
        }

        private void DisposeReader()
        {
            if (sp is VorbisWaveReader vwr)
            {
                vwr.Dispose();
            }
            else if (sp is AudioFileReader afr)
            {
                afr?.Dispose();
            }
        }

        public void Play()
        {
            var track = Tracks[currentTrack];
            wo.Volume = track.Volume;
            wo?.Play();
        }

        public void Stop()
        {
            wo?.Stop();
        }

        private void Wo_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (!closing)
            {
                NextTrack();
            }
        }

        public void Dispose()
        {
            closing = true;
            wo?.Stop();
            wo?.Dispose(); 
            DisposeReader();
        }

        public List<RPAudioTrack> Tracks { get; set; }
        public RPTrackPlayMode PlayMode { get; }
        public int CurrentTrack { get; set; }

        public float? Volume
        {
            get => Tracks[currentTrack]?.Volume;
            set => Tracks[currentTrack].Volume = value ?? 0.0f;
        }
    }
}
