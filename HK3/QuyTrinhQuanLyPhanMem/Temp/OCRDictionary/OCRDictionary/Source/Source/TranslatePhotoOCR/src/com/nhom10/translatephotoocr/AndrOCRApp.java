package com.nhom10.translatephotoocr;

import android.app.Application;
import android.content.Context;

public class AndrOCRApp extends Application{
	
	private static AndrOCRApp s_instance;

    public AndrOCRApp ()
    {
        s_instance = this;
    }

    public static Context getContext()
    {
        return s_instance;
    }
    
    public static String myGetString(int resId)
    {
        return getContext().getString(resId);       
    }


}
