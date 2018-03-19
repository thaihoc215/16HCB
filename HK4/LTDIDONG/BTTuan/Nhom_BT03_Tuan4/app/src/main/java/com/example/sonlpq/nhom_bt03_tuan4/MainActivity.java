package com.example.sonlpq.nhom_bt03_tuan4;

import android.app.ListActivity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

public class MainActivity extends ListActivity {

    TextView txtMsg;
    // The n-th row in the list will consist of [icon, label]
    // where icon = thumbnail[n] and label=items[n]
    String[] items = {"Data-1", "Data-2", "Data-3", "Data-4"};
    Integer[] thumbnails = {R.drawable.pic01_small, R.drawable.pic02_small,
            R.drawable.pic03_small, R.drawable.pic04_small};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        txtMsg = (TextView) findViewById(R.id.txtMsg);
        // the arguments of the custom adapter are:
        // activityContex, layout-to-be-inflated, labels, icons
        CustomIconLabelAdapter adapter = new CustomIconLabelAdapter(
                this,
                R.layout.custom_row_icon_label,
                items,
                thumbnails);
        // bind intrinsic ListView to custom adapter
        setListAdapter(adapter);
    }

    @Override
    protected void onListItemClick(ListView l, View v, int position, long id) {
        super.onListItemClick(l, v, position, id);
        String text = " Position: " + position + "   " + items[position];
        txtMsg.setText(text);

    }

}
