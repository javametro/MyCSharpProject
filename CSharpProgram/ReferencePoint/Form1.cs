using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Diagnostics;

namespace ReferencePoint
{
    public partial class Form1 : Form
    {
        Image _image;
        IntPtr _desktopHandle;
        string msg;

        [DllImport("User32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindow(string windowClassName, string windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(ref PointStruct pointStruct);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr WindowFromPoint(PointStruct point);

        [DllImport("user32.dll", EntryPoint = "GetAncestor", SetLastError = true)]
        public static extern IntPtr GetAncestor(IntPtr windowHandle, GetAncestorFlags gaFlags);
            
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);


        public AutomationElement RootWindow { get; private set; }

        public struct PointStruct
        {
            /// <summary>
            /// 横向值
            /// </summary>
            int X;

            /// <summary>
            /// 纵向值
            /// </summary>
            int Y;

            public PointStruct(int x, int y)
            {
                X = x;
                Y = y;
            }

            public PointStruct(Point point)
            {
                this.X = (int)point.X;
                this.Y = (int)point.Y;
            }
        }

        public enum GetAncestorFlags
        {
            /// <summary>
            /// 查找父窗口,
            /// 不包括所有者，功能同GetParent功能
            /// </summary>
            GA_PARENT = 1,

            /// <summary>
            /// 通过遍历父窗口链获取根窗口
            /// </summary>
            GA_ROOT = 2,

            /// <summary>
            /// 通过遍历父窗口链和使用GetParent函数返回的所有者窗口来获取根窗口
            /// </summary>
            GA_ROOTOWNER = 3
        }

        public Form1()
        {
            string resourcesFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Resources);
            Settings.CursorFilePath = Path.Combine(resourcesFolder, "BullsEye_48.cur");
            InitializeComponent();
            pb_Target.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Target_MouseDown);
            pb_Target.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_Target_MouseUp);
        }

        private void pb_Target_MouseDown(object sender, MouseEventArgs e)
        {
            _image = this.pb_Target.Image;
            this.pb_Target.Image = null;
            var cursor = new Cursor(Settings.CursorFilePath);
            this.Cursor = cursor;
        }

        private IntPtr GetRootWindowElement(IntPtr handle)
        {
            var parentHandle = GetAncestor(handle, GetAncestorFlags.GA_PARENT);
            if (parentHandle != null && !parentHandle.Equals(IntPtr.Zero)
                && !parentHandle.Equals(_desktopHandle)
                && !parentHandle.Equals(handle))
            {
                return GetRootWindowElement(parentHandle);
            }
            else
            {
                return handle;
            }
        }

        private void pb_Target_MouseUp(object sender, MouseEventArgs e)
        {
            this.pb_Target.Image = _image;
            this.Cursor = Cursors.Default;
            var thisHandle = this.Handle;
            var deskTopHandle = FindWindow("SysListView32", null);
            PointStruct mousePoint = new PointStruct();
            GetCursorPos(ref mousePoint);
            var handle = WindowFromPoint(mousePoint);
            if(!handle.Equals(null) && !handle.Equals(IntPtr.Zero) && !handle.Equals(this.Handle))
            {
                msg = string.Empty;
                AutomationElement automationElement = AutomationElement.FromHandle(handle);
                msg += automationElement.Current.Name + "\n";
                msg += automationElement.Current.AutomationId + "\n";
                msg += automationElement.Current.ClassName + "\n";
                msg += automationElement.Current.ControlType + "\n";
                MessageBox.Show(msg);
            }

            //try
            //{
            //    if (!handle.Equals(null) && !handle.Equals(IntPtr.Zero) && !handle.Equals(this.Handle))
            //    {
            //        handle = GetRootWindowElement(handle);
            //        RootWindow = AutomationElement.FromHandle(handle);
            //        if (RootWindow == null)
            //            return;

            //        object controlTypeValue = RootWindow.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty, true);
            //        if (controlTypeValue == AutomationElement.NotSupported)
            //            return;

            //        if (!controlTypeValue.Equals(ControlType.Window))
            //        {
            //            var parentHandle = GetAncestor(handle, GetAncestorFlags.GA_PARENT);
            //            if (parentHandle != null)
            //            {
            //                RootWindow = AutomationElement.FromHandle(parentHandle);
            //                handle = parentHandle;
            //            }
            //        }

            //        if (RootWindow != null)
            //        {
            //            object automationIdDefault = RootWindow.GetCurrentPropertyValue(AutomationElement.AutomationIdProperty, true);
            //            if (automationIdDefault != AutomationElement.NotSupported)
            //            {
            //            }
            //            object classNameDefault = RootWindow.GetCurrentPropertyValue(AutomationElement.ClassNameProperty, true);
            //            if (classNameDefault != AutomationElement.NotSupported)
            //            {
                            
            //            }
            //            object controlTypeDefault = RootWindow.GetCurrentPropertyValue(AutomationElement.ControlTypeProperty, true);
            //            if (controlTypeDefault != AutomationElement.NotSupported)
            //            {
            //                var controlType = controlTypeDefault as ControlType;
                           
            //            }
            //            object nameDefault = RootWindow.GetCurrentPropertyValue(AutomationElement.NameProperty, true);
            //            if (nameDefault != AutomationElement.NotSupported)
            //            {
                            
            //            }
            //            int processId;
            //            GetWindowThreadProcessId(handle, out processId);
                  

            //            var process = Process.GetProcessById(processId);
                       
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("详情：{0}", ex);
            //}
        }
    }
}
