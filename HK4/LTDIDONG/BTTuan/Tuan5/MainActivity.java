package gravity.hcb16.tuan5;

import android.app.Activity;
import android.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

public class MainActivity extends Activity implements MainCallbacks {

    FragmentTransaction ft;
    FragmentRed redFragment;
    FragmentBlue blueFragment;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        // create a new BLUE fragment - show it
        ft = getFragmentManager().beginTransaction();
        blueFragment = FragmentBlue.newInstance("first-blue");
        ft.replace(R.id.main_holder_blue, blueFragment);
        ft.commit();

        // create a new RED fragment - show it
        ft = getFragmentManager().beginTransaction();
        redFragment = FragmentRed.newInstance("first-red");
        ft.replace(R.id.main_holder_red, redFragment);
        ft.commit();


    }

    @Override
    public void onMsgFromFragToMain(String sender, String strInfo, int position, int size) {
        if (sender.equals("RED-FRAG")) {
            // TODO: if needed, do here something on behalf of the RED fragment
            blueFragment.onMsgFromMainToFragment("" + strInfo, position, size);
        }

        if (sender.equals("BLUE-FRAG")) {
            try {
                redFragment.onMsgFromMainToFragment("" + strInfo, position, size);
            } catch (Exception e) {
                Log.e("ERROR", "onStrFromFragToMain " + e.getMessage());
            }
        }
    }
}
