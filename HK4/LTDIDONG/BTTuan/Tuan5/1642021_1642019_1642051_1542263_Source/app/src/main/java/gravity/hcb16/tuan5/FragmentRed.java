package gravity.hcb16.tuan5;

import android.app.Fragment;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

/**
 * Created by sonlpq on 3/20/2018.
 */

public class FragmentRed extends Fragment implements FragmentCallbacks {

    MainActivity main;
    TextView txtRed;
    Button btnFrist;
    Button btnLastest;
    Button btnPre;
    Button btnNext;
    int position = -1;
    int size;
    public static FragmentRed newInstance(String strArg1) {
        FragmentRed fragment = new FragmentRed();
        Bundle bundle = new Bundle();
        bundle.putString("arg1", strArg1);
        fragment.setArguments(bundle);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);   // Activities containing this fragment must implement interface: MainCallbacks
        if (!(getActivity() instanceof MainCallbacks)) {
            throw new IllegalStateException(" Activity must implement MainCallbacks");
        }
        main = (MainActivity) getActivity(); // use this reference to invoke main callbacks  }

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        LinearLayout view_layout_red = (LinearLayout) inflater.inflate(R.layout.layout_red, null);

        txtRed = (TextView) view_layout_red.findViewById(R.id.textView1Red);
        try {
            Bundle arguments = getArguments();
            String redMessage = arguments.getString("arg1", "");
            txtRed.setText(redMessage);
        } catch (Exception e) {
            Log.e("RED BUNDLE ERROR - ", "" + e.getMessage());
        }

        btnFrist = (Button) view_layout_red.findViewById(R.id.buttonFirst);
        btnFrist.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                main.onMsgFromFragToMain("RED-FRAG", "", 0, size);
            }
        });

        btnLastest = (Button) view_layout_red.findViewById(R.id.buttonLastest);
        btnLastest.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                main.onMsgFromFragToMain("RED-FRAG", "", size - 1, size);
            }
        });

        btnPre = (Button) view_layout_red.findViewById(R.id.buttonPre);
        btnPre.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                main.onMsgFromFragToMain("RED-FRAG", "", position - 1, size);
            }
        });

        btnNext = (Button) view_layout_red.findViewById(R.id.buttonNext);
        btnNext.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                main.onMsgFromFragToMain("RED-FRAG", "", position + 1, size);
            }
        });
        txtRed.setText("Danh sach hoc sinh");
        return view_layout_red;
    }

    @Override
    public void onMsgFromMainToFragment(String strValue, int pos, int mySize) {
        // receiving a message from MainActivity (it may happen at any point in time)
        txtRed.setText(""+strValue);
        position = pos;
        size = mySize;
    }
}

