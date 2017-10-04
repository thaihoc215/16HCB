package quanlyduan_group7.snaptrans.language;

import android.util.Log;

import quanlyduan_group7.snaptrans.language.offline.Database;

/**
 * Created by qttbc on 18/12/2015.
 */
public class TranslatorOffline {
    private static final String TAG = TranslatorBing.class.getSimpleName();

    /**
     *  Translate using Offline Translate library
     * @param sourceLanguageCode Source language code, for example, "en"
     * @param targetLanguageCode Target language code, for example, "es"
     * @param sourceText Text to send for translation
     * @return Translated text
     */
    static String translate(String sourceLanguageCode, String targetLanguageCode, String sourceText, Database dataOffline) {
        try {
            Log.d(TAG, sourceLanguageCode + " -> " + targetLanguageCode);
            String listTranslate[] = sourceText.toLowerCase().split(" ");
            String result = "";
            int size = listTranslate.length;
            for(int i=0; i<size; i++)
            {
                result += dataOffline.getMeanOfWord(listTranslate[i],2);
                if(i<size-1) result += " ";
            }
            return result;
        } catch (Exception e) {
            Log.e(TAG, "Caught exeption in translation request.");
            e.printStackTrace();
            return Translator.BAD_TRANSLATION_MSG;
        }
    }
}
