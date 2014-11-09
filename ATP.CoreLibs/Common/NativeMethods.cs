/*************************************************************************
 * 
 * Summary: This class used to simulate mouse to click control.
 * Update Date: 2009-7-13 14:08
 * Version:
 * 
 * ***********************************************************************/

using System;
using System.Drawing;
using System.Windows;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Runtime.InteropServices;

namespace ATP.CoreLibs
{
    /// <summary>
    /// Click the element by simulating mouse.
    /// </summary>
    public static class NativeMethods
    {
        #region Fields

        /// <summary>
        /// Add mouse move event 
        /// </summary>
        /// <param name="x">Move to specify x coordinate</param>
        /// <param name="y">Move to specify y coordinate</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        extern static bool SetCursorPos(int x, int y);
        /// <summary>
        /// Mouse click event
        /// </summary>
        /// <param name="a">MouseEventFlag </param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        [DllImport("user32.dll")]
        extern static void mouse_event(int a, int x, int y, int d, int e);

        #endregion

        #region Common
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataFlags"></param>
        /// <param name="dataX"></param>
        /// <param name="dataY"></param>
        /// <param name="data"></param>
        /// <param name="dataExtraInfo"></param>
        /// <returns></returns>
       [System.Runtime.InteropServices.DllImport("user32")]
       private static extern int mouse_event(UInt32 dataFlags, UInt32 dataX, UInt32 dataY, UInt32 data, IntPtr dataExtraInfo);

        const int MOUSEEVENTF_MOVE = 0x0001;
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        /// <summary>
        /// This Method used to make the cursor position over the targetElement
        /// </summary>
        /// <param name="targetElement">Target control element</param>
        public static void SetCursorPosition(AutomationElement targetElement)
        {
            System.Windows.Point ClickPoint;

            System.Drawing.Point point = new System.Drawing.Point();

            if (targetElement.TryGetClickablePoint(out ClickPoint))
            {
                point = new System.Drawing.Point((int)ClickPoint.X, (int)ClickPoint.Y);
            }

            Cursor.Position = point;
        }

       /// <summary>
        /// Set the cursor postion. 
        /// </summary>
        /// <param name="offsetX">Relative offset X</param>
        /// <param name="offsetY">Relative offset Y</param>
        public static void SetCursorPS(int offsetX, int offsetY)
        {
            SetCursorPos(offsetX, offsetY);
        }


        #endregion

        #region Click left mouse

        /// <summary>
        /// MouseEvent LEFTDOWN | LEFTUP 
        /// </summary>
        public static void ClickLeftMouse()
        {
            mouse_event(MOUSEEVENTF_MOVE, 0, 0, 0, IntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, IntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Make the cursor position over the targetElement and then click left mouse.
        /// </summary>
        /// <param name="targetElement">target control automationElement</param>
        public static void ClickLeftMouse(AutomationElement targetElement)
        {
            SetCursorPosition(targetElement);
            NativeMethods.ClickLeftMouse();
        }

        /// <summary>
        /// Click left mouse by the targetElement increment.
        /// </summary>
        /// <param name="aeControl">Target control automationElement</param>
        /// <param name="incrementX">Relative offset with X</param>
        /// <param name="incrementY">Relative offset with Y</param>
        public static void ClickLeftMouse(AutomationElement aeControl, int incrementX, int incrementY)
        {
            int x = (int)aeControl.Current.BoundingRectangle.X + incrementX;
            int y = (int)aeControl.Current.BoundingRectangle.Y + incrementY;
            //Make the cursor position to the element.
            SetCursorPos(x, y);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(0x002, x, y, 0, 0);
            mouse_event(0x004, x, y, 0, 0);
        }

        public static void ClickLeftMouseById(int processId, string automationId, int incrementX, int incrementY)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlById(processId, automationId, null, 3000);
            ClickLeftMouse(element, incrementX, incrementY);
        }

        public static void ClickLeftMouseByIName(int processId, string controlName, int incrementX, int incrementY)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlByName(processId, controlName, null, 3000);
            ClickLeftMouse(element, incrementX, incrementY);
        }


        /// <summary>
        /// Double click left mouse by the targetElement increment.
        /// </summary>
        /// <param name="aeControl">Target control automationElement</param>
        /// <param name="incrementX">Relative offset with X</param>
        /// <param name="incrementY">Relative offset with Y</param>
        public static void DoubleClickLeftMouse(AutomationElement aeControl, int incrementX, int incrementY)
        {
            int x = (int)aeControl.Current.BoundingRectangle.X + incrementX;
            int y = (int)aeControl.Current.BoundingRectangle.Y + incrementY;
            //Make the cursor position to the element.
            SetCursorPos(x, y);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(0x002, x, y, 0, 0);
            mouse_event(0x002, x, y, 0, 0);
            mouse_event(0x004, x, y, 0, 0);
        }

        /// <summary>
        /// Double click left mouse by the targetElement increment.
        /// </summary>
        /// <param name="aeControl">Target control automationElement</param>
        /// <param name="incrementX">Relative offset with X</param>
        /// <param name="incrementY">Relative offset with Y</param>
        public static void ClickDoubleLeftMouse(AutomationElement aeControl, int incrementX, int incrementY)
        {
            int x = (int)aeControl.Current.BoundingRectangle.X + incrementX;
            int y = (int)aeControl.Current.BoundingRectangle.Y + incrementY;
            //Make the cursor position to the element.
            SetCursorPos(x, y);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(0x002, x, y, 0, 0);
            mouse_event(0x004, x, y, 0, 0);
            mouse_event(0x002, x, y, 0, 0);
            mouse_event(0x004, x, y, 0, 0);
        }

        /// <summary>
        /// Click left mouse on the offset increment.
        /// </summary>
        /// <param name="offsetX">relative offset with X</param>
        /// <param name="offsetY">relative offset with Y</param>
        public static void ClickLeftMouse(int offsetX, int offsetY)
        {
            //Make the cursor position to the element.
            SetCursorPos(offsetX, offsetY);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(0x002, offsetX, offsetY, 0, 0);
            mouse_event(0x004, offsetX, offsetY, 0, 0);
        }

        /// <summary>
        /// Click left mouse according to the element relative increment.
        /// </summary>
        /// <param name="aeControl">Target control automationElement</param>
        public static void ClickableLeftMouse(AutomationElement aeControl)
        {
            Rect re = aeControl.Current.BoundingRectangle;
            int x = (int)(re.Left + re.Width / 2);
            int y = (int)(re.Top + re.Height / 2);
            //Make the cursor position to the element.
            SetCursorPos(x, y);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(0x002, x, y, 0, 0);
            mouse_event(0x004, x, y, 0, 0);
        }

        public static void ClickableLeftMouseById(int processId, string autimationId, int timeOut)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlById(processId, autimationId, null, timeOut);
            ClickableLeftMouse(element);
        }

        public static void ClickableLeftMouseByName(int processId, string controlName, int timeOut)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlByName(processId, controlName, null, timeOut);
            ClickableLeftMouse(element);
        }

        #endregion

        #region Click right mouse

        /// <summary>
        /// MouseEvent RIGHTDOWN | RIGHTUP
        /// </summary>
        public static void ClickRightMouse()
        {
            mouse_event(MOUSEEVENTF_MOVE, 0, 0, 0, IntPtr.Zero);
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, IntPtr.Zero);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Make the cursor position over the targetElement and then click right mouse.
        /// </summary>
        /// <param name="targetElement"></param>
        public static void ClickRightMouse(AutomationElement targetElement)
        {
            SetCursorPosition(targetElement);
            NativeMethods.ClickRightMouse();
        }

        /// <summary>
        /// Make the cursor position over the targetElement and then click right mouse.
        /// </summary>
        /// <param name="aeControl">Target control automationElement</param>
        /// <param name="incrementX">Relative offset with X</param>
        /// <param name="incrementY">Relative offset with Y</param>
        public static void ClickRightMouse(AutomationElement aeControl, int incrementX, int incrementY)
        {
            int x = (int)aeControl.Current.BoundingRectangle.X + incrementX;
            int y = (int)aeControl.Current.BoundingRectangle.Y + incrementY;
            //Make the cursor position to the element.
            SetCursorPos(x, y);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(0x0008, x, y, 0, 0);
            mouse_event(0x0010, x, y, 0, 0);

        }

        /// <summary>
        /// Click right mouse by element automation Id.
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// <param name="automationId">AutomationId</param>
        /// <param name="incrementX">X increment</param>
        /// <param name="incrementY">Y increment</param>
        public static void ClickRightMouseById(int processId, string automationId, int incrementX, int incrementY)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlById(processId, automationId, null, 3000);
            ClickRightMouse(element, incrementX, incrementY);
        }

        /// <summary>
        /// Click right mouse by element name.
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// <param name="controlName">Control name</param>
        /// <param name="incrementX">Relative offset X</param>
        /// <param name="incrementY">Relative offset Y</param>
        public static void ClickRightMouseByName(int processId, string controlName, int incrementX, int incrementY)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlByName(processId, controlName, null, 3000);
            ClickRightMouse(element, incrementX, incrementY);
        }

        /// <summary>
        /// Click left mouse according to the element relative increment.
        /// </summary>
        /// <param name="aeControl">Target control automationElement</param>
        public static void ClickableRightMouse(AutomationElement aeControl)
        {
            Rect re = aeControl.Current.BoundingRectangle;
            int x = (int)(re.Left + re.Width / 2);
            int y = (int)(re.Top + re.Height / 2);
            //Make the cursor position to the element.
            SetCursorPos(x, y);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(0x0008, x, y, 0, 0);
            mouse_event(0x0010, x, y, 0, 0);
        }

        public static void ClickableRightMouseById(int processId, string autimationId, int timeOut)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlById(processId, autimationId, null, timeOut);
            ClickableRightMouse(element);
        }

        public static void ClickableRightMouseByName(int processId, string controlName, int timeOut)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControlByName(processId, controlName, null, timeOut);
            ClickableRightMouse(element);
        }

        #endregion

        #region Other mouse operator


        /// <summary>
        /// Select a row and drag to the pane then drop on the pane
        /// </summary>
        /// <param name="myElement">AutomationElement instance which you want to drag</param>
        /// <param name="targetElement">TargetElement that you want to drop </param>
        /// <param name="targetX">Target x point that you want to drop </param>
        /// <param name="targetY">Target y point that you want to drop </param>
        public static void DragAndDrop(AutomationElement myElement, AutomationElement targetElement,
            int targetX,int targetY )
        {

            int x = (int)myElement.Current.BoundingRectangle.X + 10;
            int y = (int)myElement.Current.BoundingRectangle.Y + 5;

            int targetxP = (int)targetElement.Current.BoundingRectangle.X + targetX;
            int targetyP = (int)targetElement.Current.BoundingRectangle.Y + targetY;
            //Make the cursor position to the element.
            SetCursorPos(x, y);
            //mouse_event(MOUSEEVENTF_MOVE ,x,y,0,0);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);

            SetCursorPos(targetxP, targetyP);
            mouse_event(MOUSEEVENTF_ABSOLUTE, targetxP, targetyP, 0, 0);

            mouse_event(MOUSEEVENTF_LEFTDOWN, targetxP, targetyP, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, targetxP, targetyP, 0, 0);
        }

        /// <summary>
        /// Move the mouse to the element
        /// </summary>
        /// <param name="myElement">Automation element</param>
        /// <param name="targetX">Target x point that you want to move</param>
        /// <param name="targetY">Target y point that you want to move</param>
        public static void MoveMouse(AutomationElement myElement, int targetX, int targetY)
        {
            int targetxP = (int)myElement.Current.BoundingRectangle.X + targetX;
            int targetyP = (int)myElement.Current.BoundingRectangle.Y + targetY;
            SetCursorPos(targetxP, targetyP);
            mouse_event(MOUSEEVENTF_MOVE, targetxP, targetyP, 0, 0);
        }

        #endregion
    }
}