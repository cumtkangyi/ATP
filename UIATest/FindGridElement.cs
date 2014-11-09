/*************************************************************************
 * 
 * Summary: This class used to get element by automatio Id or name.
 * Update Date: 2009-7-11 14:25
 * Version:
 * 
 * ***********************************************************************/

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace UIATest
{
    /// <summary>
    /// Get the element by automation Id or control name.
    /// </summary>
    public class FindGridElement
    {
        public AutomationElement FindGrid(AutomationElement parent,int level)
        {
            int count = 0;
            TreeWalker controlViewWalker = TreeWalker.ControlViewWalker;
            if (parent != null)
            {
                for (AutomationElement element = controlViewWalker.GetFirstChild(parent);
                    element != null; element = TreeWalker.ControlViewWalker.GetNextSibling(element))
                {
                    level += 1;
                    if (element.Current.ControlType == ControlType.DataGrid)
                    {

                        count++;
                        if (count == level)
                        {
                            return element;
                        }
                    }
                    else
                    {
                        return FindGrid(element, level - 1);
                    }
                }
            }
            return null;
        }
    }
}
