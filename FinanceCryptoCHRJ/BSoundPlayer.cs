using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;

namespace NAudioPractice1
{

    //从无限循环播放器里借过来的代码

    public class BSoundPlayer
    {
		public bool advancedloop = false;
		public long loopMilliTime = 0;
        private IWavePlayer wavePlayer;
        private AudioFileReader audioFileReader;
		NotifyingSampleProvider meter ;
        public string FileName = "";

        private bool isPlaying = false;
        public bool IsPlaying
        {
            get { return isPlaying; }
        }

        public TimeSpan CurrentTime
        {
            get
            {
                if (audioFileReader == null)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return audioFileReader.CurrentTime;
                }
            }
			set
			{
				if (audioFileReader != null)
				{
					audioFileReader.CurrentTime = value;
					justStopped = false;
				}

			}
        }


		public void pause()
		{
			if (wavePlayer != null)
			{
				wavePlayer.Pause();
				isPlaying = false;
			}
		}

        public TimeSpan TotalTime
        {
            get
            {
                if (audioFileReader == null)
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    return audioFileReader.TotalTime;
                }
            }
        }
		public TimeSpan totalTime()
		{
			return audioFileReader.TotalTime;
		}

        private float volume = 1f;
        public float Volume
        {
            get { return volume; }
            set
            {
                if (value >= 0 && value <= 1f)
                {
                    volume = value;
                    if (audioFileReader != null)
                    {
                        audioFileReader.Volume = value;
                    }
                }
            }
        }

        public BSoundPlayer(string filename)
        {
			FileName = filename;
			if (string.IsNullOrEmpty(FileName))
			{
				throw new ArgumentNullException();
			}
			wavePlayer = new WaveOut();
			((WaveOut)wavePlayer).NumberOfBuffers = 4;
			audioFileReader = new AudioFileReader(FileName);
			audioFileReader.Volume = volume;
			meter = new NotifyingSampleProvider(audioFileReader);
			meter.Sample += onVolChanged;
			wavePlayer.Init(new SampleToWaveProvider(meter));
			wavePlayer.PlaybackStopped += OnPlaybackStopped;
			totallong = audioFileReader.Length;
		}

        public BSoundPlayer(Stream inputstream)
        {
            FileName = "<MEM>";
            wavePlayer = new WaveOut();
            
            ((WaveOut)wavePlayer).NumberOfBuffers = 4;
            audioFileReader = new AudioFileReader(FileName);
            audioFileReader.Volume = volume;
            meter = new NotifyingSampleProvider(audioFileReader);
            meter.Sample += onVolChanged;
            wavePlayer.Init(new SampleToWaveProvider(meter));
            wavePlayer.PlaybackStopped += OnPlaybackStopped;
            totallong = audioFileReader.Length;
        }


        public void Play()
        {
			if (justStopped)
			{

				CurrentTime = TimeSpan.Zero;
			}

            if (isPlaying)
            {
                return;
            }
            wavePlayer.Play();
            isPlaying = true;
        }

        public void Stop()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Stop();
				isPlaying = false;
            }
        }
		public float currentVolume = 0;
		private int secondpassed;
		private int fpscount;
		public int lastfps;
		private int lastMillsec=0;


		int currentsp = 0;
		float curmax = 0f;
		int maxsps = 1000;
		public void onVolChanged(object sender,SampleEventArgs e)
		{
			currentsp++;
			float avs = (e.Left + e.Right) / 2f;
			if (Math.Abs(avs) > curmax)
			{
				curmax = Math.Abs(avs);
			}

			if (currentsp > maxsps)
			{
				onVol(curmax);
				currentsp = 0;
				curmax = 0f;
			}

		}
		public long currentlong;
		public long totallong;
		void onVol(float current)
		{
			if (secondpassed != DateTime.Now.Second)
			{
				lastfps = fpscount;
				fpscount = 0;
			}

			secondpassed = DateTime.Now.Second;

			currentVolume = current;
			fpscount++;

			currentlong = audioFileReader.Position;

			if(advancedloop)
			if (TotalTime - CurrentTime < TimeSpan.FromMilliseconds(200))
			{
				//2919192
				audioFileReader.CurrentTime = audioFileReader.CurrentTime-TimeSpan.FromMilliseconds(loopMilliTime);
			}


		}	

		public void Dispose()
		{
			this.wavePlayer.Stop();
			this.wavePlayer.Dispose();
			this.audioFileReader.Close();
			this.audioFileReader.Dispose();
		}

		bool justStopped = false;
		private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            isPlaying = false;
			 justStopped = false;
		}
    }
}
