using Ooui;
using PomodoroTimer.Core.Interfaces;
using PomodoroTimer.Web.Elements;
using System;

namespace PomodoroTimer.Web.Views.Shared
{
    public class InputTimer : IHtmlRender
    {
        public TimeSpan IntervalTimeSpan = new TimeSpan(0, 20, 0);
        private Label labelToggle = new Label();
        private bool running = false;
        private DateTime startTime = DateTime.Now;
        private bool notified = false;
        private Button buttonSetWorkingTime;
        private Button buttonSetBreakTime;
        private readonly SetInterval intervalTimer = new SetInterval(1);

        public Element Render() {
            intervalTimer.OnInterval += () => OnInterval();
            labelToggle.Text = (IntervalTimeSpan - (DateTime.Now - startTime)).ToString("hh\\:mm\\:ss");
            buttonSetWorkingTime = new Button() { Text = "Pomodoro" };
            buttonSetWorkingTime.Click += (s, e) => SetWorkingTime(20);
            buttonSetBreakTime = new Button() { Text = "Short Break" };
            buttonSetBreakTime.Click += (s, e) => SetWorkingTime(5);
            return new Div(buttonSetWorkingTime, buttonSetBreakTime, new Br(), labelToggle, intervalTimer.Render())
            {
                ClassName = "pt-input-timer"
            };
        }

        private void SetWorkingTime(int workingTime) {
            IntervalTimeSpan = new TimeSpan(0, workingTime, 0);
            running = true;
            startTime = DateTime.Now;
            notified = false;
        }

        private void OnInterval()
        {
            if (running)
            {
                var red = new Color(255, 0, 0, 255);
                var beforeAlert = (startTime.AddMinutes(IntervalTimeSpan.Minutes) > DateTime.Now);
                labelToggle.Text = (IntervalTimeSpan - (DateTime.Now - startTime)).ToString("hh\\:mm\\:ss");
                labelToggle.Style.Color = beforeAlert ? Colors.Black : red;
                if (!beforeAlert && !notified) {
                    var notifierScript = new Script("notifyMe('End of time!'); beep(); var notifyScript = document.getElementsByClassName('notifyme-script')[0]; html.removeChild(notifyScript);")
                    {
                        ClassName = "notifyme-script"
                    };
                    labelToggle.AppendChild(notifierScript);
                    notified = true;
                }
            }
        }
    }
}