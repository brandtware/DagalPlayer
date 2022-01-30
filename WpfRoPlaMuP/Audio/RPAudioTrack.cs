using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagalPlayer
{
    public class RPAudioTrack
    {
        long fadeInFrom = 0;
        long fadeOutFrom = 0;
        float volume = 0;
        string path = string.Empty;

        public RPAudioTrack(string path, int fadeInFrom = 0, int fadeOutFrom = -1, float volume = 1.0f)
        {
            if (File.Exists(path))
            {
                this.FadeInFrom = fadeInFrom;
                this.FadeOutFrom = fadeOutFrom;
                this.path = path;
                this.Volume = volume;
            }
            else
                throw new FileNotFoundException(path);
         }

        public long FadeOutFrom { get => fadeOutFrom; set => fadeOutFrom = value; }
        public long FadeInFrom { get => fadeInFrom; set => fadeInFrom = value; }
        public float Volume { get => volume; set => volume = value; }
        public string Path { get => path; set => path = value; }

        public string[] ToStringArray()
        {
            return new string[]
            {
                System.IO.Path.GetFileName (path), volume.ToString(), fadeInFrom.ToString(), fadeOutFrom.ToString()
            };
        }
    }
}
