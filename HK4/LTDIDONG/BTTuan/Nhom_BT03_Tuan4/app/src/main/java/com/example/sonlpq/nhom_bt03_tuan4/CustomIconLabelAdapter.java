package com.example.sonlpq.nhom_bt03_tuan4;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

/**
 * Created by sonlpq on 3/13/2018.
 */

public class CustomIconLabelAdapter extends ArrayAdapter<String> {

    Context context;
    Integer[] thumbnails;
    String[] items;

    public CustomIconLabelAdapter(Context context, int layoutToBeInflated, String[] items, Integer[] thumbnails) {
        super(context, R.layout.custom_row_icon_label, items);
        this.context = context;
        this.thumbnails = thumbnails;
        this.items = items;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = ((Activity) context).getLayoutInflater();
        View row = inflater.inflate(R.layout.custom_row_icon_label, null);
        TextView label = (TextView) row.findViewById(R.id.label);
        ImageView icon = (ImageView) row.findViewById(R.id.icon);
        label.setText(items[position]);
        icon.setImageResource(thumbnails[position]);
        return (row);
    }
}
