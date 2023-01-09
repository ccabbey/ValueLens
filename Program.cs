using System;
using System.Windows.Forms;
using ValueLens.View;

namespace ValueLens
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            var view = new MainForm();

            var presenter = new Presenter.ChartPresenter(view);

            Application.Run(view);
        }
    }

}
