using Ooui;
using System;
using System.Collections.Generic;
using System.Text;

namespace PomodoroTimer.Core.Services
{
    public static class OouiGlobals
    {
        public static void Initialization() {
            UI.HeadHtml += @"
<meta charset='utf-8'>
<meta http-equiv='x-ua-compatible' content='ie=edge'>
<meta name='description' content=''>
<meta name='viewport' content='width=device-width, initial-scale=1, shrink-to-fit=no'>

            ";
            UI.BodyHeaderHtml += @"
<main role='main'>
";
            UI.BodyFooterHtml += @"
</main>
";
        }
    }
}
