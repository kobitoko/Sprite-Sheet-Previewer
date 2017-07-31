using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using AnimatedGif;
using System.Windows.Forms;

namespace csSpriteSheetPreviewer
{
    class Previewer
    {
        List<string> imageStringList = new List<string>();
        List<Bitmap> bitmapList = new List<Bitmap>();
        public Bitmap Sheet;
        int indexImg = 0;
        int indexMaxImg = 1;
        int fps = 30;
        Timer t = new Timer();
        EventHandler callback = null;
        bool pause = false;
        SheetManager importer;

        public Previewer()
        {
            importer = new SheetManager(this);
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

        public int SetMaxFrame { get => indexMaxImg; set => indexMaxImg = value - 1; }

        public List<string> FileNames { get => imageStringList; }
        
        public List<Bitmap> Frames { get => bitmapList; }

        // Given path of filename(s) it will import those into bitmap list, 
        // and returns whether it is a single spritesheet or not (seperate animation files).
        public bool ImportFrames(List<string> pathFilenamesList)
        {
            // Store the path of file(s)
            imageStringList.AddRange(pathFilenamesList);
            // Check if it's a spritesheet (1 image file)
            bool isSpriteSheet = imageStringList.Count == 1;
            if (isSpriteSheet)
            {
                importer.LoadSheetFromFile();
            }
            else
            {
                // Get the list of frame image data.
                importer.GetFramesFromFiles();
                SetMaxFrame = bitmapList.Count;
            }
            return isSpriteSheet;
        }

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

        public void NextFrame()
        {
            if(!pause)
                indexImg = (indexImg + 1) % indexMaxImg;
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

        public void ChangeSheet(int colx, int rowy, bool isPixelsSize = false)
        {
            this.Clear(true);
            importer.GetFramesFromSheet(colx, rowy, isPixelsSize);
            t.Start();
        }

        // Stop animation and clear frames of old sprites.
        public void Clear(bool onlyFrames=false) {
            t.Stop();
            indexImg = 0;
            if(Sheet != null && !onlyFrames)
                Sheet.Dispose();
            foreach (Image i in bitmapList)
            {
                i.Dispose();
            }
            bitmapList.Clear();
            if(!onlyFrames)
                imageStringList.Clear();
        }
    }
}
