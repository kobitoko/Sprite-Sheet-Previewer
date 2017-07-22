using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AnimatedGif;
using System.Threading.Tasks;
using csSpriteSheetPreviewer;

namespace csSpriteSheetPreviewExporter
{
    public partial class Form1 : Form
    {
        Previewer previewer = new Previewer();

        float zoom = 1;
        int[] position = { 0, 0 };
        int[] lastMousePosition = { -1, -1 };

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
                previewer.Clear();

                // Todo: Make importing into it's own class, and use it inside Previewer. UI just passes the files to Previewer.

                // Store the path of file(s)
                previewer.FileNames.AddRange(file.FileNames.ToList());
                // Check if it's a spritesheet (1 image file)
                if (previewer.FileNames.Count == 1) {
                    groupBox5.Enabled = true;
                    groupBox5.Visible = true;
                }
                foreach (string location in previewer.FileNames)
                {
                    previewer.AddFrame(location);
                }

                framesBar.Maximum = previewer.TotalFrameCount() - 1;
                fpsValue.Text = previewer.Fps.ToString();
                previewImageBox.Refresh();
                previewer.SetFrameRedraw(new EventHandler(renderUpdate));
            }
        }

        private void renderUpdate(object sender, EventArgs e)
        {
            previewImageBox.Refresh();
            previewer.NextFrame();
            framesBar.Value = previewer.CurrentFrame;
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.control.paint?view=netframework-4.5
        private void previewImageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (previewer.TotalFrameCount() > 0)
            {
                Image img = previewer.GetCurrentFrame();
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
            if (previewer.FileNames.Count == 0)
            {
                MessageBox.Show("No sprite was loaded, cannot export an empty gif.", "Nothing to export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GifButton.Enabled = false;
            // Initialize progressbar
            exportGifProgress.Visible = true;
            exportGifProgress.Bounds = GifButton.Bounds;
            exportGifProgress.Minimum = 1;
            exportGifProgress.Maximum = previewer.FileNames.Count;
            exportGifProgress.Value = 1;
            exportGifProgress.Step = 1;
            // Taken from https://stackoverflow.com/questions/14962969/how-can-i-use-async-to-increase-winforms-performance
            Task task = Task.Run(() => previewer.ExportToGif(updateProgressBar));
            await task;
            MessageBox.Show("Exporting gif finished");
            exportGifProgress.Visible = false;
            GifButton.Enabled = true;
        }
        
        private void updateProgressBar()
        {
            // Perform task on thread of UI, thanks to https://stackoverflow.com/questions/36340639/async-progress-bar-update
            // This is called inside another thread, thus has to be called from the original UI thread.
            exportGifProgress.Invoke(new Action(() =>
            {
                exportGifProgress.PerformStep();
            }));
        }
        
        private void framesBar_Scroll(object sender, EventArgs e)
        {
            previewer.CurrentFrame = framesBar.Value;
        }

        private void fpsValue_TextChanged(object sender, EventArgs e)
        {
            int tryValue = 0;
            if (int.TryParse(fpsValue.Text, out tryValue)) {
                previewer.Fps = tryValue;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            previewer.TogglePause();
        }
    }
}
;