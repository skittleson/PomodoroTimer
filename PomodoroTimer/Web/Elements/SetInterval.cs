using Ooui;
using PomodoroTimer.Core.Interfaces;
using System;
using System.Text;
using System.Xml;

namespace PomodoroTimer.Web.Elements
{
    public class SetInterval : IHtmlRender
    {
        private readonly string uniqueId = Guid.NewGuid().ToString();
        private Label label;

        /// <summary>
        /// Due to the lack of threading in WASM, use JS to do intervals
        /// </summary>
        public SetInterval(uint timeoutInSecs)
        {
            if (timeoutInSecs < 1) {
                throw new Exception("setInterval must be greater than 1 sec.");
            }
            label = new Label();
            label.ClassName = uniqueId;
            var scriptBuilder = new StringBuilder();
            scriptBuilder.Append("setInterval(function(){document.getElementsByClassName('");
            scriptBuilder.Append(uniqueId);
            scriptBuilder.Append("')[0].click(); },");
            scriptBuilder.Append(timeoutInSecs * 1000);
            scriptBuilder.Append(");");
            label.AppendChild(new Script(scriptBuilder.ToString()));
            label.Click += SetInterval_Click;
        }

        private void SetInterval_Click(object sender, TargetEventArgs e) => OnInterval?.Invoke();

        public Element Render() => label;

        public delegate void EventOnInterval();

        public event EventOnInterval OnInterval;
    }
}
