﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace LeonTools.Common
{
    public sealed class FileDropHandler : IMessageFilter, IDisposable
    {

        #region native members

        [DllImport("user32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ChangeWindowMessageFilterEx(IntPtr hWnd, uint message, ChangeFilterAction action, in ChangeFilterStruct pChangeFilterStruct);

        [DllImport("shell32.dll", SetLastError = false, CallingConvention = CallingConvention.Winapi)]
        private static extern void DragAcceptFiles(IntPtr hWnd, bool fAccept);

        [DllImport("shell32.dll", SetLastError = false, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Winapi)]
        private static extern uint DragQueryFile(IntPtr hWnd, uint iFile, StringBuilder lpszFile, int cch);

        [DllImport("shell32.dll", SetLastError = false, CallingConvention = CallingConvention.Winapi)]
        private static extern void DragFinish(IntPtr hDrop);

        [StructLayout(LayoutKind.Sequential)]
        private struct ChangeFilterStruct
        {
            public uint CbSize;
            public ChangeFilterStatu ExtStatus;
        }

        private enum ChangeFilterAction : uint
        {
            MSGFLT_RESET,
            MSGFLT_ALLOW,
            MSGFLT_DISALLOW
        }

        private enum ChangeFilterStatu : uint
        {
            MSGFLTINFO_NONE,
            MSGFLTINFO_ALREADYALLOWED_FORWND,
            MSGFLTINFO_ALREADYDISALLOWED_FORWND,
            MSGFLTINFO_ALLOWED_HIGHER
        }

        private const uint WM_COPYGLOBALDATA = 0x0049;
        private const uint WM_COPYDATA = 0x004A;
        private const uint WM_DROPFILES = 0x0233;

        #endregion


        private const uint GetIndexCount = 0xFFFFFFFFU;

        private UIElement _ContainerControl;

        private readonly bool _DisposeControl;

        public UIElement ContainerControl { get; }

        public FileDropHandler(UIElement containerControl) : this(containerControl, false) { }

        public FileDropHandler(UIElement containerControl, bool releaseControl)
        {
            _ContainerControl = containerControl ?? throw new ArgumentNullException("control", "control is null.");

            _DisposeControl = releaseControl;

            var status = new ChangeFilterStruct() { CbSize = 8 };

            if (!ChangeWindowMessageFilterEx(containerControl.GetHandle(), WM_DROPFILES, ChangeFilterAction.MSGFLT_ALLOW, in status)) throw new Win32Exception(Marshal.GetLastWin32Error());
            if (!ChangeWindowMessageFilterEx(containerControl.GetHandle(), WM_COPYGLOBALDATA, ChangeFilterAction.MSGFLT_ALLOW, in status)) throw new Win32Exception(Marshal.GetLastWin32Error());
            if (!ChangeWindowMessageFilterEx(containerControl.GetHandle(), WM_COPYDATA, ChangeFilterAction.MSGFLT_ALLOW, in status)) throw new Win32Exception(Marshal.GetLastWin32Error());
            DragAcceptFiles(containerControl.GetHandle(), true);
            System.Windows.Forms.Application.AddMessageFilter(this);

            //if (!ChangeWindowMessageFilterEx(containerControl.Handle, WM_DROPFILES, ChangeFilterAction.MSGFLT_ALLOW, in status)) throw new Win32Exception(Marshal.GetLastWin32Error());
            //if (!ChangeWindowMessageFilterEx(containerControl.Handle, WM_COPYGLOBALDATA, ChangeFilterAction.MSGFLT_ALLOW, in status)) throw new Win32Exception(Marshal.GetLastWin32Error());
            //if (!ChangeWindowMessageFilterEx(containerControl.Handle, WM_COPYDATA, ChangeFilterAction.MSGFLT_ALLOW, in status)) throw new Win32Exception(Marshal.GetLastWin32Error());
            //DragAcceptFiles(containerControl.Handle, true);
            //Application.AddMessageFilter(this);
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (_ContainerControl == null) return false;
            //if (_ContainerControl.AllowDrop) return _ContainerControl.AllowDrop = false;
            if (m.Msg == WM_DROPFILES)
            {
                var handle = m.WParam;

                var fileCount = DragQueryFile(handle, GetIndexCount, null, 0);

                var fileNames = new string[fileCount];

                var sb = new StringBuilder(262);
                var charLength = sb.Capacity;
                for (uint i = 0; i < fileCount; i++)
                {
                    if (DragQueryFile(handle, i, sb, charLength) > 0) fileNames[i] = sb.ToString();
                }
                DragFinish(handle);
                _ContainerControl.AllowDrop = true;
                //_ContainerControl.DoDragDrop(fileNames, DragDropEffects.All);
                DragDrop.DoDragDrop(_ContainerControl, fileNames, System.Windows.DragDropEffects.All);
                _ContainerControl.AllowDrop = false;
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            if (_ContainerControl == null)
            {
                //if (_DisposeControl && !_ContainerControl.IsDisposed) _ContainerControl.Dispose();
                System.Windows.Forms.Application.RemoveMessageFilter(this);
                _ContainerControl = null;
            }
        }
    }
}
