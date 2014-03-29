using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;

public class ButtonHandlerAttribute : ActionNameSelectorAttribute
{
    private readonly Regex ButtonNameParser = new Regex("^(?<name>.*?)(\\[(?<arg>.+?)\\])*$",
        RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private string argumentNames;
    private string[] arguments;

    public ButtonHandlerAttribute()
    {
        this.ValueArgumentName = "value";
    }

    public bool AllowGetRequests { get; set; }

    public string ActionName { get; set; }

    public string ButtonName { get; set; }

    public string ArgumentNames
    {
        get
        {
            return this.argumentNames;
        }
        set
        {
            this.argumentNames = value;
            if (String.IsNullOrWhiteSpace(value))
                this.arguments = null;
            else
                this.arguments = value.Split(',').Select(s => s.Trim()).ToArray();
        }
    }

    public string ValueArgumentName { get; set; }

    public override bool IsValidName(ControllerContext controllerContext, string actionName, System.Reflection.MethodInfo methodInfo)
    {
        if (!AllowGetRequests)
            if (controllerContext.HttpContext.Request.GetHttpMethodOverride().Equals("GET", StringComparison.OrdinalIgnoreCase))
                return false;

        if (this.ActionName != null)
            if (!this.ActionName.Equals(actionName, StringComparison.OrdinalIgnoreCase))
                return false;

        var values = new NameValueCollection();
        if ((this.arguments == null) || (this.arguments.Length == 0))
        {
            var buttonName = this.ButtonName ?? methodInfo.Name;

            if (controllerContext.HttpContext.Request[buttonName] == null)
                return false;

            if (this.ValueArgumentName != null)
                values.Add(this.ValueArgumentName, controllerContext.HttpContext.Request[buttonName]);
        }
        else
        {
            var buttonName = this.ButtonName ?? methodInfo.Name;
            var buttonNamePrefix = buttonName + "[";
            string buttonFieldname = null;
            string[] args = null;
            foreach (var fieldname in controllerContext.HttpContext.Request.Form.AllKeys
                .Union(controllerContext.HttpContext.Request.QueryString.AllKeys))
            {
                if (fieldname.StartsWith(buttonNamePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    var match = ButtonNameParser.Match(fieldname);
                    if (match == null) continue;
                    args = match.Groups["arg"].Captures.OfType<Capture>().Select(c => c.Value).ToArray();
                    if (args.Length != this.arguments.Length) continue;
                    buttonFieldname = fieldname;
                    break;
                }
            }

            if (buttonFieldname == null)
                return false;

            if (this.ValueArgumentName != null)
                values.Add(this.ValueArgumentName, controllerContext.HttpContext.Request[buttonFieldname]);

            for (int i = 0; i < this.arguments.Length; i++)
            {
                values.Add(this.arguments[i], args[i]);
            }
        }

        var valueProviders = new List<IValueProvider>();
        valueProviders.Add(new NameValueCollectionValueProvider(values, Thread.CurrentThread.CurrentCulture));
        valueProviders.Add(controllerContext.Controller.ValueProvider);
        controllerContext.Controller.ValueProvider = new ValueProviderCollection(valueProviders);

        return true;
    }
}