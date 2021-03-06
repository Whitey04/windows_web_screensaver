using System;
using System.Windows.Forms;

namespace ScreenSaver
{
	public class ScreenSaver
	{
		[STAThread]
		static void Main(string[] args)
		{
			// If Windows passes arguments...
			if (args.Length > 0)
			{
				// If argument is /c...
				if (args[0].ToLower().Trim().Substring(0,2) == "/c")
				{
					// We will add code here later
				}
				// If argument is /s...
				else if (args[0].ToLower() == "/s")
				{
				    StartScreenSaver();
				}
			}
			// If there is no argument just start the screen saver
			else
			{
                StartScreenSaver();
			}
		}

        private static UrlList createUrlList()
        {
            var urlList = new UrlList();
            urlList.addUrl("http://www.bbc.co.uk/news/");
            urlList.addUrl("https://www.google.com/news?vanilla=1");
            urlList.addUrl("http://news.ycombinator.com/");
            return urlList;
        }

	    private static void StartScreenSaver()
	    {
            int screenCount = Screen.AllScreens.Length;
            ScreensaverForm[] screensaverForms = new ScreensaverForm[screenCount];
            
            // Start the screen saver on all the displays the computer has
	        for (int x = 0; x < screenCount; x++)
	        {
                screensaverForms[x] = new ScreensaverForm(x, createUrlList());
                screensaverForms[x].Show();
	        }
            
            while (true)
            {
                Application.DoEvents();
                // if any screen is not visible then return
                for (int x = 0; x < screenCount; x++)
                {
                    if (screensaverForms[x].Visible == false) return;
                }
            }
	    }
	}
}