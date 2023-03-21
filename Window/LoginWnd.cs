using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Threading.Tasks;

namespace Wonder {
    public partial class LoginWnd : Form {
        public LoginWnd()
        {
            InitializeComponent();
        }


        #region
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // 获取画布
            Graphics g = e.Graphics;
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            double width = rec.Width;
            double height = rec.Height;
            System.Windows.Point startPot = new System.Windows.Point(0, 0);
            System.Windows.Point EndPot = new System.Windows.Point(Width, Height);
            System.Windows.Media.Color startColor = System.Windows.Media.Color.FromArgb(0xFF, 0x5E, 0xFC, 0xE8);
            System.Windows.Media.Color endColor = System.Windows.Media.Color.FromArgb(0xFF, 0x73, 0x6E, 0xFE);
            System.Windows.Media.LinearGradientBrush brush = new LinearGradientBrush(startColor, endColor, startPot, EndPot);
        }
        #endregion
    }
}
