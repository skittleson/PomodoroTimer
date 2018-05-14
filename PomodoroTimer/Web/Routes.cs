using Ooui;
using PomodoroTimer.Web.Elements;
using PomodoroTimer.Web.Views;

namespace PomodoroTimer.Web
{
    public static class Routes
    {
        public static void Initialization() {
            UI.Publish("/", BuildBody((new HomePage()).Render()));
        }

        public static Element BuildBody(Element body) {
            const string notifyJsScript = "/notify.js";
            if (UI.ServerEnabled) {
                UI.PublishFile(notifyJsScript, "Web/Javascript/" + notifyJsScript, "text/javascript");
            }
            return new Div(body, 
                new Script { Source = notifyJsScript });
        }
    }
}
