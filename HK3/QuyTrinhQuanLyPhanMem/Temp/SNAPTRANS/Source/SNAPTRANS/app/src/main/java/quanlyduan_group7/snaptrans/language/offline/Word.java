package quanlyduan_group7.snaptrans.language.offline;

import java.io.Serializable;

/**
 * Created by Thanh Vong on 11/11/2015.
 */
public class Word implements Serializable{
    public String word=""; // tu
    public String indexBegin=""; // vi tri Byte dau tien
    public String lengMean=""; /// so luong byte cua tu + nghia

    public boolean isLoaded;

    public String mean=""; // nghia va giai thich
    public String popularMean="";// nghia pho bien

    public Word(String w, String bg, String end){
    }

    // Khoi tao, tu chuoi tach' thanh word, indexBegin, indexEnd
    public Word(String oneline){
        String[] listword = oneline.split("\t");

        this.word = listword[0];
        this.indexBegin = listword[1];
        this.lengMean = listword[2];
        this.word = this.word.trim();
        this.isLoaded = false;
    }

    public void setMean(String m){
        this.mean = m;
        popularMean(m);
        this.isLoaded=true;
    }

    // Ham chuyen tu co so 64 sang co so 10
    public int convert64to10(String str){
        try {
            int decValue = 0;
            String base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
            int len = str.length();
            for (int i = 0; i < len; i++) {
                int pos = base64.indexOf(str.charAt(i));
                decValue += (int)Math.pow(64,len-i-1)*pos;// pow(64, len - i - 1) * pos;
            }
            return decValue;
        }
        catch (Exception ex) {
            return -1;
        }

    }

    public int idxBegin(){
        return convert64to10(indexBegin);
    }
    public int idxEnd(){
        return convert64to10(lengMean);
    }

    private void popularMean(String mean){
        String listMean[] = mean.split("\\n");
        int index =0;
        while(listMean[index].charAt(0) != '-')
        {
            index++;
        }
        String text = listMean[index];
        String popularMean = "";
        char temp[]=text.toCharArray();
        for(int i=2, j=-1; i<temp.length; i++)
        {
            if(temp[i]=='(')
            {
                j = text.indexOf(")",i+1);
                if(j<temp.length-1) i=j+1;
            }
            if(temp[i]=='[')
            {
                j = text.indexOf("]",j+1);
                if(j<temp.length-1) i=j+1;
            }
            if(temp[i]==','||temp[i]==';'||temp[i]=='!'||temp[i]=='?') break;
            if(!Character.isLetter(temp[i]) && temp[i]!=' ') continue;
            popularMean+=temp[i];
        }
        this.popularMean = popularMean;
    }
}
