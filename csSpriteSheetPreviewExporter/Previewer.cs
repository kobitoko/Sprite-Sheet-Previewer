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
        Bitmap sheet;
        Size sheetSize;
        int indexImg = 0;
        int indexMaxImg = 1;
        int fps = 30;
        Timer t = new Timer();
        EventHandler callback = null;
        bool pause = false;
        bool isSpriteSheet = false;
        SheetManager importer;

        public Previewer()
        {
            importer = new SheetManager(this);
        }

        public int Fps {

            get => fps;

            set
            {
                int newFps = value;
                if (newFps > 999)
                    newFps = 999;
                if (newFps < 1)
                    newFps = 1;
                fps = newFps;
                t.Interval = this.GetFrameDelay();
            }
        }

        public bool isPaused()
        {
            return pause;
        }

        public int CurrentFrame { get => indexImg; set => indexImg = value; }

        public int SetMaxFrame { get => indexMaxImg; set => indexMaxImg = value - 1; }

        public List<string> FileNames { get => imageStringList; }
        
        public List<Bitmap> Frames { get => bitmapList; }

        public Bitmap SpriteSheet { get => sheet; set => sheet = value; }

        public Size SheetSize { get => sheetSize; set => sheetSize = value; }

        // Given path of filename(s) it will import those into bitmap list, 
        // and returns whether it is a single spritesheet or not (seperate animation files).
        public bool ImportFrames(List<string> pathFilenamesList)
        {
            // Store the path of file(s)
            imageStringList.AddRange(pathFilenamesList);
            // Check if it's a spritesheet (1 image file)
            isSpriteSheet = imageStringList.Count == 1;
            if (isSpriteSheet)
            {
                importer.LoadSheetFromFile();
                SetMaxFrame = importer.FrameRects.Count;
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
            int count = 0;
            if (isSpriteSheet)
                count = importer.FrameRects.Count;
            else
                count = bitmapList.Count;
            return count;
        }

        public Bitmap GetCurrentFrame()
        {
            return GetFrame(indexImg);
        }

        public Bitmap GetFrame(int index)
        {
            Bitmap frameToReturn;
            if (isSpriteSheet)
                frameToReturn = bitmapList[0].Clone(importer.FrameRects[index], SpriteSheet.PixelFormat);
            else
                frameToReturn = bitmapList[index];
            return frameToReturn;
        }

        public void NextFrame()
        {
            if (!pause && (bitmapList.Count > 1 || importer.FrameRects.Count > 1))
                indexImg = (indexImg + 1) % (indexMaxImg+1);
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
                //Enumerate through all the frames
                for (int i = 0; i<SetMaxFrame; i++)
                {
                    //Add the image to gifEncoder with default Quality
                    if(isSpriteSheet)
                        gifCreator.AddFrame(sheet.Clone(importer.FrameRects[i], SpriteSheet.PixelFormat), GifQuality.Bit8);
                    else
                        gifCreator.AddFrame(new Bitmap(imageStringList[i]), GifQuality.Bit8); 
                    // Delegate, calls function to update the progressbar in the UI.
                    UiProgressUpdate();
                }
            } // gifCreator.Finish and gifCreator.Dispose is called here
        }

        public void ChangeSheet(int colx, int rowy)
        {
            if (!isSpriteSheet)
                return;
            t.Stop();
            // It shall be not lower than 1.
            colx = (colx < 1 ? 1 : colx);
            rowy = (rowy < 1 ? 1 : rowy);
            // It shall be not higher than 999
            colx = (colx > 999 ? 999 : colx);
            rowy = (rowy > 999 ? 999 : rowy);
            importer.GetFramesFromSheet(colx, rowy);
            indexImg = 0;
            SetMaxFrame = Math.Max(importer.FrameRects.Count, 1);
            t.Start();
        }

        // Stop animation and clear frames of old sprites.
        public void Clear(bool onlyFrames=false) {
            t.Stop();
            indexImg = 0;
            if(sheet != null && !onlyFrames)
                sheet.Dispose();
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
