package gravity.hcb16.tuan5;

import android.app.Fragment;
import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Adapter;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;


/**
 * Created by sonlpq on 3/20/2018.
 */

public class FragmentBlue extends Fragment implements FragmentCallbacks {

    MainActivity main;
    String message = "";
    ListView listView;
    private String items[] = {"Class-01", "Class-02", "Class-03", "Class-04"};
    private String hs[] = {"1.Hoang Nhat Vuong \n2.Le Phuoc Quang Son", "1.Nguyen Thai Hoa \n2.Ha Nguyen Thai Hoc", "1.Nguyen Xuan Phuc \n2.Ba Hoang Vuong", "1.Ly Cong Tang \n2.Dinh Nhat Tue"};

    public static FragmentBlue newInstance(String strArg) {
        FragmentBlue fragment = new FragmentBlue();
        Bundle args = new Bundle();
        args.putString("strArg1", strArg);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        try {
            main = (MainActivity) getActivity();

        } catch (IllegalStateException e) {
            throw new IllegalStateException("MainActivity must implement callbacks");
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        LinearLayout layout_blue = (LinearLayout) inflater.inflate(R.layout.layout_blue, null);

        listView = (ListView) layout_blue.findViewById(R.id.listView1Blue);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(main, android.R.layout.simple_list_item_1, items);
        listView.setAdapter(adapter);
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
                changeColor(position);
                main.onMsgFromFragToMain("BLUE-FRAG", hs[position], position, hs.length);
            }
        });
        return layout_blue;
    }


    @Override
    public void onMsgFromMainToFragment(String strValue, int pos, int size) {
        if (pos < hs.length && pos >= 0) {
            changeColor(pos);
            main.onMsgFromFragToMain("BLUE-FRAG", hs[pos], pos, hs.length);
        }
    }

    private void changeColor(int pos){
        for(int a = 0; a < hs.length; a++)
        {
            if(a == pos) {
                listView.getChildAt(a).setBackgroundColor(Color.RED);
            }else{
                listView.getChildAt(a).setBackgroundColor(Color.WHITE);
            }
        }
    }
}
