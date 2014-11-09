using System.Windows.Automation;


[Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
public class ControlIdentification
{
    // Fields
    [CompilerGenerated]
    private IgnorableValue<string> AutomationId;
    [CompilerGenerated]
    private IgnorableValue<ControlType> ControlType;
    [CompilerGenerated]
    private IgnorableValue<string> HelpText;
    [CompilerGenerated]
    private IgnorableValue<string> Name;

    // Methods
    public ControlIdentification()
    {
        this.Name = new IgnorableValue<string>();
        this.AutomationId = new IgnorableValue<string>();
        this.ControlType = new IgnorableValue<ControlType>();
        this.HelpText = new IgnorableValue<string>();
    }

    private AutomationElement BreathFirstFindFirstUsingFindAll(AutomationElement parent, Condition condition)
    {
        if (this.ElementMatchesCondition(parent, condition))
        {
            return parent;
        }
        Queue<AutomationElement> queue = new Queue<AutomationElement>();
        queue.Enqueue(parent);
        while (queue.Count > 0)
        {
            foreach (AutomationElement element2 in queue.Dequeue().FindAll(TreeScope.Children, Condition.TrueCondition))
            {
                if (this.ElementMatchesCondition(element2, condition))
                {
                    return element2;
                }
                queue.Enqueue(element2);
            }
        }
        return null;
    }

    private AutomationElement BreathFirstFindFirstUsingRefreshedCache(AutomationElement parent, Condition condition)
    {
        CacheRequest request = new CacheRequest();
        request.AutomationElementMode = AutomationElementMode.Full;
        request.TreeFilter = System.Windows.Automation.Automation.RawViewCondition;
        request.TreeScope = TreeScope.Children | TreeScope.Element;
        AutomationElement updatedCache = parent.GetUpdatedCache(request);
        if (this.ElementMatchesCondition(updatedCache, condition))
        {
            return updatedCache;
        }
        Queue<AutomationElement> queue = new Queue<AutomationElement>();
        queue.Enqueue(updatedCache);
        while (queue.Count > 0)
        {
            foreach (AutomationElement element4 in queue.Dequeue().GetUpdatedCache(request).CachedChildren)
            {
                if (this.ElementMatchesCondition(element4, condition))
                {
                    return element4;
                }
                queue.Enqueue(element4);
            }
        }
        return null;
    }

    private AutomationElement BreathFirstFindFirstUsingTreeWalker(AutomationElement parent, Condition condition)
    {
        if (this.ElementMatchesCondition(parent, condition))
        {
            return parent;
        }
        Queue<AutomationElement> queue = new Queue<AutomationElement>();
        queue.Enqueue(parent);
        while (queue.Count > 0)
        {
            AutomationElement element = queue.Dequeue();
            for (AutomationElement element2 = TreeWalker.RawViewWalker.GetFirstChild(element); element2 != null; element2 = TreeWalker.RawViewWalker.GetNextSibling(element2))
            {
                if (this.ElementMatchesCondition(element2, condition))
                {
                    return element2;
                }
                queue.Enqueue(element2);
            }
        }
        return null;
    }

    private Condition BuildFindCondition()
    {
        List<Condition> list = new List<Condition>();
        if (!this.Name.Ignore)
        {
            list.Add(new PropertyCondition(AutomationElement.NameProperty, this.Name.Value));
        }
        if (!this.AutomationId.Ignore)
        {
            list.Add(new PropertyCondition(AutomationElement.AutomationIdProperty, this.AutomationId.Value));
        }
        if (!this.HelpText.Ignore)
        {
            list.Add(new PropertyCondition(AutomationElement.HelpTextProperty, this.HelpText.Value));
        }
        if (!this.ControlType.Ignore)
        {
            list.Add(new PropertyCondition(AutomationElement.ControlTypeProperty, this.ControlType.Value));
        }
        if (list.Count == 0)
        {
            return Condition.TrueCondition;
        }
        if (list.Count == 1)
        {
            return list[0];
        }
        return new AndCondition(list.ToArray());
    }

    private bool ElementMatchesCondition(AutomationElement element, Condition condition)
    {
        if (!this.AutomationId.Ignore && (this.AutomationId.Value != element.Current.AutomationId))
        {
            return false;
        }
        if (!this.ControlType.Ignore && (this.ControlType.Value != element.Current.ControlType))
        {
            return false;
        }
        if (!this.Name.Ignore && (this.Name.Value != element.Current.Name))
        {
            return false;
        }
        if (!this.HelpText.Ignore && (this.HelpText.Value != element.Current.HelpText))
        {
            return false;
        }
        return true;
    }

    public virtual AutomationElement Find(AutomationElement parent)
    {
        AutomationElement ae = null;
        StringBuilder builder = new StringBuilder();
        try
        {
            CrazyMouse.Start();
            Condition condition = this.BuildFindCondition();
            DateTime now = DateTime.Now;
            ae = this.BreathFirstFindFirstUsingRefreshedCache(parent, condition);
            builder.AppendLine(string.Format("BreathFirstFindFirstUsingRefreshedCache took {0} seconds to execute.", DateTime.Now.Subtract(now).TotalSeconds));
            if (ae == null)
            {
                now = DateTime.Now;
                ae = parent.FindFirst(TreeScope.Descendants, condition);
                builder.AppendLine(string.Format("FindFirst took {0} seconds to execute.", DateTime.Now.Subtract(now).TotalSeconds));
            }
            if (ae == null)
            {
                now = DateTime.Now;
                ae = this.BreathFirstFindFirstUsingFindAll(parent, condition);
                builder.AppendLine(string.Format("BreathFirstFindFirstUsingFindAll took {0} seconds to execute.", DateTime.Now.Subtract(now).TotalSeconds));
            }
            if (ae == null)
            {
                now = DateTime.Now;
                ae = this.BreathFirstFindFirstUsingTreeWalker(parent, condition);
                builder.AppendLine(string.Format("BreathFirstFindFirstUsingTreeWalker took {0} seconds to execute.", DateTime.Now.Subtract(now).TotalSeconds));
            }
        }
        finally
        {
            CrazyMouse.Stop();
        }
        if (ae == null)
        {
            builder.AppendLine(this.ToString() + " not found in " + parent.ToString2());
            throw new Exception(builder.ToString());
        }
        ae.MoveTo();
        return ae;
    }

    public virtual List<AutomationElement> FindAll(AutomationElement parent)
    {
        return this.FindAll(parent, true);
    }

    public virtual List<AutomationElement> FindAll(AutomationElement parent, bool deep)
    {
        AutomationElementCollection elements = null;
        try
        {
            CrazyMouse.Start();
            TreeScope scope = deep ? TreeScope.Descendants : TreeScope.Children;
            elements = parent.FindAll(scope, this.BuildFindCondition());
        }
        finally
        {
            CrazyMouse.Stop();
        }
        if (elements == null)
        {
            throw new Exception(this.ToString() + " not found in " + parent.ToString2());
        }
        List<AutomationElement> list = new List<AutomationElement>();
        foreach (AutomationElement element in elements)
        {
            element.MoveTo();
            list.Add(element);
        }
        return list;
    }

    public virtual bool Ignore()
    {
        return ((this.AutomationId.Ignore && this.Name.Ignore) && this.HelpText.Ignore);
    }

    public override string ToString()
    {
        return string.Format("Control Name={0}, AutomationId={1}, ControlType={2}.", this.Name, this.AutomationId, this.ControlType.Ignore ? "not set" : this.ControlType.Value.ProgrammaticName);
    }

    // Properties
    public IgnorableValue<string> AutomationId
    {
        [CompilerGenerated]
        get
        {
            return this.AutomationId;
        }
        [CompilerGenerated]
        set
        {
            this.AutomationId = value;
        }
    }

    public IgnorableValue<ControlType> ControlType
    {
        [CompilerGenerated]
        get
        {
            return this.ControlType;
        }
        [CompilerGenerated]
        set
        {
            this.ControlType = value;
        }
    }

    public IgnorableValue<string> HelpText
    {
        [CompilerGenerated]
        get
        {
            return this.HelpText;
        }
        [CompilerGenerated]
        set
        {
            this.HelpText = value;
        }
    }

    public IgnorableValue<string> Name
    {
        [CompilerGenerated]
        get
        {
            return this.Name;
        }
        [CompilerGenerated]
        set
        {
            this.Name = value;
        }
    }
}

 
