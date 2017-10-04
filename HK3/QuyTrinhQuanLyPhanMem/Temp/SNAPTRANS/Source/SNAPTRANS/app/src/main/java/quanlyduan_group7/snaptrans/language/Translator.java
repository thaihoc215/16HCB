package quanlyduan_group7.snaptrans.language;

import android.app.Activity;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;

import quanlyduan_group7.snaptrans.CaptureActivity;
import quanlyduan_group7.snaptrans.PreferencesActivity;
import quanlyduan_group7.snaptrans.language.offline.Database;

/**
 * Delegates translation requests to the appropriate translation service.
 */
public class Translator {

  public static final String BAD_TRANSLATION_MSG = "[Translation unavailable]";
  
  private Translator(Activity activity) {  
    // Private constructor to enforce noninstantiability
  }
  
  static String translate(Activity activity, String sourceLanguageCode, String targetLanguageCode, String sourceText, Database dataOffline) {
    
    // Check preferences to determine which translation API to use--Google, or Bing.
    SharedPreferences prefs = PreferenceManager.getDefaultSharedPreferences(activity);
    String api = prefs.getString(PreferencesActivity.KEY_TRANSLATOR, CaptureActivity.DEFAULT_TRANSLATOR);
    
    // Delegate the translation based on the user's preference.
    if (api.equals(PreferencesActivity.TRANSLATOR_BING)) {
      
      // Get the correct code for the source language for this translation service.
      sourceLanguageCode = TranslatorBing.toLanguage(
          LanguageCodeHelper.getTranslationLanguageName(activity.getBaseContext(), sourceLanguageCode));
      
      return TranslatorBing.translate(sourceLanguageCode, targetLanguageCode, sourceText);
    } else if (api.equals(PreferencesActivity.TRANSLATOR_GOOGLE)) {
      
      // Get the correct code for the source language for this translation service.
      sourceLanguageCode = TranslatorGoogle.toLanguage(
          LanguageCodeHelper.getTranslationLanguageName(activity.getBaseContext(), sourceLanguageCode));      
      
      return TranslatorGoogle.translate(sourceLanguageCode, targetLanguageCode, sourceText);
    }
    else if(api.equals(PreferencesActivity.TRANSLATOR_OFFLINE)){
      return TranslatorOffline.translate(sourceLanguageCode, targetLanguageCode, sourceText, dataOffline);

    }
    return BAD_TRANSLATION_MSG;
  }
}