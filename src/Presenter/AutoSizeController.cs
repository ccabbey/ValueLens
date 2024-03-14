using System.Collections.Generic;
using System.Windows.Forms;

namespace ValueLens.Presenter
{
    /// <summary>
    /// 自动缩放控制器类
    /// </summary>
    public class AutoSizeController
    {
        private Form _form;

        private IList<Control> _controls = new List<Control>();

        public AutoSizeController(Form form)
        {
            _form = form;
            _initFormRect.Width = form.Width;
            _initFormRect.Height = form.Height;
        }

        public struct ControlRect
        {
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }

        private IList<ControlRect> _initControlRects = new List<ControlRect>();


        private ControlRect _initFormRect;

        /// <summary>
        /// 记录控件的大小特征。
        /// </summary>
        /// <param name="control"></param>
        public void AddControl(Control control)
        {
            ControlRect rect = new ControlRect
            {
                Left = control.Left,
                Top = control.Top,
                Width = control.Width,
                Height = control.Height
            };
            _initControlRects.Add(rect);
            _controls.Add(control);
        }

        //v1.0.6 增加removeControl方法
        public void RemoveControl(Control control)
        {
            _initControlRects.RemoveAt(getControlIndex(control));
            _controls.Remove(control);
        }
        //

        private int getControlIndex(Control control)
        {
            return _controls.IndexOf(control);
        }

        public bool AutoScaleEnabled = true;

        public void AutoSize()
        {
            //取得缩放后的窗体大小，并计算缩放比例
            float wScale = (float)_form.Width / (float)_initFormRect.Width;
            float hScale = (float)_form.Height / (float)_initFormRect.Height;

            //if (wScale<1f && hScale < 1f)
            //{
            //    _form.Width = _initFormRect.Width;
            //    _form.Height = _initFormRect.Height;
            //}

            //遍历对控件进行缩放
            ////v1.0.6 优化移除控件后，重新调整趋势图的比例，以便填满窗体空间
            ////存储最低的控件位置
            //int lowestBorderPosition = 0;
            //foreach (Control ctl in _controls)
            //{
            //    if (ctl.Top + ctl.Height > lowestBorderPosition)
            //    {
            //        lowestBorderPosition = ctl.Top + ctl.Height;
            //    }
            //}
            //if(lowestBorderPosition < _form.Height)
            //{
            //    lowestBorderPosition = _form.Height - 100;
            //}

            foreach (Control ctl in _controls)
            {
                if (AutoScaleEnabled)
                {
                    int id = getControlIndex(ctl);
                    ctl.Left = (int)(_initControlRects[id].Left * wScale);
                    ctl.Top = (int)(_initControlRects[id].Top * hScale);
                    ctl.Width = (int)(_initControlRects[id].Width * wScale);
                    ctl.Height = (int)(_initControlRects[id].Height * hScale);
                    //ctl.Width = _initControlRects[id].Width + _form.Width - _initFormRect.Width;
                    //ctl.Height = _initControlRects[id].Height + _form.Height- _initFormRect.Height;
                
                    
                    
                }

            }


        }
        //auto resize study
        //https://www.cnblogs.com/AmatVictorialCuram/p/5066670.html
    }
}
