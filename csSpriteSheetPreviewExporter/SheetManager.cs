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
            previewer.Sheet = new Bitmap(previewer.FileNames.First<string>());
        }

        public void GetFramesFromSheet(int colx, int rowy, bool isPixelsSize)
        {
            Size size = new Size();
            if (!isPixelsSize)
            {
                size.Width = previewer.Sheet.Size.Width / colx;
                size.Height = previewer.Sheet.Size.Height / rowy;
            } else
            {
                size = new Size(colx, rowy);
            }
            for (int i = 0; i < rowy-1; i++)
            {
                for (int j = 0; j < colx-1; j++)
                {
                    RectangleF frame = new RectangleF(i*size.Width, j*size.Height, (i+1) * size.Width, (j+1) * size.Height);
                    previewer.Frames.Add(previewer.Sheet.Clone(frame, previewer.Sheet.PixelFormat));
                }
            }
            previewer.SetMaxFrame = Math.Max(previewer.Frames.Count, 1);
            Console.WriteLine("not null? " + previewer.Sheet != null);
            Console.WriteLine(previewer.Frames.Count); // <- 0, does frame adding not work for some reason?? cloning crop fails?
            Console.WriteLine(previewer.Sheet.Size.ToString());
            Console.WriteLine(size.ToString());

        }
    }
}
