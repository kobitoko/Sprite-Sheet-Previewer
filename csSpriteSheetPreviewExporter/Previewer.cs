using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using AnimatedGif;
using System.Threading.Tasks;

namespace csSpriteSheetPreviewer
{
    class Previewer
    {
        List<string> imageStringList = new List<string>();
        List<Bitmap> bitmapList = new List<Bitmap>();
        int indexImg = 0;
        int fps = 30;

        public Previewer()
        {
        }

        public int Fps { get => fps; set => fps = value; }

        public int CurrentFrame { get => indexImg; set => indexImg = value; }

        public List<string> FileNames { get => imageStringList; }

        public List<Bitmap> Frames { get => bitmapList; }

        public int GetFrameDelay()
        {
            return FpsToMs(fps);
        }

        public int TotalFrameCount()
        {
            return bitmapList.Count;
        }

        public Bitmap GetCurrentFrame()
        {
            return bitmapList[indexImg];
        }

        public void AddFrame(string pathLocation)
        {
            bitmapList.Add(new Bitmap(pathLocation));
        }

        public void NextFrame()
        {
            indexImg = (indexImg + 1) % bitmapList.Count;
        }


        static public int FpsToMs(int fps)
        {
            int value = fps;
            if (value < 1)
                value = 1;
            return 1000 / value;
        }

        public void Clear() {
            indexImg = 0;
            foreach (Image i in bitmapList)
            {
                i.Dispose();
            }
            bitmapList.Clear();
            imageStringList.Clear();
        }
    }
}
