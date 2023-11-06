using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using System.Diagnostics;

namespace Android_Editor_Close_Bug {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if ANDROID

            builder.ConfigureLifecycleEvents(events => {
                //https://github.com/dotnet/docs-maui/blob/main/docs/fundamentals/app-lifecycle.md
                events.AddAndroid(android => android.OnBackPressed((activity) => backButtonPressed(null) && false));

                //THIS IS MISSING THE onKeyDown, onKeyUp, dispatchKeyEvent, and/or dispatchKeyEventPreIme EVENTS WE WOULD NEED TO CATCH TO MAKE THIS WORK:
                //https://stackoverflow.com/questions/3940127/intercept-back-button-from-soft-keyboard
                //https://stackoverflow.com/questions/3988478/block-back-button-in-android/3988567

                //ONBACK PRESSED IS NOT CAPTURED BY SOFT KEYBOARD CLOSURE, ONLY BACK PRESS ONCE KEYBOARD ALREADY CLOSED

            });

            bool backButtonPressed(string eventName, string type = null) {
                Debug.WriteLine("====== BACK BUTTON PRESSED"); //this only occurs on pure back button, not soft keyboard cancel (when keyboard open not called)
                TestPage.Instance.editor.Unfocus(); //will not work on keyboard close as will not then be invoked
                return true;
            }

#endif
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
