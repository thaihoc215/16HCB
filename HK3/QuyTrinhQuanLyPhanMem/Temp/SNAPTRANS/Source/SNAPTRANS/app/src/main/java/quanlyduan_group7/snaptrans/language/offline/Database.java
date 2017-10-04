package quanlyduan_group7.snaptrans.language.offline;

import android.content.Context;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.RandomAccessFile;
import java.io.Serializable;
import java.util.Hashtable;

/**
 * Created by Thanh Vong on 11/23/2015.
 */
public class Database implements Runnable,Serializable{
    private BufferedReader wfile = null;
    private static RandomAccessFile mfile=null;
    private Hashtable<String, Word> Words = new Hashtable<String, Word>();

    public Database(Context mycontext){
        try {
            File t = new File("/sdcard/anhviet109k.dict");
            if(!t.exists()) {
                copyFileFromAssetsToInternalStorage(mycontext);
            }
            mfile = new RandomAccessFile("/sdcard/anhviet109k.dict","rw");

            wfile = new BufferedReader(
                    new InputStreamReader(mycontext.getAssets().open("Data/anhviet109k.index"), "UTF-8"));
        }
        catch(IOException e) {
        } finally {
        }

        new Thread(this).start();

    }

    public String getMeanOfWord(String wor, int type){
        String result = wor;
        Word w = Words.get(wor);
        if(w!=null) {
            if(!w.isLoaded) w.setMean(LoadMean(w));
            switch(type)
            {
                case 1: result = w.mean; break;
                case 2: result = w.popularMean; break;
                default: result = w.mean;
            }

        }
        return result;
    }

    @Override
    public void run() {
        Loadword();
    }

    private void Loadword(){
        try {
            String mLine;
            while ((mLine = wfile.readLine()) != null) {
                Word temp = new Word(mLine);
                Words.put(temp.word,temp);
            }
        } catch (IOException e) {
        } finally {
            if (wfile != null) {
                try {
                    wfile.close();
                } catch (IOException e) {
                }
            }
        }
    }

    private String LoadMean(Word avi){
        String mLine="";
        try {
            int charCout = avi.idxEnd();
            int start = avi.idxBegin();
            byte[] buff = new byte[charCout];
            mfile.seek(start);
            mfile.read(buff, 0, charCout);
            mLine = new String(buff, "UTF8").replaceAll("\0+", "");

        } catch (IOException e) {
        } finally {

        }
        return mLine;
    }

    private void copyFileFromAssetsToInternalStorage(Context mycontext){
        InputStream in = null;
        OutputStream out = null;
        try {
            in = mycontext.getAssets().open("Data/anhviet109k.dict");
            File f = new File("/sdcard/anhviet109k.dict");
            out = new FileOutputStream(f);
            copyFile(in,out);
            BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(out));
            in.close();
            out.flush();
            out.close();
        } catch(IOException e) {
        }
    }

    private void copyFile(InputStream in, OutputStream out) throws IOException {
        byte[] buffer = new byte[1024];
        int read;
        while ((read = in.read(buffer)) != -1) {
            out.write(buffer, 0, read);
        }
    }
}
