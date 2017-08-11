using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace csSpriteSheetPreviewer
{
    // Later this class should have also a method to change and add/modify frames of a 
    // single spritesheet and extract the frames from it using rows columns and update frames accordingly to those values.
    class SheetManager
    {
        Previewer previewer;
        private List<RectangleF> framesRects = new List<RectangleF>();

        public List<RectangleF> FrameRects { get => framesRects; }

        public SheetManager(Previewer p)
        {
            previewer = p;
        }

        public void GetFramesFromFiles()
        {
            // For now each frame, todo spritesheet!
            foreach (string location in previewer.FileNames)
            {
                previewer.Frames.Add(new Bitmap(location));
            }
        }

        public void LoadSheetFromFile()
        {
            framesRects.Clear();
            previewer.SpriteSheet = new Bitmap(previewer.FileNames.First<string>());
            previewer.SheetSize = previewer.SpriteSheet.Size;
            setRectsToSheet();
            previewer.Frames.Add(previewer.SpriteSheet.Clone() as Bitmap);
        }

        public void GetFramesFromSheet(int colx, int rowy)
        {
            framesRects.Clear();
            Size size = new Size();
            size.Width = previewer.SheetSize.Width / colx;
            size.Height = previewer.SheetSize.Height / rowy;
            for (int i = 0; i < rowy; i++)
            {
                for (int j = 0; j < colx; j++)
                {
                    float x = Math.Min(j * size.Width, previewer.SheetSize.Width);
                    float y = Math.Min(i * size.Height, previewer.SheetSize.Height);
                    float x2 = size.Width;
                    float y2 = size.Height;
                    if (x+x2 > previewer.SheetSize.Width || y+y2 > previewer.SheetSize.Width || x2 < 1 || y2 < 1 )
                        continue;
                    framesRects.Add(new RectangleF(x, y, x2, y2));
                }
            }
            if (framesRects.Count == 0)
                setRectsToSheet();
        }

        private void setRectsToSheet()
        {
            Size sheetSize = previewer.SpriteSheet.Size;
            RectangleF rectOfSheet = new RectangleF(new PointF(0, 0), sheetSize);
            framesRects.Add(rectOfSheet);
        }
    }
}
