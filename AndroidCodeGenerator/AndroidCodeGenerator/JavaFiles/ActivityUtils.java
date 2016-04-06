package ir.royapajoohesh.utils;

import android.app.Activity;
import android.content.Context;
import android.content.pm.ActivityInfo;
import android.content.res.Configuration;

/* Created by DrTJ @ April 2015 */

public class ActivityUtils {
    public static void SetOrientation(Activity context, Orientations tabletOrientation, Orientations phoneOrientation) {
        Orientations orientation = (isTablet(context)) ? tabletOrientation : phoneOrientation;
        int Orientation = orientation == Orientations.Portrait ? ActivityInfo.SCREEN_ORIENTATION_PORTRAIT 
        													   : ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE;
        context.setRequestedOrientation(Orientation);
    }

    public static boolean isTablet(Context context) {
        int screenLayout = context.getResources().getConfiguration().screenLayout;
        return  (screenLayout & Configuration.SCREENLAYOUT_SIZE_MASK) >= Configuration.SCREENLAYOUT_SIZE_LARGE;
    }

	public static Orientations CurrentOrientation(Activity context) {
		return context.getResources().getConfiguration().orientation == ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE 
				? Orientations.Landscape
				: Orientations.Portrait;
	}
}


