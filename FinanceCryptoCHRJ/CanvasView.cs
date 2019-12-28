using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FinanceCrypto
{
    public partial class CanvasView : UserControl
    {
        public CanvasView()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, false);
            this.UpdateStyles();
        }


        BufferedGraphics bufgpc;
        public void init() {
            bufgpc = new BufferedGraphicsContext().Allocate(CreateGraphics(), new Rectangle(0, 0, Width, Height));
        }

        private void CanvasView_Disposed(object sender, EventArgs e)
        {
            bufgpc.Dispose();
        }
        

        public Graphics Graphics {
            get {
                return bufgpc.Graphics;
            }
        }


        public void Render() {
            bufgpc.Render();
        }

        
    }

    

}
