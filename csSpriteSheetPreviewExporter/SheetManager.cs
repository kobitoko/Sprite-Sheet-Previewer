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

        public void GetFramesFromFile()
        {
            // For now each frame, todo spritesheet!
            foreach (string location in previewer.FileNames)
            {
                previewer.AddFrame(location);
            }
        }

    }
}
