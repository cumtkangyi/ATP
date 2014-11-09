using System;
using System.Text;
using System.Windows.Automation;

namespace ATP.Core
{
    public static class PatternOperator
    {
        // Methods
        public static void AddToSelection(AutomationElement element)
        {
            AutomationPatternHelper.GetSelectionItemPattern(element).AddToSelection();
        }

        public static void AssertChecked(AutomationElement element, bool expected)
        {
            TogglePattern currentPattern = AutomationPatternHelper.GetTogglePattern(element);
            ToggleState indeterminate = ToggleState.Indeterminate;
            if (expected == true)
            {
                indeterminate = ToggleState.On;
            }
            else if (expected == false)
            {
                indeterminate = ToggleState.Off;
            }
            ToggleState toggleState = currentPattern.Current.ToggleState;
            if (indeterminate != toggleState)
            {
                throw new Exception(string.Format("ToggleState is not as expected. Expected: {0}, Actual: {1}. ({2})", indeterminate.ToString(), toggleState.ToString(), element.ToString()));
            }
        }

        public static void AssertEnabled(AutomationElement element, bool expected)
        {
            bool isEnabled = element.Current.IsEnabled;
            if (expected != isEnabled)
            {
                throw new Exception(string.Format("Enableness is not as expected. Expected: {0}, Actual: {1}. ({2})", expected, isEnabled, element.ToString()));
            }
        }

        public static void AssertName(AutomationElement element, string expected)
        {
            string name = element.Current.Name;
            if (expected != name)
            {
                throw new Exception(string.Format("Name is not as expected. Expected: {0}, Actual: {1}. ({2})", expected, name, element.ToString()));
            }
        }

        public static void AssertRangeMaximum(AutomationElement element, double expected)
        {
            RangeValuePattern currentPattern = AutomationPatternHelper.GetRangeValuePattern(element);
            double maximum = currentPattern.Current.Maximum;
            if (expected != maximum)
            {
                throw new Exception(string.Format("Range Maximum is not as expected. Expected: {0}, Actual: {1}. ({2})", expected, maximum, element.ToString()));
            }
        }

        public static void AssertRangeMinimum(AutomationElement element, double expected)
        {
            RangeValuePattern currentPattern = AutomationPatternHelper.GetRangeValuePattern(element);
            double minimum = currentPattern.Current.Minimum;
            if (expected != minimum)
            {
                throw new Exception(string.Format("Range Minimum is not as expected. Expected: {0}, Actual: {1}. ({2})", expected, minimum, element.ToString()));
            }
        }

        public static void AssertRangeValue(AutomationElement element, double expected)
        {
            RangeValuePattern currentPattern = AutomationPatternHelper.GetRangeValuePattern(element);
            double num = currentPattern.Current.Value;
            if (expected != num)
            {
                throw new Exception(string.Format("RangeValue is not as expected. Expected: {0}, Actual: {1}. ({2})", expected, num, element.ToString()));
            }
        }

        public static void AssertReadyForUserInteraction(AutomationElement element)
        {
            WindowPattern currentPattern = AutomationPatternHelper.GetWindowPattern(element);
            WindowInteractionState windowInteractionState = currentPattern.Current.WindowInteractionState;
            if (windowInteractionState != WindowInteractionState.ReadyForUserInteraction)
            {
                throw new Exception(string.Format("Window is not ready for user interaction. State is {0}. ({1})", windowInteractionState.ToString(), element.ToString()));
            }
        }

        public static void AssertSelected(AutomationElement element, bool expected)
        {
            SelectionItemPattern currentPattern = AutomationPatternHelper.GetSelectionItemPattern(element);
            bool isSelected = currentPattern.Current.IsSelected;
            if (expected != isSelected)
            {
                throw new Exception(string.Format("Selected is not as expected. Expected: {0}, Actual: {1}. ({2})", expected, isSelected, element.ToString()));
            }
        }

        public static void AssertValue(AutomationElement element, string expected)
        {
            string str = GetValue(element);
            if (expected != str)
            {
                throw new Exception(string.Format("Value is not as expected. Expected: '{0}', Actual: '{1}'. ({2})", expected, str, element.ToString()));
            }
        }

        //public static void AssertView(AutomationElement element, string expectedViewStyle)
        //{
        //    string strB = null;
        //    object obj2;
        //    if (element.TryGetCurrentPattern(MultipleViewPattern.Pattern, out obj2))
        //    {
        //        MultipleViewPattern pattern = (MultipleViewPattern)obj2;
        //        strB = pattern.GetViewName(pattern.Current.CurrentView);
        //    }
        //    else if (element.Current.ControlType == ControlType.DataGrid)
        //    {
        //        strB = "Details";
        //    }
        //    else if (element.Current.ControlType == ControlType.List)
        //    {
        //        strB = "List";
        //    }
        //    else
        //    {
        //        strB = "unknown";
        //    }
        //    if (string.Compare(expectedViewStyle, strB, true) != 0)
        //    {
        //        throw new Exception(string.Format("ViewStyle is not as expected. Expected: {0}, Actual={1}.", expectedViewStyle, strB));
        //    }
        //}

        public static void AssertVisible(AutomationElement element, bool expected)
        {
            bool flag = !element.Current.IsOffscreen;
            if (expected != flag)
            {
                throw new Exception(string.Format("Visibility is not as expected. Expected: {0}, Actual: {1}. ({2})", expected, flag, element.ToString()));
            }
        }

        public static void Collapse(AutomationElement element)
        {
            ExpandCollapsePattern currentPattern = AutomationPatternHelper.GetExpandCollapsePattern(element);
            if (currentPattern.Current.ExpandCollapseState == ExpandCollapseState.Expanded)
            {
                currentPattern.Collapse();
            }
        }

        public static void Expand(AutomationElement element)
        {
            ExpandCollapsePattern currentPattern = AutomationPatternHelper.GetExpandCollapsePattern(element);
            if (currentPattern.Current.ExpandCollapseState == ExpandCollapseState.Collapsed)
            {
                currentPattern.Expand();
            }
        }

        public static string GetText(AutomationElement element)
        {
            TextPattern currentPattern = AutomationPatternHelper.GetTextPattern(element);
            return currentPattern.DocumentRange.GetText(-1);
        }

        public static string GetValue(AutomationElement element)
        {
            ValuePattern currentPattern = AutomationPatternHelper.GetValuePattern(element);
            return currentPattern.Current.Value;
        }

        public static string GetWindowState(AutomationElement element)
        {
            try
            {
                WindowPattern currentPattern = AutomationPatternHelper.GetWindowPattern(element);
                return currentPattern.Current.WindowInteractionState.ToString();
            }
            catch (Exception exception)
            {
                return ("Unable to retrieve window state. " + exception.Message);
            }
        }

        public static void Invoke(AutomationElement element)
        {
            AutomationPatternHelper.GetInvokePattern(element).Invoke();
        }

        public static void Maximize(AutomationElement element)
        {
            WindowPattern currentPattern = AutomationPatternHelper.GetWindowPattern(element);
            if (currentPattern.Current.CanMaximize)
            {
                currentPattern.SetWindowVisualState(WindowVisualState.Maximized);
            }
        }

        public static void Minimize(AutomationElement element)
        {
            WindowPattern currentPattern = AutomationPatternHelper.GetWindowPattern(element);
            if (currentPattern.Current.CanMinimize)
            {
                currentPattern.SetWindowVisualState(WindowVisualState.Minimized);
            }
        }

        public static void Restore(AutomationElement element)
        {
            AutomationPatternHelper.GetWindowPattern(element).SetWindowVisualState(WindowVisualState.Normal);
        }

        public static void Select(AutomationElement element)
        {
            AutomationPatternHelper.GetSelectionItemPattern(element).Select();
        }

        public static void SetRangeValue(AutomationElement element, double valueToSet)
        {
            AutomationPatternHelper.GetRangeValuePattern(element).SetValue(valueToSet);
        }

        public static void SetValue(AutomationElement element, string value)
        {
            AutomationPatternHelper.GetValuePattern(element).SetValue(value);
        }

        public static void AppendValue(AutomationElement element, string value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AutomationPatternHelper.GetValuePattern(element).Current.Value);
            sb.Append(value);
            SetValue(element, sb.ToString());
        }

        public static void Toggle(AutomationElement element, bool toggle)
        {
            TogglePattern currentPattern = AutomationPatternHelper.GetTogglePattern(element);
            ToggleState indeterminate = ToggleState.Indeterminate;
            if (toggle == true)
            {
                indeterminate = ToggleState.On;
            }
            else if (toggle == false)
            {
                indeterminate = ToggleState.Off;
            }
            while (currentPattern.Current.ToggleState != indeterminate)
            {
                currentPattern.Toggle();
            }
        }

        public static string ToString(this AutomationElement element)
        {
            return string.Format("AutomationElement: AutomationID='{0}', Name='{1}', ControlType='{2}', LocalizedControlType='{3}', IsEnabled='{4}', IsOffscreen='{5}', ItemStatus='{6}'", new object[] { element.Current.AutomationId, element.Current.Name, element.Current.ControlType.ToString(), element.Current.LocalizedControlType, element.Current.IsEnabled.ToString(), element.Current.IsOffscreen.ToString(), element.Current.ItemStatus });
        }

    }
}