using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace ATP.Core
{
    /// <summary>
    /// To get the AutomationPattern 
    /// </summary>
    public class AutomationPatternHelper
    {
        #region DockPattern helper

        /// <summary>
        /// Get DockPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>DockPattern instance</returns>
        public static DockPattern GetDockPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(DockPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the DockPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as DockPattern;
        }

        /// <summary>
        /// Get DockPosition
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>DockPosition instance</returns>
        public static DockPosition GetDockPosition(AutomationElement element)
        {
            return GetDockPattern(element).Current.DockPosition;
        }

        /// <summary>
        /// Set DockPosition
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        public static void SetDockPattern(AutomationElement element, DockPosition dockPosition)
        {
            GetDockPattern(element).SetDockPosition(dockPosition);
        }

        #endregion

        #region ExpandCollapsePattern helper

        /// <summary>
        /// Get ExpandCollapsePattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>ExpandCollapsePattern instance</returns>
        public static ExpandCollapsePattern GetExpandCollapsePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ExpandCollapsePattern.", 
                    element.Current.AutomationId,element.Current.Name));
            }
            return currentPattern as ExpandCollapsePattern;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        public void Collapse(ExpandCollapsePattern pattern)
        {
            pattern.Collapse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        public void Expand(ExpandCollapsePattern pattern)
        {
            pattern.Expand();
        }

        #endregion

        #region GridPattern helper
        /// <summary>
        /// Get GridPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>GridPattern instance</returns>
        public static GridPattern GetGridPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(GridPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the GridPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as GridPattern;
        }

        /// <summary>
        /// Get grid cell element
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <param name="row">Grid row index</param>
        /// <param name="column">Grid column index</param>
        /// <returns>Target grid cell element</returns>
        public AutomationElement GetGridItem(AutomationElement element, int row, int column)
        {
            GridPattern pattern = GetGridPattern(element);
            if (pattern != null)
                return pattern.GetItem(row, column);
            return null;
        }

        #endregion

        /// <summary>
        /// Get GridItempattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>GridItempattern instance</returns>
        public static GridItemPattern GetGridItemPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(GridItemPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the GridItemPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as GridItemPattern;
        }

        /// <summary>
        /// Get InvokePattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>InvokePattern instance</returns>
        public static InvokePattern GetInvokePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(InvokePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the InvokePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as InvokePattern;
        }

        /// <summary>
        /// Get MultipleViewPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>MultipleViewPattern instance</returns>
        public static MultipleViewPattern GetMultipleViewPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(MultipleViewPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the MultipleViewPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as MultipleViewPattern;
        }

        /// <summary>
        /// Get RangeValuePattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>RangeValuePattern instance</returns>
        public static RangeValuePattern GetRangeValuePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(RangeValuePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the RangeValuePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as RangeValuePattern;
        }

        /// <summary>
        /// Get ScrollPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>ScrollPattern instance</returns>
        public static ScrollPattern GetScrollPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ScrollPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ScrollPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as ScrollPattern;
        }

        /// <summary>
        /// Get ScrollItemPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>ScrollItemPattern instance</returns>
        public static ScrollItemPattern GetScrollItemPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ScrollItemPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ScrollItemPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as ScrollItemPattern;
        }

        /// <summary>
        /// Get SelectionPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>SelectionPattern instance</returns>
        public static SelectionPattern GetSelectionPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(SelectionPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the SelectionPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as SelectionPattern;
        }

        /// <summary>
        /// Get SelectItemPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>SelectItemPattern instance</returns>
        public static SelectionItemPattern GetSelectionItemPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the SelectionItemPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as SelectionItemPattern;
        }

        /// <summary>
        /// Get TablePattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>TablePattern instance</returns>
        public static TablePattern GetTablePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(TablePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the TablePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as TablePattern;
        }

        /// <summary>
        /// Get TextPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>TextPattern instance</returns>
        public static TextPattern GetTextPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(TextPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the TextPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as TextPattern;
        }

        /// <summary>
        /// Get TogglePattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>TogglePattern instance</returns>
        public static TogglePattern GetTogglePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(TogglePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the TogglePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as TogglePattern;
        }

        /// <summary>
        /// Get TransformPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>TransformPattern instance</returns>
        public static TransformPattern GetTransformPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(TransformPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the TransformPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as TransformPattern;
        }

        /// <summary>
        /// To get the ValuePattern
        /// </summary>
        /// <param name="element">Target element</param>
        /// <returns>ValuePattern instance</returns>
        public static ValuePattern GetValuePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ValuePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ValuePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as ValuePattern;
        }

        /// <summary>
        /// Get WindowPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>WindowPattern instance</returns>
        public static WindowPattern GetWindowPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(WindowPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the WindowPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as WindowPattern;
        }
    }
}
