using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csSpriteSheetPreviewer
{
    // Later this class should have also a method to change and add/modify frames of a 
    // single spritesheet and extract the frames from it using rows columns and update frames accordingly to those values.
    class SheetManager
    {
        Previewer previewer;

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
            previewer.SpriteSheet = new Bitmap(previewer.FileNames.First<string>());
            // Clone it so calling Clear in previwer won't free up the Bitmap spriteSheet.
            previewer.Frames.Add(previewer.SpriteSheet.Clone() as Bitmap);
            previewer.SheetSize = previewer.SpriteSheet.Size;
        }

        public void GetFramesFromSheet(int colx, int rowy, bool isPixelsSize)
        {
            Size size = new Size();
            if (!isPixelsSize)
            {
                size.Width = previewer.SheetSize.Width / colx;
                size.Height = previewer.SheetSize.Height / rowy;
            } else
            {
                size.Width = colx;
                size.Height = rowy;
            }
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
                    RectangleF frame = new RectangleF(x, y, x2, y2);
                    previewer.Frames.Add(previewer.SpriteSheet.Clone(frame, previewer.SpriteSheet.PixelFormat));
                }
            }
        }
    }
}
