package com.nhom10.translatephotoocr;

import android.util.Log;

import com.memetix.mst.language.Language;
import com.memetix.mst.translate.Translate;

public class TranslatorBing {
	  private static final String TAG = TranslatorBing.class.getSimpleName();
	  private static final String CLIENT_ID = "ocr-translate";
	  private static final String CLIENT_SECRET = "FPMBk9CCiS8EP6PsKe3kTsG0C6GjdCymd6aksj7Ii0o=";
	  
	  static String translate(String sourceLanguageCode, String targetLanguageCode, String sourceText) throws Exception{
	    Translate.setClientId(CLIENT_ID);
	    Translate.setClientSecret(CLIENT_SECRET);
	    //Log.d(TAG, sourceLanguageCode + " -> " + targetLanguageCode);
	    return Translate.execute(sourceText, Language.fromString(sourceLanguageCode), 
	          Language.fromString(targetLanguageCode));
	  }
 
	  public static String toLanguage(String languageName) throws IllegalArgumentException {    
	    // Convert string to all caps
	    String standardizedName = languageName.toUpperCase();
	    
	    // Replace spaces with underscores
	    standardizedName = standardizedName.replace(' ', '_');
	    
	    // Remove parentheses
	    standardizedName = standardizedName.replace("(", "");   
	    standardizedName = standardizedName.replace(")", "");
	    
	    // Map Norwegian-Bokmal to Norwegian
	    if (standardizedName.equals("NORWEGIAN_BOKMAL")) {
	      standardizedName = "NORWEGIAN";
	    }
	    
	    try {
	      return Language.valueOf(standardizedName).toString();
	    } catch (IllegalArgumentException e) {
	      Log.e(TAG, "Not found--returning default language code");
	      return "en";
	    }
	  }
}