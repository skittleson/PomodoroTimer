using Ooui;

namespace PomodoroTimer.Web.Elements
{
    public class Script : Element
    {
        public Script()
            : base("Script")
        {

        }

        public string Source
        {
            get => GetStringAttribute("src", null);
            set => SetAttributeProperty("src", value);
        }

        public Script(string text)
            : this()
        {
            Text = text;
        }
    }
}
