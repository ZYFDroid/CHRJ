using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceCryptoCHRJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int fpsCounter = 0;
        int lastFps = 0;

        int lastSecond = 0;


        float position = 0;
        float velotry = 0;
        float maxVelotry = 2.7182818459f;

        Bitmap bg = Properties.Resources.chrj_bg1;

        private void renderTimer_Tick(object sender, EventArgs e)
        {


            DateTime now = DateTime.Now;
            Graphics canv = gdi.Graphics;
            canv.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            canv.Clear(Color.Transparent);

            #region Draw Names
            canv.FillRectangle(Brushes.White, canvas.Left,canvas.Top, canvas.Width,canvas.Height);
            if (nameDrawingItems.Count > 0)
            {
                float len = nameDrawingItems.Count;
                int lenint = nameDrawingItems.Count;
                while (position < 0) {position += len;}
                while (position >= len){position -= len;}

                int leftPtr = (int)position;
                int rightPtr = leftPtr + 1;
                while (rightPtr >= lenint) { rightPtr -= lenint; }

                nameDrawingItems[leftPtr].draw(canv,position - (float)leftPtr);
                nameDrawingItems[rightPtr].draw(canv,position - (rightPtr > 0 ? rightPtr : rightPtr+lenint));

                #region Physic Calculating

                if (!isDragging)
                {
                    int next = (int)Math.Round(position);
                    if (velotry < 0) { next--; } else if(velotry>0) { next++; }
                    while (next < 0) { next += lenint; }
                    while (next >= lenint) { next -= lenint; }


                    if (velotry > maxVelotry) { velotry = maxVelotry; }
                    if (velotry < -maxVelotry) { velotry = -maxVelotry; }
                    if (Math.Abs(velotry) < 0.004f) { velotry = 0; }
                    if (!mainRollClicking && nameDrawingItems[next].nameItem.isDisabled)
                    {
                        if (Math.Abs(velotry) < 0.024)
                        {
                            velotry = 0;
                        }
                    }
                    else {
                        velotry *= 0.985f;
                    }
                    position += velotry;

                    if (velotry == 0)
                    {
                        if ((position % 1 > 0.02 && position % 1 < 0.98))
                        {
                            if (position % 1 > 0.5f)
                            {
                                position += 0.019f;
                            }
                            else
                            {
                                position -= 0.019f;
                            }
                        }
                        else
                        {
                            position = (float)Math.Round(position);
                        }
                    }

                    if (mainRollClicking)
                    {
                        if (velotry == 0) { velotry = 0.004f; }
                        velotry *= 1.18f;
                    }
                }
                else
                {
                    int current = (int)Math.Round(position);
                    while (current < 0) { current += lenint; }
                    while (current >= lenint) { current -= lenint; }
                    Text = current.ToString();
                    if (velotry > 0.1 && nameDrawingItems[current].nameItem.isDisabled)
                    {
                        isDragging = false;
                    }
                    else {
                        velotry = 0;
                    }
                }

                #endregion


            }

            #endregion

            #region Draw Form Controls
            canv.DrawImage(bg, 0, 0);
            canv.DrawString("FPS:" + lastFps, areaFPS.Font, Brushes.White, areaFPS.Location);

            #endregion

            gdi.UpdateWindow();

            
            fpsCounter++;
            if (now.Second != lastSecond) {
                lastFps = fpsCounter;
                fpsCounter = 0;
            }
            lastSecond = now.Second;


            
        }


        bool isDragging = false;

        class NameItem {
            public string name;
            public bool isDisabled;

            public NameItem(string name, bool isDisabled)
            {
                this.name = name;
                this.isDisabled = isDisabled;
            }
        }

        class NameDrawingItem {
            public NameItem nameItem;
            Font drawingFont;
            PointF beginPoint;
            float areaWidth = 0;



            public NameDrawingItem(NameItem nameItem,Graphics g,int left,int top,int width,int height)
            {
                this.nameItem = nameItem;
                float beginFontSize = 50;
                bool inLoop = true;
                SizeF strSize = g.MeasureString(nameItem.name, new Font(FontFamily.GenericSansSerif, beginFontSize));
                if (strSize.Width <= width && strSize.Height <= height)
                {
                    while (inLoop) {
                        beginFontSize++;
                        strSize = g.MeasureString(nameItem.name, new Font(FontFamily.GenericSansSerif, beginFontSize));
                        if (strSize.Width > width || strSize.Height > height) {
                            beginFontSize--;
                            inLoop = false;
                        }
                    }
                }
                else {
                    while (inLoop)
                    {
                        beginFontSize--;
                        strSize = g.MeasureString(nameItem.name, new Font(FontFamily.GenericSansSerif, beginFontSize));
                        if (strSize.Width <= width && strSize.Height <= height)
                        {
                            inLoop = false;
                        }
                    }
                }

                drawingFont = new Font(FontFamily.GenericSansSerif, beginFontSize);
                beginPoint = new PointF(width/2 - strSize.Width/2 + left,height/2 - strSize.Height/2+ top);
                areaWidth = width;
            }

            public void draw(Graphics g, float offset) {
                g.DrawString(nameItem.name, drawingFont, Brushes.Black, beginPoint.X - areaWidth * offset, beginPoint.Y);
            }
        }

        List<NameDrawingItem> nameDrawingItems = new List<NameDrawingItem>();

        public void initItems() {

            List<NameItem> nameItems = new List<NameItem>();
            nameItems.Add(new NameItem("Name1", false));
            nameItems.Add(new NameItem("Name2", false));
            nameItems.Add(new NameItem("Name3", false));
            nameItems.Add(new NameItem("Name4", false));
            nameItems.Add(new NameItem("Name5", false));
            nameItems.Add(new NameItem("Name6", false));
            nameItems.Add(new NameItem("Name7", false));
            nameItems.Add(new NameItem("Name8", false));
            nameItems.Add(new NameItem("Name9", false));
            nameItems.Add(new NameItem("Name10", true));

            loadItems(nameItems);

        }

        void loadItems(List<NameItem> nameItems) {
            nameDrawingItems.Clear();
            nameItems.ForEach(i => nameDrawingItems.Add(new NameDrawingItem(i, gdi.Graphics, canvas.Left, canvas.Top, canvas.Width, canvas.Height)));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | MyGDIFramework.GdiSystem.Win32.WS_EX_LAYERED;
                return cp;
            }
        }

        MyGDIFramework.GdiSystem gdi;

        private void Form1_Load(object sender, EventArgs e)
        {
            gdi = new MyGDIFramework.GdiSystem(this);
            bg = new Bitmap(bg, this.Size);
            initItems();
        }
        
        

        bool mainRollClicking = false;
        private void btnMainRoll_MouseDown(object sender, MouseEventArgs e)
        {
            mainRollClicking = true;
        }

        private void btnMainRoll_MouseUp(object sender, MouseEventArgs e)
        {
            mainRollClicking = false;
        }

        private void btnMainRoll_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        bool isFrmMoving = false;
        Point lastPoint = Point.Empty;
        private void areaTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            isFrmMoving = true;
            lastPoint = e.Location;
        }

        private void areaTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFrmMoving) {
                this.Left += (e.X - lastPoint.X);
                this.Top += (e.Y - lastPoint.Y);
                if (Top < 0) { Top = 0; }
                //lastPoint = e.Location;
            }
        }

        private void areaTopBar_MouseUp(object sender, MouseEventArgs e)
        {
            isFrmMoving = false;
            TopMost = true;
        }


        float deltaPosition = 0;
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastPoint = e.Location;
            deltaPosition = 0;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) {
                deltaPosition = -(float)(e.Location.X - lastPoint.X) / (float)(canvas.Width);
                position += deltaPosition;
                lastPoint = e.Location;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            velotry = deltaPosition;
        }

        Random rnd = new Random();

        private void label2_Click(object sender, EventArgs e)
        {
            velotry = 1.5f + (float)rnd.NextDouble();
        }


        private void borderDockTimer_Tick(object sender, EventArgs e)
        {
            if (Top <= 0) {
                int temptop = Top;
                if (new Rectangle(Location, Size).Contains(MousePosition) || (velotry!=0 || position % 1 !=0))
                {
                    temptop = temptop + 10;
                    if (temptop > 0)
                    {
                        temptop = 0;
                    }
                }
                else {
                    temptop = temptop- 10;
                    if (temptop < -Height + 1) {
                        temptop = -Height + 1;
                    }
                }
                if (temptop != Top) {
                    Top=temptop; 
                }
            }
        }
    }
}
