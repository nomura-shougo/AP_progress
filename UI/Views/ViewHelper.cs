using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views
{
    internal class ViewHelper
    {
        internal static void InputErrorProc(Control control, string message)
        {
            MessageBox.Show(
                message
                , "入力エラー"
                , MessageBoxButtons.OK
                );
            control.Focus();
        }
    }
}
