#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace FireChat.Handlers;

public static class BorderlessEntryHandler {
    public static void ApplyCustomHandler() {

        EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) => {

#if ANDROID
            handler.PlatformView.Background = null;
            handler.PlatformView.SetPadding(0, 0, 0, 0);
            handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#endif

#if IOS || MACCATALYST
            handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
            handler.PlatformView.Layer.BorderWidth = 0;
#endif

#if WINDOWS
            handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            handler.PlatformView.Background = null;
#endif
        });
    }
}