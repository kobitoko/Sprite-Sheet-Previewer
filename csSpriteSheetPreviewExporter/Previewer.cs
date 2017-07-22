using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using AnimatedGif;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csSpriteSheetPreviewer
{
    class Previewer
    {
        List<string> imageStringList = new List<string>();
        List<Bitmap> bitmapList = new List<Bitmap>();
        int indexImg = 0;
        int fps = 30;
        Timer t = new Timer();
        EventHandler callback = null;
        bool pause = false;

        public Previewer()
        {
        }

        public int Fps {

            get => fps;

            set
            {
                fps = value;
                t.Interval = this.GetFrameDelay();
            }
        }

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
            if(!pause)
                indexImg = (indexImg + 1) % bitmapList.Count;
        }


        static public int FpsToMs(int fps)
        {
            int value = fps;
            if (value < 1)
                value = 1;
            return 1000 / value;
        }

        public void TogglePause()
        {
            pause = !pause;
        }

        // Call the callback function when it's time for the next frame to be drawn, depending on fps.
        public void SetFrameRedraw(EventHandler callbackFunc) {
            if (callback != null)
                t.Tick -= callback;
            callback = callbackFunc;
            t.Interval = this.GetFrameDelay();
            t.Start();
            t.Tick += callbackFunc;
        }

        public void ExportToGif(Action UiProgressUpdate)
        {
            // Taken from https://github.com/mrousavy/AnimatedGif
            // Remove file extension, and preserves the path of the imported file(s).
            string filename = Path.GetFileNameWithoutExtension(this.FileNames[0]);
        string path = Path.GetDirectoryName(this.FileNames[0]);
			// Exporting the gif in the same directory as source images. Should ask for confirmation
            using (AnimatedGifCreator gifCreator = AnimatedGif.AnimatedGif.Create($"{path}\\Animated_{filename}.gif", this.GetFrameDelay()))
            {
                //Enumerate through a List<System.Drawing.Bitmap> of all frames
                for(int i = 0; i<this.TotalFrameCount(); i++)
                {
                    //Add the image to gifEncoder with default Quality
                    gifCreator.AddFrame(this.Frames[i], GifQuality.Bit8);
                    // Delegate, calls function to update the progressbar in the UI.
                    UiProgressUpdate();
                }
            } // gifCreator.Finish and gifCreator.Dispose is called here
        }


        // Stop animation and clear frames of old sprites.
        public void Clear() {
            t.Stop();
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
