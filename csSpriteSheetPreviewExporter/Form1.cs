using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AnimatedGif;
using System.Threading.Tasks;

namespace csSpriteSheetPreviewExporter
{
    public partial class Form1 : Form
    {
        List<Bitmap> bitmapList = new List<Bitmap>();
        List<string> imageStringList = new List<string>();
        int indexImg = 0;
        int fps = 33; // 1000/30 == 30fps
        float zoom = 1;
        Timer t = new Timer();
        int[] position = { 0, 0 };
        int[] lastMousePosition = { -1, -1 };
        bool shouldRender = true;

        public Form1()
        {
            InitializeComponent();
            // https://docs.microsoft.com/en-us/dotnet/framework/winforms/advanced/working-with-images-bitmaps-icons-and-metafiles
            // https://msdn.microsoft.com/en-us/library/system.drawing.graphics.aspx

            // Add the paint event to the picture box
            previewImageBox.Paint += new PaintEventHandler(this.previewImageBox_Paint);
            groupBox5.Enabled = false;
            groupBox5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
			// filter examples: https://msdn.microsoft.com/en-us/library/system.windows.forms.filedialog.filter(v=vs.110).aspx
            file.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
            //string directoryPath = Path.GetDirectoryName(filePath);
            if (file.ShowDialog() == DialogResult.OK)
            {
                indexImg = 0;
                shouldRender = false;
                t.Stop();
                t.Dispose();
                t = new Timer();
                imageStringList.Clear();
                foreach(Image i in bitmapList)
                {
                    i.Dispose();
                }
                bitmapList.Clear();
                imageStringList.AddRange(file.FileNames.ToList());
                if (imageStringList.Count == 1) {
                    groupBox5.Enabled = true;
                    groupBox5.Visible = true;
                }
                foreach (string s in imageStringList)
                {
                    bitmapList.Add(new Bitmap(s));
                }
                previewImageBox.Refresh();
                t.Interval = fps;
                t.Start();
                t.Tick += new EventHandler(renderUpdate);
                shouldRender = true;
            }
        }

        private void renderUpdate(object sender, EventArgs e)
        {
            previewImageBox.Refresh();
            indexImg = (indexImg + 1) % bitmapList.Count;
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.paint?view=netframework-4.5
        private void previewImageBox_Paint(object sender, PaintEventArgs e)
        {
            if (!shouldRender)
                return;
            Graphics g = e.Graphics;
            if (bitmapList.Count > 0)
            {
                Image img = bitmapList[indexImg];
                float ratio = img.Width / img.Height;
                float newHeight = img.Height * zoom;
                g.DrawImage(img, position[0], position[1], newHeight*ratio, newHeight);
            }
        }

        private void previewImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastMousePosition[0] = e.X;
                lastMousePosition[1] = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                position[0] = 0;
                position[1] = 0;
            }
        }

        private void previewImageBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 0)
                zoomIn(true);
            else if (e.Delta < 0)
                zoomIn(false);
        }

        private void previewImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            // Move sprite image preview
            position[0] += e.X - lastMousePosition[0];
            position[1] += e.Y - lastMousePosition[1];

            lastMousePosition[0] = e.X;
            lastMousePosition[1] = e.Y;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            zoomIn(true);
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            zoomIn(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            changeTextZoom();
        }

        private void textBox1_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                changeTextZoom();
        }

        private void zoomIn(bool makeBigger)
        {
            int zoomIn = (makeBigger ? 1 : -1);
            zoom += zoomIn * 0.1f;
            updateZoom();
        }

        private void changeTextZoom()
        {
            char[] seperators = {' ', '%'};
            string input = textBox1.Text.Split(seperators)[0];
            int result = 0;
            if (!int.TryParse(input, out result))
                return;
            zoom = result / 100f;
            updateZoom();
        }

        private void updateZoom()
        {
            if (zoom > 15f)
                zoom = 15f;
            if (zoom < 0.01f)
                zoom = 0.01f;
            textBox1.Text = string.Format("{0:0}%", zoom * 100);
        }

        private async void GifButton_Click(object sender, EventArgs e)
        {
            if (imageStringList.Count == 0)
            {
                MessageBox.Show("No sprite was loaded, cannot export an empty gif.", "Nothing to export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GifButton.Enabled = false;
            // Initialize progressbar
            exportGifProgress.Visible = true;
            exportGifProgress.Bounds = GifButton.Bounds;
            exportGifProgress.Minimum = 1;
            exportGifProgress.Maximum = imageStringList.Count;
            exportGifProgress.Value = 1;
            exportGifProgress.Step = 1;
            // Taken from https://stackoverflow.com/questions/14962969/how-can-i-use-async-to-increase-winforms-performance
            Task task = Task.Run(() => exportToGif());
            await task;
            MessageBox.Show("Exporting gif finished");
            exportGifProgress.Visible = false;
            GifButton.Enabled = true;
        }
        
        private void exportToGif()
        {
            // Taken from https://github.com/mrousavy/AnimatedGif
            // Remove file extension, and preserves the path of the imported file(s).
            string filename = Path.GetFileNameWithoutExtension(imageStringList[0]);
            string path = Path.GetDirectoryName(imageStringList[0]);
			// Exporting the gif in the same directory as source images. Should ask for confirmation
            using (AnimatedGifCreator gifCreator = AnimatedGif.AnimatedGif.Create($"{path}\\Animated_{filename}.gif", fps))
            {
                //Enumerate through a List<System.Drawing.Bitmap> of all frames
                for(int i = 0; i<bitmapList.Count; i++)
                {
                    //Add the image to gifEncoder with default Quality
                    gifCreator.AddFrame(bitmapList[i], GifQuality.Bit8);

                    // Perform task on thread of UI, thanks to https://stackoverflow.com/questions/36340639/async-progress-bar-update
                    exportGifProgress.Invoke(new Action(() =>
                    {
                        exportGifProgress.PerformStep();
                    }));
                }
            } // gifCreator.Finish and gifCreator.Dispose is called here
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void fpsValue_TextChanged(object sender, EventArgs e)
        {
            // this is not really fps but ms delay per frame value atm. i.e. 33ms ~ 30fps
            if (int.TryParse(fpsValue.Text, out fps))
                t.Interval = fps;
        }
    }
}
;