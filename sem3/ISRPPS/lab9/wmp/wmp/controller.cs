using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace wmp
{
    public class controller
    {
        private model model;
        private Form1 view;

        public controller(Form1 view, model model)
        {
            this.model = model;
            this.view = view;
        }

        public void mooving_start() { model.mooving_start(); }
        public void mooving_stop() { model.mooving_stop(); }
        public void left_start() { model.left_start(); }
        public void left_stop() { model.left_stop(); }
        public void rigth_start() { model.right_start(); }
        public void right_stop() { model.right_stop(); }
        public void down_start() { model.down_start(); }
        public void down_stop() { model.down_stop(); }

        public void CheckCon(ref GroupBox gb, ref Panel pl, Point CursorPos, Point DockBottomL, Size DockBottomS, Point DockLeftL, Size DockLeftS, Point DockTopL, Size DockTopS, Point DockRightL)
        {
            model.CheckCon(ref gb, ref pl, CursorPos, DockBottomL, DockBottomS, DockLeftL, DockLeftS, DockTopL, DockTopS, DockRightL);
        }
    }
}
