using System;
using System.Windows;
using System.Windows.Interop;

namespace LeonTools.Common
{
    public static class WpfHelper
    {
        public static IntPtr GetHandle(this DependencyObject control)
        {
            HwndSource hs = (HwndSource)PresentationSource.FromDependencyObject(control);
            return hs.Handle;
        }
    }
}
