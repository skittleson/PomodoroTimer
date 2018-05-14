using Ooui;
using PomodoroTimer.Core.Interfaces;
using PomodoroTimer.Web.Elements;
using PomodoroTimer.Web.Views.Shared;

namespace PomodoroTimer.Web.Views
{
    public class HomePage : IHtmlRender
    {
        public Element Render() {

            var timer = (new InputTimer());
            var taskAtHand = new TextArea();
            taskAtHand.SetAttribute("placeholder", "what are you suppose to be working on?");

            return new Div(timer.Render(),
                new Br(),
                taskAtHand
                );
        }
    }
}
