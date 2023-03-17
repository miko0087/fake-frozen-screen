using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktopNotWorking
{
    public partial class ImageForm : Form
    {
        public ImageForm(Image image, Size size, Point position)
        {
            InitializeComponent();
            this.Location = position;
            this.pictureBox1.BackgroundImage = image;
            this.pictureBox1.Size = size;
            this.Size = size;
            this.Focus();
        }
    }
}
