using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using NAudioPractice1;

namespace FinanceCryptoCHRJ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BSoundPlayer bgmPlayer;
        String cfgPath = "config.dat";
        int selecting = 0;
        Button[] selectionButtons;

        AppSettings appSettings = new AppSettings();

        List<NameDrawingItem> nameDrawingItems = new List<NameDrawingItem>();
        int fpsCounter = 0;
        int lastFps = 0;

        int lastSecond = 0;


        float position = 0;
        float velotry = 0;
        float maxVelotry = 2.7182818459f;

        float absvel = 0;

        int currentIndex = 0;

        bool requestBlask = false;

        Bitmap bg = Properties.Resources.chrj_bg1;

        private void renderTimer_Tick(object sender, EventArgs e)
        {

            absvel = Math.Abs(velotry);
            DateTime now = DateTime.Now;
            Graphics canv = gdi.Graphics;
            canv.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            canv.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            canv.Clear(Color.Transparent);

            #region Draw Names
            canv.FillRectangle(Brushes.White, displayArea.Left,displayArea.Top, displayArea.Width,displayArea.Height);
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

                canv.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

                canv.FillRectangle(Brushes.Transparent, 0, 0, displayArea.Left, Height);
                canv.FillRectangle(Brushes.Transparent, displayArea.Right,0 , Width-displayArea.Right, Height);

                canv.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
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
                        else if (Math.Abs(velotry) > 0.038) {
                            if (requestBlask)
                            {
                                velotry *= 0.88f;
                                if (Math.Abs(velotry) < 0.05)
                                {
                                    requestBlask = false;
                                }
                            }
                            velotry *= 0.985f;
                        }
                    }
                    else {
                        if (requestBlask) {
                            velotry *= 0.88f;
                            if (Math.Abs(velotry) < 0.05) {
                                requestBlask = false;
                            }
                        }
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
                    currentIndex = (int)Math.Round(position);
                    while (currentIndex < 0) { currentIndex += lenint; }
                    while (currentIndex >= lenint) { currentIndex -= lenint; }
                    
                    if (absvel > 0.1 && nameDrawingItems[currentIndex].nameItem.isDisabled)
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

            btnFastRoll.Text = Math.Abs(velotry) < 0.05f ? "快速摇号" : "快速停止";

            if (!mainRollClicking) { btnStickyRoll.Text = "炫迈摇号"; }

            #region Draw Form Controls
            canv.DrawImage(bg, 0, 0);
            canv.DrawString("FPS:" + lastFps, areaFPS.Font, Brushes.White, areaFPS.Location);
            float calcWidth = (float)Math.Sqrt(Math.Abs(velotry) / maxVelotry) * (float)btnMainRoll.Width - 7;
            if (calcWidth > btnMainRoll.Width) { calcWidth = btnMainRoll.Width; }
            if (calcWidth < 0) { calcWidth = 0; }
            canv.FillRectangle(alphaBackgroundBrush, btnMainRoll.Left, btnMainRoll.Top, calcWidth, btnMainRoll.Height);
            canv.FillRectangle(alphaBackgroundBrush, selectionButtons[selecting].Left, selectionButtons[selecting].Top, selectionButtons[selecting].Width, selectionButtons[selecting].Height);
            drawStringCenter(canv, btnMainRoll,white);
            drawStringCenter(canv, btnSlot0,black);
            drawStringCenter(canv, btnSlot1,black);
            drawStringCenter(canv, btnSlot2,black);
            drawStringCenter(canv, btnSlot3,black);
            drawStringCenter(canv, btnSlot4,black);
            drawStringCenter(canv, btnSlot5,black);
            drawStringCenter(canv, btnSlot6,black);
            drawStringCenter(canv, btnFastRoll, white);
            drawStringCenter(canv, btnStickyRoll, white);
            drawStringCenter(canv, btnSetting, white);

            #endregion

            

            if (chkHasBgm.Checked)
            {
                if (velotry > 0)
                {
                    beginMusic();
                    bgmPlayer.Volume = ((float)Math.Sqrt(Math.Abs(velotry) / maxVelotry));
                    int bgmPos = (int)(bgmPlayer.CurrentTime.TotalMilliseconds / 500 % 8);

                    canv.FillRectangle(bgmEffect[bgmPos], displayArea.Left, displayArea.Top, displayArea.Width, displayArea.Height);
                }
                else {
                    stopMusic();
                }
            }
            else {
                stopMusic();
            }

            gdi.UpdateWindow();


            fpsCounter++;
            if (now.Second != lastSecond) {
                lastFps = fpsCounter;
                fpsCounter = 0;
            }
            lastSecond = now.Second;


            
        }

        void beginMusic() {
            if (!bgmPlayer.IsPlaying) {
                bgmPlayer.Play();
            }
        }

        void stopMusic() {
            if (bgmPlayer.IsPlaying) {
                bgmPlayer.pause();
            }
        }

        Brush alphaBackgroundBrush = new SolidBrush(Color.FromArgb(72, 0, 0, 0));
        Brush white = Brushes.White;
        Brush black = Brushes.Black;
        

        Brush[] bgmEffect = new Brush[] {
            new SolidBrush(Color.FromArgb(64,255,0,0)),
            new SolidBrush(Color.FromArgb(64,255,127,0)),
            new SolidBrush(Color.FromArgb(64,255,255,0)),
            new SolidBrush(Color.FromArgb(64,0,255,0)),
            new SolidBrush(Color.FromArgb(64,0,255,255)),
            new SolidBrush(Color.FromArgb(64,0,0,255)),
            new SolidBrush(Color.FromArgb(64,127,0,255)),
            new SolidBrush(Color.FromArgb(64,255,0,255))
        };

        void initDrawing() {
            bg = new Bitmap(bg, this.Size);
            centerFormat = new StringFormat(StringFormatFlags.NoWrap);
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            selectionButtons = new Button[] {
                btnSlot0,
                btnSlot1,
                btnSlot2,
                btnSlot3,
                btnSlot4,
                btnSlot5,
                btnSlot6,
            };
            bgmPlayer = new BSoundPlayer("BGM45515.mp3");
            bgmPlayer.advancedloop = true;
            bgmPlayer.loopMilliTime = 45515;
        }

        StringFormat centerFormat;
        void drawStringCenter(Graphics g,Control ctl,Brush color) {
            g.DrawString(ctl.Text, ctl.Font, color, new RectangleF(ctl.Left, ctl.Top, ctl.Width, ctl.Height), centerFormat);
        }

        bool isDragging = false;

        public class NameItem {
            public string name;
            public bool isDisabled;

            public NameItem(string name, bool isDisabled)
            {
                this.name = name;
                this.isDisabled = isDisabled;
            }
            public NameItem() { }
        }

        public class NameDrawingItem {
            public NameItem nameItem;
            Font drawingFont;
            float areaWidth = 0;
            RectangleF drawingArea;
            Brush drawingBrush = Brushes.Black;
            PointF drawingPoint;

            StringFormat drawingFormat = new StringFormat(StringFormatFlags.NoWrap)
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.Character
            };

            public NameDrawingItem(NameItem nameItem,Graphics g,int left,int top,int width,int height)
            {
                
                this.nameItem = nameItem;
                float beginFontSize = 50;
                FontFamily usingFont = SystemFonts.DefaultFont.FontFamily;

                
                

                bool inLoop = true;
                SizeF strSize = g.MeasureString(nameItem.name, new Font(usingFont, beginFontSize));
                if (strSize.Width <= width && strSize.Height <= height)
                {
                    while (inLoop) {
                        beginFontSize++;
                        strSize = g.MeasureString(nameItem.name, new Font(usingFont, beginFontSize));
                        if (strSize.Width > width || strSize.Height > height) {
                            beginFontSize--;
                            strSize = g.MeasureString(nameItem.name, new Font(usingFont, beginFontSize));
                            inLoop = false;
                        }
                    }
                }
                else {
                    while (inLoop)
                    {
                        beginFontSize--;
                        strSize = g.MeasureString(nameItem.name, new Font(usingFont, beginFontSize));
                        if (strSize.Width <= width && strSize.Height <= height)
                        {
                            inLoop = false;
                        }
                    }
                }
                drawingFont = new Font(FontFamily.GenericSerif, beginFontSize);
                float strHeight = g.MeasureString("永", drawingFont).Width;
                areaWidth = width;
                drawingArea = new RectangleF(0, top+14, width, height);
                drawingPoint = new PointF(width / 2 - strSize.Width / 2 + left, height / 2 - strSize.Height / 2 + top+14/* Magic. Do not touch */);
            }

            public void draw(Graphics g, float offset) {
                //drawingArea.X = 0;
                //drawingArea.Offset(-areaWidth * offset, 0);
                //g.DrawString(nameItem.name, drawingFont, Brushes.Black, drawingArea, drawingFormat);
                g.DrawString(nameItem.name, drawingFont, drawingBrush, drawingPoint.X - areaWidth * offset, drawingPoint.Y);
            }
        }

        public class NameItemCollecton {
            public string name;
            public List<NameItem> items;
        }

        public class AppSettings {
            public List<string> subpasswords = new List<string>();
            public List<NameItemCollecton> nameListCollections = new List<NameItemCollecton>();
        }


        public static FinanceCrypto.CryptoObject cryptor = new FinanceCrypto.CryptoObject();
        public void initItems() {
            bool loaded = false;
            if (File.Exists(cfgPath))
            {
                try
                {
                    string rawdata = File.ReadAllText(cfgPath, Encoding.UTF8);
                    cryptor.loadFromXml(rawdata);
                    appSettings = JsonConvert.DeserializeObject<AppSettings>(cryptor.getData());
                    loaded = true;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
            }
            else {
                loaded = false;
            }
            if (!loaded) {
                MessageBox.Show("第一次使用请设定主密码");
                string password = FrmInputPassword.CreatePassword(this);
                if (null == password) { Application.Exit(); return; }
                cryptor.init(password);
                appSettings = new AppSettings();
                for (int i = 0; i < 7; i++) {
                    NameItemCollecton nameItemCollection = new NameItemCollecton() { name = "未命名摇号", items = new List<NameItem>()};
                    for (int j = 1; j <= 30; j++) {
                        nameItemCollection.items.Add(new NameItem(j.ToString(), false));
                    }
                    appSettings.nameListCollections.Add(nameItemCollection);
                }
                string json = JsonConvert.SerializeObject(appSettings);
                
                cryptor.setData(json, password);
                File.WriteAllText(cfgPath, cryptor.exportToXml(), Encoding.UTF8);
            }

            for (int i = 0; i < appSettings.nameListCollections.Count; i++) {
                selectionButtons[i].Text = appSettings.nameListCollections[i].name;
            }

            loadItems(appSettings.nameListCollections[selecting].items);
            
        }

        void loadItems(List<NameItem> nameItems) {
            nameDrawingItems.Clear();
            nameItems.ForEach(i => nameDrawingItems.Add(new NameDrawingItem(i, gdi.Graphics, displayArea.Left, displayArea.Top, displayArea.Width, displayArea.Height)));
            velotry = 0;position = 0;
            mainRollClicking = false;
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
            initDrawing();
            initItems();
        }


        #region Interactive
        bool mainRollClicking = false;
        private void btnMainRoll_MouseDown(object sender, MouseEventArgs e)
        {
            mainRollClicking = true;
            btnMainRoll.Text = "松开停止摇号";
        }

        private void btnMainRoll_MouseUp(object sender, MouseEventArgs e)
        {
            mainRollClicking = false;
            btnMainRoll.Text = "按住开始摇号";
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
            try
            {
                if (nameDrawingItems.Count <= 0) { return; }

                if (absvel > 0.1 && nameDrawingItems[currentIndex].nameItem.isDisabled)
                {
                    isDragging = false;
                }
                isDragging = true;
                lastPoint = e.Location;
                deltaPosition = 0;
            }
            catch (Exception) {
                isDragging = false;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) {
                deltaPosition = -(float)(e.Location.X - lastPoint.X) / (float)(displayArea.Width);
                position += deltaPosition;
                lastPoint = e.Location;
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                velotry = deltaPosition;
            }
        }

        Random rnd = new Random();

        private void label2_Click(object sender, EventArgs e)
        {
            if (Math.Abs(velotry) < 0.05)
            {
                velotry = 1.5f + (float)rnd.NextDouble();
            }
            else {
                requestBlask = true;
                mainRollClicking = false;
            }
        }


        private void borderDockTimer_Tick(object sender, EventArgs e)
        {
            if (Top <= 0) {
                int temptop = Top;
                if (new Rectangle(Location, Size).Contains(MousePosition) || (velotry!=0 || position % 1 !=0))
                {
                    temptop = temptop + 16;
                    if (temptop > 0)
                    {
                        temptop = 0;
                    }
                }
                else {
                    temptop = temptop- 16;
                    if (temptop < -Height + 1) {
                        temptop = -Height + 1;
                    }
                }
                if (temptop != Top) {
                    Top=temptop; 
                }
                if (temptop == -Height + 1)
                {
                    renderTimer.Enabled = false;
                }
                else {
                    renderTimer.Enabled = true;
                }
            }
        }
        
        private void btnStickyRoll_Click(object sender, EventArgs e)
        {
            mainRollClicking = !mainRollClicking;
            btnStickyRoll.Text = mainRollClicking ? "炫迈停止" : "炫迈摇号";
        }

        private void btnSlot0_Click(object sender, EventArgs e)
        {
            selecting = int.Parse(((Button)sender).Name.Replace("btnSlot", ""));
            loadItems(appSettings.nameListCollections[selecting].items);
        }

        #endregion

        #region serurity
        private void btnSetting_Click(object sender, EventArgs e)
        {
            string password = FrmInputPassword.Input(this, "请输入密码");
            if (cryptor.verifyPassword(password))
            {
                openSetting(password);
                return;
            }
            else {
                password = testSubPassword(password);
                if (password != "") {
                    openSetting(password);
                    return;
                }
            }
            MessageBox.Show("密码错误");
        }

        string testSubPassword(string password) {
            foreach(string subp in appSettings.subpasswords) {
                try
                {
                    string mainpass = FinanceCrypto.CryptoHelper.AesDecrypt(subp, password);
                    if (mainpass.StartsWith("MAINPASS")) {
                        return mainpass.Substring(24);
                    }
                }
                catch (Exception ex) { }
            }
            return "";
        }

        void openSetting(String password) {
            this.TopMost = false;
            this.renderTimer.Enabled = false;
            this.borderDockTimer.Enabled = false;
            new FrmEdit(password).ShowDialog();
            this.TopMost = true;
            this.renderTimer.Enabled = true;
            this.borderDockTimer.Enabled = true;
            File.WriteAllText(cfgPath, cryptor.exportToXml(), Encoding.UTF8);
            initItems();
        }

        private void btnSecurityCheck_Click(object sender, EventArgs e)
        {
            string password = FrmInputPassword.Input(this, "请输入密码");
            if (!cryptor.verifyPassword(password)) {
                password = testSubPassword(password);
            }
            if (!cryptor.verifyPassword(password)) {
                MessageBox.Show("密码错误");
                return;
            }
            if (cryptor.verifyData(password))
            {
                MessageBox.Show("数据校验成功，可以放心使用");
            }
            else {
                MessageBox.Show("数据校验失败，名单可能已经被篡改","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadItems(appSettings.nameListCollections[selecting].items);
        }

        private void btnRemoveCurrent_Click(object sender, EventArgs e)
        {
            if (nameDrawingItems.Count > 0)
            {
                nameDrawingItems.RemoveAt(currentIndex);

                if (nameDrawingItems.All(el => el.nameItem.isDisabled)) {
                    nameDrawingItems.ForEach(el => el.nameItem.isDisabled = false);
                }
            }
        }

        #endregion
    }

}
